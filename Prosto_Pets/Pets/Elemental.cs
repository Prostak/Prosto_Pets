//////////////-
// ELEMENTAL //
//////////////-


using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Elemental : PetTacticsBase
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

            List<AandC> elemental_abilities;



////////////////
// ELEMENTALS //
////////////////
if( petName == "Fel Flame" || petName == "Searing Scorchling" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Scorched Earth",  () =>  ! weather("Scorched Earth") ),	// Slot 2
			new AandC( "Conflagrate", () => 	debuff("Immolate") || debuff("Flamethrower") || weather("Scorched Earth") ),	// Slot 3
			new AandC( "Immolation", () => 		! buff("Immolation") ),	// Slot 3
			new AandC( "Immolate", () => 		! debuff("Immolate") && ! debuff("Flamethrower") && ! weather("Scorched Earth") ),	// Slot 2
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Flame Breath" 	),	// Slot 1
		}
;else if(petName == "Frigid Frostling" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Frost Shock" 	),	// Slot 1
			new AandC( "Surge" 			),	// Slot 1
			new AandC( "Frost Nova" 		),	// Slot 2
			new AandC( "Slippery Ice" 	),	// Slot 2
			new AandC( "Ice Tomb" 		),	// Slot 3
			new AandC( "Howling Blast" 	),	// Slot 3
		}
;else if(petName == "Grinder" || petName == "Lumpy" || petName == "Pebble" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Stone Shot" 		),	// Slot 1
			new AandC( "Stone Rush" 		),	// Slot 1
			new AandC( "Sandstorm" 		),	// Slot 2
			new AandC( "Rupture" 		),	// Slot 2
			new AandC( "Rock Barrage" 	),	// Slot 3
			new AandC( "Quake" 			),	// Slot 3
		}
;else if(petName == "Kirin Tor Familiar" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Beam" 			),	// Slot 1
			new AandC( "Arcane Blast" 	),	// Slot 1
			new AandC( "Gravity" 		),	// Slot 2
			new AandC( "Arcane Storm" 	),	// Slot 2
			new AandC( "Arcane Explosion"),	// Slot 3
			new AandC( "Dark Simulacrum" ),	// Slot 3
		}
;else if(petName == "Living Sandling" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Punch" 			),	// Slot 1
			new AandC( "Sand Bolt" 		),	// Slot 1
			new AandC( "Stoneskin" 		),	// Slot 2
			new AandC( "Sandstorm" 		),	// Slot 2
			new AandC( "Stone Rush" 		),	// Slot 3
			new AandC( "Quicksand" 		),	// Slot 3
		}
;else if(petName == "Pandaren Air Spirit" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 3
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Wild Winds" 		),	// Slot 1
			new AandC( "Whirlwind" 		),	// Slot 2
			new AandC( "Soothing Mists" 	),	// Slot 2
			new AandC( "Arcane Storm" 	),	// Slot 3
		}
;else if(petName == "Pandaren Earth Spirit" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Stone Shot" 		),	// Slot 1
			new AandC( "Stone Rush" 		),	// Slot 1
			new AandC( "Rupture" 		),	// Slot 2
			new AandC( "Rock Barrage" 	),	// Slot 2
			new AandC( "Crystal Prison" 	),	// Slot 3
			new AandC( "Mudslide"	 	),	// Slot 3
		}
;else if(petName == "Pandaren Fire Spirit" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Cauterize", () => 		hp < 0.7 ),	// Slot 3
			new AandC( "Immolate", () => 		! debuff("Immolate") && ! debuff("Flamethrower") && ! weather("Scorched Earth") ),	// Slot 2
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Magma Wave" 		),	// Slot 1
			new AandC( "Flamethrower" 	),	// Slot 2
			new AandC( "Conflagrate"	 	),	// Slot 3
		}
;else if(petName == "Pandaren Water Spirit" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Dive" 			),	// Slot 3
			new AandC( "Water Jet" 		),	// Slot 1
			new AandC( "Tidal Wave" 		),	// Slot 1
			new AandC( "Healing Wave" 	),	// Slot 2
			new AandC( "Whirlpool" 		),	// Slot 2
			new AandC( "Geyser"	 		),	// Slot 3
		}
;else if(petName == "Thundertail Flapper" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Tail Slap" 		),	// Slot 1
			new AandC( "Jolt" 			),	// Slot 1
			new AandC( "Buried Treasure" ),	// Slot 2
			new AandC( "Lightning Shield"),	// Slot 2
			new AandC( "Thunderbolt" 	),	// Slot 3
			new AandC( "Beaver Dam"		),	// Slot 3
		}
