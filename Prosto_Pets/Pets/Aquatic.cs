//////////////////////-
//// AQUATIC / WATER //
//////////////////////-

using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Aquatic : PetTacticsBase
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

            List<AandC> aquatic_abilities;

            //////////////////
            //// DRAENOR //
            //////////////////

            if (petName == "Moonshell Crab" )
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Arcane Slash",      ()=> hpEnemy < 0.2 ),	        // Slot 1
			new AandC( "Moon Tears"                                     ),	// Slot 3
			new AandC( "Renewing Mists",    ()=> hp < 0.7 && ! buff("Renewing Mists")	),	// Slot 3
			new AandC( "Amplify Magic",	    ()=> hp > 0.4	          ),	// Slot 2
			new AandC( "Shell Shield",      ()=> hp < hpEnemy && ! buff("Shell Shield" )),	        // Slot 2
			new AandC( "Arcane Slash" 			                      ),	// Slot 1
			new AandC( "Water Jet" 		                          ),	    // Slot 1
		};
            else if (petName == "Zangar Crawler")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Devour", 			() => hpEnemy < 0.20 ),	// Slot 3,  if we kill the enemy with Devour, we restore health
			new AandC( "Blood in the Water",()=> debuff("Bleeding") ),	// Slot 3
			new AandC( "Rip",               ()=> ! debuff("Bleeding")	),	// Slot 1
			new AandC( "Spiny Carapace" 			          ),	// Slot 2
			new AandC( "Shell Shield",      ()=> hp < hpEnemy && ! buff("Shell Shield" )),	// Slot 2
			new AandC( "Rip" 			                      ),	// Slot 1
			new AandC( "Claw" 		                          ),	// Slot 1
		};


            
