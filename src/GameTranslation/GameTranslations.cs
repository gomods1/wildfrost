using System;
using System.IO;
using System.Linq;
using Deadpan.Enums.Engine.Components.Modding;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace WildfrostAccessibility
{
    /// <summary>
    /// Translations of the game's own text that the game does not ship.
    ///
    /// Wildfrost ships English, Japanese, Korean and Chinese only. The mod adds
    /// a Spanish locale and fills its string tables (GameTranslations.Spanish.cs),
    /// so a player who downloads this mod alone can play the whole game in
    /// Spanish — cards, menus, tutorials and journal as well as the mod's own
    /// speech.
    ///
    /// Spanish shows up in the game's own language setting next to the
    /// built-in languages; the mod's speech follows whatever is picked there
    /// (see Loc.GetCurrentLanguageCode).
    /// </summary>
    public static partial class GameTranslations
    {
        private static readonly LocaleIdentifier Spanish = new LocaleIdentifier(SystemLanguage.Spanish);

        /// <summary>The font the Spanish text is drawn in; it has every accented letter.</summary>
        private const string SpanishFontFile = "Caudex-Regular.ttf";

        // The locale this mod created, so Unload removes only what it added
        // (another translation mod may have added Spanish first)
        private static Locale _addedLocale;
        private static TMP_FontAsset _spanishFont;
        private static string _modDirectory;
        private static bool _gameStartHooked;
        private static bool _localeHooked;

        /// <summary>
        /// Register the bundled translations and pick the game's language. Call
        /// once during mod load, after Loc has read the language choice.
        /// </summary>
        public static void Initialize(string modDirectory)
        {
            _modDirectory = modDirectory;

            try
            {
                RegisterSpanish();
            }
            catch (Exception ex)
            {
                Debug.LogError($"[WildfrostAccessibility] Spanish game text failed to register: {ex}");
                return;
            }

            LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
            _localeHooked = true;

            // The game picks its startup locale before mods load, when Spanish
            // did not exist yet, so the choice is made again once the game is up.
            // Enabled later from the Mods menu, the game is already up.
            if (GameManager.Ready)
            {
                ApplyStartupLanguage();
            }
            else
            {
                Events.OnGameStart += OnGameStart;
                _gameStartHooked = true;
            }
        }

        /// <summary>
        /// Undo Initialize: back to English if Spanish was showing, and take
        /// the Spanish entry out of the game's language list.
        /// </summary>
        public static void Shutdown()
        {
            if (_gameStartHooked)
            {
                Events.OnGameStart -= OnGameStart;
                _gameStartHooked = false;
            }

            try
            {
                if (_addedLocale != null)
                {
                    if (LocalizationSettings.SelectedLocale == _addedLocale)
                        SelectLocale("en");
                    LocalizationSettings.AvailableLocales.Locales.Remove(_addedLocale);
                    _addedLocale = null;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"[WildfrostAccessibility] Removing the Spanish locale failed: {ex.Message}");
            }

            if (_localeHooked)
            {
                LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
                _localeHooked = false;
            }
        }

        // ---- Registration ------------------------------------------------------

        private static void RegisterSpanish()
        {
            bool existed = LocalizationSettings.AvailableLocales.Locales.Any(l => l.Identifier == Spanish);
            Locale locale = LocalizationHelper.TryAddLocale(Spanish);
            if (!existed)
            {
                _addedLocale = locale;
                // The name the game's own language dropdown shows
                locale.name = "Español";
            }

            foreach (var (table, fill) in SpanishTables)
                fill(LocalizationHelper.GetCollection(table, Spanish));

            Debug.Log($"[WildfrostAccessibility] Spanish game text registered ({SpanishTables.Length} tables)");
        }

        // ---- Choosing the game language ----------------------------------------

        private static void OnGameStart()
        {
            if (_gameStartHooked)
            {
                Events.OnGameStart -= OnGameStart;
                _gameStartHooked = false;
            }
            ApplyStartupLanguage();
        }

        /// <summary>
        /// The game restores its saved language before mods load, when Spanish
        /// did not exist yet, so a player who picked Spanish would start in
        /// English. Restore the saved choice again now that Spanish exists. On
        /// a first run, with nothing saved, start in the system's language if
        /// the game has it — a Spanish system then starts in Spanish.
        /// </summary>
        private static void ApplyStartupLanguage()
        {
            try
            {
                if (LocalizationSettings.SelectedLocale == null)
                    return;

                string saved = global::Settings.Load("Language", "");
                if (!string.IsNullOrWhiteSpace(saved))
                    SelectLocale(saved);
                else
                    SelectLocale(new LocaleIdentifier(Application.systemLanguage).Code);
            }
            catch (Exception ex)
            {
                Debug.LogError($"[WildfrostAccessibility] Restoring the game language failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Switch the game to the locale matching a language code ("es",
        /// "es-MX", "zh-Hans") for this session; the saved setting is left
        /// alone. Returns false when the game has no such locale.
        /// </summary>
        private static bool SelectLocale(string code)
        {
            Locale locale = FindLocale(code);
            if (locale == null)
                return false;

            if (LocalizationSettings.SelectedLocale != locale)
                LocalizationSettings.SelectedLocale = locale;
            return true;
        }

        private static Locale FindLocale(string code)
        {
            if (string.IsNullOrEmpty(code))
                return null;

            var locales = LocalizationSettings.AvailableLocales.Locales;
            Locale exact = locales.FirstOrDefault(l =>
                string.Equals(l.Identifier.Code, code, StringComparison.OrdinalIgnoreCase));
            if (exact != null)
                return exact;

            // Chinese differs by script, so only an exact match will do
            if (code.StartsWith("zh", StringComparison.OrdinalIgnoreCase))
                return null;

            string language = BaseLanguage(code);
            return locales.FirstOrDefault(l =>
                string.Equals(BaseLanguage(l.Identifier.Code), language, StringComparison.OrdinalIgnoreCase));
        }

        private static string BaseLanguage(string code)
        {
            int dash = code.IndexOf('-');
            return dash > 0 ? code.Substring(0, dash) : code;
        }

        // ---- Font --------------------------------------------------------------

        /// <summary>
        /// FontSetterSystem falls back to the default font for a locale it does
        /// not know; once it has, Spanish gets its own font. Runs after the
        /// game's handler, which subscribed first.
        /// </summary>
        private static void OnLocaleChanged(Locale locale)
        {
            if (locale == null || locale.Identifier != Spanish)
                return;

            try
            {
                if (_spanishFont == null)
                {
                    string path = Path.Combine(_modDirectory ?? "", SpanishFontFile);
                    if (!File.Exists(path))
                        return;
                    _spanishFont = TMP_FontAsset.CreateFontAsset(new Font(path));
                }

                AccessTools.Field(typeof(FontSetterSystem), "current").SetValue(null, _spanishFont);
                AccessTools.Method(typeof(FontSetterSystem), "UpdateFontSetters").Invoke(null, null);
            }
            catch (Exception ex)
            {
                Debug.LogError($"[WildfrostAccessibility] Spanish font failed to load: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// The game's language dropdown lists the locales once, when it first
    /// starts. If that happened before Spanish was added (the mod enabled from
    /// the Mods menu mid-session, or removed again), refresh the list each time
    /// the dropdown is shown so it always matches the available languages.
    /// </summary>
    [HarmonyPatch(typeof(SetLanguage), "OnEnable")]
    internal static class SetLanguageRefreshPatch
    {
        [HarmonyPrefix]
        private static void Prefix(SetLanguage __instance)
        {
            try
            {
                if (!Traverse.Create(__instance).Field<bool>("init").Value)
                    return;

                var dropdown = Traverse.Create(__instance).Field<TMP_Dropdown>("dropdown").Value;
                var locales = LocalizationSettings.AvailableLocales.Locales;
                if (dropdown == null || dropdown.options.Count == locales.Count)
                    return;

                dropdown.options = locales.Select(l => new TMP_Dropdown.OptionData(l.name)).ToList();
            }
            catch (Exception ex)
            {
                Debug.LogError($"[WildfrostAccessibility] Refreshing the language list failed: {ex.Message}");
            }
        }
    }
}
