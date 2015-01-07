//////////////
// HUMANOID //
//////////////

using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Humanoid : PetTacticsBase
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

            List<AandC> humanoid_abilities;


////////////
// GNOMES //
////////////
if( petName == "Father Winter's Helper" || petName == "Winter's Little Helper" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Snowball" 		),	// Slot 1
			new AandC( "Ice Lance" 		),	// Slot 1
			new AandC( "Call Blizzard" 	),	// Slot 2
			new AandC( "Eggnog" 			),	// Slot 2
			new AandC( "Ice Tomb" 		),	// Slot 3
			new AandC( "Gift of Winter's Veil"),	// Slot 3
		}
//////////////
// HOPLINGS //
//////////////
;else if(petName == "Feral Vermling" || petName == "Hopling" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Crush" 			),	// Slot 1
			new AandC( "Tongue Lash" 	),	// Slot 1
			new AandC( "Sticky Goo" 		),	// Slot 2
			new AandC( "Poison Lash" 	),	// Slot 2
			new AandC( "Backflip" 		),	// Slot 3
			new AandC( "Dreadful Breath" ),	// Slot 3
		}
////////////
// HUMANS //
////////////
// None able to battle

//////////
// IMPS //
//////////
;else if(petName == "Corefire Imp" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Rush", () => 			speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 1
			new AandC( "Immolation", () => 		! buff("Immolation") ),	// Slot 2
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Flamethrower" 	),	// Slot 2
			new AandC( "Cauterize" 		),	// Slot 3
			new AandC( "Wild Magic" 		),	// Slot 3
		}
;else if(petName == "Fiendish Imp" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Rush", () => 			speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 3
			new AandC( "Immolation", () => 		! buff("Immolation") ),	// Slot 2
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Sear Magic"		),	// Slot 1
			new AandC( "Flamethrower" 	),	// Slot 2
			new AandC( "Nether Gate" 	),	// Slot 3
		}
;else if(petName == "Gregarious Grell" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Immolate", () => 		! debuff("Immolate") ),	// Slot 2
			new AandC( "Punch" 			),	// Slot 1
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Phase Shift" 	),	// Slot 2
			new AandC( "Cauterize" 		),	// Slot 3
			new AandC( "Sear Magic" 		),	// Slot 3
		}
////////////-
// MOONKIN //
////////////-
;else if(petName == "Moonkin Hatchling" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 3
			new AandC( "Punch" 			),	// Slot 1
			new AandC( "Solar Beam" 		),	// Slot 1
			new AandC( "Entangling Roots"),	// Slot 2
			new AandC( "Clobber" 		),	// Slot 2
			new AandC( "Moonfire" 		),	// Slot 3
		}
////////////-
// MURLOCS //
////////////-
;else if(petName == "Deathy" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Punch" 			),	// Slot 1
			new AandC( "Deep Breath" 	),	// Slot 1
			new AandC( "Scorched Earth" 	),	// Slot 2
			new AandC( "Call Darkness" 	),	// Slot 2
			new AandC( "Clobber" 		),	// Slot 3
			new AandC( "Roar" 			),	// Slot 3
		}
;else if(petName == "Grunty" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Gauss Rifle" 	),	// Slot 1
			new AandC( "U-238 Rounds" 	),	// Slot 1
			new AandC( "Stimpack" 		),	// Slot 2
			new AandC( "Shield Block" 	),	// Slot 2
			new AandC( "Launch" 			),	// Slot 3
			new AandC( "Lock-On" 		),	// Slot 3
		}
;else if(petName == "Gurky" || petName == "Lurky" || petName == "Murki" || petName == "Murky" || petName == "Terky" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Punch" 			),	// Slot 1
			new AandC( "Flank" 			),	// Slot 1
			new AandC( "Acid Touch" 		),	// Slot 2
			new AandC( "Lucky Dance" 	),	// Slot 2
			new AandC( "Clobber" 		),	// Slot 3
			new AandC( "Stampede" 		),	// Slot 3
		}
;else if(petName == "Murkablo" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Bone Prison" 	),	// Slot 1
			new AandC( "Agony" 			),	// Slot 2
			new AandC( "Drain Power" 	),	// Slot 2
			new AandC( "Blast of Hatred" ),	// Slot 3
			new AandC( "Scorched Earth" 	),	// Slot 3
		}
;else if(petName == "Murkimus the Gladiator" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Punch" 			),	// Slot 1
			new AandC( "Flurry" 			),	// Slot 1
			new AandC( "Shield Block" 	),	// Slot 2
			new AandC( "Counterstrike" 	),	// Slot 2
			new AandC( "Heroic Leap" 	),	// Slot 3
			new AandC( "Haymaker" 		),	// Slot 3
		}
//////////
// ORCS //
//////////
// None able to battle

//////////////////-
// MISCELLANEOUS //
//////////////////-
;else if(petName == "Anubisath Idol" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Deflection", () =>   shouldIHide	    ),	// Slot 3
			new AandC( "Sandstorm"  ),	                            // Slot 2
			new AandC( "Crush" 			),	// Slot 1
			new AandC( "Demolish"       ),	// Slot 1
			new AandC( "Stoneskin" 		),	// Slot 2
			new AandC( "Rupture" 		),	// Slot 3
		}