;else if(petName == "Tiny Twister" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 3
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Wild Winds" 		),	// Slot 1
			new AandC( "Flyby" 			),	// Slot 2
			new AandC( "Bash" 			),	// Slot 2
			new AandC( "Sandstorm"		),	// Slot 3
		}
;else if(petName == "Water Waveling" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Water Jet" 		),	// Slot 1
			new AandC( "Ice Lance" 		),	// Slot 1
			new AandC( "Frost Nova" 		),	// Slot 2
			new AandC( "Frost Shock" 	),	// Slot 2
			new AandC( "Geyser" 			),	// Slot 3
			new AandC( "Tidal Wave"		),	// Slot 3
		}
;else if(petName == "Tainted Waveling" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Acidic Goo",  () =>	! debuff("Acidic Goo") ),	// Slot 2
			new AandC( "Ooze Touch" 		),	// Slot 1
			new AandC( "Poison Spit" 	),	// Slot 1
			new AandC( "Corrosion"		),	// Slot 2
			new AandC( "Healing Wave" 	),	// Slot 3
			new AandC( "Creeping Ooze"	),	// Slot 3
		}
////////////
// GEODES //
////////////
;else if(petName == "Ashstone Core" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Crystal Overload",  () => buff("Crystal Overload") && hp > 0.50 ),	// Slot 2
			new AandC( "Feedback" 		),	// Slot 1
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Stoneskin" 		),	// Slot 2
			new AandC( "Crystal Prison" 	),	// Slot 3
			new AandC( "Instability" 	),	// Slot 3
		}
;else if(petName == "Crimson Geode" || petName == "Elementium Geode" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Crystal Overload",  () => buff("Crystal Overload") && hp > 0.50 ),	// Slot 2
			new AandC( "Feedback" 		),	// Slot 1
			new AandC( "Spark" 			),	// Slot 1
			new AandC( "Amplify Magic" 	),	// Slot 2
			new AandC( "Stone Rush" 		),	// Slot 3
			new AandC( "Elementium Bolt" ),	// Slot 3
		}
//////////////
// MYTHICAL //
//////////////
;else if(petName == "Core Hound Pup" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Howl" 			),	// Slot 2
			new AandC( "Dodge" 			),	// Slot 2
			new AandC( "Burn" 			),	// Slot 3
			new AandC( "Burrow" 			),	// Slot 3
		}
;else if(petName == "Dark Phoenix Hatchling" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Conflagrate", () => 	debuff("Immolate") || debuff("Flamethrower") || weather("Scorched Earth") ),	// Slot 3
			new AandC( "Immolate", () => 		! debuff("Immolate") && ! debuff("Flamethrower") && ! weather("Scorched Earth") ),	// Slot 2
			new AandC( "Darkflame" 		),	// Slot 2
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Laser" 			),	// Slot 1
			new AandC( "Dark Rebirth" 	),	// Slot 3
		}
;else if(petName == "Lil' Ragnaros" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Conflagrate", () => 	debuff("Immolate") || debuff("Flamethrower") || weather("Scorched Earth") ),	// Slot 2
			new AandC( "Flamethrower", () => 	! debuff("Immolate") && ! debuff("Flamethrower") && ! weather("Scorched Earth") ),	// Slot 3
			new AandC( "Sons of the Flame"),	// Slot 3
			new AandC( "Magma Trap" 		),	// Slot 2
			new AandC( "Sulfuras Smash" 	),	// Slot 1
			new AandC( "Magma Wave" 		),	// Slot 1
		}
;else if(petName == "Phoenix Hatchling" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Cauterize", () => 		hp < 0.7 ),	// Slot 2
			new AandC( "Immolation", () => 		! buff("Immolation") ),	// Slot 3
			new AandC( "Immolate", () => 		! debuff("Immolate") && ! debuff("Flamethrower") && ! weather("Scorched Earth") ),	// Slot 2
			new AandC( "Conflagrate", () => 	debuff("Immolate") || debuff("Flamethrower") || weather("Scorched Earth") ),	// Slot 3
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Peck" 			),	// Slot 1
		}
