namespace WildfrostAccessibility
{
    /// <summary>
    /// What the deckpack contributes to ItemDescriber: the card menu's buttons
    /// read as their role names, and while an upgrade is held the eligible
    /// cards read as assignment targets (charm slots first).
    /// </summary>
    public static partial class DeckpackNavigator
    {
        /// <summary>
        /// Deckpack-specific item descriptions, hooked into ItemDescriber:
        /// menu buttons get their role names, and while an upgrade is held the
        /// eligible cards read as assignment targets (charm slots first).
        /// Returns null when the deckpack has nothing special to say.
        /// </summary>
        public static string DescribeItem(UINavigationItem item, ScreenHandler owner)
        {
            if (item == null || !IsOpen) return null;

            var menu = _menuWasOpen ? ActiveMenu() : null;
            if (menu != null
                && (item.GetComponentInParent<DeckSelectSequence>() != null
                    || (item.clickHandler != null
                        && item.clickHandler.GetComponentInParent<DeckSelectSequence>() != null))
                && item.GetComponentInParent<Entity>() == null)
            {
                return MenuLabel(menu, item, owner);
            }

            var dragHandler = _dragHandler;
            if (dragHandler != null && dragHandler.IsDragging)
            {
                Entity entity = item.GetComponentInParent<Entity>();
                if (entity == null && item.clickHandler != null)
                    entity = item.clickHandler.GetComponentInParent<Entity>();
                if (entity != null && entity.data != null)
                    return DescribeAssignTarget(entity);
            }

            return null;
        }

        /// <summary>
        /// "Snow Fox, 1 of 3 charm slots used, Companion, attack 4, 8 of 8
        /// health, acts in 3, Frenzy 2, Bombth Charm" — the card's ordinary
        /// focus read with the free-slot count spliced in after the name.
        /// Choosing where a charm goes is a comparison between cards, so it
        /// needs the same stats every other card read gives: this used to stop
        /// at the name, the slot count and the charms already attached, which
        /// left the counter — often the whole reason a charm goes on one card
        /// rather than another — unsaid.
        /// </summary>
        private static string DescribeAssignTarget(Entity entity)
        {
            string desc = ItemDescriber.DescribeEntityFocus(entity);
            if (string.IsNullOrEmpty(desc))
                desc = entity.data.title;

            return ItemDescriber.InsertAfterName(desc, DescribeSlotUsage(entity));
        }

        /// <summary>
        /// "1 of 3 charm slots used" for the focused card, or null when the held
        /// upgrade isn't a charm (crowns and tokens have their own slot) or the
        /// card's slot data can't be read.
        /// </summary>
        private static string DescribeSlotUsage(Entity entity)
        {
            var dragData = _dragDisplay != null ? _dragDisplay.data : null;
            if (dragData != null && dragData.type != CardUpgradeData.Type.Charm)
                return null;

            try
            {
                int total = entity.data.charmSlots;
                try { total += entity.data.customData?.Get("extraCharmSlots", 0) ?? 0; }
                catch { /* cards without custom data */ }
                int used = 0;
                foreach (var upgrade in entity.data.upgrades)
                {
                    if (upgrade != null && upgrade.type == CardUpgradeData.Type.Charm
                        && upgrade.takeSlot)
                        used++;
                }
                return Loc.Get("deckpack_target_slots", used, total);
            }
            catch
            {
                return null; // slots stay unspoken if the data is unreadable
            }
        }

    }
}
