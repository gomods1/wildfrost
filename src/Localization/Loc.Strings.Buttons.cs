namespace WildfrostAccessibility
{
    /// <summary>
    /// Labels for buttons that carry no text of their own (icons), named by
    /// ScreenHandler.ButtonText from the object's name or components. The key
    /// is "button_" plus the English label in lower case with underscores
    /// ("Battle Log" -> "button_battle_log"). Brand names (Discord, Steam, ...)
    /// have no key and are spoken as they are. English and Spanish; other
    /// languages fall back to English.
    /// </summary>
    public static partial class Loc
    {
        private static void RegisterButtonStrings()
        {
            string[,] labels =
            {
                // English label, Spanish label
                { "Website", "Sitio web" },
                { "Link", "Enlace" },
                { "Settings", "Ajustes" },
                { "Options", "Opciones" },
                { "Credits", "Créditos" },
                { "Quit", "Salir" },
                { "Exit", "Salir" },
                { "Back", "Volver" },
                { "Close", "Cerrar" },
                { "Play", "Jugar" },
                { "Continue", "Continuar" },
                { "Mods", "Mods" },
                { "Restart", "Reiniciar" },
                { "Resume", "Reanudar" },
                { "Journal", "Diario" },
                { "Battle Log", "Registro de batalla" },
                { "Log", "Registro" },
                { "Help", "Ayuda" },
                { "Inspect", "Inspeccionar" },
                { "Info", "Información" },
                { "Pause", "Pausa" },
                { "Inventory", "Inventario" },
                { "Backpack", "Mochila" },
                { "Deck", "Mazo" },
                { "Deck View", "Ver mazo" },
                { "Shop", "Tienda" },
                { "Reward", "Recompensa" },
                { "Charms", "Talismanes" },
                { "Upgrades", "Mejoras" },
                { "Lore", "Historia" },
                { "Lore Pages", "Páginas de historia" },
                { "Redraw Bell", "Campana" },
                { "Bell", "Campana" },
                { "Confirm", "Confirmar" },
                { "Accept", "Aceptar" },
                { "Cancel", "Cancelar" },
                { "Deny", "Rechazar" },
                { "Skip", "Saltar" },
                { "Next", "Siguiente" },
                { "Previous", "Anterior" },
                { "End Turn", "Terminar turno" },
                { "Undo", "Deshacer" },
                { "Recall", "Retirar" },
                { "Flee", "Huir" },
                { "Abandon Run", "Abandonar partida" },
            };

            for (int i = 0; i < labels.GetLength(0); i++)
            {
                string key = ButtonLabelKey(labels[i, 0]);
                Add("en", key, labels[i, 0]);
                Add("es", key, labels[i, 1]);
            }
        }

        /// <summary>The string key for an English button label.</summary>
        public static string ButtonLabelKey(string englishLabel)
        {
            return "button_" + englishLabel.ToLowerInvariant().Replace(' ', '_');
        }

        /// <summary>
        /// An English button label in the current language, or the label
        /// unchanged when it has no translation (brand names, unknown labels).
        /// </summary>
        public static string ButtonLabel(string englishLabel)
        {
            if (string.IsNullOrEmpty(englishLabel))
                return englishLabel;
            return TryGet(ButtonLabelKey(englishLabel), out string text) ? text : englishLabel;
        }
    }
}