////////////////
// PLANT LIFE //
////////////////
;else if(petName == "Ammen Vale Lashling" || petName == "Crimson Lasher" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Lash" 			),	// Slot 1
			new AandC( "Poison Lash" 	),	// Slot 1
			new AandC( "Soothing Mists" 	),	// Slot 2
			new AandC( "Plant" 			),	// Slot 2
			new AandC( "Stun Seed" 		),	// Slot 3
			new AandC( "Entangling Roots"),	// Slot 3
		}
;else if(petName == "Ruby Sapling" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Photosynthesis", () => 	! buff("Photosynthesis") && hp < 0.8 ),	// Slot 3
			new AandC( "Shell Shield",  () =>  ! buff("Shell Shield") ),	// Slot 2
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Poisoned Branch" ),	// Slot 1
			new AandC( "Thorns" 			),	// Slot 2
			new AandC( "Entangling Roots"),	// Slot 3
		}
;else if(petName == "Singing Sunflower" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Photosynthesis", () => 	! buff("Photosynthesis") && hp < 0.8 ),	// Slot 2
			new AandC( "Early Advantage",() =>  hp < hpEnemy ),	// Slot 3
			new AandC( "Lash" 			),	// Slot 1
			new AandC( "Solar Beam" 		),	// Slot 1
			new AandC( "Inspiring Song" 	),	// Slot 2
			new AandC( "Sunlight" 		),	// Slot 3
		}
;else if(petName == "Sinister Squashling" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Poison Lash" 	),	// Slot 1
			new AandC( "Thorns" 			),	// Slot 2
			new AandC( "Stun Seed" 		),	// Slot 2
			new AandC( "Plant" 			),	// Slot 3
			new AandC( "Leech Seed" 		),	// Slot 3
		}
;else if(petName == "Teldrassil Sproutling" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Photosynthesis", () => 	! buff("Photosynthesis") && hp < 0.8 ),	// Slot 2
			new AandC( "Shell Shield",   () =>  ! buff("Shell Shield") ),	// Slot 1
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Poisoned Branch" ),	// Slot 2
			new AandC( "Thorns" 			),	// Slot 3
			new AandC( "Entangling Roots"),	// Slot 3
		}
;else if(petName == "Terrible Turnip" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Weakening Blow", () =>	hpEnemy > 0.05 ),	// Slot 1 // Can! reduce enemy below 1 hp
			new AandC( "Tidal Wave" 		),	// Slot 1
			new AandC( "Leech Seed" 		),	// Slot 2
			new AandC( "Inspiring Song" 	),	// Slot 2
			new AandC( "Sunlight" 		),	// Slot 3
			new AandC( "Sons of the Root"),	// Slot 3
		}
;else if(petName == "Tiny Bog Beast" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Leap", () => 			speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC( "Crush" 			),	// Slot 1
			new AandC( "Clobber" 		),	// Slot 1
			new AandC( "Lash" 			),	// Slot 2
			new AandC( "Poison Lash" 	),	// Slot 3
			new AandC( "Rampage" 		),	// Slot 3
		}
;else if(petName == "Venus" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Lash" 			),	// Slot 1
			new AandC( "Poison Lash" 	),	// Slot 1
			new AandC( "Sunlight" 		),	// Slot 2
			new AandC( "Plant" 			),	// Slot 2
			new AandC( "Stun Seed" 		),	// Slot 3
			new AandC( "Leech Seed" 		),	// Slot 3
		}
;else if(petName == "Withers" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Photosynthesis", () => 	! buff("Photosynthesis") && hp < 0.8 ),	// Slot 2
			new AandC( "Shell Shield",  () =>  ! buff("Shell Shield") ),	// Slot 1
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Poisoned Branch" ),	// Slot 2
			new AandC( "Thorns" 			),	// Slot 3
			new AandC( "Entangling Roots"),	// Slot 3
		}
;else if(petName == "Blossoming Ancient" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Photosynthesis", () =>	! buff("Photosynthesis") && hp < 0.8 ),	// Slot 2
			new AandC( "Poisoned Branch"	),	// Slot 1
			new AandC( "Ironbark" 		),	// Slot 1
			new AandC( "Autumn Breeze" 	),	// Slot 2
			new AandC( "Stun Seed" 		),	// Slot 3
			new AandC( "Sunlight"		),	// Slot 3
		}
