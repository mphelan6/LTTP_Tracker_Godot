using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class SaveMonitor
{
	// every check
	public static Check[] Checks;

	// checks for each level
	public static Check[] Checks_LW;
	public static Check[] Checks_DW;

	public static Check[] Checks_CA;

	public static Check[] Checks_L1;
	public static Check[] Checks_L2;
	public static Check[] Checks_L3;

	public static Check[] Checks_AG;

	public static Check[] Checks_D1;
	public static Check[] Checks_D2;
	public static Check[] Checks_D3;
	public static Check[] Checks_D4;
	public static Check[] Checks_D5;
	public static Check[] Checks_D6;
	public static Check[] Checks_D7;

	public static Check[] Checks_GT;

	public static void StartupSaveMonitor()
	{
		// initialize the size of the savechecks to the same size of the CheckName enum
		Checks = new Check[Check.NUM_CHECKS];

		// add all of the checks
		Checks[(int)Check.Name.BLINDS_HIDEOUT_TOP]                        = new Check(0x23A, 0x10);
		Checks[(int)Check.Name.BLINDS_HIDEOUT_LEFT]                       = new Check(0x23A, 0x20);
		Checks[(int)Check.Name.BLINDS_HIDEOUT_RIGHT]                      = new Check(0x23A, 0x40);
		Checks[(int)Check.Name.BLINDS_HIDEOUT_FAR_LEFT]                   = new Check(0x23A, 0x80);
		Checks[(int)Check.Name.BLINDS_HIDEOUT_FAR_RIGHT]                  = new Check(0x23B, 0x01);
		Checks[(int)Check.Name.SECRET_PASSAGE]                            = new Check(0x0AA, 0x10);
		Checks[(int)Check.Name.WATERFALL_FAIRY_LEFT]                      = new Check(0x228, 0x10);
		Checks[(int)Check.Name.WATERFALL_FAIRY_RIGHT]                     = new Check(0x228, 0x20);
		Checks[(int)Check.Name.KINGS_TOMB]                                = new Check(0x226, 0x10);
		Checks[(int)Check.Name.FLOODGATE_CHEST]                           = new Check(0x216, 0x10);
		Checks[(int)Check.Name.LINKS_HOUSE]                               = new Check(0x208, 0x10);
		Checks[(int)Check.Name.KAKARIKO_TAVERN]                           = new Check(0x206, 0x10);
		Checks[(int)Check.Name.CHICKEN_HOUSE]                             = new Check(0x210, 0x10);
		Checks[(int)Check.Name.AGINAHS_CAVE]                              = new Check(0x214, 0x10);
		Checks[(int)Check.Name.SAHASRAHLAS_HUT_LEFT]                      = new Check(0x20A, 0x10);
		Checks[(int)Check.Name.SAHASRAHLAS_HUT_MIDDLE]                    = new Check(0x20A, 0x20);
		Checks[(int)Check.Name.SAHASRAHLAS_HUT_RIGHT]                     = new Check(0x20A, 0x40);
		Checks[(int)Check.Name.KAKARIKO_WELL_TOP]                         = new Check(0x05E, 0x10);
		Checks[(int)Check.Name.KAKARIKO_WELL_LEFT]                        = new Check(0x05E, 0x20);
		Checks[(int)Check.Name.KAKARIKO_WELL_MIDDLE]                      = new Check(0x05E, 0x40);
		Checks[(int)Check.Name.KAKARIKO_WELL_RIGHT]                       = new Check(0x05E, 0x80);
		Checks[(int)Check.Name.KAKARIKO_WELL_BOTTOM]                      = new Check(0x05F, 0x01);
		Checks[(int)Check.Name.LOST_WOODS_HIDEOUT]                        = new Check(0x1C3, 0x02);
		Checks[(int)Check.Name.LUMBERJACK_TREE]                           = new Check(0x1C5, 0x02);
		Checks[(int)Check.Name.CAVE_45]                                   = new Check(0x237, 0x04);
		Checks[(int)Check.Name.GRAVEYARD_CAVE]                            = new Check(0x237, 0x02);
		Checks[(int)Check.Name.CHECKERBOARD_CAVE]                         = new Check(0x24D, 0x02);
		Checks[(int)Check.Name.MINI_MOLDORM_CAVE_FAR_LEFT]                = new Check(0x246, 0x10);
		Checks[(int)Check.Name.MINI_MOLDORM_CAVE_LEFT]                    = new Check(0x246, 0x20);
		Checks[(int)Check.Name.MINI_MOLDORM_CAVE_RIGHT]                   = new Check(0x246, 0x40);
		Checks[(int)Check.Name.MINI_MOLDORM_CAVE_FAR_RIGHT]               = new Check(0x246, 0x80);
		Checks[(int)Check.Name.MINI_MOLDORM_CAVE_GENEROUS_GUY]            = new Check(0x247, 0x04);
		Checks[(int)Check.Name.ICE_ROD_CAVE]                              = new Check(0x240, 0x10);
		Checks[(int)Check.Name.BONK_ROCK_CAVE]                            = new Check(0x248, 0x10);
		Checks[(int)Check.Name.DESERT_PALACE_BIG_CHEST]                   = new Check(0x0E6, 0x10);
		Checks[(int)Check.Name.DESERT_PALACE_TORCH]                       = new Check(0x0E7, 0x04);
		Checks[(int)Check.Name.DESERT_PALACE_MAP_CHEST]                   = new Check(0x0E8, 0x10);
		Checks[(int)Check.Name.DESERT_PALACE_COMPASS_CHEST]               = new Check(0x10A, 0x10);
		Checks[(int)Check.Name.DESERT_PALACE_BIG_KEY_CHEST]               = new Check(0x0EA, 0x10);
		Checks[(int)Check.Name.DESERT_PALACE_DESERT_TILES_1_POT_KEY]      = new Check(0x0C7, 0x04);
		Checks[(int)Check.Name.DESERT_PALACE_BEAMOS_HALL_POT_KEY]         = new Check(0x0A7, 0x04);
		Checks[(int)Check.Name.DESERT_PALACE_DESERT_TILES_2_POT_KEY]      = new Check(0x087, 0x04);
		Checks[(int)Check.Name.DESERT_PALACE_BOSS]                        = new Check(0x067, 0x08);
		Checks[(int)Check.Name.EASTERN_PALACE_COMPASS_CHEST]              = new Check(0x150, 0x10);
		Checks[(int)Check.Name.EASTERN_PALACE_BIG_CHEST]                  = new Check(0x152, 0x10);
		Checks[(int)Check.Name.EASTERN_PALACE_DARK_SQUARE_POT_KEY]        = new Check(0x175, 0x04);
		Checks[(int)Check.Name.EASTERN_PALACE_DARK_EYEGORE_KEY_DROP]      = new Check(0x133, 0x04);
		Checks[(int)Check.Name.EASTERN_PALACE_CANNONBALL_CHEST]           = new Check(0x172, 0x10);
		Checks[(int)Check.Name.EASTERN_PALACE_BIG_KEY_CHEST]              = new Check(0x170, 0x10);
		Checks[(int)Check.Name.EASTERN_PALACE_MAP_CHEST]                  = new Check(0x154, 0x10);
		Checks[(int)Check.Name.EASTERN_PALACE_BOSS]                       = new Check(0x191, 0x08);
		Checks[(int)Check.Name.HYRULE_CASTLE_BOOMERANG_CHEST]             = new Check(0x0E2, 0x10);
		Checks[(int)Check.Name.HYRULE_CASTLE_BOOMERANG_GUARD_KEY_DROP]    = new Check(0x0E3, 0x04);
		Checks[(int)Check.Name.HYRULE_CASTLE_MAP_CHEST]                   = new Check(0x0E4, 0x10);
		Checks[(int)Check.Name.HYRULE_CASTLE_MAP_GUARD_KEY_DROP]          = new Check(0x0E5, 0x04);
		Checks[(int)Check.Name.HYRULE_CASTLE_ZELDAS_CHEST]                = new Check(0x100, 0x10);
		Checks[(int)Check.Name.HYRULE_CASTLE_BIG_KEY_DROP]                = new Check(0x101, 0x04);
		Checks[(int)Check.Name.SEWERS_DARK_CROSS]                         = new Check(0x064, 0x10);
		Checks[(int)Check.Name.SEWERS_KEY_RAT_KEY_DROP]                   = new Check(0x043, 0x04);
		Checks[(int)Check.Name.SEWERS_SECRET_ROOM_LEFT]                   = new Check(0x022, 0x10);
		Checks[(int)Check.Name.SEWERS_SECRET_ROOM_MIDDLE]                 = new Check(0x022, 0x20);
		Checks[(int)Check.Name.SEWERS_SECRET_ROOM_RIGHT]                  = new Check(0x022, 0x40);
		Checks[(int)Check.Name.SANCTUARY]                                 = new Check(0x024, 0x10);
		Checks[(int)Check.Name.CASTLE_TOWER_ROOM_03]                      = new Check(0x1C0, 0x10);
		Checks[(int)Check.Name.CASTLE_TOWER_DARK_MAZE]                    = new Check(0x1A0, 0x10);
		Checks[(int)Check.Name.CASTLE_TOWER_DARK_ARCHER_KEY_DROP]         = new Check(0x181, 0x04);
		Checks[(int)Check.Name.CASTLE_TOWER_CIRCLE_OF_POTS_KEY_DROP]      = new Check(0x161, 0x04);
		Checks[(int)Check.Name.SPECTACLE_ROCK_CAVE]                       = new Check(0x1D5, 0x04);
		Checks[(int)Check.Name.PARADOX_CAVE_LOWER_FAR_LEFT]               = new Check(0x1DE, 0x10);
		Checks[(int)Check.Name.PARADOX_CAVE_LOWER_LEFT]                   = new Check(0x1DE, 0x20);
		Checks[(int)Check.Name.PARADOX_CAVE_LOWER_RIGHT]                  = new Check(0x1DE, 0x40);
		Checks[(int)Check.Name.PARADOX_CAVE_LOWER_FAR_RIGHT]              = new Check(0x1DE, 0x80);
		Checks[(int)Check.Name.PARADOX_CAVE_LOWER_MIDDLE]                 = new Check(0x1DF, 0x01);
		Checks[(int)Check.Name.PARADOX_CAVE_UPPER_LEFT]                   = new Check(0x1FE, 0x10);
		Checks[(int)Check.Name.PARADOX_CAVE_UPPER_RIGHT]                  = new Check(0x1FE, 0x20);
		Checks[(int)Check.Name.SPIRAL_CAVE]                               = new Check(0x1FC, 0x10);
		Checks[(int)Check.Name.TOWER_OF_HERA_BASEMENT_CAGE]               = new Check(0x10F, 0x04);
		Checks[(int)Check.Name.TOWER_OF_HERA_MAP_CHEST]                   = new Check(0x0EE, 0x10);
		Checks[(int)Check.Name.TOWER_OF_HERA_BIG_KEY_CHEST]               = new Check(0x10E, 0x10);
		Checks[(int)Check.Name.TOWER_OF_HERA_COMPASS_CHEST]               = new Check(0x04E, 0x20);
		Checks[(int)Check.Name.TOWER_OF_HERA_BIG_CHEST]                   = new Check(0x04E, 0x10);
		Checks[(int)Check.Name.TOWER_OF_HERA_BOSS]                        = new Check(0x00F, 0x08);
		Checks[(int)Check.Name.HYPE_CAVE_TOP]                             = new Check(0x23C, 0x10);
		Checks[(int)Check.Name.HYPE_CAVE_MIDDLE_RIGHT]                    = new Check(0x23C, 0x20);
		Checks[(int)Check.Name.HYPE_CAVE_MIDDLE_LEFT]                     = new Check(0x23C, 0x40);
		Checks[(int)Check.Name.HYPE_CAVE_BOTTOM]                          = new Check(0x23C, 0x80);
		Checks[(int)Check.Name.HYPE_CAVE_GENEROUS_GUY]                    = new Check(0x23D, 0x04);
		Checks[(int)Check.Name.PEG_CAVE]                                  = new Check(0x24F, 0x04);
		Checks[(int)Check.Name.PYRAMID_FAIRY_LEFT]                        = new Check(0x22C, 0x10);
		Checks[(int)Check.Name.PYRAMID_FAIRY_RIGHT]                       = new Check(0x22C, 0x20);
		Checks[(int)Check.Name.BREWERY]                                   = new Check(0x20C, 0x10);
		Checks[(int)Check.Name.CSHAPED_HOUSE]                             = new Check(0x238, 0x10);
		Checks[(int)Check.Name.CHEST_GAME]                                = new Check(0x20D, 0x04);
		Checks[(int)Check.Name.MIRE_SHED_LEFT]                            = new Check(0x21A, 0x10);
		Checks[(int)Check.Name.MIRE_SHED_RIGHT]                           = new Check(0x21A, 0x20);
		Checks[(int)Check.Name.SUPERBUNNY_CAVE_TOP]                       = new Check(0x1F0, 0x10);
		Checks[(int)Check.Name.SUPERBUNNY_CAVE_BOTTOM]                    = new Check(0x1F0, 0x20);
		Checks[(int)Check.Name.SPIKE_CAVE]                                = new Check(0x22E, 0x10);
		Checks[(int)Check.Name.HOOKSHOT_CAVE_TOP_RIGHT]                   = new Check(0x078, 0x10);
		Checks[(int)Check.Name.HOOKSHOT_CAVE_TOP_LEFT]                    = new Check(0x078, 0x20);
		Checks[(int)Check.Name.HOOKSHOT_CAVE_BOTTOM_RIGHT]                = new Check(0x078, 0x80);
		Checks[(int)Check.Name.HOOKSHOT_CAVE_BOTTOM_LEFT]                 = new Check(0x078, 0x40);
		Checks[(int)Check.Name.MIMIC_CAVE]                                = new Check(0x218, 0x10);
		Checks[(int)Check.Name.SWAMP_PALACE_ENTRANCE]                     = new Check(0x050, 0x10);
		Checks[(int)Check.Name.SWAMP_PALACE_MAP_CHEST]                    = new Check(0x06E, 0x10);
		Checks[(int)Check.Name.SWAMP_PALACE_POT_ROW_POT_KEY]              = new Check(0x071, 0x04);
		Checks[(int)Check.Name.SWAMP_PALACE_TRENCH_1_POT_KEY]             = new Check(0x06F, 0x04);
		Checks[(int)Check.Name.SWAMP_PALACE_HOOKSHOT_POT_KEY]             = new Check(0x06D, 0x04);
		Checks[(int)Check.Name.SWAMP_PALACE_BIG_CHEST]                    = new Check(0x06C, 0x10);
		Checks[(int)Check.Name.SWAMP_PALACE_COMPASS_CHEST]                = new Check(0x08C, 0x10);
		Checks[(int)Check.Name.SWAMP_PALACE_TRENCH_2_POT_KEY]             = new Check(0x06B, 0x04);
		Checks[(int)Check.Name.SWAMP_PALACE_BIG_KEY_CHEST]                = new Check(0x06A, 0x10);
		Checks[(int)Check.Name.SWAMP_PALACE_WEST_CHEST]                   = new Check(0x068, 0x10);
		Checks[(int)Check.Name.SWAMP_PALACE_FLOODED_ROOM_LEFT]            = new Check(0x0EC, 0x10);
		Checks[(int)Check.Name.SWAMP_PALACE_FLOODED_ROOM_RIGHT]           = new Check(0x0EC, 0x20);
		Checks[(int)Check.Name.SWAMP_PALACE_WATERFALL_ROOM]               = new Check(0x0CC, 0x10);
		Checks[(int)Check.Name.SWAMP_PALACE_WATERWAY_POT_KEY]             = new Check(0x02D, 0x04);
		Checks[(int)Check.Name.SWAMP_PALACE_BOSS]                         = new Check(0x00D, 0x08);
		Checks[(int)Check.Name.THIEVES_TOWN_BIG_KEY_CHEST]                = new Check(0x1B6, 0x20);
		Checks[(int)Check.Name.THIEVES_TOWN_MAP_CHEST]                    = new Check(0x1B6, 0x10);
		Checks[(int)Check.Name.THIEVES_TOWN_COMPASS_CHEST]                = new Check(0x1B8, 0x10);
		Checks[(int)Check.Name.THIEVES_TOWN_AMBUSH_CHEST]                 = new Check(0x196, 0x10);
		Checks[(int)Check.Name.THIEVES_TOWN_HALLWAY_POT_KEY]              = new Check(0x179, 0x04);
		Checks[(int)Check.Name.THIEVES_TOWN_SPIKE_SWITCH_POT_KEY]         = new Check(0x157, 0x04);
		Checks[(int)Check.Name.THIEVES_TOWN_ATTIC]                        = new Check(0x0CA, 0x10);
		Checks[(int)Check.Name.THIEVES_TOWN_BIG_CHEST]                    = new Check(0x088, 0x10);
		Checks[(int)Check.Name.THIEVES_TOWN_BLINDS_CELL]                  = new Check(0x08A, 0x10);
		Checks[(int)Check.Name.THIEVES_TOWN_BOSS]                         = new Check(0x159, 0x08);
		Checks[(int)Check.Name.SKULL_WOODS_COMPASS_CHEST]                 = new Check(0x0CE, 0x10);
		Checks[(int)Check.Name.SKULL_WOODS_MAP_CHEST]                     = new Check(0x0B0, 0x20);
		Checks[(int)Check.Name.SKULL_WOODS_BIG_CHEST]                     = new Check(0x0B0, 0x10);
		Checks[(int)Check.Name.SKULL_WOODS_POT_PRISON]                    = new Check(0x0AE, 0x20);
		Checks[(int)Check.Name.SKULL_WOODS_PINBALL_ROOM]                  = new Check(0x0D0, 0x10);
		Checks[(int)Check.Name.SKULL_WOODS_BIG_KEY_CHEST]                 = new Check(0x0AE, 0x10);
		Checks[(int)Check.Name.SKULL_WOODS_WEST_LOBBY_POT_KEY]            = new Check(0x0AD, 0x04);
		Checks[(int)Check.Name.SKULL_WOODS_BRIDGE_ROOM]                   = new Check(0x0B2, 0x10);
		Checks[(int)Check.Name.SKULL_WOODS_SPIKE_CORNER_KEY_DROP]         = new Check(0x073, 0x04);
		Checks[(int)Check.Name.SKULL_WOODS_BOSS]                          = new Check(0x053, 0x08);
		Checks[(int)Check.Name.ICE_PALACE_JELLY_KEY_DROP]                 = new Check(0x01D, 0x04);
		Checks[(int)Check.Name.ICE_PALACE_COMPASS_CHEST]                  = new Check(0x05C, 0x10);
		Checks[(int)Check.Name.ICE_PALACE_CONVEYOR_KEY_DROP]              = new Check(0x07D, 0x04);
		Checks[(int)Check.Name.ICE_PALACE_FREEZOR_CHEST]                  = new Check(0x0FC, 0x10);
		Checks[(int)Check.Name.ICE_PALACE_BIG_CHEST]                      = new Check(0x13C, 0x10);
		Checks[(int)Check.Name.ICE_PALACE_ICED_T_ROOM]                    = new Check(0x15C, 0x10);
		Checks[(int)Check.Name.ICE_PALACE_MANY_POTS_POT_KEY]              = new Check(0x13F, 0x04);
		Checks[(int)Check.Name.ICE_PALACE_SPIKE_ROOM]                     = new Check(0x0BE, 0x10);
		Checks[(int)Check.Name.ICE_PALACE_BIG_KEY_CHEST]                  = new Check(0x03E, 0x10);
		Checks[(int)Check.Name.ICE_PALACE_HAMMER_BLOCK_KEY_DROP]          = new Check(0x07F, 0x04);
		Checks[(int)Check.Name.ICE_PALACE_MAP_CHEST]                      = new Check(0x07E, 0x10);
		Checks[(int)Check.Name.ICE_PALACE_BOSS]                           = new Check(0x1BD, 0x08);
		Checks[(int)Check.Name.MISERY_MIRE_BIG_CHEST]                     = new Check(0x186, 0x10);
		Checks[(int)Check.Name.MISERY_MIRE_MAP_CHEST]                     = new Check(0x186, 0x20);
		Checks[(int)Check.Name.MISERY_MIRE_MAIN_LOBBY]                    = new Check(0x184, 0x10);
		Checks[(int)Check.Name.MISERY_MIRE_BRIDGE_CHEST]                  = new Check(0x144, 0x10);
		Checks[(int)Check.Name.MISERY_MIRE_SPIKES_POT_KEY]                = new Check(0x167, 0x04);
		Checks[(int)Check.Name.MISERY_MIRE_SPIKE_CHEST]                   = new Check(0x166, 0x10);
		Checks[(int)Check.Name.MISERY_MIRE_FISHBONE_POT_KEY]              = new Check(0x143, 0x04);
		Checks[(int)Check.Name.MISERY_MIRE_CONVEYOR_CRYSTAL_KEY_DROP]     = new Check(0x183, 0x04);
		Checks[(int)Check.Name.MISERY_MIRE_COMPASS_CHEST]                 = new Check(0x182, 0x10);
		Checks[(int)Check.Name.MISERY_MIRE_BIG_KEY_CHEST]                 = new Check(0x1A2, 0x10);
		Checks[(int)Check.Name.MISERY_MIRE_BOSS]                          = new Check(0x121, 0x08);
		Checks[(int)Check.Name.TURTLE_ROCK_COMPASS_CHEST]                 = new Check(0x1AC, 0x10);
		Checks[(int)Check.Name.TURTLE_ROCK_ROLLER_ROOM_LEFT]              = new Check(0x16E, 0x10);
		Checks[(int)Check.Name.TURTLE_ROCK_ROLLER_ROOM_RIGHT]             = new Check(0x16E, 0x20);
		Checks[(int)Check.Name.TURTLE_ROCK_POKEY_1_KEY_DROP]              = new Check(0x16D, 0x04);
		Checks[(int)Check.Name.TURTLE_ROCK_CHAIN_CHOMPS]                  = new Check(0x16C, 0x10);
		Checks[(int)Check.Name.TURTLE_ROCK_POKEY_2_KEY_DROP]              = new Check(0x027, 0x04);
		Checks[(int)Check.Name.TURTLE_ROCK_BIG_KEY_CHEST]                 = new Check(0x028, 0x10);
		Checks[(int)Check.Name.TURTLE_ROCK_BIG_CHEST]                     = new Check(0x048, 0x10);
		Checks[(int)Check.Name.TURTLE_ROCK_CRYSTAROLLER_ROOM]             = new Check(0x008, 0x10);
		Checks[(int)Check.Name.TURTLE_ROCK_EYE_BRIDGE_BOTTOM_LEFT]        = new Check(0x1AA, 0x80);
		Checks[(int)Check.Name.TURTLE_ROCK_EYE_BRIDGE_BOTTOM_RIGHT]       = new Check(0x1AA, 0x40);
		Checks[(int)Check.Name.TURTLE_ROCK_EYE_BRIDGE_TOP_LEFT]           = new Check(0x1AA, 0x20);
		Checks[(int)Check.Name.TURTLE_ROCK_EYE_BRIDGE_TOP_RIGHT]          = new Check(0x1AA, 0x10);
		Checks[(int)Check.Name.TURTLE_ROCK_BOSS]                          = new Check(0x149, 0x08);
		Checks[(int)Check.Name.PALACE_OF_DARKNESS_SHOOTER_ROOM]           = new Check(0x012, 0x10);
		Checks[(int)Check.Name.PALACE_OF_DARKNESS_THE_ARENA_BRIDGE]       = new Check(0x054, 0x20);
		Checks[(int)Check.Name.PALACE_OF_DARKNESS_STALFOS_BASEMENT]       = new Check(0x014, 0x10);
		Checks[(int)Check.Name.PALACE_OF_DARKNESS_BIG_KEY_CHEST]          = new Check(0x074, 0x10);
		Checks[(int)Check.Name.PALACE_OF_DARKNESS_THE_ARENA_LEDGE]        = new Check(0x054, 0x10);
		Checks[(int)Check.Name.PALACE_OF_DARKNESS_MAP_CHEST]              = new Check(0x056, 0x10);
		Checks[(int)Check.Name.PALACE_OF_DARKNESS_COMPASS_CHEST]          = new Check(0x034, 0x20);
		Checks[(int)Check.Name.PALACE_OF_DARKNESS_DARK_BASEMENT_LEFT]     = new Check(0x0D4, 0x10);
		Checks[(int)Check.Name.PALACE_OF_DARKNESS_DARK_BASEMENT_RIGHT]    = new Check(0x0D4, 0x20);
		Checks[(int)Check.Name.PALACE_OF_DARKNESS_DARK_MAZE_TOP]          = new Check(0x032, 0x10);
		Checks[(int)Check.Name.PALACE_OF_DARKNESS_DARK_MAZE_BOTTOM]       = new Check(0x032, 0x20);
		Checks[(int)Check.Name.PALACE_OF_DARKNESS_BIG_CHEST]              = new Check(0x034, 0x10);
		Checks[(int)Check.Name.PALACE_OF_DARKNESS_HARMLESS_HELLWAY]       = new Check(0x034, 0x40);
		Checks[(int)Check.Name.PALACE_OF_DARKNESS_BOSS]                   = new Check(0x0B5, 0x08);
		Checks[(int)Check.Name.GANONS_TOWER_CONVEYOR_CROSS_POT_KEY]       = new Check(0x117, 0x04);
		Checks[(int)Check.Name.GANONS_TOWER_BOBS_TORCH]                   = new Check(0x119, 0x04);
		Checks[(int)Check.Name.GANONS_TOWER_HOPE_ROOM_LEFT]               = new Check(0x118, 0x20);
		Checks[(int)Check.Name.GANONS_TOWER_HOPE_ROOM_RIGHT]              = new Check(0x118, 0x40);
		Checks[(int)Check.Name.GANONS_TOWER_TILE_ROOM]                    = new Check(0x11A, 0x10);
		Checks[(int)Check.Name.GANONS_TOWER_COMPASS_ROOM_TOP_LEFT]        = new Check(0x13A, 0x10);
		Checks[(int)Check.Name.GANONS_TOWER_COMPASS_ROOM_TOP_RIGHT]       = new Check(0x13A, 0x20);
		Checks[(int)Check.Name.GANONS_TOWER_COMPASS_ROOM_BOTTOM_LEFT]     = new Check(0x13A, 0x40);
		Checks[(int)Check.Name.GANONS_TOWER_COMPASS_ROOM_BOTTOM_RIGHT]    = new Check(0x13A, 0x80);
		Checks[(int)Check.Name.GANONS_TOWER_CONVEYOR_STAR_PITS_POT_KEY]   = new Check(0x0F7, 0x04);
		Checks[(int)Check.Name.GANONS_TOWER_DMS_ROOM_TOP_LEFT]            = new Check(0x0F6, 0x10);
		Checks[(int)Check.Name.GANONS_TOWER_DMS_ROOM_TOP_RIGHT]           = new Check(0x0F6, 0x20);
		Checks[(int)Check.Name.GANONS_TOWER_DMS_ROOM_BOTTOM_LEFT]         = new Check(0x0F6, 0x40);
		Checks[(int)Check.Name.GANONS_TOWER_DMS_ROOM_BOTTOM_RIGHT]        = new Check(0x0F6, 0x80);
		Checks[(int)Check.Name.GANONS_TOWER_MAP_CHEST]                    = new Check(0x116, 0x10);
		Checks[(int)Check.Name.GANONS_TOWER_DOUBLE_SWITCH_POT_KEY]        = new Check(0x137, 0x04);
		Checks[(int)Check.Name.GANONS_TOWER_FIRESNAKE_ROOM]               = new Check(0x0FA, 0x10);
		Checks[(int)Check.Name.GANONS_TOWER_RANDOMIZER_ROOM_TOP_LEFT]     = new Check(0x0F8, 0x10);
		Checks[(int)Check.Name.GANONS_TOWER_RANDOMIZER_ROOM_TOP_RIGHT]    = new Check(0x0F8, 0x20);
		Checks[(int)Check.Name.GANONS_TOWER_RANDOMIZER_ROOM_BOTTOM_LEFT]  = new Check(0x0F8, 0x40);
		Checks[(int)Check.Name.GANONS_TOWER_RANDOMIZER_ROOM_BOTTOM_RIGHT] = new Check(0x0F8, 0x80);
		Checks[(int)Check.Name.GANONS_TOWER_BOBS_CHEST]                   = new Check(0x118, 0x80);
		Checks[(int)Check.Name.GANONS_TOWER_BIG_CHEST]                    = new Check(0x118, 0x10);
		Checks[(int)Check.Name.GANONS_TOWER_BIG_KEY_ROOM_LEFT]            = new Check(0x038, 0x20);
		Checks[(int)Check.Name.GANONS_TOWER_BIG_KEY_ROOM_RIGHT]           = new Check(0x038, 0x40);
		Checks[(int)Check.Name.GANONS_TOWER_BIG_KEY_CHEST]                = new Check(0x038, 0x10);
		Checks[(int)Check.Name.GANONS_TOWER_MINI_HELMASAUR_ROOM_LEFT]     = new Check(0x07A, 0x10);
		Checks[(int)Check.Name.GANONS_TOWER_MINI_HELMASAUR_ROOM_RIGHT]    = new Check(0x07A, 0x20);
		Checks[(int)Check.Name.GANONS_TOWER_MINI_HELMASAUR_KEY_DROP]      = new Check(0x07B, 0x04);
		Checks[(int)Check.Name.GANONS_TOWER_PREMOLDORM_CHEST]             = new Check(0x07A, 0x40);
		Checks[(int)Check.Name.GANONS_TOWER_VALIDATION_CHEST]             = new Check(0x09A, 0x10);
		Checks[(int)Check.Name.BOTTLE_MERCHANT]                           = new Check(0x3c9, 0x02);
		Checks[(int)Check.Name.PURPLE_CHEST]                              = new Check(0x3c9, 0x10);
		Checks[(int)Check.Name.LINKS_UNCLE]                               = new Check(0x3c6, 0x01);
		Checks[(int)Check.Name.HOBO]                                      = new Check(0x3c9, 0x01);
		Checks[(int)Check.Name.OLD_MAN]                                   = new Check(0x410, 0x1);
		Checks[(int)Check.Name.KING_ZORA]                                 = new Check(0x410, 0x2);
		Checks[(int)Check.Name.SICK_KID]                                  = new Check(0x410, 0x4);
		Checks[(int)Check.Name.STUMPY]                                    = new Check(0x410, 0x8);
		Checks[(int)Check.Name.SAHASRAHLA]                                = new Check(0x410, 0x10);
		Checks[(int)Check.Name.CATFISH]                                   = new Check(0x410, 0x20);
		Checks[(int)Check.Name.LIBRARY]                                   = new Check(0x410, 0x80);
		Checks[(int)Check.Name.ETHER_TABLET]                              = new Check(0x411, 0x1);
		Checks[(int)Check.Name.BOMBOS_TABLET]                             = new Check(0x411, 0x2);
		Checks[(int)Check.Name.BLACKSMITH]                                = new Check(0x411, 0x4);
		Checks[(int)Check.Name.MUSHROOM]                                  = new Check(0x411, 0x10);
		Checks[(int)Check.Name.POTION_SHOP]                               = new Check(0x411, 0x20);
		Checks[(int)Check.Name.MAGIC_BAT]                                 = new Check(0x411, 0x80);
		Checks[(int)Check.Name.FLUTE_SPOT]                                = new Check(0x2AA, 0x40);
		Checks[(int)Check.Name.SUNKEN_TREASURE]                           = new Check(0x2BB, 0x40);
		Checks[(int)Check.Name.ZORAS_LEDGE]                               = new Check(0x301, 0x40);
		Checks[(int)Check.Name.LAKE_HYLIA_ISLAND]                         = new Check(0x2B5, 0x40);
		Checks[(int)Check.Name.MAZE_RACE]                                 = new Check(0x2A8, 0x40);
		Checks[(int)Check.Name.DESERT_LEDGE]                              = new Check(0x2B0, 0x40);
		Checks[(int)Check.Name.MASTER_SWORD_PEDESTAL]                     = new Check(0x300, 0x40);
		Checks[(int)Check.Name.SPECTACLE_ROCK]                            = new Check(0x283, 0x40);
		Checks[(int)Check.Name.PYRAMID]                                   = new Check(0x2DB, 0x40);
		Checks[(int)Check.Name.DIGGING_GAME]                              = new Check(0x2E8, 0x40);
		Checks[(int)Check.Name.BUMPER_CAVE_LEDGE]                         = new Check(0x2CA, 0x40);
		Checks[(int)Check.Name.FLOATING_ISLAND]                           = new Check(0x285, 0x40);

		Checks_LW = new Check[] {
			SaveMonitor.Checks[(int)Check.Name.BLINDS_HIDEOUT_TOP],
			SaveMonitor.Checks[(int)Check.Name.BLINDS_HIDEOUT_LEFT],
			SaveMonitor.Checks[(int)Check.Name.BLINDS_HIDEOUT_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.BLINDS_HIDEOUT_FAR_LEFT],
			SaveMonitor.Checks[(int)Check.Name.BLINDS_HIDEOUT_FAR_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.WATERFALL_FAIRY_LEFT],
			SaveMonitor.Checks[(int)Check.Name.WATERFALL_FAIRY_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.KINGS_TOMB],
			SaveMonitor.Checks[(int)Check.Name.FLOODGATE_CHEST],
			SaveMonitor.Checks[(int)Check.Name.LINKS_HOUSE],
			SaveMonitor.Checks[(int)Check.Name.KAKARIKO_TAVERN],
			SaveMonitor.Checks[(int)Check.Name.CHICKEN_HOUSE],
			SaveMonitor.Checks[(int)Check.Name.AGINAHS_CAVE],
			SaveMonitor.Checks[(int)Check.Name.SAHASRAHLAS_HUT_LEFT],
			SaveMonitor.Checks[(int)Check.Name.SAHASRAHLAS_HUT_MIDDLE],
			SaveMonitor.Checks[(int)Check.Name.SAHASRAHLAS_HUT_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.KAKARIKO_WELL_TOP],
			SaveMonitor.Checks[(int)Check.Name.KAKARIKO_WELL_LEFT],
			SaveMonitor.Checks[(int)Check.Name.KAKARIKO_WELL_MIDDLE],
			SaveMonitor.Checks[(int)Check.Name.KAKARIKO_WELL_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.KAKARIKO_WELL_BOTTOM],
			SaveMonitor.Checks[(int)Check.Name.LOST_WOODS_HIDEOUT],
			SaveMonitor.Checks[(int)Check.Name.LUMBERJACK_TREE],
			SaveMonitor.Checks[(int)Check.Name.CAVE_45],
			SaveMonitor.Checks[(int)Check.Name.GRAVEYARD_CAVE],
			SaveMonitor.Checks[(int)Check.Name.CHECKERBOARD_CAVE],
			SaveMonitor.Checks[(int)Check.Name.MINI_MOLDORM_CAVE_FAR_LEFT],
			SaveMonitor.Checks[(int)Check.Name.MINI_MOLDORM_CAVE_LEFT],
			SaveMonitor.Checks[(int)Check.Name.MINI_MOLDORM_CAVE_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.MINI_MOLDORM_CAVE_FAR_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.MINI_MOLDORM_CAVE_GENEROUS_GUY],
			SaveMonitor.Checks[(int)Check.Name.ICE_ROD_CAVE],
			SaveMonitor.Checks[(int)Check.Name.BONK_ROCK_CAVE],
			SaveMonitor.Checks[(int)Check.Name.SECRET_PASSAGE],
			SaveMonitor.Checks[(int)Check.Name.SPECTACLE_ROCK_CAVE],
			SaveMonitor.Checks[(int)Check.Name.PARADOX_CAVE_LOWER_FAR_LEFT],
			SaveMonitor.Checks[(int)Check.Name.PARADOX_CAVE_LOWER_LEFT],
			SaveMonitor.Checks[(int)Check.Name.PARADOX_CAVE_LOWER_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.PARADOX_CAVE_LOWER_FAR_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.PARADOX_CAVE_LOWER_MIDDLE],
			SaveMonitor.Checks[(int)Check.Name.PARADOX_CAVE_UPPER_LEFT],
			SaveMonitor.Checks[(int)Check.Name.PARADOX_CAVE_UPPER_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.SPIRAL_CAVE],
			SaveMonitor.Checks[(int)Check.Name.MIMIC_CAVE],
			SaveMonitor.Checks[(int)Check.Name.BOTTLE_MERCHANT],
			SaveMonitor.Checks[(int)Check.Name.LINKS_UNCLE],
			SaveMonitor.Checks[(int)Check.Name.HOBO],
			SaveMonitor.Checks[(int)Check.Name.OLD_MAN],
			SaveMonitor.Checks[(int)Check.Name.KING_ZORA],
			SaveMonitor.Checks[(int)Check.Name.SICK_KID],
			SaveMonitor.Checks[(int)Check.Name.SAHASRAHLA],
			SaveMonitor.Checks[(int)Check.Name.LIBRARY],
			SaveMonitor.Checks[(int)Check.Name.ETHER_TABLET],
			SaveMonitor.Checks[(int)Check.Name.BOMBOS_TABLET],
			SaveMonitor.Checks[(int)Check.Name.MUSHROOM],
			SaveMonitor.Checks[(int)Check.Name.POTION_SHOP],
			SaveMonitor.Checks[(int)Check.Name.MAGIC_BAT],
			SaveMonitor.Checks[(int)Check.Name.FLUTE_SPOT],
			SaveMonitor.Checks[(int)Check.Name.SUNKEN_TREASURE],
			SaveMonitor.Checks[(int)Check.Name.ZORAS_LEDGE],
			SaveMonitor.Checks[(int)Check.Name.LAKE_HYLIA_ISLAND],
			SaveMonitor.Checks[(int)Check.Name.MAZE_RACE],
			SaveMonitor.Checks[(int)Check.Name.DESERT_LEDGE],
			SaveMonitor.Checks[(int)Check.Name.MASTER_SWORD_PEDESTAL],
			SaveMonitor.Checks[(int)Check.Name.SPECTACLE_ROCK],
			SaveMonitor.Checks[(int)Check.Name.BUMPER_CAVE_LEDGE],
			SaveMonitor.Checks[(int)Check.Name.FLOATING_ISLAND]
		};

		Checks_DW = new Check[] {
			SaveMonitor.Checks[(int)Check.Name.SUPERBUNNY_CAVE_TOP],
			SaveMonitor.Checks[(int)Check.Name.SUPERBUNNY_CAVE_BOTTOM],
			SaveMonitor.Checks[(int)Check.Name.HOOKSHOT_CAVE_TOP_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.HOOKSHOT_CAVE_TOP_LEFT],
			SaveMonitor.Checks[(int)Check.Name.HOOKSHOT_CAVE_BOTTOM_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.HOOKSHOT_CAVE_BOTTOM_LEFT],
			SaveMonitor.Checks[(int)Check.Name.SPIKE_CAVE],
			SaveMonitor.Checks[(int)Check.Name.CATFISH],
			SaveMonitor.Checks[(int)Check.Name.PYRAMID],
			SaveMonitor.Checks[(int)Check.Name.HYPE_CAVE_TOP],
			SaveMonitor.Checks[(int)Check.Name.HYPE_CAVE_MIDDLE_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.HYPE_CAVE_MIDDLE_LEFT],
			SaveMonitor.Checks[(int)Check.Name.HYPE_CAVE_BOTTOM],
			SaveMonitor.Checks[(int)Check.Name.HYPE_CAVE_GENEROUS_GUY],
			SaveMonitor.Checks[(int)Check.Name.PEG_CAVE],
			SaveMonitor.Checks[(int)Check.Name.PYRAMID_FAIRY_LEFT],
			SaveMonitor.Checks[(int)Check.Name.PYRAMID_FAIRY_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.BREWERY],
			SaveMonitor.Checks[(int)Check.Name.CSHAPED_HOUSE],
			SaveMonitor.Checks[(int)Check.Name.CHEST_GAME],
			SaveMonitor.Checks[(int)Check.Name.MIRE_SHED_LEFT],
			SaveMonitor.Checks[(int)Check.Name.MIRE_SHED_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.PURPLE_CHEST],
			SaveMonitor.Checks[(int)Check.Name.STUMPY],
			SaveMonitor.Checks[(int)Check.Name.DIGGING_GAME],
			SaveMonitor.Checks[(int)Check.Name.BLACKSMITH]
		};

		Checks_L1 = new Check[] {
			SaveMonitor.Checks[(int)Check.Name.EASTERN_PALACE_COMPASS_CHEST],
			SaveMonitor.Checks[(int)Check.Name.EASTERN_PALACE_BIG_CHEST],
			SaveMonitor.Checks[(int)Check.Name.EASTERN_PALACE_DARK_SQUARE_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.EASTERN_PALACE_DARK_EYEGORE_KEY_DROP],
			SaveMonitor.Checks[(int)Check.Name.EASTERN_PALACE_CANNONBALL_CHEST],
			SaveMonitor.Checks[(int)Check.Name.EASTERN_PALACE_BIG_KEY_CHEST],
			SaveMonitor.Checks[(int)Check.Name.EASTERN_PALACE_MAP_CHEST],
			SaveMonitor.Checks[(int)Check.Name.EASTERN_PALACE_BOSS]
		};

		Checks_L2 = new Check[] {
			SaveMonitor.Checks[(int)Check.Name.DESERT_PALACE_BIG_CHEST],
			SaveMonitor.Checks[(int)Check.Name.DESERT_PALACE_TORCH],
			SaveMonitor.Checks[(int)Check.Name.DESERT_PALACE_MAP_CHEST],
			SaveMonitor.Checks[(int)Check.Name.DESERT_PALACE_COMPASS_CHEST],
			SaveMonitor.Checks[(int)Check.Name.DESERT_PALACE_BIG_KEY_CHEST],
			SaveMonitor.Checks[(int)Check.Name.DESERT_PALACE_DESERT_TILES_1_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.DESERT_PALACE_BEAMOS_HALL_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.DESERT_PALACE_DESERT_TILES_2_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.DESERT_PALACE_BOSS]
		};

		Checks_L3 = new Check[] {
			SaveMonitor.Checks[(int)Check.Name.TOWER_OF_HERA_BASEMENT_CAGE],
			SaveMonitor.Checks[(int)Check.Name.TOWER_OF_HERA_MAP_CHEST],
			SaveMonitor.Checks[(int)Check.Name.TOWER_OF_HERA_BIG_KEY_CHEST],
			SaveMonitor.Checks[(int)Check.Name.TOWER_OF_HERA_COMPASS_CHEST],
			SaveMonitor.Checks[(int)Check.Name.TOWER_OF_HERA_BIG_CHEST],
			SaveMonitor.Checks[(int)Check.Name.TOWER_OF_HERA_BOSS]
		};

		Checks_AG = new Check[] {
			SaveMonitor.Checks[(int)Check.Name.CASTLE_TOWER_ROOM_03],
			SaveMonitor.Checks[(int)Check.Name.CASTLE_TOWER_DARK_MAZE],
			SaveMonitor.Checks[(int)Check.Name.CASTLE_TOWER_DARK_ARCHER_KEY_DROP],
			SaveMonitor.Checks[(int)Check.Name.CASTLE_TOWER_CIRCLE_OF_POTS_KEY_DROP]
		};

		Checks_D1 = new Check[] {
			SaveMonitor.Checks[(int)Check.Name.PALACE_OF_DARKNESS_SHOOTER_ROOM],
			SaveMonitor.Checks[(int)Check.Name.PALACE_OF_DARKNESS_THE_ARENA_BRIDGE],
			SaveMonitor.Checks[(int)Check.Name.PALACE_OF_DARKNESS_STALFOS_BASEMENT],
			SaveMonitor.Checks[(int)Check.Name.PALACE_OF_DARKNESS_BIG_KEY_CHEST],
			SaveMonitor.Checks[(int)Check.Name.PALACE_OF_DARKNESS_THE_ARENA_LEDGE],
			SaveMonitor.Checks[(int)Check.Name.PALACE_OF_DARKNESS_MAP_CHEST],
			SaveMonitor.Checks[(int)Check.Name.PALACE_OF_DARKNESS_COMPASS_CHEST],
			SaveMonitor.Checks[(int)Check.Name.PALACE_OF_DARKNESS_DARK_BASEMENT_LEFT],
			SaveMonitor.Checks[(int)Check.Name.PALACE_OF_DARKNESS_DARK_BASEMENT_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.PALACE_OF_DARKNESS_DARK_MAZE_TOP],
			SaveMonitor.Checks[(int)Check.Name.PALACE_OF_DARKNESS_DARK_MAZE_BOTTOM],
			SaveMonitor.Checks[(int)Check.Name.PALACE_OF_DARKNESS_BIG_CHEST],
			SaveMonitor.Checks[(int)Check.Name.PALACE_OF_DARKNESS_HARMLESS_HELLWAY],
			SaveMonitor.Checks[(int)Check.Name.PALACE_OF_DARKNESS_BOSS]
		};

		Checks_D2 = new Check[] {
			SaveMonitor.Checks[(int)Check.Name.SWAMP_PALACE_ENTRANCE],
			SaveMonitor.Checks[(int)Check.Name.SWAMP_PALACE_MAP_CHEST],
			SaveMonitor.Checks[(int)Check.Name.SWAMP_PALACE_POT_ROW_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.SWAMP_PALACE_TRENCH_1_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.SWAMP_PALACE_HOOKSHOT_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.SWAMP_PALACE_BIG_CHEST],
			SaveMonitor.Checks[(int)Check.Name.SWAMP_PALACE_COMPASS_CHEST],
			SaveMonitor.Checks[(int)Check.Name.SWAMP_PALACE_TRENCH_2_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.SWAMP_PALACE_BIG_KEY_CHEST],
			SaveMonitor.Checks[(int)Check.Name.SWAMP_PALACE_WEST_CHEST],
			SaveMonitor.Checks[(int)Check.Name.SWAMP_PALACE_FLOODED_ROOM_LEFT],
			SaveMonitor.Checks[(int)Check.Name.SWAMP_PALACE_FLOODED_ROOM_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.SWAMP_PALACE_WATERFALL_ROOM],
			SaveMonitor.Checks[(int)Check.Name.SWAMP_PALACE_WATERWAY_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.SWAMP_PALACE_BOSS]
		};

		Checks_D3 = new Check[] {
			SaveMonitor.Checks[(int)Check.Name.SKULL_WOODS_COMPASS_CHEST],
			SaveMonitor.Checks[(int)Check.Name.SKULL_WOODS_MAP_CHEST],
			SaveMonitor.Checks[(int)Check.Name.SKULL_WOODS_BIG_CHEST],
			SaveMonitor.Checks[(int)Check.Name.SKULL_WOODS_POT_PRISON],
			SaveMonitor.Checks[(int)Check.Name.SKULL_WOODS_PINBALL_ROOM],
			SaveMonitor.Checks[(int)Check.Name.SKULL_WOODS_BIG_KEY_CHEST],
			SaveMonitor.Checks[(int)Check.Name.SKULL_WOODS_WEST_LOBBY_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.SKULL_WOODS_BRIDGE_ROOM],
			SaveMonitor.Checks[(int)Check.Name.SKULL_WOODS_SPIKE_CORNER_KEY_DROP],
			SaveMonitor.Checks[(int)Check.Name.SKULL_WOODS_BOSS]
		};

		Checks_D4 = new Check[] {
			SaveMonitor.Checks[(int)Check.Name.THIEVES_TOWN_BIG_KEY_CHEST],
			SaveMonitor.Checks[(int)Check.Name.THIEVES_TOWN_MAP_CHEST],
			SaveMonitor.Checks[(int)Check.Name.THIEVES_TOWN_COMPASS_CHEST],
			SaveMonitor.Checks[(int)Check.Name.THIEVES_TOWN_AMBUSH_CHEST],
			SaveMonitor.Checks[(int)Check.Name.THIEVES_TOWN_HALLWAY_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.THIEVES_TOWN_SPIKE_SWITCH_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.THIEVES_TOWN_ATTIC],
			SaveMonitor.Checks[(int)Check.Name.THIEVES_TOWN_BIG_CHEST],
			SaveMonitor.Checks[(int)Check.Name.THIEVES_TOWN_BLINDS_CELL],
			SaveMonitor.Checks[(int)Check.Name.THIEVES_TOWN_BOSS]
		};

		Checks_D5 = new Check[] {
			SaveMonitor.Checks[(int)Check.Name.ICE_PALACE_JELLY_KEY_DROP],
			SaveMonitor.Checks[(int)Check.Name.ICE_PALACE_COMPASS_CHEST],
			SaveMonitor.Checks[(int)Check.Name.ICE_PALACE_CONVEYOR_KEY_DROP],
			SaveMonitor.Checks[(int)Check.Name.ICE_PALACE_FREEZOR_CHEST],
			SaveMonitor.Checks[(int)Check.Name.ICE_PALACE_BIG_CHEST],
			SaveMonitor.Checks[(int)Check.Name.ICE_PALACE_ICED_T_ROOM],
			SaveMonitor.Checks[(int)Check.Name.ICE_PALACE_MANY_POTS_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.ICE_PALACE_SPIKE_ROOM],
			SaveMonitor.Checks[(int)Check.Name.ICE_PALACE_BIG_KEY_CHEST],
			SaveMonitor.Checks[(int)Check.Name.ICE_PALACE_HAMMER_BLOCK_KEY_DROP],
			SaveMonitor.Checks[(int)Check.Name.ICE_PALACE_MAP_CHEST],
			SaveMonitor.Checks[(int)Check.Name.ICE_PALACE_BOSS]
		};

		Checks_D6 = new Check[] {
			SaveMonitor.Checks[(int)Check.Name.MISERY_MIRE_BIG_CHEST],
			SaveMonitor.Checks[(int)Check.Name.MISERY_MIRE_MAP_CHEST],
			SaveMonitor.Checks[(int)Check.Name.MISERY_MIRE_MAIN_LOBBY],
			SaveMonitor.Checks[(int)Check.Name.MISERY_MIRE_BRIDGE_CHEST],
			SaveMonitor.Checks[(int)Check.Name.MISERY_MIRE_SPIKES_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.MISERY_MIRE_SPIKE_CHEST],
			SaveMonitor.Checks[(int)Check.Name.MISERY_MIRE_FISHBONE_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.MISERY_MIRE_CONVEYOR_CRYSTAL_KEY_DROP],
			SaveMonitor.Checks[(int)Check.Name.MISERY_MIRE_COMPASS_CHEST],
			SaveMonitor.Checks[(int)Check.Name.MISERY_MIRE_BIG_KEY_CHEST],
			SaveMonitor.Checks[(int)Check.Name.MISERY_MIRE_BOSS]
		};

		Checks_D7 = new Check[] {
			SaveMonitor.Checks[(int)Check.Name.TURTLE_ROCK_COMPASS_CHEST],
			SaveMonitor.Checks[(int)Check.Name.TURTLE_ROCK_ROLLER_ROOM_LEFT],
			SaveMonitor.Checks[(int)Check.Name.TURTLE_ROCK_ROLLER_ROOM_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.TURTLE_ROCK_POKEY_1_KEY_DROP],
			SaveMonitor.Checks[(int)Check.Name.TURTLE_ROCK_CHAIN_CHOMPS],
			SaveMonitor.Checks[(int)Check.Name.TURTLE_ROCK_POKEY_2_KEY_DROP],
			SaveMonitor.Checks[(int)Check.Name.TURTLE_ROCK_BIG_KEY_CHEST],
			SaveMonitor.Checks[(int)Check.Name.TURTLE_ROCK_BIG_CHEST],
			SaveMonitor.Checks[(int)Check.Name.TURTLE_ROCK_CRYSTAROLLER_ROOM],
			SaveMonitor.Checks[(int)Check.Name.TURTLE_ROCK_EYE_BRIDGE_BOTTOM_LEFT],
			SaveMonitor.Checks[(int)Check.Name.TURTLE_ROCK_EYE_BRIDGE_BOTTOM_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.TURTLE_ROCK_EYE_BRIDGE_TOP_LEFT],
			SaveMonitor.Checks[(int)Check.Name.TURTLE_ROCK_EYE_BRIDGE_TOP_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.TURTLE_ROCK_BOSS]
		};

		Checks_GT = new Check[] {
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_CONVEYOR_CROSS_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_BOBS_TORCH],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_HOPE_ROOM_LEFT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_HOPE_ROOM_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_TILE_ROOM],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_COMPASS_ROOM_TOP_LEFT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_COMPASS_ROOM_TOP_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_COMPASS_ROOM_BOTTOM_LEFT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_COMPASS_ROOM_BOTTOM_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_CONVEYOR_STAR_PITS_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_DMS_ROOM_TOP_LEFT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_DMS_ROOM_TOP_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_DMS_ROOM_BOTTOM_LEFT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_DMS_ROOM_BOTTOM_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_MAP_CHEST],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_DOUBLE_SWITCH_POT_KEY],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_FIRESNAKE_ROOM],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_RANDOMIZER_ROOM_TOP_LEFT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_RANDOMIZER_ROOM_TOP_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_RANDOMIZER_ROOM_BOTTOM_LEFT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_RANDOMIZER_ROOM_BOTTOM_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_BOBS_CHEST],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_BIG_CHEST],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_BIG_KEY_ROOM_LEFT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_BIG_KEY_ROOM_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_BIG_KEY_CHEST],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_MINI_HELMASAUR_ROOM_LEFT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_MINI_HELMASAUR_ROOM_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_MINI_HELMASAUR_KEY_DROP],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_PREMOLDORM_CHEST],
			SaveMonitor.Checks[(int)Check.Name.GANONS_TOWER_VALIDATION_CHEST]
		};

		Thread SaveMonitorThread = new Thread(() => MonitorSaveData());
		SaveMonitorThread.Start();
	}

	private static void MonitorSaveData()
	{
		UdpClient  udpClient  = new UdpClient(35911);
		IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Loopback, 35911);

		while (true)
		{
			Byte[] saveData = udpClient.Receive(ref ipEndPoint);

			foreach (Check check in Checks) {
				if ((saveData[check.address] & check.mask) != 0) {
					check.isCollected = true;
				} else {
					check.isCollected = false;
				}
			}
		}
	}
}
