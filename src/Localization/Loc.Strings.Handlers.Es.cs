namespace WildfrostAccessibility
{
    /// <summary>
    /// The Spanish part of the screen handler string table: Town, ContinueRun,
    /// Map, Battle, CharacterSelect and its tribes, MainMenu, BattleWin,
    /// CampaignEnd, the Daily Voyage balloon, the deckpack inventory, the map
    /// node categories, the pause menu, the story events, and the shared item
    /// descriptions.
    /// </summary>
    public static partial class Loc
    {
        private static void RegisterHandlerStringsSpanish()
        {
            // ----- Spanish ------------------------------------------------------

            Add("es", "stat_health", "{0} de vida");
            Add("es", "stat_health_of_max", "{0} de {1} de vida");
            Add("es", "stat_attack", "{0} de ataque");
            Add("es", "stat_counter", "contador {0}");
            Add("es", "pocket_draw", "Mazo de robo, {0} cartas");
            Add("es", "pocket_draw_one", "Mazo de robo, 1 carta");
            Add("es", "pocket_discard", "Pila de descarte, {0} cartas");
            Add("es", "pocket_discard_one", "Pila de descarte, 1 carta");
            Add("es", "card_count_multiple", "{0}, {1} copias");
            Add("es", "no_item_focused", "Nada seleccionado.");
            Add("es", "no_info_available", "No hay información disponible.");
            Add("es", "gold_amount", "Oro: {0}.");
            Add("es", "shop_price", "Cuesta {0} de oro.");
            Add("es", "shop_price_afford", "Cuesta {0} de oro. Tienes {1}.");
            Add("es", "shop_price_cant_afford", "Cuesta {0} de oro. No puedes pagarlo; tienes {1}.");
            Add("es", "scene_CharacterSelect", "Selección de personaje.");
            Add("es", "scene_Cards", "Colección de cartas.");
            Add("es", "scene_Mods", "Mods.");
            Add("es", "scene_Credits", "Créditos.");
            Add("es", "scene_TownUnlocks", "Desbloqueos del pueblo.");
            Add("es", "scene_Event", "Evento.");
            Add("es", "scene_BossReward", "Recompensa de jefe.");
            Add("es", "scene_BattleWin", "¡Batalla ganada! Pantalla de victoria.");
            Add("es", "scene_CampaignEnd", "Fin del viaje.");
            Add("es", "campaignend_win", "¡Victoria!");
            Add("es", "campaignend_defeat", "Derrotado.");
            Add("es", "campaignend_vanquished", "¡Victoria total!");
            Add("es", "campaignend_time", "Tiempo");
            Add("es", "campaignend_battles", "Batallas ganadas");
            Add("es", "campaignend_blings", "Blings");
            Add("es", "campaignend_score", "Tu puntuación: {0}.");
            Add("es", "campaignend_town_progress", "Progreso del pueblo: {0}.");
            Add("es", "help_campaignend", "Resumen al terminar un viaje: resultado, estadísticas de la partida, progreso del pueblo y puntuación final. Las flechas llegan a Volver al pueblo y Puntuaciones, Enter selecciona. Ctrl+Arriba repite el resumen.");
            Add("es", "battlewin_continue", "Pulsa Enter para continuar.");
            Add("es", "battlewin_injuries", "Heridos en esta batalla: {0}.");
            Add("es", "battlewin_not_ready", "La pantalla de victoria todavía está apareciendo, un momento.");
            Add("es", "help_battlewin", "Pantalla de victoria tras ganar una batalla. Puede mostrar compañeros heridos en el combate. Enter continúa el viaje.");
            Add("es", "charselect_tribes", "Elige una tribu. Usa las flechas arriba y abajo para moverte entre las tribus; se lee el nombre y el estilo de cada tribu al enfocarla. Pulsa la flecha derecha para oír los líderes y el mazo inicial de esa tribu, o mantén Control y pulsa arriba para recorrerlos. Pulsa Intro para elegir la tribu enfocada, o Escape para volver atrás.");
            Add("es", "charselect_leaders", "Elige a tu líder. Las flechas cambian de líder, Enter selecciona.");
            Add("es", "charselect_chosen", "{0} elegido. Enter confirma, Escape devuelve la carta.");
            Add("es", "charselect_chosen_generic", "Carta elegida. Enter confirma, Escape la devuelve.");
            Add("es", "charselect_cancelled", "Elección cancelada, de vuelta a la lista.");
            Add("es", "charselect_pets", "Elige tu mascota inicial. Las flechas cambian, Enter selecciona.");
            Add("es", "charselect_starting", "¡Vamos! Comienza el viaje.");
            Add("es", "tribe_locked", "{0}, bloqueada");
            Add("es", "tribe_locked_hint", "Las tribus nuevas se desbloquean según se llena la barra de progreso del pueblo: sigue ganando batallas y terminando partidas.");
            Add("es", "tribe_locked_building", "El desbloqueo aparece en {0}.");
            Add("es", "tribe_locked_blocked", "{0} está bloqueada, así que no se puede elegir. {1}");
            Add("es", "charselect_tribes_locked", "Las tribus que aún no has desbloqueado se siguen mostrando: se leen como bloqueadas y no se pueden elegir.");
            Add("es", "inspect_no_confirm", "Este panel no se puede confirmar aquí. Escape devuelve la carta.");
            Add("es", "help_charselect", "Selección de personaje, en tres etapas. Primero una tribu: las flechas arriba y abajo cambian entre las tribus y leen el nombre y el estilo de cada una, la flecha derecha lee los líderes y el mazo inicial de la tribu, y Control más arriba los recorre en el búfer de revisión. Enter elige la tribu enfocada. Luego un líder y una mascota inicial, explorados con las flechas, Enter para elegir. Tras elegir una carta, Enter confirma y continúa, Escape la devuelve. I inspecciona la carta enfocada.");
            Add("es", "help_main_menu", "Menú principal. Flechas arriba y abajo cambian de botón, Enter selecciona. F1 repite esta ayuda, F10 alterna el modo de depuración.");
            Add("es", "screen_town", "Pueblo, tu campamento base.");
            Add("es", "town_hint", "Las flechas cambian de edificio, Enter selecciona, I describe el edificio seleccionado. F1 para ayuda.");
            Add("es", "gate_continue_tutorial", "Tu viaje de tutorial está en curso. Pulsa Enter para continuarlo");
            Add("es", "gate_start_tutorial", "Comienza tu primer viaje. El juego te ofrecerá el tutorial");
            Add("es", "gate_continue_run", "Tu viaje está en curso. Pulsa Enter para continuarlo");
            Add("es", "gate_start_run", "Comienza un nuevo viaje");

            // Daily Voyage balloon
            Add("es", "balloon_start_run", "Comienza el viaje diario: un mazo fijo y modificadores, puntuado en la clasificación. Enter abre el viaje de hoy");
            Add("es", "balloon_continue_run", "Tu viaje diario está en curso. Pulsa Enter para continuarlo");
            Add("es", "balloon_deck", "Mazo fijo de {0} cartas: {1}");
            Add("es", "balloon_modifiers", "{0} modificadores: {1}");
            Add("es", "balloon_loading", "Viaje diario. Cargando el viaje de hoy.");
            Add("es", "balloon_play_desc", "Comienza el viaje diario de hoy");
            Add("es", "balloon_scores_desc", "Abre la clasificación del viaje de hoy");
            Add("es", "balloon_buttons_hint", "Izquierda y derecha cambian entre Vamos y Clasificación, Enter elige, I lo lee otra vez, Escape sale");
            Add("es", "help_town", "Pueblo. Tu base entre viajes. Los edificios desbloquean cartas y desafíos. Las flechas cambian de edificio, I lee su función, Enter lo abre. La Puerta comienza o continúa tu viaje.");
            Add("es", "screen_continue_run", "Continuar viaje. Tienes un viaje en curso.");
            Add("es", "continue_missing_data", "Este viaje usa contenido que falta y no puede continuarse.");
            Add("es", "continue_started", "Comenzado el {0}.");
            Add("es", "continue_leader", "Tu líder: {0}.");
            Add("es", "continue_deck", "Mazo de {0} cartas: {1}.");
            Add("es", "continue_hint", "Las flechas repasan cartas y botones. Enter en Vamos continúa el viaje.");
            Add("es", "continue_button_desc", "Continúa tu viaje");
            Add("es", "continue_back_desc", "Vuelve al pueblo");
            Add("es", "help_continue_run", "Pantalla de continuar viaje. Muestra el viaje en curso: líder, mazo y fecha de inicio. Enter en el botón de continuar reanuda el viaje. El botón de volver regresa al pueblo. Rendirse abandona el viaje.");
            Add("es", "screen_map", "Mapa del viaje.");
            Add("es", "map_zone", "Zona: {0}.");
            Add("es", "map_you_are_at", "Estás en {0}.");
            Add("es", "map_destinations", "{0} destinos: {1}.");
            Add("es", "map_hint", "Flechas izquierda y derecha recorren el camino, Enter viaja. M lee todo el mapa, I lee detalles, G lee el oro, P abre el inventario.");
            Add("es", "map_node_here", "estás aquí");
            Add("es", "map_node_enter", "Enter para entrar");
            Add("es", "map_only_location", "Este es el único lugar revelado por ahora.");
            Add("es", "map_no_controls", "No hay nada más en esta pantalla.");
            Add("es", "map_node_cleared", "completado");
            Add("es", "map_node_available", "disponible, pulsa Enter para viajar aquí");
            Add("es", "map_node_available_short", "disponible");
            Add("es", "map_node_ahead", "más adelante");
            Add("es", "map_node_not_reachable", "no accesible");
            Add("es", "map_battle_waves", "{0} oleadas");
            Add("es", "map_not_ready", "El mapa aún no está listo.");
            Add("es", "map_overview", "Resumen del mapa, {0} lugares conocidos.");
            Add("es", "map_hidden_nodes", "{0} lugares más sin revelar");
            Add("es", "map_wave_enemies", "Oleada {0}: {1}");
            Add("es", "map_fork_here", "El camino se divide aquí y las ramas no vuelven a unirse: elegir una renuncia a las otras.");
            Add("es", "map_fork_rejoins", "las rutas vuelven a unirse, no se pierde nada");
            Add("es", "map_fork_gives_up", "elegir esto renuncia a: {0}");
            Add("es", "map_fork_gives_up_more", "elegir esto renuncia a: {0}, y {1} más");
            Add("es", "map_fork_gives_up_unseen", "elegir esto renuncia a {0} lugares más adelante en la otra rama");
            Add("es", "help_map", "Mapa del viaje. Tu viaje es un camino de lugares. Flechas izquierda y derecha cambian de lugar. Enter viaja a un lugar disponible. Arriba y abajo alcanzan los mazos y otros controles. M lee todo el mapa, I lee detalles del lugar seleccionado incluidos enemigos, G lee tu oro. P abre tu inventario con el mazo y los talismanes.");

            // Inventario (deckpack): mazo, reserva, amuletos, coronas
            Add("es", "deckpack_unavailable", "No hay inventario en esta pantalla.");
            Add("es", "deckpack_blocked", "El inventario no se puede abrir ahora.");
            Add("es", "deckpack_open", "Inventario abierto.");
            Add("es", "deckpack_closed", "Inventario cerrado.");
            Add("es", "deckpack_part_deck", "{0} en el mazo");
            Add("es", "deckpack_part_reserve", "{0} en la reserva");
            Add("es", "deckpack_part_charms", "{0} talismanes");
            Add("es", "deckpack_part_charm_one", "1 talismán");
            Add("es", "deckpack_part_crowns", "{0} coronas");
            Add("es", "deckpack_part_crown_one", "1 corona");
            Add("es", "deckpack_hint", "Arriba y abajo cambian de grupo, izquierda y derecha se mueven dentro. Enter en un talismán lo coge, Enter en una carta abre sus opciones. P o Escape cierra. F1 para la ayuda completa.");
            Add("es", "deckpack_group_deck", "Mazo, {0} cartas");
            Add("es", "deckpack_group_deck_one", "Mazo, 1 carta");
            Add("es", "deckpack_group_reserve", "Reserva, {0} cartas");
            Add("es", "deckpack_group_reserve_one", "Reserva, 1 carta");
            Add("es", "deckpack_group_charms", "Talismanes, {0}");
            Add("es", "deckpack_group_crowns", "Coronas, {0}");
            Add("es", "deckpack_group_controls", "Botones");
            Add("es", "deckpack_pickup", "{0} cogido. {1} cartas pueden llevarlo. Las flechas cambian entre ellas, Enter lo fija de forma permanente, Escape lo devuelve.");
            Add("es", "deckpack_pickup_one", "{0} cogido. Una carta puede llevarlo. Enter lo fija de forma permanente, Escape lo devuelve.");
            Add("es", "deckpack_pickup_none", "{0}: ninguna carta puede llevarlo ahora. Devuelto.");
            Add("es", "deckpack_battle_blocked", "Los talismanes no se pueden fijar durante la batalla.");
            Add("es", "deckpack_returned", "{0} devuelto.");
            Add("es", "deckpack_applying", "Fijando {0} a {1}.");
            Add("es", "deckpack_applied", "{0} fijado.");
            Add("es", "deckpack_not_eligible", "Esta carta no puede llevar {0}.");
            Add("es", "deckpack_target_slots", "{0} de {1} huecos de talismán usados");
            Add("es", "charm_gained", "¡Talismán conseguido! {0}");
            Add("es", "charm_gained_hint", "Enter lo fija ahora a una carta, Escape lo guarda en tu inventario para más tarde.");
            Add("es", "charm_reserved", "{0} guardado en tu inventario. Fíjalo cuando quieras pulsando P.");
            Add("es", "charm_assign_button", "{0} Enter fija este talismán ahora a una carta, Escape lo guarda en tu inventario para más tarde.");
            Add("es", "deckpack_menu_open", "Opciones de {0}: {1}. Izquierda y derecha eligen, Enter activa, Escape cierra.");
            Add("es", "deckpack_menu_closed", "Opciones cerradas.");
            Add("es", "deckpack_option_rename", "Renombrar");
            Add("es", "deckpack_option_take_crown", "Quitar corona");
            Add("es", "deckpack_option_move_reserve", "Mover a la reserva");
            Add("es", "deckpack_option_move_deck", "Mover al mazo");
            Add("es", "deckpack_moved_reserve", "{0} movida a la reserva.");
            Add("es", "deckpack_moved_deck", "{0} movida al mazo.");
            Add("es", "deckpack_crown_taken", "Corona quitada de {0} y devuelta al inventario.");
            Add("es", "deckpack_card_blocked", "Las opciones de carta no están disponibles ahora.");
            Add("es", "help_deckpack", "Inventario. Tu mazo, cartas de reserva y los talismanes y coronas conseguidos. Arriba y abajo cambian de grupo: mazo, reserva, talismanes, coronas y botones. Izquierda y derecha se mueven dentro del grupo. Enter en un talismán o corona lo coge: las flechas cambian entre las cartas que pueden llevarlo, Enter lo fija de forma permanente, Escape lo devuelve. Enter en una carta abre sus opciones, como moverla entre mazo y reserva. I inspecciona la carta enfocada. P o Escape cierra el inventario.");
            // Map node categories
            Add("es", "node_type_boss", "batalla de jefe");
            Add("es", "node_type_battle", "batalla");
            Add("es", "node_type_shop", "tienda");
            Add("es", "node_type_gnomeshop", "tienda de gnomos");
            Add("es", "node_type_charm", "evento de talismán");
            Add("es", "node_type_gold", "tesoro");
            Add("es", "node_type_item", "evento de objeto");
            Add("es", "node_type_companion", "evento de compañero");
            Add("es", "node_type_copyitem", "evento de copia de objeto");
            Add("es", "node_type_curseitems", "evento de maldición");
            Add("es", "node_type_injuredcompanion", "compañero herido");
            Add("es", "node_type_journalpage", "página del diario");
            Add("es", "node_type_charmshop", "tienda de talismanes");
            Add("es", "node_type_clunkshop", "tienda de trastos");
            Add("es", "node_type_muncher", "muncher");
            Add("es", "node_type_event", "evento");
            // Battle: turn flow, the four groups, playing and moving cards,
            // combat events, in-fight card readouts and the navigation edge cue
            Add("es", "screen_battle", "¡Batalla!");
            Add("es", "battle_wave_total", "{0} oleadas enemigas.");
            Add("es", "battle_hand_count", "{0} cartas en mano.");
            Add("es", "battle_hint", "Arriba y abajo cambian entre mano, tableros, campana y pilas. Izquierda y derecha se mueven dentro. Enter coge y coloca cartas. F1 para ayuda de batalla.");
            Add("es", "battle_your_turn", "Tu turno. {0} cartas en mano.");
            Add("es", "battle_resolving", "Resolviendo el turno.");
            Add("es", "battle_over", "Batalla terminada.");
            Add("es", "battle_turn", "Turno {0}.");
            Add("es", "battle_bell_rung", "Campana de robo tocada. Robando una mano nueva.");
            Add("es", "battle_group_empty", "{0} está vacío.");
            Add("es", "battle_nothing_to_focus", "Nada que seleccionar.");
            Add("es", "group_hand", "Mano");
            Add("es", "group_your_board", "Tu tablero");
            Add("es", "group_enemy_board", "Tablero enemigo");
            Add("es", "group_system", "Campana y pilas");
            Add("es", "battle_card_picked_up", "{0} en mano.");
            Add("es", "battle_pickup_hint", "Las flechas eligen objetivo, Enter la coloca.");
            Add("es", "battle_card_released", "{0} colocada.");
            Add("es", "battle_invalid_target", "Objetivo no válido.");
            Add("es", "battle_cannot_play", "No se puede jugar esa carta ahora.");
            Add("es", "battle_bell_not_ready", "La campana de robo no está disponible ahora.");
            Add("es", "battle_hand_empty", "Tu mano está vacía.");
            Add("es", "battle_acts_in", "actúa en {0}");
            Add("es", "battle_use_on_hand", "Jugar sin objetivo");
            Add("es", "battle_no_waves", "Sin información de oleadas.");
            Add("es", "battle_wave_n", "Oleada {0}: {1}");
            Add("es", "battle_boss_wave", "oleada de jefe");
            Add("es", "battle_all_waves_spawned", "Todas las oleadas han aparecido.");
            Add("es", "battle_next_wave", "Próxima oleada en {0} turnos.");
            Add("es", "battle_bell_charged", "La campana de robo está cargada. Tocarla roba una mano nueva gratis.");
            Add("es", "battle_bell_charging", "La campana de robo estará lista en {0} turnos. Tocarla ahora gasta tu turno.");
            Add("es", "battle_bell_counter", "Se carga en {0} turnos.");
            Add("es", "battle_phase_play", "Te toca.");
            Add("es", "battle_phase_other", "Esperando.");
            Add("es", "battle_hit", "{0} golpea a {1} por {2}.");
            Add("es", "battle_takes_damage", "{0} recibe {1} de daño.");
            Add("es", "battle_healed", "{0} recupera {1} de vida.");
            Add("es", "battle_dodged", "{0} esquivó el golpe.");
            Add("es", "battle_destroyed", "{0} destruido.");
            Add("es", "battle_status_applied", "{0} de {1} aplicado a {2}.");
            Add("es", "battle_your_unit", "tu {0}");
            Add("es", "battle_enemy_unit", "{0} enemigo");
            Add("es", "help_battle", "Batalla. Arriba y abajo cambian de grupo: mano, tu tablero, tablero enemigo, campana y pilas. Izquierda y derecha se mueven dentro del grupo. Enter en una carta de la mano la coge; mientras la sostienes, arriba y abajo cambian de fila, izquierda y derecha se mueven por la fila, nada da la vuelta; Enter la coloca. Enter en una de tus unidades del tablero la coge para moverla: una casilla libre la mueve, una ocupada intercambia o empuja, la zona de retirada la saca del tablero. Mover y retirar son acciones gratuitas que no terminan tu turno. Escape devuelve la carta cogida. I inspecciona la carta enfocada, Escape cierra la inspección. Jugar una carta o tocar la campana termina tu turno. Teclas de lectura: H mano, B tablero, W oleadas, R campana, T turno, G oro, M campanas de modificador, Control C contadores aliados, Control Mayús C contadores enemigos, Control H vida de los aliados, Control Mayús H vida de los enemigos. P abre tu inventario. Pulsa O para el menú del juego con los ajustes.");
            Add("es", "battle_unit_picked_up", "{0} levantada del tablero.");
            Add("es", "battle_move_hint", "Las flechas eligen una casilla de destino o la zona de retirada, Enter confirma, Escape cancela.");
            Add("es", "tutorial_drag_hint", "Para seleccionar y colocar: pulsa Enter sobre la carta, elige el destino con las flechas y pulsa Enter otra vez.");
            Add("es", "tutorial_inspect_hint", "También puedes mantener Ctrl y pulsar arriba para recorrer todos los detalles de la carta seleccionada, uno por uno. Ctrl más izquierda o derecha cambia a otros búferes de revisión.");
            Add("es", "tutorial_counter_keys_hint", "No hace falta seguir los contadores carta por carta: pulsa Ctrl C para oír cada una de tus unidades y en cuántos turnos actúa, y Ctrl Mayús C para lo mismo en el lado enemigo.");
            Add("es", "tutorial_health_keys_hint", "Para saber a quién conviene retirar, pulsa Ctrl H para la vida de tus compañeros, o Ctrl Mayús H para la de los enemigos.");
            Add("es", "battle_unit_moved", "{0} movida.");
            Add("es", "battle_unit_recalled", "{0} retirada.");
            Add("es", "battle_free_action", "Acción gratuita, tu turno continúa.");
            Add("es", "battle_pickup_cancelled", "{0} devuelta.");
            Add("es", "battle_cannot_move", "Esta unidad no se puede mover ahora.");
            Add("es", "battle_recall_zone", "Zona de retirada. Suelta aquí para retirar la unidad.");
            Add("es", "battle_play_anchor", "Zona de juego. Enter juega la carta sin objetivo.");
            Add("es", "battle_trigger_snowed", "{0} está cubierta de nieve y no puede actuar.");
            Add("es", "battle_trigger_nullified", "La acción de {0} fue anulada.");
            Add("es", "battle_trigger_smackback", "¡{0} contraataca a {1}!");
            Add("es", "battle_trigger_laststand", "¡{0} actúa con su último aliento!");
            Add("es", "battle_trigger_chain", "{0} es activada por {1}.");
            Add("es", "battle_trigger_acts", "{0} actúa.");
            Add("es", "battle_kill_combo", "Combo x{0}: {0} muertes este turno.");
            Add("es", "battle_kill_combo_gold", "Combo x{0}: {0} muertes este turno, {1} de oro extra.");
            Add("es", "battle_gold_dropped", "{0} de oro.");
            Add("es", "battle_crown_deploy_one", "Una carta coronada en tu mano se despliega antes de la batalla: pulsa Enter sobre ella para colocarla ahora.");
            Add("es", "battle_crown_deploy", "{0} cartas coronadas en tu mano se despliegan antes de la batalla: colócalas ahora.");
            Add("es", "card_crowned", "Coronada, se despliega al inicio de la batalla.");
            Add("es", "card_charm_one", "Talismán: {0}.");
            Add("es", "card_charms", "{0} talismanes: {1}.");
            Add("es", "card_token_one", "Ficha: {0}.");
            Add("es", "card_tokens", "{0} fichas: {1}.");
            Add("es", "counter_frozen", "contador congelado por la nieve");
            Add("es", "battle_status_damage", "{0} recibe {1} de daño de {2}.");
            Add("es", "battle_shell_blocked", "{0}: Shell bloquea {1} de daño.");
            Add("es", "battle_shell_blocked_all", "{2} golpea a {0}. Shell bloquea los {1} de daño.");
            Add("es", "battle_counter_reduced", "{0}: contador reducido en {1}, actúa en {2}.");
            Add("es", "battle_attack_gain", "{0} gana {1} de ataque, ahora {2}.");
            Add("es", "battle_attack_lose", "{0} pierde {1} de ataque, ahora {2}.");
            Add("es", "battle_counter_gain", "{0}: contador aumentado en {1}, actúa en {2}.");
            Add("es", "battle_counters_allies", "Contadores aliados");
            Add("es", "battle_counters_enemies", "Contadores enemigos");
            Add("es", "battle_counters_none_ally", "Ningún aliado con contador.");
            Add("es", "battle_counters_none_enemy", "Ningún enemigo con contador.");
            Add("es", "battle_health_allies", "Vida de los aliados");
            Add("es", "battle_health_enemies", "Vida de los enemigos");
            Add("es", "battle_health_none_ally", "Ningún aliado en el tablero.");
            Add("es", "battle_health_none_enemy", "Ningún enemigo en el tablero.");
            Add("es", "nav_edge", "Borde.");
            Add("es", "battle_not_a_target", "No es un objetivo válido para esta carta.");
            // Taking an item from an event, then the mechanic wording the card
            // description builder assembles: triggers, targets and summons
            Add("es", "event_item_taken", "Tomaste {0}.");
            Add("es", "status_mech_applies", "aplica {0} {1}");
            Add("es", "status_mech_damage", "causa {0} de daño");
            Add("es", "mech_when_card_destroyed", "cuando otra carta es destruida");
            Add("es", "mech_when_ally_killed", "cuando un aliado muere");
            Add("es", "mech_when_unit_killed", "cuando una unidad muere");
            Add("es", "mech_when_clunker_destroyed", "cuando un Clunker es destruido");
            Add("es", "mech_when_hit", "al ser golpeado");
            Add("es", "mech_when_unit_hit", "cuando otra unidad es golpeada");
            Add("es", "mech_when_damage_taken", "al recibir daño");
            Add("es", "mech_when_healed", "al ser curado");
            Add("es", "mech_when_ally_healed", "cuando un aliado es curado");
            Add("es", "mech_when_deployed", "al desplegarse");
            Add("es", "mech_when_destroyed", "al ser destruido");
            Add("es", "mech_when_drawn", "al robarse");
            Add("es", "mech_on_kill", "al matar");
            Add("es", "mech_on_turn", "en su turno");
            Add("es", "mech_every_turn", "cada turno");
            Add("es", "mech_after_attack", "después de atacar");
            Add("es", "mech_on_hit", "al golpear");
            Add("es", "mech_to_self", "a sí mismo");
            Add("es", "mech_to_allies", "a todos los aliados");
            Add("es", "mech_to_allies_row", "a los aliados de su fila");
            Add("es", "mech_to_front_ally", "al aliado delantero");
            Add("es", "mech_to_enemies", "a todos los enemigos");
            Add("es", "mech_to_front_enemy", "al enemigo delantero");
            Add("es", "mech_to_attacker", "al atacante");
            Add("es", "mech_to_target", "a su objetivo");
            Add("es", "mech_to_random_ally", "a un aliado al azar");
            Add("es", "mech_to_random_enemy", "a un enemigo al azar");
            Add("es", "mech_to_hand", "a las cartas de la mano");
            Add("es", "mech_summons", "Invoca a {0}: {1}.");
            Add("es", "mech_summons_bare", "Invoca a {0}.");
            Add("es", "mech_summon_counter", "actúa cada {0}");
            Add("es", "mech_trigger_meaning", "Activarse significa que esta carta ataca en cuanto eso ocurre, a su propio objetivo, además de su turno normal. Su cuenta atrás no se reinicia, así que el ataque es gratis.");
            Add("es", "mech_trigger_retaliate", "Cuando algo golpea a esta carta, contraataca al agresor de inmediato, además de su turno normal.");
            // Card badges: injuries, mentioned keywords and upgrade kinds
            Add("es", "card_injured_one", "Herido.");
            Add("es", "card_injured", "Herido x{0}.");
            Add("es", "card_mentions", "Menciona a {0}");
            Add("es", "upgrade_charm", "talismán");
            Add("es", "upgrade_crown", "corona");
            Add("es", "upgrade_token", "ficha");
            // Back on the battle screen: Last Stand, injuries, the crown
            // holder, and the redraw, wave and modifier bells
            Add("es", "battle_last_stand", "¡Último aliento! {0} se niega a caer. La batalla se decide con una tirada de dados. Pulsa Enter para tirar los dados.");
            Add("es", "battle_last_stand_generic", "¡Último aliento! La batalla se decide con una tirada de dados. Pulsa Enter para tirar los dados.");
            Add("es", "battle_last_stand_rolling", "Tirando los dados.");
            Add("es", "battle_last_stand_won", "¡Ganas el último aliento!");
            Add("es", "battle_last_stand_lost", "Pierdes el último aliento.");
            Add("es", "battle_companion_injured", "¡{0} ha sido herido!");
            Add("es", "crown_holder_empty", "Soporte de corona, vacío. La corona ya fue tomada.");
            Add("es", "battle_bell_name", "Campana de robo");
            Add("es", "battle_wave_bell_name", "Campana de oleadas");
            Add("es", "battle_wave_incoming", "{0} enemigos llegan en {1} turnos.");
            Add("es", "battle_wave_overflow", "{0} de ellos no cabrán en el tablero enemigo.");
            Add("es", "battle_wave_call_early", "Puede tocarse para llamar la oleada antes.");
            Add("es", "battle_wave_call_reward", "Recompensa por tocarla ahora: {0} de oro.");
            Add("es", "battle_no_modifiers", "No hay campanas de modificador activas.");
            Add("es", "battle_modifier_bell", "Campana de modificador.");
            // Game menu (the pause screen): tabs, settings rows and lore pages
            Add("es", "screen_pause", "Menú del juego.");
            Add("es", "pause_hint", "Arriba y abajo se mueven por la página, Enter activa. Izquierda y derecha cambian de pestaña, o cambian el valor de un ajuste. T salta a las pestañas, Escape vuelve atrás. Pulsa O para cerrar el menú.");
            Add("es", "pause_no_tabs", "No hay pestañas accesibles aquí. Escape vuelve atrás.");
            Add("es", "pause_tab_named", "{0}, pestaña. Enter para abrir.");
            Add("es", "pause_tab", "Pestaña. Enter para abrir.");
            Add("es", "pause_tab_opened", "{0} abierta.");
            Add("es", "pause_closed", "Menú cerrado.");
            Add("es", "pause_unavailable", "El menú no está disponible ahora.");
            Add("es", "setting_adjust_hint", "Izquierda y derecha cambian el valor.");
            Add("es", "setting_percent", "{0} por ciento");
            Add("es", "nav_nothing", "No hay nada que enfocar aquí.");
            Add("es", "row_not_interactive", "Esta entrada es de solo lectura.");
            Add("es", "pause_lore_page", "Página de historia");
            Add("es", "pause_lore_locked", "bloqueada");
            Add("es", "pause_lore_new", "nueva");
            Add("es", "pause_lore_open_hint", "Enter para leer.");
            Add("es", "pause_lore_close_hint", "Escape cierra la página.");
            Add("es", "pause_lore_closed", "Página cerrada.");
            Add("es", "stat_no_value", "ninguno");
            Add("es", "help_pause", "Menú del juego. Arriba y abajo se mueven por los elementos de la página, Enter activa. Izquierda y derecha se mueven por las pestañas, o cambian el valor de un ajuste. T salta a las pestañas. Escape vuelve un nivel atrás, por ejemplo fuera de una categoría de ajustes. Tab y Mayús Tab también recorren la página. Pulsa O para cerrar el menú.");
            // Story events (Event scene, cinema bar text), the inspect view
            // and the shared prompt panel
            Add("es", "event_prompt_action", "Pulsa Enter.");
            Add("es", "event_crack", "Grieta {0} de 4.");
            Add("es", "select_blocked", "Esto no se puede elegir ahora mismo.");
            Add("es", "select_blocked_reason", "Aún no permitido. {0}");
            Add("es", "inspect_opened", "Inspeccionando {0}. Escape para cerrar.");
            Add("es", "inspect_closed", "Inspección cerrada.");
            Add("es", "nothing_to_inspect", "No hay nada que inspeccionar aquí.");
            Add("es", "help_panel_hint", "Las flechas izquierda y derecha eligen un botón, Enter lo pulsa, Escape vuelve atrás.");
            Add("es", "help_panel_no_back", "Este aviso necesita una respuesta. Usa izquierda y derecha, luego Enter.");
            // Translated later and kept in key order: the town overlays and
            // unlock buildings, the shrine challenges, the character select
            // back and position labels, the Icebreaker Hut's map events, the
            // tribe names, blurbs and hall, and the in-front placement
            // tutorial hint. Tribe names themselves stay as they are —
            // Snowdwellers, Shademancers and Clunkmasters are proper nouns
            // the game never translates either.
            Add("es", "building_back", "Atrás.");
            Add("es", "building_closed", "Cerrado.");
            Add("es", "building_overlay_hint", "Las flechas mueven entre los estandartes, Enter abre uno, Escape sale, I lee de nuevo.");
            Add("es", "challenge_hidden", "{0}, reto oculto");
            Add("es", "challenge_stone", "Reto");
            Add("es", "charselect_back", "Volver");
            Add("es", "charselect_leader_pos", "Líder {0} de {1}: {2}");
            Add("es", "charselect_pet_pos", "Mascota {0} de {1}: {2}");
            Add("es", "event_node_CampaignNodeCharmShop", "Tienda de talismanes");
            Add("es", "event_node_CampaignNodeCopyItem", "Copiar un objeto");
            Add("es", "event_node_CampaignNodeCurseItems", "Objetos malditos");
            Add("es", "icebreaker_hint", "Las flechas mueven entre los eventos de mapa, Enter lee qué hace uno, Escape sale, I repite el resumen.");
            Add("es", "icebreaker_unlock_intro", "Completa este reto para desbloquear el siguiente evento de mapa:");
            Add("es", "icebreaker_unlocked", "{0} de {1} eventos de mapa desbloqueados: {2}.");
            Add("es", "icebreaker_unlocked_none", "Ninguno de sus {0} eventos de mapa está desbloqueado todavía.");
            Add("es", "overlay_browse", "{0} elementos. Usa las flechas para recorrerlos.");
            Add("es", "overlay_item", "{0}, {1} de {2}");
            Add("es", "overlay_position", "{0} de {1}");
            Add("es", "shrine_hint", "Arriba y abajo cambian entre pendientes y completados, izquierda y derecha recorren.");
            Add("es", "shrine_none_completed", "No hay retos completados.");
            Add("es", "shrine_none_incomplete", "No hay retos pendientes.");
            Add("es", "shrine_row_completed", "Retos completados");
            Add("es", "shrine_row_incomplete", "Retos pendientes");
            Add("es", "shrine_summary", "{0} pendientes, {1} completados.");
            Add("es", "tribe_banner", "Estandarte de tribu");
            Add("es", "tribe_name_Basic", "Moradores de la Nieve");
            Add("es", "tribe_name_Magic", "Sombramantes");
            Add("es", "tribe_name_Clunk", "Chatarreros");
            Add("es", "tribe_desc_Basic", "La tribu inicial y la más apta para principiantes. Congelan a los enemigos con Escarcha y Nieve para que pierdan turnos, y aumentan su ataque con Bonus.");
            Add("es", "tribe_desc_Clunk", "Inventores que luchan con Chatarra, máquinas pesadas que aguantan los golpes, y objetos de Basura. Abruman al enemigo a base de masa y maquinaria.");
            Add("es", "tribe_desc_Magic", "Una tribu agresiva y de alto riesgo construida en torno a Sombra y Picante. Acumulan ataque temporal para golpear rápido y fuerte, pero sus unidades son frágiles.");
            Add("es", "tribe_leaders", "Líderes: {0}.");
            Add("es", "tribe_leaders_random", "Los líderes se generan al azar: eliges entre tres después de escoger esta tribu.");
            Add("es", "tribe_no_roster", "Esta tribu no tiene líderes ni mazo inicial listados.");
            Add("es", "tribe_starting_deck", "Mazo inicial: {0}.");
            Add("es", "tribe_unlock_intro", "Completa este reto para desbloquear la siguiente tribu:");
            Add("es", "tribehall_hint", "Las flechas mueven entre los estandartes de tribu, Enter abre la página de la tribu enfocada, Escape sale, I repite el resumen.");
            Add("es", "tribehall_unlocked", "{0} de {1} tribus desbloqueadas: {2}.");
            Add("es", "tribehall_unlocked_none", "Ninguna de sus {0} tribus está desbloqueada todavía.");
            Add("es", "tutorial_drag_hint_infront", "Cómo hacerlo: pulsa Enter sobre la carta, usa las flechas para elegir la unidad delante de la que quieres ponerla, y pulsa Enter — tu carta ocupa ese hueco y empuja a la unidad hacia atrás.");
            Add("es", "unlock_all_done", "Aquí está todo desbloqueado.");
            Add("es", "unlock_detail_back", "Escape vuelve atrás.");
            Add("es", "unlock_entry_locked", "{0} sigue bloqueado.");
            Add("es", "unlock_next_intro", "Siguiente desbloqueo:");
            Add("es", "unlock_slot_locked", "Hueco bloqueado");
            Add("es", "unlock_state_locked", "bloqueado");
            Add("es", "unlock_state_unlocked", "desbloqueado");
            Add("es", "unlockhut_hint", "Las flechas mueven entre los huecos, Escape sale, I repite el resumen.");
            Add("es", "unlockhut_unlocked", "{0} de {1} desbloqueados: {2}.");
            Add("es", "unlockhut_unlocked_none", "Ninguno de sus {0} huecos está abierto todavía.");

            // Closing the prompt panel, and the event screen's F1 help
            Add("es", "help_panel_closed", "Cerrado.");
            Add("es", "help_event", "Pantalla de evento. Un evento de historia en tu viaje; su título y texto se leen cuando aparecen. Las flechas mueven entre elementos, Enter activa. En una tienda, cada artículo dice su precio y si puedes pagarlo; pulsa Enter sobre él para comprarlo, y G para oír tu oro actual. I inspecciona la carta enfocada, como el clic derecho para jugadores videntes, Escape cierra la inspección. P abre tu inventario.");

        }
    }
}