//////////////////-
// SHALE SPIDERS //
//////////////////-
;else if(petName == "Amethyst Shale Hatchling" || petName == "Crimson Shale Hatchling" || petName == "Emerald Shale Hatchling" || petName == "Tiny Shale Spider" || petName == "Topaz Shale Hatchling" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Leech Life" 		),	// Slot 1
			new AandC( "Sticky Web" 		),	// Slot 2
			new AandC( "Poison Spit" 	),	// Slot 2
			new AandC( "Stone Rush" 		),	// Slot 3
			new AandC( "Stoneskin" 		),	// Slot 3
		}
//////////////////-
// MISCELLANEOUS //
//////////////////-
;else if(petName == "Cinder Kitten" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Scorched Earth",  () =>  ! weather("Scorched Earth") ),	// Slot 3
			new AandC( "Immolate", () => 		! debuff("Immolate") && ! debuff("Flamethrower") && ! weather("Scorched Earth") ),	// Slot 2
			new AandC( "Leap", () => 			speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2 // if( your (1) speed is slower than you enemy (2) && ! boosted
			new AandC( "Claw" 			),	// Slot 1
			new AandC( "Rend" 			),	// Slot 1
			new AandC( "Prowl" 			),	// Slot 3
		}
;else if(petName == "Electrified Razortooth" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Devour", () => 			hpEnemy < 0.20 ),	// Slot 3,  if( we kill the enemy with Devour, we restore health
			new AandC( "Rip" 			),	// Slot 1
			new AandC( "Jolt" 			),	// Slot 1
			new AandC( "Paralyzing Shock"),	// Slot 2
			new AandC( "Lightning Shield"),	// Slot 2
			new AandC( "Blood in the Water"),	// Slot 3
		}
;else if(petName == "Jade Tentacle" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Photosynthesis", () => 	! buff("Photosynthesis") && hp < 0.8 ),	// Slot 2
			new AandC( "Shell Shield",  () =>  ! buff("Shell Shield") ),	// Slot 2
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Poisoned Branch" ),	// Slot 1
			new AandC( "Entangling Roots"),	// Slot 3
			new AandC( "Thorns" 			),	// Slot 3
		}
;else if(petName == "Lava Crab" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Survival", () => 		hp < 0.3 ),	// Slot 1
			new AandC( "Cauterize", () => 		hp < 0.7 ),	// Slot 2
			new AandC( "Shell Shield",  () =>  ! buff("Shell Shield") ),	// Slot 2
			new AandC( "Conflagrate" 	),	// Slot 3
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Magma Wave" 		),	// Slot 3
		}
;else if(petName == "Sapphire Cub" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Lash" 			),	// Slot 1
			new AandC( "Pounch" 			),	// Slot 1
			new AandC( "Rake" 			),	// Slot 2
			new AandC( "Screech" 		),	// Slot 2
			new AandC( "Stone Rush" 		),	// Slot 3
			new AandC( "Prowl" 			),	// Slot 3
		}
;else if(petName == "Spirit of Summer" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Scorched Earth",  () =>  ! weather("Scorched Earth") ),	// Slot 2
			new AandC( "Immolation", () => 		! buff("Immolation") ),	// Slot 3
			new AandC( "Immolate", () => 		! debuff("Immolate") && ! debuff("Flamethrower") && ! weather("Scorched Earth") ),	// Slot 2
			new AandC( "Conflagrate", () => 	debuff("Immolate") || debuff("Flamethrower") || weather("Scorched Earth") ),	// Slot 3
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Flame Breath" 	),	// Slot 1
		}
;else if(petName == "Tiny Snowman" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Snowball" 		),	// Slot 1
			new AandC( "Magic Hat" 		),	// Slot 1
			new AandC( "Call Blizzard" 	),	// Slot 2
			new AandC( "Frost Nova" 		),	// Slot 2
			new AandC( "Howling Blast" 	),	// Slot 3
			new AandC( "Deep Freeze" 	),	// Slot 3
		}
;else if(petName == "Molten Corgi" )
	elemental_abilities = new List<AandC>() 
		{
			new AandC( "Puppies of the Flame", ()=> shouldIHide ),	// Slot 3
			new AandC( "Cauterize", ()=> hp<0.7 		),	// Slot 2
			new AandC( "Superbark" 	),	// Slot 2
			new AandC( "Bark" 		),	// Slot 1
			new AandC( "Flamethrower" 		),	// Slot 1
			new AandC( "Inferno Herding" 	),	// Slot 3    // TODO NOW: define enemy lowest hp
		};
//////////////////-

            else // Unknown pet
            {
                Logger.Alert("Unknown elemental pet: " + petName);
                return null;
            }
            return elemental_abilities;
        }
    }
}
