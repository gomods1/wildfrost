using System.Collections.Generic;
using System.Linq;
using Deadpan.Enums.Engine.Components.Modding;
using UnityEngine;
using UnityEngine.UI;

namespace WildfrostAccessibility
{
    /// <summary>
    /// Accessibility handler for the Mods screen (main menu → Mods). Each mod
    /// is a row built from the game's ModHolder prefab: a bell toggle, an
    /// open-folder button and, for local mods, a publish button. The buttons
    /// carry no text, so the generic reader spoke the bell sprite ("Bell").
    /// This handler reads the row's mod instead — its title and whether it is
    /// on — and announces the new state when a mod is toggled.
    /// </summary>
    public class ModsHandler : NavigableScreenHandler
    {
        public override string Name => "Mods";

        private bool _modEventsHooked;

        public override string GetHelpText() => Loc.Get("help_mods");

        public override void OnEnter()
        {
            base.OnEnter();
            if (!_modEventsHooked)
            {
                Events.OnModLoaded += OnModToggled;
                Events.OnModUnloaded += OnModToggled;
                _modEventsHooked = true;
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            if (_modEventsHooked)
            {
                Events.OnModLoaded -= OnModToggled;
                Events.OnModUnloaded -= OnModToggled;
                _modEventsHooked = false;
            }
        }

        protected override bool TryAnnounceScreen()
        {
            // The rows are built in ModsSceneManager.Start; wait for them
            var holders = Object.FindObjectsOfType<ModHolder>();
            if (holders.Length == 0 && Bootstrap.Mods.Count > 0)
                return false;

            int on = holders.Count(h => h.Mod != null && h.Mod.HasLoaded);
            var parts = new List<string>
            {
                Loc.Get("scene_Mods"),
                Loc.Get("mods_summary", holders.Length, on)
            };
            string hint = HintOnce("mods_hint");
            if (hint != null)
                parts.Add(hint);

            ScreenReader.SayEvent(string.Join(" ", parts), interrupt: true);
            return true;
        }

        protected override string GetItemDescription(UINavigationItem item)
        {
            ModHolder holder = FindModHolder(item);
            if (holder?.Mod == null)
                return base.GetItemDescription(item);

            WildfrostMod mod = holder.Mod;
            string state = Loc.Get(mod.HasLoaded ? "mods_state_on" : "mods_state_off");

            switch (GetButtonRole(item))
            {
                case ButtonRole.OpenFolder:
                    return Loc.Get("mods_open_folder", mod.Title);
                case ButtonRole.Publish:
                    return Loc.Get("mods_publish", mod.Title);
                default:
                    var parts = new List<string> { Loc.Get("mods_row", mod.Title, state) };
                    // Turning this mod off unloads the screen reader support itself
                    if (mod.HasLoaded && mod is WildfrostAccessibilityMod)
                        parts.Add(Loc.Get("mods_self_warning"));
                    return string.Join(" ", parts);
            }
        }

        public override List<string> GetFocusedDetailParts(UINavigationItem item)
        {
            ModHolder holder = FindModHolder(item);
            if (holder?.Mod == null)
                return null;

            var parts = new List<string> { holder.Mod.Title };
            string description = TextProcessor.StripRichText(holder.Mod.Description ?? "").Trim();
            if (!string.IsNullOrEmpty(description))
                parts.Add(description);
            parts.Add(Loc.Get(holder.Mod.HasLoaded ? "mods_state_on" : "mods_state_off"));
            return parts;
        }

        private void OnModToggled(WildfrostMod mod)
        {
            if (mod == null)
                return;
            ScreenReader.Say(Loc.Get("mods_toggled", mod.Title,
                Loc.Get(mod.HasLoaded ? "mods_state_on" : "mods_state_off")), interrupt: true);
            DebugLogger.Log(DebugLogger.LogCategory.Handler, Name,
                $"Mod toggled: {mod.GUID} loaded={mod.HasLoaded}");
        }

        /// <summary>
        /// The mod row a focused button belongs to. The game instantiates the
        /// row prefab and fetches its ModHolder with GetComponentInChildren, so
        /// the holder may sit beside the buttons rather than above them: climb
        /// until an ancestor contains exactly one holder. Stops at the list
        /// container, which holds every row's holder.
        /// </summary>
        private ModHolder FindModHolder(UINavigationItem item)
        {
            if (item == null)
                return null;

            foreach (Transform start in new[] { item.transform, item.clickHandler != null ? item.clickHandler.transform : null })
            {
                if (start == null)
                    continue;

                ModHolder direct = start.GetComponentInParent<ModHolder>();
                if (direct != null)
                    return direct;

                for (Transform t = start.parent; t != null; t = t.parent)
                {
                    var holders = t.GetComponentsInChildren<ModHolder>(true);
                    if (holders.Length == 1)
                        return holders[0];
                    if (holders.Length > 1)
                        break;
                }
            }

            DebugLogger.Log(DebugLogger.LogCategory.Handler, Name,
                $"No ModHolder for {NavigationHelper.GetPath(item.transform)}");
            return null;
        }

        private enum ButtonRole { Toggle, OpenFolder, Publish }

        /// <summary>
        /// Which ModHolder method the button calls, read from its onClick
        /// listeners (the buttons have no text to go by). Unknown → the toggle,
        /// the row's main action.
        /// </summary>
        private static ButtonRole GetButtonRole(UINavigationItem item)
        {
            foreach (GameObject go in new[] { item.gameObject, item.clickHandler })
            {
                if (go == null)
                    continue;
                foreach (Button button in go.GetComponentsInChildren<Button>(true))
                {
                    var click = button.onClick;
                    for (int i = 0; i < click.GetPersistentEventCount(); i++)
                    {
                        switch (click.GetPersistentMethodName(i))
                        {
                            case nameof(ModHolder.OpenModDirectory): return ButtonRole.OpenFolder;
                            case nameof(ModHolder.PublishMod): return ButtonRole.Publish;
                            case nameof(ModHolder.ToggleMod): return ButtonRole.Toggle;
                        }
                    }
                }
            }
            return ButtonRole.Toggle;
        }
    }
}
