////////////////
// CRITTER //
////////////////

using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Critter : PetTacticsBase
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

            List<AandC> critter_abilities;


////////////////
// ARMADILLOS //
////////////////
            if (petName == "Armadillo Pup" || petName == "Stone Armadillo")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Shell Shield",  () =>  ! buff("Shell Shield") ),	// Slot 2
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Roar" 			),	// Slot 2
			new AandC( "Infected Claw" 	),	// Slot 3
			new AandC( "Powerball" 		),	// Slot 3
		}
                    //////////-
                    // BIRDS //
                    //////////-
            ;
            else if (petName == "Darkmoon Hatchling")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Hawk Eye",	() =>	! buff("Hawk Eye") ),	// Slot 2
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Trample" 		),	// Slot 1
			new AandC( "Screech" 		),	// Slot 2
			new AandC( "Flock" 			),	// Slot 3
			new AandC( "Predatory Strike"),	// Slot 3
		}
            ;
            else if (petName == "Egbert" || petName == "Mulgore Hatchling")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Adrenaline Rush",  () =>speed < speedEnemy && ! buff("Adrenaline") ),	// Slot 2
			new AandC( "Shell Shield",  () =>  ! buff("Shell Shield") ),	// Slot 2
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Trample" 		),	// Slot 3
			new AandC( "Feign Death" 	),	// Slot 3
		}
                    //////////
                    // DEER //
                    //////////
            ;
            else if (petName == "Fawn" || petName == "Gazelle Fawn" || petName == "Little Fawn" || petName == "Winter Reindeer")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Tranquility", () => 	hp < 0.7 && ! buff("Tranquility") ),	// Slot 2
			new AandC( "Bleat", () => 			hp < 0.7 ),	// Slot 3
			new AandC( "Headbutt" 		),	// Slot 3
			new AandC( "Hoof" 			),	// Slot 1
			new AandC( "Stampede" 		),	// Slot 1
			new AandC( "Nature's Ward" 	),	// Slot 2
		}
                    ////////////
                    // ELEKKS //
                    ////////////
            ;
            else if (petName == "Peanut" || petName == "Pint-Sized Pink Pachyderm")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Survival", () => 		hp < 0.3 ),	// Slot 2
			new AandC( "Headbutt" 		),	// Slot 3
			new AandC( "Smash" 			),	// Slot 1
			new AandC( "Trample" 		),	// Slot 1
			new AandC( "Trumpet Strike" 	),	// Slot 2
			new AandC( "Stampede" 		),	// Slot 3
		}
                    ////////////-
                    // INSECTS //
                    ////////////-
            ;
            else if (petName == "Beetle" || petName == "Cockroach" || petName == "Creepy Crawly" || petName == "Crystal Beetle" || petName == "Death's Head Cockroach" || petName == "Deepholm Cockroach" || petName == "Dung Beetle" || petName == "Fire-Proof Roach" || petName == "Gold Beetle" || petName == "Irradiated Roach" || petName == "Locust" || petName == "Resilient Roach" || petName == "Roach" || petName == "Sand Scarab" || petName == "Savory Beetle" || petName == "Scarab Hatchling" || petName == "Stinkbug" || petName == "Tainted Cockroach" || petName == "Tol'vir Scarab" || petName == "Twilight Beetle" || petName == "Undercity Cockroach")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Survival", () => 		hp < 0.3 ),	// Slot 2
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Flank" 			),	// Slot 1
			new AandC( "Hiss" 			),	// Slot 2
			new AandC( "Swarm" 			),	// Slot 3
			new AandC( "Apocalypse" 		),	// Slot 3
		}
            ;
            else if (petName == "Fire Beetle" || petName == "Lava Beetle")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Apocalypse" 		),	// Slot 3
			new AandC( "Cauterize", () => hp < 0.7		),	// Slot 2
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Flank" 			),	// Slot 1
			new AandC( "Hiss" 			),	// Slot 2
			new AandC( "Scorched Earth" 	),	// Slot 3
		}
            ;
            else if (petName == "Grassland Hopper" || petName == "Marsh Fiddler" || petName == "Red Cricket" || petName == "Singing Cricket")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Nature's Touch",  () =>hp < 0.7 ),	// Slot 3
			new AandC( "Skitter" 		),	// Slot 1
			new AandC( "Screech" 		),	// Slot 1
			new AandC( "Swarm" 			),	// Slot 2
			new AandC( "Cocoon Strike" 	),	// Slot 2
			new AandC( "Inspiring Song" 	),	// Slot 3
		}
            ;
            else if (petName == "Imperial Silkworm")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Burrow" 			),	// Slot 3
			new AandC( "Chomp" 			),	// Slot 1
			new AandC( "Consume" 		),	// Slot 1
			new AandC( "Sticky Goo" 		),	// Slot 2
			new AandC( "Moth Balls" 		),	// Slot 2
			new AandC( "Moth Dust" 		),	// Slot 3
		}
            ;
            else if (petName == "Nether Roach")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Survival", () => 		hp < 0.3 ),	// Slot 2
			new AandC( "Flank" 			),	// Slot 3
			new AandC( "Nether Blast" 	),	// Slot 1
			new AandC( "Hiss" 			),	// Slot 1
			new AandC( "Swarm" 			),	// Slot 2
			new AandC( "Apocalypse" 		),	// Slot 3
		}
                    ////////////-
                    // MARMOTS //
                    ////////////-
            ;
            else if (petName == "Borean Marmot" || petName == "Brown Marmot" || petName == "Brown Prairie Dog" || petName == "Prairie Dog" || petName == "Yellow-Bellied Marmot")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Burrow" 			),	// Slot 3
			new AandC( "Adrenaline Rush",  () => speed < speedEnemy && ! buff("Adrenaline") ),	// Slot 2
			new AandC( "Leap", () => 			 speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 3
			new AandC( "Chomp" 			),	// Slot 1
			new AandC( "Comeback" 		),	// Slot 1
			new AandC( "Crouch" 			),	// Slot 2
		}
                    //////////
                    // PIGS //
                    //////////
            ;
            else if (petName == "Golden Pig" || petName == "Lucky" || petName == "Mr. Wiggles" || petName == "Silver Pig")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Headbutt" 		),	// Slot 3
			new AandC( "Hoof" 			),	// Slot 1
			new AandC( "Diseased Bite" 	),	// Slot 1
			new AandC( "Crouch" 			),	// Slot 2
			new AandC( "Buried Treasure" ),	// Slot 2
			new AandC( "Uncanny Luck" 	),	// Slot 3
		}
                    ////////////-
                    // RABBITS //
                    ////////////-
            ;
            else if (petName == "Alpine Hare" || petName == "Arctic Hare" || petName == "Brown Rabbit" || petName == "Elfin Rabbit" || petName == "Grasslands Cottontail" || petName == "Hare" || petName == "Mountain Cottontail" || petName == "Rabbit" || petName == "Snowshoe Hare" || petName == "Snowshoe Rabbit" || petName == "Spring Rabbit" || petName == "Tolai Hare" || petName == "Tolai Hare Pup")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Burrow" 			),	// Slot 3
			new AandC( "Dodge" 			),	// Slot 2
			new AandC( "Adrenaline Rush",  () => speed < speedEnemy && ! buff("Adrenaline") ),	// Slot 2
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Flurry" 			),	// Slot 1
			new AandC( "Stampede"		),	// Slot 3
		}
            ;
            else if (petName == "Darkmoon Rabbit")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Burrow" 			),	// Slot 3
			new AandC( "Dodge" 			),	// Slot 2
			new AandC( "Vicious Streak",  () =>speed < speedEnemy && ! buff("Vicious Streak") ),	// Slot 2
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Huge, Sharp Teeth!"),	// Slot 1
			new AandC( "Stampede"		),	// Slot 3
		}
            ;
            else if (petName == "Wolpertinger")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Headbutt" 		),	// Slot 3
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Horn Attack" 	),	// Slot 1
			new AandC( "Flyby" 			),	// Slot 2
			new AandC( "Sleeping Gas" 	),	// Slot 2
			new AandC( "Rampage"			),	// Slot 3
		}
                    //////////////////-
                    // RATS && MICE //
                    //////////////////-
            ;
            else if (petName == "Black Rat" || petName == "Carrion Rat" || petName == "Fjord Rat" || petName == "Giant Sewer Rat" || petName == "Highlands Mouse" || petName == "Long-tailed Mole" || petName == "Mouse" || petName == "Rat" || petName == "Redridge Rat" || petName == "Stormwind Rat" || petName == "Stowaway Rat" || petName == "Tainted Rat" || petName == "Undercity Rat" || petName == "Wharf Rat" || petName == "Yakrat" || petName == "Prairie Mouse")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Survival", () =>		hp < 0.3 ),	// Slot 3
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Comeback" 		),	// Slot 1
			new AandC( "Flurry" 			),	// Slot 2
			new AandC( "Poison Fang" 	),	// Slot 2
			new AandC( "Stampede" 		),	// Slot 3
		}
            ;
            else if (petName == "Grotto Vole" || petName == "Whiskers the Rat")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Survival", () => 		hp < 0.3 ),	// Slot 2
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Flurry" 			),	// Slot 1
			new AandC( "Sting" 			),	// Slot 2
			new AandC( "Stampede" 		),	// Slot 3
			new AandC( "Comeback"		),	// Slot 3
		}
            ;
            else if (petName == "Malayan Quillrat" || petName == "Malayan Quillrat Pup" || petName == "Porcupette" || petName == "Silent Hedgehog")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Survival", () => 		hp < 0.3 ),	// Slot 3
			new AandC( "Spiked Skin",  () =>  ! buff("Spiked Skin") ),	// Slot 2
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Poison Fang" 	),	// Slot 1
			new AandC( "Counterstrike" 	),	// Slot 2
			new AandC( "Powerball"		),	// Slot 3
		}
                    //////////-
                    // SHEEP //
                    //////////-
            ;
            else if (petName == "Black Lamb" || petName == "Elwynn Lamb")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Headbutt" 		),	// Slot 3
			new AandC( "Hoof" 			),	// Slot 1
			new AandC( "Chew" 			),	// Slot 1
			new AandC( "Comeback" 		),	// Slot 2
			new AandC( "Sooth" 			),	// Slot 2
			new AandC( "Rampage"			),	// Slot 3
		}
                    //////////////////////
                    // SKUNKS && COONS //
                    //////////////////////
            ;
            else if (petName == "Bandicoon" || petName == "Bandicoon Kit" || petName == "Masked Tanuki" || petName == "Masked Tanuki Pup" || petName == "Shy Bandicoon")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Survival", () => 		hp < 0.3 ),	// Slot 2
			new AandC( "Poison Fang",  () =>  ! debuff("Poisoned") ),	// Slot 3
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Tongue Lash" 	),	// Slot 1
			new AandC( "Counterstrike" 	),	// Slot 2
			new AandC( "Powerball"		),	// Slot 3
		}
            ;
            else if (petName == "Highlands Skunk" || petName == "Mountain Skunk" || petName == "Skunk" || petName == "Stinker")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Flurry" 			),	// Slot 1
			new AandC( "Rake" 			),	// Slot 2
			new AandC( "Perk Up" 		),	// Slot 2
			new AandC( "Stench" 			),	// Slot 3
			new AandC( "Bleat"			),	// Slot 3
		}
                    ////////////
                    // SNAILS //
                    ////////////
            ;
            else if (petName == "Rapana Whelk" || petName == "Rusty Snail" || petName == "Scooter the Snail" || petName == "Shimmershell Snail" || petName == "Silkbead Snail")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Acidic Goo",  () =>	! debuff("Acidic Goo") ),	// Slot 2
			new AandC( "Shell Shield",  () =>  ! buff("Shell Shield") ),	// Slot 2
			new AandC( "Headbutt"		),	// Slot 3
			new AandC( "Dive" 			),	// Slot 3
			new AandC( "Ooze Touch" 		),	// Slot 1
			new AandC( "Absorb" 			),	// Slot 1
		}
                    //////////////-
                    // SQUIRRELS //
                    //////////////-
            ;
            else if (petName == "Alpine Chipmunk" || petName == "Grizzly Squirrel" || petName == "Nuts" || petName == "Red-Tailed Chipmunk" || petName == "Squirrel")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Adrenaline Rush",  () => speed < speedEnemy && ! buff("Adrenaline") ),	// Slot 2
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Woodchipper" 	),	// Slot 1
			new AandC( "Crouch" 			),	// Slot 2
			new AandC( "Nut Barrage" 	),	// Slot 3
			new AandC( "Stampede" 		),	// Slot 3
		}
            ;
            else if (petName == "Blighted Squirrel")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Adrenaline Rush",  () => speed < speedEnemy && ! buff("Adrenaline") ),	// Slot 2
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Woodchipper" 	),	// Slot 1
			new AandC( "Crouch" 			),	// Slot 2
			new AandC( "Rabid Strike" 	),	// Slot 3
			new AandC( "Stampede" 		),	// Slot 3
		}
                    //////////////////-
                    // MISCELLANEOUS //
                    //////////////////-
            ;
            else if (petName == "Lucky Quilen Cub" || petName == "Perky Pug")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Burrow" 			),	// Slot 3
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Comeback" 		),	// Slot 1
			new AandC( "Perk Up" 		),	// Slot 2
			new AandC( "Buried Treasure" ),	// Slot 2
			new AandC( "Trample" 		),	// Slot 3
		}
            ;
            else if (petName == "Porcupette")
                critter_abilities = new List<AandC>() 
		{
			new AandC( "Survival", () => 		hp < 0.3 ),	// Slot 3
			new AandC( "Spiked Skin",  () =>  ! buff("Spiked Skin") ),	// Slot 2
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Poison Fang" 	),	// Slot 1
			new AandC( "Counterstrike" 	),	// Slot 2
			new AandC( "Powerball" 		),	// Slot 3
		};
            //////////////////-

            else // Unknown critter
            {
                Logger.Alert("Unknown critter pet: " + petName);
                return null;
            }
            return critter_abilities;
        }
    }
}