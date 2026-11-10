using System;
using System.Text.RegularExpressions;
using UnityEngine.Localization.Settings;

namespace WildfrostAccessibility
{
    /// <summary>
    /// The Spanish counterpart of MakeDragAccessible, for the game's Spanish
    /// text (see GameTranslations): "Clic Derecho" becomes the I key, "Clic
    /// Izquierdo" and bare clicks become Enter, and "arrastra X a Y" becomes
    /// "selecciona X y colocalo en Y" followed by the how-to hint.
    /// </summary>
    public static partial class PopupReader
    {
        private const RegexOptions Ci = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant;

        /// <summary>Whether the game is showing its Spanish text, so tutorial wording is Spanish.</summary>
        private static bool GameTextIsSpanish()
        {
            try
            {
                var locale = LocalizationSettings.SelectedLocale;
                return locale != null
                    && locale.Identifier.Code.StartsWith("es", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private static string MakeDragAccessibleSpanish(string text)
        {
            // The game writes the key name in brackets ("Puedes hacer [Clic
            // Derecho] sobre..."); the brackets go with the name they hold
            const string Right = @"(?:\[\s*clic[\s-]?derecho\s*\]|\bclic[\s-]?derecho\b)";
            const string Left = @"(?:\[\s*clic[\s-]?izquierdo\s*\]|\bclic[\s-]?izquierdo\b)";

            // Right click inspects; the mod binds I
            text = Regex.Replace(text, @"\b(hacer|presionar|pulsar)\s+" + Right, m => KeepCase(m.Value, "pulsar la tecla I"), Ci);
            text = Regex.Replace(text, @"\b(haz|presiona|pulsa)\s+" + Right, m => KeepCase(m.Value, "pulsa la tecla I"), Ci);
            text = Regex.Replace(text, Right, "la tecla I", Ci);

            // Left click is the confirm action; the mod's confirm is Enter
            text = Regex.Replace(text, @"\b(hacer|presionar|pulsar)\s+" + Left, m => KeepCase(m.Value, "pulsar Enter"), Ci);
            text = Regex.Replace(text, @"\b(haz|presiona|pulsa)\s+" + Left, m => KeepCase(m.Value, "pulsa Enter"), Ci);
            text = Regex.Replace(text, Left, "Enter", Ci);

            // Remaining clicks activate the focused item
            text = Regex.Replace(text, @"\bhaciendo\s+clic\b", m => KeepCase(m.Value, "pulsando Enter"), Ci);
            text = Regex.Replace(text, @"\bhacer\s+clic\b", m => KeepCase(m.Value, "pulsar Enter"), Ci);
            text = Regex.Replace(text, @"\bhaz\s+clic\b", m => KeepCase(m.Value, "pulsa Enter"), Ci);
            text = Regex.Replace(text, @"\bclic\b", "Enter", Ci);

            string beforeDrag = text;

            // "arrastrandolo a una carta" → "seleccionandolo y colocandolo en una carta"
            text = Regex.Replace(text,
                @"\barrastr[aá]ndol(?<g>[oa]s?)\s+(?<to>al|a)\b",
                m => "seleccionandol" + m.Groups["g"].Value + " y colocandol" + m.Groups["g"].Value
                    + Destination(m.Groups["to"].Value),
                Ci);

            // "arrastra X frente a Y" → "selecciona X y colocalo frente a Y"
            text = RewriteDragEs(text, @"(?<x>[^.!?|]*?\S)\s+frente\s+a\b", _ => " frente a");

            // "arrastra a tu Lider desde tu Mano al Campo" → "... y colocalo en el Campo"
            text = RewriteDragEs(text, @"(?<x>[^.!?|]*?\S\s+desde\s+[^.!?|]*?\S)\s+(?<to>al|a)\b",
                m => Destination(m.Groups["to"].Value));

            // "arrastra X a Y" → "selecciona X y colocalo en Y". The thing dragged
            // may start with the personal "a" ("arrastra a tu Lider"), which is
            // not the destination
            text = RewriteDragEs(text, @"(?<x>(?:a\s+)?[^.!?|]*?\S)\s+(?<to>al|a)\b",
                m => Destination(m.Groups["to"].Value));

            // Bare mentions with no destination
            text = Regex.Replace(text, @"\barrastrando\b", m => KeepCase(m.Value, "seleccionando y colocando"), Ci);
            text = Regex.Replace(text, @"\barrastrar\b", m => KeepCase(m.Value, "seleccionar y colocar"), Ci);
            text = Regex.Replace(text, @"\barrastra\b", m => KeepCase(m.Value, "selecciona y coloca"), Ci);

            if (text != beforeDrag)
            {
                bool inFront = Regex.IsMatch(text, @"\bfrente a\b", Ci);
                text += " " + Loc.Get(inFront ? "tutorial_drag_hint_infront" : "tutorial_drag_hint");
            }

            return text;
        }

        /// <summary>
        /// Rewrite one "arrastra …" sentence shape, keeping the verb form
        /// (imperative, infinitive or gerund). The pattern must capture the
        /// dragged thing as group "x"; <paramref name="destination"/> gives
        /// the text that replaces the destination preposition.
        /// </summary>
        private static string RewriteDragEs(string text, string tailPattern, Func<Match, string> destination)
        {
            return Regex.Replace(text,
                @"\barrastr(?<form>ando|ar|a)\s+" + tailPattern,
                m =>
                {
                    string x = m.Groups["x"].Value;
                    string dest = destination(m);
                    string result;
                    switch (m.Groups["form"].Value.ToLowerInvariant())
                    {
                        case "ando": result = "seleccionando " + x + " y colocandolo" + dest; break;
                        case "ar": result = "seleccionar " + x + " y colocarlo" + dest; break;
                        default: result = "selecciona " + x + " y colocalo" + dest; break;
                    }
                    // "Arrastra" opening a sentence stays capitalised
                    return KeepCase(m.Value, result);
                },
                Ci);
        }

        /// <summary>The replacement, capitalised if the word it replaces was.</summary>
        private static string KeepCase(string original, string replacement)
        {
            return char.IsUpper(original[0])
                ? char.ToUpperInvariant(replacement[0]) + replacement.Substring(1)
                : replacement;
        }

        /// <summary>"al" → " en el", "a" → " en".</summary>
        private static string Destination(string preposition)
        {
            return string.Equals(preposition, "al", StringComparison.OrdinalIgnoreCase) ? " en el" : " en";
        }
    }
}
