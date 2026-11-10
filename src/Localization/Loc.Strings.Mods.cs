namespace WildfrostAccessibility
{
    /// <summary>
    /// Strings for the Mods screen (ModsHandler): the mod list summary, each
    /// row's name and on/off state, the row buttons, and the F1 help.
    /// Languages without an entry fall back to English.
    /// </summary>
    public static partial class Loc
    {
        private static void RegisterModsStrings()
        {
            Add("en", "mods_summary", "{0} mods, {1} on.");
            Add("en", "mods_hint", "Arrow keys move between mods, Enter turns the focused mod on or off, Escape goes back.");
            Add("en", "mods_state_on", "on");
            Add("en", "mods_state_off", "off");
            Add("en", "mods_row", "{0}, {1}.");
            Add("en", "mods_toggled", "{0} {1}.");
            Add("en", "mods_open_folder", "Open folder of {0}.");
            Add("en", "mods_publish", "Publish {0} to the Workshop.");
            Add("en", "mods_self_warning", "Turning this off stops all speech.");
            Add("en", "help_mods", "Mods screen. Lists the installed mods; each reads its name and whether it is on. Enter turns the focused mod on or off. Ctrl+arrows on the Details buffer read its description. Escape goes back to the main menu.");

            Add("de", "mods_summary", "{0} Mods, {1} aktiv.");
            Add("de", "mods_hint", "Pfeiltasten wechseln zwischen Mods, Eingabe schaltet den fokussierten Mod ein oder aus, Escape geht zurueck.");
            Add("de", "mods_state_on", "an");
            Add("de", "mods_state_off", "aus");
            Add("de", "mods_row", "{0}, {1}.");
            Add("de", "mods_toggled", "{0} {1}.");
            Add("de", "mods_open_folder", "Ordner von {0} oeffnen.");
            Add("de", "mods_publish", "{0} im Workshop veroeffentlichen.");
            Add("de", "mods_self_warning", "Ausschalten beendet jede Sprachausgabe.");
            Add("de", "help_mods", "Mods-Bildschirm. Listet die installierten Mods; jeder nennt seinen Namen und ob er an ist. Eingabe schaltet den fokussierten Mod ein oder aus. Strg+Pfeiltasten im Details-Puffer lesen seine Beschreibung. Escape geht zurueck ins Hauptmenue.");

            Add("es", "mods_summary", "{0} mods, {1} activados.");
            Add("es", "mods_hint", "Las flechas mueven entre mods, Enter activa o desactiva el mod enfocado, Escape vuelve.");
            Add("es", "mods_state_on", "activado");
            Add("es", "mods_state_off", "desactivado");
            Add("es", "mods_row", "{0}, {1}.");
            Add("es", "mods_toggled", "{0} {1}.");
            Add("es", "mods_open_folder", "Abrir la carpeta de {0}.");
            Add("es", "mods_publish", "Publicar {0} en el Workshop.");
            Add("es", "mods_self_warning", "Desactivarlo detiene toda la voz.");
            Add("es", "help_mods", "Pantalla de mods. Lista los mods instalados; cada uno dice su nombre y si está activado. Enter activa o desactiva el mod enfocado. Ctrl+flechas en el búfer de Detalles leen su descripción. Escape vuelve al menú principal.");

            Add("fr", "mods_summary", "{0} mods, {1} actives.");
            Add("fr", "mods_hint", "Les fleches passent d'un mod a l'autre, Entree active ou desactive le mod selectionne, Echap revient.");
            Add("fr", "mods_state_on", "active");
            Add("fr", "mods_state_off", "desactive");
            Add("fr", "mods_row", "{0}, {1}.");
            Add("fr", "mods_toggled", "{0} {1}.");
            Add("fr", "mods_open_folder", "Ouvrir le dossier de {0}.");
            Add("fr", "mods_publish", "Publier {0} sur le Workshop.");
            Add("fr", "mods_self_warning", "Le desactiver arrete toute la voix.");
            Add("fr", "help_mods", "Ecran des mods. Liste les mods installes ; chacun dit son nom et s'il est active. Entree active ou desactive le mod selectionne. Ctrl+fleches sur le tampon Details lisent sa description. Echap revient au menu principal.");
        }
    }
}
