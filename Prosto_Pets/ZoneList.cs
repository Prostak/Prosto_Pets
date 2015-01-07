using System.Collections;

namespace Prosto_Pets
{

    class ZoneList
    {
        ////////////////////////////
        //// ZONES AND PET LEVELS //
        ////////////////////////////
        private Hashtable ZT;
        private string Continent;

        void add(string Zone, int a, int b)
        {
            ZT[Zone] = (a + b) / 2;
        }

        public ZoneList()
        {
            //  	    ("ZONE", MIN, MAX );
            // KALIMDOR
            ZT = new Hashtable();
            Continent = "KALI";
            add("Orgrimmar", 1, 1);
            add("Azuremyst Isle", 1, 2);
            add("Durotar", 1, 2);
            add("Mulgore", 1, 2);
            add("Teldrassil", 1, 2);
            add("Darnassus", 1, 3);
            add("Exodar", 1, 3);
            add("Thunder Bluff", 1, 3);
            add("Northern Barrens", 3, 4);
            add("Azshara", 3, 6);
            add("Bloodmyst Isle", 3, 6);
            add("Darkshore", 3, 6);
            add("Ashenvale", 4, 6);
            add("Stonetalon Mountains", 5, 7);
            add("Desolace", 7, 9);
            add("Southern Barrens", 9, 10);
            add("Feralas", 11, 12);
            add("Dustwallow Marsh", 12, 13);
            add("Tanaris", 13, 14);
            add("Thousand Needles", 13, 14);
            add("Felwood", 14, 15);
            add("Moonglade", 15, 16);
            add("Un'Goro Crater", 15, 16);
            add("Ahn'Qiraj: The Fallen Kingdom", 16, 17);
            add("Silithus", 16, 17);
            add("Winterspring", 17, 18);

            // EASTERN KINGDOMS
            Continent = "EK";
            add("Stormwind City", 1, 1);
            add("Dun Morogh", 1, 2);
            add("Elwynn Forest", 1, 2);
            add("Eversong Woods", 1, 2);
            add("Tirisfal Glades", 1, 2);
            add("Undercity", 1, 2);
            add("Ironforge", 1, 3);
            add("Silvermoon City", 1, 3);
            add("Westfall", 3, 4);
            add("Ghostlands", 3, 6);
            add("Loch Modan", 3, 6);
            add("Silverpine Forest", 3, 6);
            add("Redridge Mountains", 4, 6);
            add("Duskwood", 5, 7);
            add("Hillsbrad Foothills", 6, 7);
            add("Wetlands", 6, 7);
            add("Arathi Highlands", 7, 8);
            add("Northern Stranglethorn", 7, 9);
            add("The Cape of Stranglethorn", 9, 10);
            add("Western Plaguelands", 10, 11);
            add("The Hinterlands", 11, 12);
            add("Eastern Plaguelands", 12, 13);
            add("Badlands", 13, 14);
            add("Searing Gorge", 13, 14);
            add("Swamp of Sorrows", 14, 15);
            add("Burning Steppes", 15, 16);
            add("Blasted Lands", 16, 17);
            add("Deadwind Pass", 17, 18);

            // OUTLAND
            Continent = "OUT";
            add("Hellfire Peninsula", 17, 18);
            add("Nagrand", 18, 19);
            add("Terokkar Forest", 18, 19);
            add("Zangarmarsh", 18, 19);
            add("Blade's Edge Mountains", 18, 20);
            add("Netherstorm", 20, 21);
            add("Shadowmoon", 20, 21);

            // NORTHREND
            Continent = "NOR";
            add("Borean Tundra", 20, 22);
            add("Howling Fjord", 20, 22);
            add("Grizzly Hills", 21, 22);
            add("Sholazar Basin", 21, 22);
            add("Crystalsong Forest", 22, 23);
            add("Zul'Drak", 22, 23);
            add("Dragonblight", 22, 23);
            add("Icecrown", 22, 23);
            add("The Storm Peaks", 22, 23);

            // CATACLYSM Zones
            Continent = "CAT";
            add("Deepholm", 22, 23);
            add("Mount Hyjal", 22, 24);
            add("Uldum", 23, 24);
            add("Twilight Highlands", 23, 24);

            // PANDARIA
            Continent = "PAN";
            add("Krasarang Wilds", 23, 25);
            add("Kun-Lai Summit", 23, 25);
            add("The Jade Forest", 23, 25);
            add("The Veiled Stair", 23, 25);
            add("Valley of the Four Winds", 23, 25);
            add("Dread Wastes", 24, 25);
            add("Townlong Steppes", 24, 25);
            add("Vale of Eternal Blossoms", 24, 25);

            // DRAENOR
            Continent = "DRA";
            add("Garrison", 23, 25);
            add("Shadowmoon Valley-DR", 23, 25);  // duplicate
            add("Gorgond", 23, 25);
            add("Talador", 23, 25);
            add("Frostfire Ridge", 24, 25);
            add("Spires Of Arak", 24, 25);
            add("Nagrand-DR", 24, 25);  // duplicate
            add("Ashran", 24, 25);
            add("Tanaan Jungle", 24, 25);
        }

        public int ZoneLevel( string ZoneName )
        {
            if( ZT.ContainsKey( ZoneName ) )
                return (int)ZT[ZoneName];
            Logger.Alert("Zone Table has no " + ZoneName + " entry. Assuming 25");
            return 25;
        }

    }
}