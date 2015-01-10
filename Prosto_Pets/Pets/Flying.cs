////////////
// FLYING //
////////////

using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Flying : PetTacticsBase
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

            List<AandC> flying_abilities;



////////////////////////
// BALLOONS && KITES //
////////////////////////
            if (petName == "Dragon Kite")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Lift-Off" 		),	// Slot 3
			new AandC( "Breath" 			),	// Slot 1
			new AandC( "Tail Sweep" 		),	// Slot 1
			new AandC( "Call Lightning" 	),	// Slot 2
			new AandC( "Roar" 			),	// Slot 2
			new AandC( "Volcano" 		),	// Slot 3
		}
            ;
            else if (petName == "Tuskarr Kite")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 2
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Frost Shock" 	),	// Slot 1
			new AandC( "Wild Winds" 		),	// Slot 2
			new AandC( "Flyby" 			),	// Slot 3
			new AandC( "Reckless Strike" ),	// Slot 3
		}
                    //////////
                    // BATS //
                    //////////
            ;
            else if (petName == "Bat" || petName == "Tirisfal Batling")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Hawk Eye",	() =>		! buff("Hawk Eye") ),	// Slot 2
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Leech Life" 		),	// Slot 1
			new AandC( "Screech" 		),	// Slot 2
			new AandC( "Reckless Strike" ),	// Slot 3
			new AandC( "Nocturnal Strike"),	// Slot 3
		}
                    //////////////////-
                    // BIRDS OF PREY //
                    //////////////////-
            ;
            else if (petName == "Blue Mini Jouster" || petName == "Dragonbone Hatchling" || petName == "Fledgling Buzzard" || petName == "Gold Mini Jouster" || petName == "Imperial Eagle Chick" || petName == "Tickbird Hatchling" || petName == "White Tickbird Hatchling")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 3
			new AandC( "Hawk Eye",	() =>		! buff("Hawk Eye") ),	// Slot 2
			new AandC( "Lift-Off" 		),	// Slot 3
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Adrenaline Rush" ),	// Slot 2
		}
            ;
            else if (petName == "Brilliant Kaliri")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Predatory Strike", () =>	hpEnemy < 0.25 ),	// Slot 3
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 2
			new AandC( "Shriek", () => 			! debuff("Attack Reduction") ),	// Slot 2
			new AandC( "Nocturnal Strike"),	// Slot 3
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Quills" 			),	// Slot 1
		}
            ;
            else if (petName == "Ji-Kun Hatchling")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Acidic Goo",  () =>	! debuff("Acidic Goo") ),	// Slot 2
			new AandC( "Slicing Wind",  () =>  ! debuff("Wild Winds") ),	// Slot 1
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Wild Winds" 		),	// Slot 2
			new AandC( "Flock" 			),	// Slot 3
			new AandC( "Caw" 			),	// Slot 3
		}
                    //////////////-
                    // FIREFLIES //
                    //////////////-
            ;
            else if (petName == "Darkmoon Glowfly")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Dazzling Dance",  () =>speed < speedEnemy && ! buff("Dazzling Dance") ),	// Slot 3
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Glowing Toxin" 	),	// Slot 2
			new AandC( "Sting" 			),	// Slot 2
			new AandC( "Confusing Sting" ),	// Slot 3
		}
            ;
            else if (petName == "Effervescent Glowfly" || petName == "Firefly" || petName == "Mei Li Sparkler" || petName == "Shrine Fly")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Confusing Sting",  () => debuff("Confusing Sting") ),  // Slot 2
			new AandC( "Swarm", () =>			! debuff("Shattered Defenses")),  // Slot 3
			new AandC( "Glowing Toxin",	() =>	! debuff("Glowing Toxin")),  // Slot 3
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Cocoon Strike" 	),	// Slot 2
		}
            ;
            else if (petName == "Tiny Flamefly")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Alpha Strike" 	),	// Slot 1
			new AandC( "Immolate" 		),	// Slot 2
			new AandC( "Hiss" 			),	// Slot 2
			new AandC( "Swarm" 			),	// Slot 3
			new AandC( "Adrenaline Rush" ),	// Slot 3
		}
                    //////////
                    // FOWL //
                    //////////
            ;
            else if (petName == "Ancona Chicken" || petName == "Chicken" || petName == "Szechuan Chicken" || petName == "Westfall Chicken")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Squawk" 			),	// Slot 2
			new AandC( "Adrenaline Rush" ),	// Slot 2
			new AandC( "Egg Barrage" 	),	// Slot 3
			new AandC( "Flock" 			),	// Slot 3
		}
            ;
            else if (petName == "Highlands Turkey" || petName == "Plump Turkey" || petName == "Turkey")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Squawk" 			),	// Slot 2
			new AandC( "Gobble Strike",  () =>speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC( "Food Coma" 		),	// Slot 3
			new AandC( "Flock" 			),	// Slot 3
		}
                    //////////////////////
                    // GULLS && RAVENS //
                    //////////////////////
            ;
            else if (petName == "Crow")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Alpha Strike" 	),	// Slot 1
			new AandC( "Squawk" 			),	// Slot 2
			new AandC( "Call Darkness" 	),	// Slot 2
			new AandC( "Murder" 			),	// Slot 3
			new AandC( "Nocturnal Strike"),	// Slot 3
		}
            ;
            else if (petName == "Gilnean Raven")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Alpha Strike" 	),	// Slot 1
			new AandC( "Drakflame" 		),	// Slot 2
			new AandC( "Call Darkness" 	),	// Slot 2
			new AandC( "Nocturnal Strike"),	// Slot 3
			new AandC( "Nevermore" 		),	// Slot 3
		}
            ;
            else if (petName == "Rustberg Gull" || petName == "Sandy Petrel" || petName == "Sea Gull")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),  // Slot 3
			new AandC( "Hawk Eye",	() =>		! buff("Hawk Eye") ),  // Slot 2
			new AandC( "Adrenaline Rush", () =>		! buff("Adrenaline") ),  // Slot 2
			new AandC( "Lift-Off" 		),	// Slot 3
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
		}
                    //////////-
                    // MOTHS //
                    //////////-
            ;
            else if (petName == "Amber Moth" || petName == "Blue Moth" || petName == "Crimson Moth" || petName == "Forest Moth" || petName == "Fungal Moth" || petName == "Garden Moth" || petName == "Gilded Moth" || petName == "Grey Moth" || petName == "Luyu Moth" || petName == "Oasis Moth" || petName == "Red Moth" || petName == "Silky Moth" || petName == "Swamp Moth" || petName == "Tainted Moth" || petName == "White Moth" || petName == "Yellow Moth")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Alpha Strike" 	),	// Slot 1
			new AandC( "Cocoon Strike" 	),	// Slot 2
			new AandC( "Adrenaline Rush" ),	// Slot 2
			new AandC( "Moth Balls" 		),	// Slot 3
			new AandC( "Moth Dust" 		),	// Slot 3
		}
            ;
            else if (petName == "Imperial Moth")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 3
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Wild Winds" 		),	// Slot 1
			new AandC( "Cocoon Strike" 	),	// Slot 2
			new AandC( "Moth Balls" 		),	// Slot 2
			new AandC( "Moth Dust" 		),	// Slot 3
		}
            ;
            else if (petName == "Skywisp Moth")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Call Lightning" 	),	// Slot 3
			new AandC( "Counterspell", () => 	speed > speedEnemy ),	// Slot 2
			new AandC( "Cocoon Strike" 	),	// Slot 2
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Reckless Strike" ),	// Slot 1
			new AandC( "Moth Dust" 		),	// Slot 3
		}

                    //////////////
                    // MYTHICAL //
                    //////////////
            ;
            else if (petName == "Cenarion Hatchling" || petName == "Hippogryph Hatchling")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Rush", () => 			speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC( "Lift-Off" 		),	// Slot 3
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Quills" 			),	// Slot 1
			new AandC( "Screech" 		),	// Slot 2
			new AandC( "Reckless Strike" ),	// Slot 3
		}
            ;
            else if (petName == "Gryphon Hatchling" || petName == "Wildhammer Gryphon Hatchling")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Lift-Off" 		),	// Slot 3
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Squawk" 			),	// Slot 2
			new AandC( "Adrenaline Rush" ),	// Slot 2
			new AandC( "Flock" 			),	// Slot 3
		}
            ;
            else if (petName == "Guardian Cub")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 3
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Onyx Bite"		),	// Slot 1
			new AandC( "Roar" 			),	// Slot 2
			new AandC( "Wild Winds" 		),	// Slot 2
			new AandC( "Reckless Strike" ),	// Slot 3
		}
                    ////////////////-
                    // NETHER RAYS //
                    ////////////////-
            ;
            else if (petName == "Fledgling Nether Ray" || petName == "Nether Ray Fry")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Arcane Blast" 	),	// Slot 1
			new AandC( "Tail Sweep" 		),	// Slot 2
			new AandC( "Slicing Wind" 	),	// Slot 2
			new AandC( "Shadow Shock" 	),	// Slot 3
			new AandC( "Lash" 			),	// Slot 3
		}
                    //////////
                    // OWLS //
                    //////////
            ;
            else if (petName == "Crested Owl" || petName == "Great Horned Owl" || petName == "Hawk Owl" || petName == "Snowy Owl")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Shriek", () => 			! debuff("Attack Reduction") ),	// Slot 2
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Quills" 			),	// Slot 1
			new AandC( "Cyclone" 		),	// Slot 2
			new AandC( "Nocturnal Strike"),	// Slot 3
			new AandC( "Predatory Strike"),	// Slot 3
		}
                    ////////////-
                    // PARROTS //
                    ////////////-
            ;
            else if (petName == "Cockatiel" || petName == "Green Wing Macaw" || petName == "Hyacinth Macaw" || petName == "Parrot" || petName == "Polly" || petName == "Senegal")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 3
			new AandC( "Lift-Off" 		),	// Slot 3
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Hawk Eye" 		),	// Slot 2
			new AandC( "Adrenaline Rush" ),	// Slot 2
		}
            ;
            else if (petName == "Miniwing")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 2
			new AandC( "Shriek", () => 			! debuff("Attack Reduction") ),	// Slot 2
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Quills" 			),	// Slot 1
			new AandC( "Nocturnal Strike"),	// Slot 3
			new AandC( "Predatory Strike"),	// Slot 3
		}
                    //////////////////-
                    // MISCELLANEOUS //
                    //////////////////-
            ;
            else if (petName == "Waterfly")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Lift-Off", 		 () =>   shouldIHide ),	// Slot 3
			new AandC( "Dodge",          () =>   shouldIHide ),	// Slot 3
			new AandC( "Barbed Stinger", () =>	    ! debuff("Poisoned") ),	// Slot 1
			new AandC( "Alpha Strike",	 () =>		speed > speedEnemy ),	// Slot 1
			new AandC( "Healing Stream", () =>      hp < 0.7 	),	// Slot 2
			new AandC( "Puncture Wound", () =>      debuff("Poisoned") 			),	// Slot 2
			new AandC( "Barbed Stinger"      ),	// Slot 1 Uncond
			new AandC( "Alpha Strike"        ),	// Slot 1 Uncond
		}
            ;
            else if (petName == "Jade Crane Chick")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 3
			new AandC( "Hawk Eye",	() =>		! buff("Hawk Eye") ),	// Slot 2
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Jadeskin" 		),	// Slot 2
			new AandC( "Flock"			),	// Slot 3
		}
            ;
            else if (petName == "Pterrordax Hatchling")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Ancient Blessing",  () => !buff("Ancient Blessing") || hp < 0.75 ),	// Slot 2
			new AandC( "Lift-Off"		),	// Slot 3
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Flyby" 			),	// Slot 1
			new AandC( "Apocalypse" 		),	// Slot 2
			new AandC( "Feign Death"		),	// Slot 3
		}
            ;
            else if (petName == "Tiny Sporebat")
                flying_abilities = new List<AandC>() 
		{
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Shadow Slash" 	),	// Slot 1
			new AandC( "Creeping Fungus" ),	// Slot 2
			new AandC( "Leech Seed" 		),	// Slot 2
			new AandC( "Spore Shrooms" 	),	// Slot 3
			new AandC( "Confusing Sting" ),	// Slot 3
		};
            //////////////////-

            else // Unknown pet
            {
                Logger.Alert("Unknown flying pet: " + petName);
                return null;
            }
            return flying_abilities;
        }
    }
}