;else if(petName == "Curious Oracle Hatchling" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Punch" 			),	// Slot 1
			new AandC( "Water Jet" 		),	// Slot 1
			new AandC( "Super Sticky Goo"),	// Slot 2
			new AandC( "Aged Yolk" 		),	// Slot 2
			new AandC( "Backflip" 		),	// Slot 3
			new AandC( "Dreadful Breath" ),	// Slot 3
		}
;else if(petName == "Curious Wolvar Pup" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Punch" 			),	// Slot 1
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Snap Trap" 		),	// Slot 2
			new AandC( "Frenzyheart Brew"),	// Slot 2
			new AandC( "Whirlwind" 		),	// Slot 3
			new AandC( "Maul" 			),	// Slot 3
		}
;else if(petName == "Flayer Youngling" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Blitz" 			),	// Slot 1
			new AandC( "Triple Snap" 	),	// Slot 1
			new AandC( "Focus" 			),	// Slot 2
			new AandC( "Deflection" 		),	// Slot 2
			new AandC( "Kick" 			),	// Slot 3
			new AandC( "Rampage" 		),	// Slot 3
		}
;else if(petName == "Harbinger of Flame" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Impale", () => 			hpEnemy < 0.25 ),	// Slot 3 You can also use "2" instead of "LE_BATTLE_PET_ENEMY"
			new AandC( "Immolate", () => 		! debuff("Immolate") ),	// Slot 2
			new AandC( "Conflagrate", () => 	debuff("Immolate") || weather("Scorched Earth") ),	// Slot 3
			new AandC( "Jab" 			),	// Slot 1
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Magma Wave" 	),	// Slot 2
		}
;else if(petName == "Harpy Youngling" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Lift-Off" 		),	// Slot 3
			new AandC( "Quills" 			),	// Slot 1
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Flyby" 			),	// Slot 2
			new AandC( "Counterstrike" 	),	// Slot 2
			new AandC( "Squawk" 			),	// Slot 3
		}
;else if(petName == "Kun-Lai Runt" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Takedown" 		),	// Slot 1
			new AandC( "Mangle" 			),	// Slot 2
			new AandC( "Frost Shock" 	),	// Slot 2
			new AandC( "Rampage" 		),	// Slot 3
			new AandC( "Deep Freeze" 	),	// Slot 3
		}
;else if(petName == "Mini Tyrael" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Holy Sword" 		),	// Slot 1
			new AandC( "Omnislash" 		),	// Slot 1
			new AandC( "Holy Justice" 	),	// Slot 2
			new AandC( "Surge of Light" 	),	// Slot 2
			new AandC( "Holy Charge" 	),	// Slot 3
			new AandC( "Restoration" 	),	// Slot 3
		}
;else if(petName == "Pandaren Monk" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Jab" 			),	// Slot 1
			new AandC( "Takedown" 		),	// Slot 1
			new AandC( "Focus Chi" 		),	// Slot 2
			new AandC( "Staggered Steps" ),	// Slot 2
			new AandC( "Fury of 1,000 Fists"),	// Slot 3
			new AandC( "Blackout Kick" 	),	// Slot 3
		}
;else if(petName == "Peddlefeet" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Bow Shot" 		),	// Slot 1
			new AandC( "Rapid Fire" 		),	// Slot 1
			new AandC( "Lovestruck" 		),	// Slot 2
			new AandC( "Perfumed Arrow" 	),	// Slot 2
			new AandC( "Shot Through The Heart"),	// Slot 3
			new AandC( "Love Potion" 	),	// Slot 3
		}
;else if(petName == "Qiraji Guardling" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Hawk Eye",	()=>	! buff("Hawk Eye") ),	// Slot 2
			new AandC( "Crush" 			),	// Slot 1
			new AandC( "Whirlwind" 		),	// Slot 1
			new AandC( "Sandstorm" 		),	// Slot 2
			new AandC( "Reckless Strike" ),	// Slot 3
			new AandC( "Blackout Kick" 	),	// Slot 3
		}
;else if(petName == "Sporeling Sprout" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Jab" 			),	// Slot 1
			new AandC( "Charge" 			),	// Slot 1
			new AandC( "Creeping Fungus" ),	// Slot 2
			new AandC( "Leech Seed" 		),	// Slot 2
			new AandC( "Spore Shrooms" 	),	// Slot 3
			new AandC( "Crouch" 			),	// Slot 3
		}
;else if(petName == "Stunted Yeti" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Punch" 			),	// Slot 1
			new AandC( "Mangle" 			),	// Slot 2
			new AandC( "Haymaker" 		),	// Slot 2
			new AandC( "Rampage" 		),	// Slot 3
			new AandC( "Bash" 			),	// Slot 3
		}
;else if(petName == "Lil' Bad Wolf" )
	humanoid_abilities = new List<AandC>() 
		{
			new AandC( "Claw" 			),	// Slot 1
			new AandC( "Counterstrike" 	),	// Slot 1
			new AandC( "Mangle" 			),	// Slot 2
			new AandC( "Dodge" 			),	// Slot 2
			new AandC( "Howl" 			),	// Slot 3
			new AandC( "Pounce" 			),	// Slot 3
		};
	
//////////////////-

            else // Unknown pet
            {
                Logger.Alert("Unknown humanoid pet: " + petName);
                return null;
            }
            return humanoid_abilities;
        }
    }
}
