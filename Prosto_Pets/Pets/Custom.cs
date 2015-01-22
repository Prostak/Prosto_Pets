//////////////////////-
//// CUSTOM //
//////////////////////-

using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Custom : PetTacticsBase
    {
        public static List<AandC> GetSpellTable()
        {
            return GetSpellTable(MyPets.ActivePet.Name);
        }

        public static List<AandC> GetSpellTable(string petName)
        {
            if (string.IsNullOrEmpty(petName))
            {
                petName = MyPets.ActivePet.Name;
            }

            List<AandC> custom_abilities = null;

            /* 
            // EXAMPLE:
             
            if (petName == "Emperor Crab" || petName == "Shore Crab" || petName == "Shore Crawler" || petName == "Spirebound Crab" || petName == "Strand Crab" || petName == "Strand Crawler") {
                custom_abilities = new List<AandC>()
		        {
			        new AandC( "Whirlpool", 		() => hpEnemy > 0.5 ),	        // Slot 3   // TODO: check if there are other enemy pets that will take a hit
			        new AandC( "Surge",             () => hpEnemy < hp	),  	    // Slot 1  -- makes it more aggressive
			        new AandC( "Renewing Mists",    () => buffLeft("Renewing Mists") < 2	),  	// Slot 2
			        new AandC( "Healing Wave", 	    () => hp < 0.7 ),	                        // Slot 2
			        new AandC( "Shell Shield", 	    () => buffLeft("Shell Shield") < 2 ),	    // Slot 3
			        new AandC( "Snap" 			),	// Slot 1
			        new AandC( "Surge" 			),	// Slot 1
		        };
            }            
            
            
            */

            return custom_abilities;
        }
    }
}