//////////////////
//// CROCOLISKS //
//////////////////
            else if (petName == "Chuck" || petName == "Muckbreath" || petName == "Snarly" || petName == "Toothy")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Devour", 			() => hpEnemy < 0.20 ),	// Slot 3,  if we kill the enemy with Devour, we restore health
			new AandC( "Rip" 			),	// Slot 1
			new AandC( "Consume" 		),	// Slot 1
			new AandC( "Surge" 			),	// Slot 2
			new AandC( "Water Jet" 		),	// Slot 2
			new AandC( "Blood in the Water" )	// Slot 3
		};

            ////////////////-
            // CRUSTACEANS //
            ////////////////-
            else if (petName == "Emperor Crab" || petName == "Shore Crab" || petName == "Shore Crawler" || petName == "Spirebound Crab" || petName == "Strand Crab" || petName == "Strand Crawler")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Surge",             () => hpEnemy < hp	),  	    // Slot 1  -- makes it more aggressive
			new AandC( "Renewing Mists",    () => buffLeft("Renewing Mists") < 2	),  	// Slot 2
			new AandC( "Healing Wave", 	    () => hp < 0.7 ),	                        // Slot 2
			new AandC( "Shell Shield", 	    () => buffLeft("Shell Shield") < 2 ),	    // Slot 3
			new AandC( "Snap" 			),	// Slot 1
			new AandC( "Surge" 			),	// Slot 1
			new AandC( "Whirlpool" 		)	// Slot 3
		};
            else if (petName == "Magical Crawdad")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Shell Shield",  () => ! buff("Shell Shield") ),	// Slot 2
			new AandC( "Snap" 			),	// Slot 1
			new AandC( "Surge" 			),	// Slot 1
			new AandC( "Renewing Mists" 	),	// Slot 2
			new AandC( "Whirlpool" 		),	// Slot 3
			new AandC( "Wish" 			)	// Slot 3
		};  
            //////////
            // FISH //
            //////////
            else if (petName == "Fishy" || petName == "Tiny Goldfish")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Healing Wave", 	() => hp < 0.7 ),	// Slot 2
			new AandC( "Water Jet" 		),	// Slot 1
			new AandC( "Surge"			),	// Slot 1
			new AandC( "Cleansing Rain" 	),	// Slot 2
			new AandC( "Whirlpool" 		),	// Slot 3
			new AandC( "Pump" 			)	// Slot 3
		};
            else if (petName == "Purple Puffer")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Healing Wave", 	() => hp < 0.7 ),	// Slot 2
			new AandC( "Water Jet" 		),	// Slot 1
			new AandC( "Surge" 			),	// Slot 1
			new AandC( "Spiked Skin" 	),	// Slot 2
			new AandC( "Whirlpool" 		),	// Slot 3
			new AandC( "Pump" 			)	// Slot 3
		};
            else if (petName == "Tiny Blue Carp")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Surge" 			),	// Slot 1
			new AandC( "Psychic Blast" 	),	// Slot 1
			new AandC( "Healing Stream" 	),	// Slot 2
			new AandC( "Wild Magic" 		),	// Slot 2
			new AandC( "Pump" 			),	// Slot 3
			new AandC( "Mana Surge" 		)	// Slot 3
		};
            else if (petName == "Tiny Green Carp")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Water Jet" 		),	// Slot 1
			new AandC( "Surge" 			),	// Slot 1
			new AandC( "Cleansing Rain" 	),	// Slot 2
			new AandC( "Healing Stream" 	),	// Slot 2
			new AandC( "Whirlpool" 		),	// Slot 3
			new AandC( "Invisibility" 	)	// Slot 3
		};
            else if (petName == "Tiny Red Carp")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Water Jet" 		),	// Slot 1
			new AandC( "Poison Spit" 	),	// Slot 1
			new AandC( "Cleansing Rain" 	),	// Slot 2
			new AandC( "Healing Stream" 	),	// Slot 2
			new AandC( "Whirlpool" 		),	// Slot 3
			new AandC( "Spiked Skin" 	),	// Slot 3
		};
            else if (petName == "Tiny White Carp")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Healing Wave", 	() => hp < 0.7 ),	// Slot 2
			new AandC( "Dive" 			),	// Slot 3
			new AandC( "Water Jet" 		),	// Slot 1
			new AandC( "Surge" 			),	// Slot 1
			new AandC( "Cleansing Rain" 	),	// Slot 2
			new AandC( "Healing Stream" 	),	// Slot 3
		};
            ////////////////////-
            // FROGS AND TOADS //
            ////////////////////-
            else if (petName == "Biletoad" || petName == "Frog" || petName == "Garden Frog" || petName == "Huge Toad" || petName == "Jubling" || petName == "Jungle Darter" || petName == "Leopard Tree Frog" || petName == "Mac Frog" || petName == "Mojo" || petName == "Small Frog" || petName == "Spotted Bell Frog" || petName == "Tree Toad" || petName == "Wood Frog" || petName == "Yellow-Bellied Bullfrog" || petName == "Toad" || petName == "Tree Frog")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Healing Wave", 	() => hp < 0.7 ),	// 
			new AandC( "Water Jet" 		),	// 
			new AandC( "Tongue Lash" 	),	// 
			new AandC( "Cleansing Rain" 	),	// 
			new AandC( "Frog Kiss" 		),	// 
			new AandC( "Swarm of Flies" 	)	// 
		};
            else if (petName == "Swamp Croaker")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Bubble", 			() => hp < 0.7 ),	// 
			new AandC( "Water Jet" 		),	// 
			new AandC( "Tongue Lash" 	),	// 
			new AandC( "Frog Kiss" 		),	// 
			new AandC( "Swarm of Flies" 	),	// 
			new AandC( "Croak" 			)	// 
		};
            ////////////-
            // INSECTS //
            ////////////-
            else if (petName == "Aqua Strider" || petName == "Dancing Water Skimmer" || petName == "Eternal Strider" || petName == "Mirror Strider")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Healing Wave", 	 () => hp < 0.7 ),	// Slot 2
			new AandC( "Cleansing Rain", () =>	hp < 0.9 ),	// Slot 2
			new AandC( "Water Jet" 		                          ),    // Slot 1
			new AandC( "Poison Spit",	 () =>	buff("Pumped Up")),	// Slot 1
			new AandC( "Soothe" 	                                    ),  // Slot 3
			new AandC( "Pump",      	 () => ! buff("Pumped Up") ),  // Slot 3
		};
            ////////////-
            // MAMMALS //
            ////////////-
            else if (petName == "Golden Civet" || petName == "Golden Civet Kitten" || petName == "Kuitan Mongoose" || petName == "Mongoose" || petName == "Mongoose Pup" || petName == "Sifang Otter" || petName == "Sifang Otter Pup")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Survival", 		() => hp < 0.3 ),	// Slot 2
			new AandC( "Dive" 			),	// Slot 3
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Gnaw" 			),	// Slot 1
			new AandC( "Screech" 		),	// Slot 2
			new AandC( "Surge" 			),	// Slot 3
		};
            //////////////
            // PENGUINS //
            //////////////
            else if (petName == "Mr. Chilly" || petName == "Pengu" || petName == "Tundra Penguin")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Surge" 			),	// Slot 1
			new AandC( "Frost Spit" 		),	// Slot 2
			new AandC( "Slippery Ice" 	),	// Slot 2
			new AandC( "Ice Lance" 		),	// Slot 3
			new AandC( "Belly Slide" 	)	// Slot 3
		};
            ////////////-
            // TURTLES //
            ////////////-
            else if (petName == "Darkmoon Turtle" || petName == "Softshell Snapling" || petName == "Speedy" || petName == "Spiny Terrapin" || petName == "Turquoise Turtle")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Healing Wave", 	() => hp < 0.7 ),	// Slot 2
			new AandC( "Headbutt" 		),	// Slot 3
			new AandC( "Shell Shield",  () => ! buff("Shell Shield") ),	// Slot 2
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Grasp" 			),	// Slot 1
			new AandC( "Powerball" 		)	// Slot 3
		};
            else if (petName == "Emerald Turtle")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Healing Wave", 	() => hp < 0.7 ),	// Slot 2
			new AandC( "Shell Shield",  () => ! buff("Shell Shield") ),	// Slot 2
			new AandC( "Headbutt" 		),	// Slot 3
			new AandC( "Emerald Bite" 	),	// Slot 1
			new AandC( "Grasp" 			),	// Slot 1
			new AandC( "Powerball" 		),	// Slot 3
		};
            else if (petName == "Wanderer's Festival Hatchling")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Shell Shield",  () => ! buff("Shell Shield") ),	// Slot 2
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Grasp" 			),	// Slot 1
			new AandC( "Perk Up" 		),	// Slot 2
			new AandC( "Pump" 			),	// Slot 3
			new AandC( "Cleansing Rain" 	)	// Slot 3
		};
            //////////////////-
            // MISCELLANEOUS //
            //////////////////-
            else if (petName == "Horny Toad")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Healing Wave", 	() => hp < 0.7 ),	// Slot 2
			new AandC( "Water Jet" 		),	// Slot 1
			new AandC( "Tongue Lash" 	),	// Slot 1
			new AandC( "Cleansing Rain" 	),	// Slot 2
			new AandC( "Frog Kiss" 		),	// Slot 3
			new AandC( "Swarm of Flies" 	)	// Slot 3
		};
            else if (petName == "Sea Pony")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Water Jet" 		),	// Slot 1
			new AandC( "Tidal Wave" 		),	// Slot 1
			new AandC( "Surge" 			),	// Slot 2
			new AandC( "Cleansing Rain" 	),	// Slot 2
			new AandC( "Whirlpool" 		),	// Slot 3
			new AandC( "Pump" 			)	// Slot 3
		};
            else if (petName == "Spawn of G'nathus")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Dive" 			),	// Slot 2
			new AandC( "Swallow You Whole"),	// Slot 1
			new AandC( "Jolt" 			),	// Slot 1
			new AandC( "Lightning Shield"),	// Slot 2
			new AandC( "Thunderbolt" 	),	// Slot 3
			new AandC( "Paralyzing Shock")	// Slot 3
		};
            else if (petName == "Gahz'rooki")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Devour", 		() => 	hpEnemy < 0.20 ),	// Slot 2,  if we kill the enemy with Devour, we restore health
			new AandC( "Bite"               ),	// Slot 1
			new AandC( "Tail Slap"   		),	// Slot 1
			new AandC( "Swallow You Whole"  ),	// Slot 2
			new AandC( "Whirlpool"   		),	// Slot 3
			new AandC( "Geyser"   )         	// Slot 3
		};
            else if (petName == "Tideskipper")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Crush"          ),	// Slot 1
			new AandC( "Grasp" 			),	// Slot 1
			new AandC( "Tidal Wave" 	),	// Slot 2
			new AandC( "Body Slam"		),	// Slot 2
			new AandC( "Clobber" 		),	// Slot 3
			new AandC( "Geyser"         ),	// Slot 3
		};
            else if (petName == "Hydraling")
                aquatic_abilities = new List<AandC>()
		{
			new AandC( "Swallow You Whole", ()=> hpEnemy<0.25 ),	// Slot 2
			new AandC( "Call Lightning", ()=> !weather("Lightning Storm")		),	// Slot 2  TODO: not always beneficial, only if mech's on our side
			new AandC( "Shell Armor" 	),	// Slot 3
			new AandC( "Whirlpool"         ),	// Slot 3
			new AandC( "Deep Byte"          ),	// Slot 1
			new AandC( "Tail Slap"		),	// Slot 1
		};

            //////////////////-
            else // Unknown aquatic
            {
                Logger.Alert("Unknown aquatic pet: " + petName);
                return null;
            }
            return aquatic_abilities;
        }
    }
}