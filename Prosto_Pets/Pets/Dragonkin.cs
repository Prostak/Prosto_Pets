////////////////
// DRAGONKIN //
////////////////

using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Dragonkin : PetTacticsBase
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

            List<AandC> dragonkin_abilities;


//////////////////-
// DRAGON WHELPS //
//////////////////-
            if (petName == "Azure Whelpling")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Claw" 			),	// Slot 1
			new AandC( "Breath" 			),	// Slot 1
			new AandC( "Arcane Storm" 	),	// Slot 2
			new AandC( "Wild Magic" 		),	// Slot 2
			new AandC( "Surge of Power" 	),	// Slot 3
			new AandC( "Ice Tomb" 		),	// Slot 3
		}
            ;
            else if (petName == "Crimson Whelpling" || petName == "Onyxian Whelpling" || petName == "Spawn of Onyxia")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Healing Flame",  () =>hp < 0.75 ),	// Slot 2
			new AandC( "Lift-Off" 		),	// Slot 3
			new AandC( "Breath" 			),	// Slot 1
			new AandC( "Tail Sweep" 		),	// Slot 1
			new AandC( "Scorched Earth" 	),	// Slot 2
			new AandC( "Deep Breath" 	),	// Slot 3
		}
            ;
            else if (petName == "Dark Whelpling")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Roar", () => 			! buff("Attack Boost") ),	// Slot 2
			new AandC( "Lift-Off" 		),	// Slot 3
			new AandC( "Shadowflame" 	),	// Slot 1
			new AandC( "Tail Sweep" 		),	// Slot 1
			new AandC( "Call Darkness" 	),	// Slot 2
			new AandC( "Deep Breath" 	),	// Slot 3
		}
            ;
            else if (petName == "Bronze Whelpling")     // Valpsjuk
                dragonkin_abilities = new List<AandC>()
		{
		new AandC( "Arcane Slash",      () => hpEnemy < 0.2 				),	// Slot 1
		new AandC( "Arcane Storm",      () => buffLeft("Arcane Storm") < 2	),	// Slot 3
		new AandC( "Early Advantage",   () => hpEnemy < hp					),	// Slot 2
		new AandC( "Tail Sweep"	    										),	// Slot 1
		new AandC( "Arcane Slash" 			                      			),	// Slot 1
		new AandC( "Crystal Prison" 		                        		),	// Slot 2
		};
            else if (petName == "Emerald Proto-Whelp")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Ancient Blessing",  () => buff("Ancient Blessing") || hp < 0.75 ),	// Slot 2
			new AandC( "Breath" 			),	// Slot 1
			new AandC( "Emerald Bite" 	),	// Slot 1
			new AandC( "Emerald Presence"),	// Slot 2
			new AandC( "Proto-Strike" 	),	// Slot 3
			new AandC( "Emerald Dream" 	),	// Slot 3
		}
            ;
            else if (petName == "Emerald Whelpling")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Moonfire", () => 		! weather("Moonlight") ),	// Slot 2
			new AandC( "Breath" 			),	// Slot 1
			new AandC( "Emerald Bite" 	),	// Slot 1
			new AandC( "Emerald Presence"),	// Slot 2
			new AandC( "Tranquility" 	),	// Slot 3
			new AandC( "Emerald Dream" 	),	// Slot 3
		}
            ;
            else if (petName == "Infinite Whelpling")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Healing Flame",  () =>hp < 0.75 ),	// Slot 2
			new AandC( "Tail Sweep" 		),	// Slot 1
			new AandC( "Sleeping Gas" 	),	// Slot 1
			new AandC( "Weakness" 		),	// Slot 2
			new AandC( "Early Advantage" ),	// Slot 3
			new AandC( "Darkflame" 		),	// Slot 3
		}
            ;
            else if (petName == "Lil' Deathwing")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Shadowflame" 	),	// Slot 1
			new AandC( "Tail Sweep" 		),	// Slot 1
			new AandC( "Call Darkness" 	),	// Slot 2
			new AandC( "Roll" 			),	// Slot 2
			new AandC( "Elementium Bolt" ),	// Slot 3
			new AandC( "Cataclysm" 		),	// Slot 3
		}
            ;
            else if (petName == "Lil' Tarecgosa")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Breath" 			),	// Slot 1
			new AandC( "Arcane Blast" 	),	// Slot 1
			new AandC( "Surge of Power" 	),	// Slot 2
			new AandC( "Wild Magic" 		),	// Slot 2
			new AandC( "Arcane Storm" 	),	// Slot 3
			new AandC( "Arcane Explosion"),	// Slot 3
		}
            ;
            else if (petName == "Nether Faerie Dragon")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Moonfire", () => 		! weather("Moonlight") ),	// Slot 3
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 3
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Arcane Blast" 	),	// Slot 1
			new AandC( "Evanescence" 	),	// Slot 2
			new AandC( "Life Exchange" 	),	// Slot 2
		}
            ;
            else if (petName == "Netherwhelp")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Breath" 			),	// Slot 1
			new AandC( "Nether Blast" 	),	// Slot 1
			new AandC( "Phase Shift" 	),	// Slot 2
			new AandC( "Accuracy" 		),	// Slot 2
			new AandC( "Instability" 	),	// Slot 3
			new AandC( "Soulrush" 		),	// Slot 3
		}
            ;
            else if (petName == "Nexus Whelpling")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Arcane Storm", ()=> !weather("Arcane Storm") 	),	// Slot 3
			new AandC( "Mana Surge" 		),	// Slot 2
			new AandC( "Tail Sweep" 		),	// Slot 1
			new AandC( "Frost Breath" 	),	// Slot 1
			new AandC( "Sear Magic" 		),	// Slot 2
			new AandC( "Wild Magic" 		),	// Slot 3
		}
            ;
            else if (petName == "Proto-Drake Whelp")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Ancient Blessing",  () => buff("Ancient Blessing") || hp < 0.75 ),	// Slot 2
			new AandC( "Roar", () => 			! buff("Attack Boost") ),	// Slot 3
			new AandC( "Breath" 			),	// Slot 1
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Flamethrower" 	),	// Slot 2
			new AandC( "Proto-Strike" 	),	// Slot 3
		}
                    ////////////////-
                    // DRAGONHAWKS //
                    ////////////////-
            ;
            else if (petName == "Blue Dragonhawk Hatchling" || petName == "Golden Dragonhawk Hatchling" || petName == "Red Dragonhawk Hatchling" || petName == "Silver Dragonhawk Hatchling")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Claw" 			),	// Slot 1
			new AandC( "Quills" 			),	// Slot 1
			new AandC( "Rake" 			),	// Slot 2
			new AandC( "Conflagrate" 	),	// Slot 2
			new AandC( "Flame Breath" 	),	// Slot 3
			new AandC( "Flamethrower" 	),	// Slot 3
		}
            ;
            else if (petName == "Phoenix Hawk Hatchling")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Lift-Off" 		),	// Slot 3
			new AandC( "Claw" 			),	// Slot 1
			new AandC( "Quills" 			),	// Slot 1
			new AandC( "Rake" 			),	// Slot 2
			new AandC( "Flyby" 			),	// Slot 2
			new AandC( "Flame Breath" 	),	// Slot 3
		}
                    //////////////
                    // SERPENTS //
                    //////////////
            ;
            else if (petName == "Celestial Dragon")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Moonfire", () => 		! weather("Moonlight") ),	// Slot 3
			new AandC( "Starfall", () => 		! weather("Moonlight") ),	// Slot 3
			new AandC( "Ancient Blessing",  () => buff("Ancient Blessing") || hp < 0.75 ),	// Slot 2
			new AandC( "Roar", () => 			! buff("Attack Boost") ),	// Slot 1
			new AandC( "Flamethrower" 	),	// Slot 1
			new AandC( "Arcane Storm" 	),	// Slot 2 // Can it remove a root if( already rooted || only prevent future roots cast against you?
		}
            ;
            else if (petName == "Essence of Competition" || petName == "Spirit of Competition")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Ancient Blessing",  () => buff("Ancient Blessing") || hp < 0.75 ),	// Slot 2
			new AandC( "Lift-Off" 		),	// Slot 3
			new AandC( "Breath" 			),	// Slot 1
			new AandC( "Tail Sweep" 		),	// Slot 1
			new AandC( "Competitive Spirit"),	// Slot 2
			new AandC( "Flamethrower" 	),	// Slot 3
		}
            ;
            else if (petName == "Soul of the Aspects" || petName == "Spirit of Competition")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Claw" 			),	// Slot 1
			new AandC( "Breath" 			),	// Slot 1
			new AandC( "Sunlight" 		),	// Slot 2
			new AandC( "Deflection" 		),	// Slot 2
			new AandC( "Surge of Light" 	),	// Slot 3
			new AandC( "Solar Beam" 		),	// Slot 3
		}
            ;
            else if (petName == "Thundering Serpent Hatchling" || petName == "Tiny Green Dragon" || petName == "Tiny Red Dragon" || petName == "Wild Golden Hatchling" || petName == "Wild Jade Hatchling")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 3
			new AandC( "Roar", () => 			! buff("Attack Boost") ),	// Slot 2
			new AandC( "Lift-Off" 		),	// Slot 3
			new AandC( "Breath" 			),	// Slot 1
			new AandC( "Tail Sweep" 		),	// Slot 1
			new AandC( "Call Lightning" 	),	// Slot 2
		}
            ;
            else if (petName == "Wild Crimson Hatchling")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Healing Flame",  () =>hp < 0.75 ),	// Slot 2
			new AandC( "Lift-Off" 		),	// Slot 3
			new AandC( "Breath" 			),	// Slot 1
			new AandC( "Tail Sweep" 		),	// Slot 1
			new AandC( "Scorched Earth" 	),	// Slot 2
			new AandC( "Deep Breath" 	),	// Slot 3
		}
                    //////////////////-
                    // MISCELLANEOUS //
                    //////////////////-
            ;
            else if (petName == "Chrominius")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Ancient Blessing",  () => !buff("Ancient Blessing") || hp < 0.75 ),	// Slot 2
			new AandC( "Howl" 			),	// Slot 2
			new AandC( "Surge of Power" 	),	// Slot 3
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Arcane Explosion"),	// Slot 1
			new AandC( "Ravage" 			),	// Slot 3
		}
            ;
            else if (petName == "Death Talon Whelpguard")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Blitz" 			),	// Slot 1
			new AandC( "Shadowflame" 	),	// Slot 1
			new AandC( "Whirlwind" 		),	// Slot 2
			new AandC( "Spiked Skin" 	),	// Slot 2
			new AandC( "Darkflame" 		),	// Slot 3
			new AandC( "Clobber" 		),	// Slot 3
		}
            ;
            else if (petName == "Sprite Darter Hatchling")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Moonfire", () => 		! weather("Moonlight") ),	// Slot 3
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 3
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Arcane Blast" 	),	// Slot 1
			new AandC( "Evanescence" 	),	// Slot 2
			new AandC( "Life Exchange" 	),	// Slot 2
		}
            ;
            else if (petName == "Untamed Hatchling")
                dragonkin_abilities = new List<AandC>() 
		{
			new AandC( "Healing Flame",  () =>  hp < 0.75 ),	// Slot 3
			new AandC( "Roar", () => 			! buff("Attack Boost") ),	// Slot 2
			new AandC( "Claw" 			),	// Slot 1
			new AandC( "Tail Sweep" 		),	// Slot 1
			new AandC( "Spiked Skin" 	),	// Slot 2
			new AandC( "Instability" 	),	// Slot 3
		};
            //////////////////-

            else // Unknown pet
            {
                Logger.Alert("Unknown dragonkin pet: " + petName);
                return null;
            }
            return dragonkin_abilities;
        }
    }
}
