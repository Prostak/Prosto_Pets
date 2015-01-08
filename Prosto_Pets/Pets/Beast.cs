////////////////
// BEAST //
////////////////  

using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Beast : PetTacticsBase
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

            List<AandC> beast_abilities;

            /////////////-
            // DRAENOR //
            /////////////-
            if (petName == "Mossbite Skitterer")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Gnaw",       ()=> speed > speedEnemy ),	// Slot 1
			new AandC("Ravage", 	() => hpEnemy < 0.2	),	// Slot 2
			new AandC("Puncture Wound", ()=> debuff("Poisoned") 	),	// Slot 3
			new AandC("Takedown",   ()=> debuff("Stunned") 			),	// Slot 1
			new AandC("Body Slam" 		),	// Slot 3
			new AandC("Gnaw" 			),	// Slot 1
			new AandC("Bite" 			),	// Slot 1
		};
            //////////-
// BEARS //
//////////-
            else if (petName == "Baby Blizzard Bear" || petName == "Poley")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Bite" 			),	// Slot 1
			new AandC("Roar" 			),	// Slot 1
			new AandC("Bash" 			),	// Slot 2
			new AandC("Hibernate" 		),	// Slot 2
			new AandC("Maul" 			),	// Slot 3
			new AandC("Call Blizzard" 	)	// Slot 3
		};
            else if (petName == "Darkshore Cub" || petName == "Dun Morogh Cub" || petName == "Hyjal Bear Cub" || petName == "Panda Cub")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Bite" 			),	// Slot 1
			new AandC("Roar" 			),	// Slot 1
			new AandC("Hibernate" 		),	// Slot 2
			new AandC("Bash" 			),	// Slot 2
			new AandC("Maul" 			),	// Slot 3
			new AandC("Rampage" 		)	// Slot 3
		};
            ////////////
            // CANINES //
            ////////////
            else if (petName == "Alpine Foxling" || petName == "Alpine Foxling Kit" || petName == "Arctic Fox Kit" || petName == "Fjord Worg Pup" || petName == "Fox Kit" || petName == "Worg Pup")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Dazzling Dance", () =>	speed < speedEnemy && ! buff("Dazzling Dance") ),	// Slot 3
			new AandC("Leap", 			() =>   speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 3
			new AandC("Bite" 			),	// Slot 1
			new AandC("Flurry" 			),	// Slot 1
			new AandC("Crouch" 			),	// Slot 2
			new AandC("Howl" 			)	// Slot 2
		};
            else if (petName == "Tito")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Cyclone",	() =>		 ! debuff("Cyclone") ),	// Slot 3
			new AandC("Bite" 			),	// Slot 1
			new AandC("Triple Snap" 	),	// Slot 1
			new AandC("Impale"			),	// Slot 2
			new AandC("Howl" 			),	// Slot 2
			new AandC("Buried Treasure" ),	// Slot 3
		};
            else if (petName == "Moon Moon")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Moon Fang"		),	// Slot 1
			new AandC("Bite" 			),	// Slot 1
			new AandC("Howl" 			),	// Slot 2
			new AandC("Crouch"			),	// Slot 2
			new AandC("Moon Tears" 		),	// Slot 3
			new AandC("Moon Dance" 		),	// Slot 3
		};
            //////////////-
            // DIREHORNS //
            //////////////-
            else if (petName == "Direhorn Runt" || petName == "Pygmy Direhorn" || petName == "Stunted Direhorn")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Trihorn Charge" 	),	// Slot 1
			new AandC("Trample" 		),	// Slot 1
			new AandC("Horn Attack" 	),	// Slot 2
			new AandC("Stampede" 		),	// Slot 2
			new AandC("Primal Cry" 		),	// Slot 3
			new AandC("Trihorn Shield" 	),	// Slot 3
		};
            ////////////-
            // FELINES //
            ////////////-
            else if (petName == "Black Tabby Cat" || petName == "Bombay Cat" || petName == "Calico Cat" || petName == "Cat" || petName == "Cheetah Cub" || petName == "Cornish Rex Cat" || petName == "Darkmoon Cub" || petName == "Nightsaber Cub" || petName == "Orange Tabby Cat" || petName == "Panther Cub" || petName == "Sand Kitten" || petName == "Siamese Cat" || petName == "Silver Tabby Cat" || petName == "Snow Cub" || petName == "White Kitten" || petName == "Winterspring Cub")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Devour", () =>			hpEnemy < 0.20 ),	// Slot 3,  if( we kill the enemy with Devour, we restore health
			new AandC("Claw" 			),	// Slot 1
			new AandC("Pounce" 			),	// Slot 1
			new AandC("Rake" 			),	// Slot 2
			new AandC("Screech" 		),	// Slot 2
			new AandC("Prowl" 			),	// Slot 3
		};
            else if (petName == "Feline Familiar")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Devour", () =>			hpEnemy < 0.20 ),	// Slot 3,  if( we kill the enemy with Devour, we restore health
			new AandC("Onyx Bite" 		),	// Slot 1
			new AandC("Pounce" 			),	// Slot 1
			new AandC("Stoneskin" 		),	// Slot 2
			new AandC("Call Darkness" 	),	// Slot 2
			new AandC("Prowl" 			),	// Slot 3
		};
            else if (petName == "Xu-Fu, Cub of Xuen")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Spirit Claws" 	),	// Slot 1
			new AandC("Bite" 			),	// Slot 1
			new AandC("Feed" 			),	// Slot 2
			new AandC("Moonfire" 		),	// Slot 2
			new AandC("Vengeance" 		),	// Slot 3
			new AandC("Prowl" 			),	// Slot 3
		};
            ////////////-
            // INSECTS //
            ////////////-
            else if (petName == "Devouring Maggot" || petName == "Festering Maggot" || petName == "Jungle Grub" || petName == "Larva" || petName == "Maggot" || petName == "Mr. Grubbs")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Leap", 	() =>		 ! buff("Speed Boost") && (speed < speedEnemy) ),	// Slot 3
			new AandC("Acidic Goo", () =>		 ! debuff("Acidic Goo") ),	// Slot 2
			new AandC("Chomp" 			),	// Slot 1
			new AandC("Consume" 		),	// Slot 1
			new AandC("Sticky Goo" 		),	// Slot 2
			new AandC("Burrow" 			),	// Slot 3
		};
            else if (petName == "Silithid Hatchling")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Survival", () =>		hp < 0.3 ),	// Slot 2
			new AandC("Devour", 	() =>		hpEnemy < 0.20 ),	// Slot 1,  if( we kill the enemy with Devour, we restore health
			new AandC("Scratch" 		),	// Slot 1
			new AandC("Hiss" 			),	// Slot 2
			new AandC("Swarm" 			),	// Slot 3
			new AandC("Sandstorm" 		),	// Slot 3
		};
            else if (petName == "Kovok")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Poison Fang" 	),	// Slot 1
			new AandC("Body Slam" 		),	// Slot 1
			new AandC("Pheromones" 		),	// Slot 2
			new AandC("Digest Brains" 	),	// Slot 2
			new AandC("Black Claw" 		),	// Slot 3
			new AandC("Puncture Wound" 	),	// Slot 3
		};
            ////////////-
            // LIZARDS //
            ////////////-
            else if (petName == "Ash Lizard" || petName == "Diemetradon Hatchling" || petName == "Horned Lizard" || petName == "Lizard Hatchling" || petName == "Plains Monitor" || petName == "Spiky Lizard" || petName == "Spiny Lizard" || petName == "Twilight Iguana")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Claw" 			),	// Slot 1
			new AandC("Quick Attack" 	),	// Slot 1
			new AandC("Screech" 		),	// Slot 2
			new AandC("Triple Snap" 	),	// Slot 2
			new AandC("Comeback" 		),	// Slot 3
			new AandC("Ravage" 			),	// Slot 3
		};
            else if (petName == "Scalded Basilisk Hatchling")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Bite" 			),	// Slot 1
			new AandC("Crystal Prison" 	),	// Slot 1
			new AandC("Roar" 			),	// Slot 2
			new AandC("Feign Death" 	),	// Slot 2
			new AandC("Thrash" 			),	// Slot 3
			new AandC("Screech" 		),	// Slot 3
		};
            else if (petName == "Warpstalker Hatchling")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Claw" 			),	// Slot 1
			new AandC("Blinkstrike" 	),	// Slot 1
			new AandC("Screech" 		),	// Slot 2
			new AandC("Triple Snap" 	),	// Slot 2
			new AandC("Ravage" 			),	// Slot 3
			new AandC("Comeback" 		),	// Slot 3
		};
            //////////////
            // PRIMATES //
            //////////////
            else if (petName == "Baby Ape" || petName == "Bananas" || petName == "Darkmoon Monkey")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Smash" 			),	// Slot 1
			new AandC("Rake" 			),	// Slot 1
			new AandC("Roar" 			),	// Slot 2
			new AandC("Clobber" 		),	// Slot 2
			new AandC("Banana Barrage" 	),	// Slot 3
			new AandC("Barrel Toss" 	),	// Slot 3
		};
            ////////////-
            // RAPTORS //
            ////////////-
            else if (petName == "Darting Hatchling" || petName == "Deviate Hatchling" || petName == "Gundrak Hatchling" || petName == "Lashtail Hatchling" || petName == "Leaping Hatchling" || petName == "Obsidian Hatchling" || petName == "Ravasaur Hatchling" || petName == "Razormaw Hatchling" || petName == "Razzashi Hatchling")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Devour", 	() =>		hpEnemy < 0.20 ),	// Slot 3,  if( we kill the enemy with Devour, we restore health
			new AandC("Leap", 		() =>	speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC("Bite" 			),	// Slot 1
			new AandC("Flank" 			),	// Slot 1
			new AandC("Screech" 		),	// Slot 2
			new AandC("Exposed Wounds" 	),	// Slot 3
		};
            else if (petName == "Zandalari Anklerender")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Devour", () =>		hpEnemy < 0.20 ),	// Slot 3,  if( we kill the enemy with Devour, we restore health
			new AandC("Leap", 	() =>		speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC("Black Claw", () => !debuff("Black Claw") 		),	// Slot 3
			new AandC("Bite" 			),	// Slot 1
			new AandC("Hunting Party" 	),	// Slot 1
			new AandC("Primal Cry" 		),	// Slot 2
			new AandC("Leap"            ),	// Slot 3    -  unconditional Leap           
		};
            else if (petName == "Zandalari Footslasher")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Leap", () =>			speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC("Bite" 			),	// Slot 1
			new AandC("Hunting Party" 	),	// Slot 1
			new AandC("Primal Cry" 		),	// Slot 2
			new AandC("Bloodfang" 		),	// Slot 3
			new AandC("Exposed Wounds" 	),	// Slot 3
		};
            else if (petName == "Zandalari Kneebiter")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Leap", () =>			speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 3
			new AandC("Black Claw", () => !debuff("Black Claw") ),	// Slot 2
			new AandC("Bite" 			),	// Slot 1
			new AandC("Hunting Party" 	),	// Slot 1
			new AandC("Screech" 		),	// Slot 2
			new AandC("Bloodfang" 		),	// Slot 3
			new AandC("Leap"            ),	// Slot 3    -  unconditional Leap           
		};
            else if (petName == "Zandalari Toenibbler")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Leap", () =>			speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC("Black Claw", () => !debuff("Black Claw") ),	// Slot 2
			new AandC("Bite" 			),	// Slot 1
			new AandC("Flank" 			),	// Slot 1
			new AandC("Primal Cry" 		),	// Slot 2
			new AandC("Bloodfang" 		),	// Slot 3
			new AandC("Leap"            ),	// Slot 3    -  unconditional Leap           
		};
            ////////////-
            // RODENTS //
            ////////////-
            else if (petName == "Bucktooth Flapper")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Survival", () =>		hp < 0.3 ),	// Slot 2
			new AandC("Tail Slap" 		),	// Slot 1
			new AandC("Gnaw" 			),	// Slot 1
			new AandC("Screech" 		),	// Slot 2
			new AandC("Woodchipper" 	),	// Slot 3
			new AandC("Chew" 			),	// Slot 3
		}
            ;
            else if (petName == "Clouded Hedgehog")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Survival", () =>		hp < 0.3 ),	// Slot 2
			new AandC("Counterstrike", () =>	speed < speedEnemy ),	// Slot 3
			new AandC("Bite" 			),	// Slot 1
			new AandC("Poison Fang" 	),	// Slot 1
			new AandC("Spiked Skin" 	),	// Slot 2
			new AandC("Powerball" 		),	// Slot 3
		}
            ;
            else if (petName == "Silent Hedgehog")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Survival", () =>		hp < 0.3 ),	// Slot 3
			new AandC("Bite" 			),	// Slot 1
			new AandC("Poison Fang" 	),	// Slot 1
			new AandC("Spiked Skin" 	),	// Slot 2
			new AandC("Counterstrike" 	),	// Slot 2
			new AandC("Powerball" 		),	// Slot 3
		}
            ;
            else if (petName == "Sumprush Rodent")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Survival", () =>		hp < 0.3 ),	// Slot 2
			new AandC("Bite" 			),	// Slot 1
			new AandC("Powerball" 		),	// Slot 1
			new AandC("Spirit Spikes" 	),	// Slot 2
			new AandC("Flank" 			),	// Slot 2
			new AandC("Vengeance" 		),	// Slot 3
		}
            ;
            else if (petName == "Vengeful Porcupette")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Survival", () =>		hp < 0.3 ),	// Slot 3
			new AandC("Gnaw" 			),	// Slot 1
			new AandC("Tail Slap" 		),	// Slot 1
			new AandC("Mudslide" 		),	// Slot 2
			new AandC("Poison Fang" 	),	// Slot 2
			new AandC("Stench" 			),	// Slot 3
		}
                    //////////////-
                    // SCORPIONS //
                    //////////////-
            ;
            else if (petName == "Crunchy Scorpion" || petName == "Durotar Scorpion" || petName == "Leopard Scorpid" || petName == "Scorpid" || petName == "Scorpling" || petName == "Stripe-Tailed Scorpid")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Crouch" 			),	// Slot 2
			new AandC("Sting", 	() =>		 ! debuff("Sting") ),	// Slot 3
			new AandC("Snap" 			),	// Slot 1
			new AandC("Triple Snap" 	),	// Slot 1
			new AandC("Screech" 		),	// Slot 2
			new AandC("Rampage" 		),	// Slot 3
		}
                    ////////////
                    // SNAKES //
                    ////////////
            ;
            else if (petName == "Adder" || petName == "Albino Snake" || petName == "Ash Viper" || petName == "Black Kingsnake" || petName == "Brown Snake" || petName == "Cobra Hatchling" || petName == "Coral Adder" || petName == "Coral Snake" || petName == "Crimson Snake" || petName == "Emerald Boa" || petName == "Grove Viper" || petName == "King Snake" || petName == "Moccasin" || petName == "Rat Snake" || petName == "Rattlesnake" || petName == "Rock Viper" || petName == "Sidewinder" || petName == "Snake" || petName == "Temple Snake" || petName == "Tree Python" || petName == "Water Snake" || petName == "Zooey Snake")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Burrow" 			),	// Slot 3
			new AandC("Bite" 			),	// Slot 1
			new AandC("Poison Fang" 	),	// Slot 1
			new AandC("Hiss" 			),	// Slot 2
			new AandC("Counterstrike" 	),	// Slot 2
			new AandC("Vicious Fang" 	),	// Slot 3
		}
            ;
            else if (petName == "Elder Python")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Bite" 			),	// Slot 1
			new AandC("Poison Fang" 	),	// Slot 1
			new AandC("Sting" 			),	// Slot 2
			new AandC("Huge Fang" 		),	// Slot 2
			new AandC("Burrow" 			),	// Slot 3
			new AandC("Slither" 		),	// Slot 3
		}
            ;
            else if (petName == "Death Adder Hatchling")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Burrow" 			),	// Slot 3
			new AandC("Poison Fang" 	),	// Slot 1
			new AandC("Vicious Fang" 	),	// Slot 1
			new AandC("Puncture Wound" 	),	// Slot 2
			new AandC("Crouch" 			),	// Slot 2
			new AandC("Blinding Poison" ),	// Slot 3
		}
                    ////////////
                    // SPIDERS //
                    ////////////
            ;
            else if (petName == "Amethyst Spiderling" || petName == "Ash Spiderling" || petName == "Desert Spider" || petName == "Dusk Spiderling" || petName == "Feverbite Hatchling" || petName == "Forest Spiderling" || petName == "Jumping Spider" || petName == "Skittering Cavern Crawler" || petName == "Smolderweb Hatchling" || petName == "Spider" || petName == "Twilight Spider" || petName == "Venomspitter Hatchling" || petName == "Widow Spiderling")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Sticky Web",	() =>	 ! debuff("Webbed") ),  // Slot 2
			new AandC("Brittle Webbing", () =>! debuff("Brittle Webbing") ),  // Slot 2
			new AandC("Leech Life",	() =>	debuff("Webbed") || debuff("Brittle Webbing") ),  // Slot 3
			new AandC("Spiderling Swarm", () => debuff("Webbed") || debuff("Brittle Webbing") ),  // Slot 3
			new AandC("Strike" 			),	// Slot 1
			new AandC("Poison Spit" 	),	// Slot 1
		}
            ;
            else if (petName == "Crystal Spider")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Leech Life", () =>		hp < 0.7 ),	// Slot 3
			new AandC("Strike" 			),	// Slot 1
			new AandC("Crystal Prison" 	),	// Slot 1
			new AandC("Sticky Web" 		),	// Slot 2
			new AandC("Brittle Webbing" ),	// Slot 2
			new AandC("Spiderling Swarm"),	// Slot 3
		}
            ;
            else if (petName == "Molten Hatchling")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Burn" 			),	// Slot 1
			new AandC("Leech Life" 		),	// Slot 1
			new AandC("Sticky Web" 		),	// Slot 2
			new AandC("Cauterize" 		),	// Slot 2
			new AandC("Magma Wave" 		),	// Slot 3
			new AandC("Brittle Webbing" ),	// Slot 3
		}
                    //////////////-
                    // UNGULATES //
                    //////////////-
            ;
            else if (petName == "Clefthoof Runt")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Survival", () =>		hp < 0.3 ),	// Slot 2
			new AandC("Smash" 			),	// Slot 1
			new AandC("Trample" 		),	// Slot 1
			new AandC("Trumpet Strike" 	),	// Slot 2
			new AandC("Horn Attack" 	),	// Slot 3
			new AandC("Stampede"		),	// Slot 3
		}
            ;
            else if (petName == "Giraffe Calf")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Survival", () =>		hp < 0.3 ),	// Slot 2
			new AandC("Headbutt" 		),	// Slot 3
			new AandC("Hoof" 			),	// Slot 1
			new AandC("Stampede" 		),	// Slot 1
			new AandC("Tranquility" 	),	// Slot 2
			new AandC("Bleat"			),	// Slot 3
		}
            ;
            else if (petName == "Little Black Ram" || petName == "Summit Kid")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Headbutt" 		),	// Slot 3
			new AandC("Hoof" 			),	// Slot 1
			new AandC("Chew" 			),	// Slot 1
			new AandC("Comeback" 		),	// Slot 2
			new AandC("Soothe" 			),	// Slot 2
			new AandC("Stampede"		),	// Slot 3
		}
            ;
            else if (petName == "Stunted Shardhorn")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Survival", () =>		hp < 0.3 ),	// Slot 1
			new AandC("Smash" 			),	// Slot 1
			new AandC("Trample" 		),	// Slot 2
			new AandC("Horn Attack" 	),	// Slot 2
			new AandC("Trumpet Strike" 	),	// Slot 3
			new AandC("Stampede"		),	// Slot 3
		}
            ;
            else if (petName == "Zao, Calfling of Niuzao")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Headbutt" 		),	// Slot 2
			new AandC("Trample" 		),	// Slot 1
			new AandC("Horn Gore" 		),	// Slot 1
			new AandC("Wish" 			),	// Slot 2
			new AandC("Niuzao's Charge" ),	// Slot 3
			new AandC("Dominance"		),	// Slot 3
		}
                    //////////////////-
                    // MISCELLANEOUS //
                    //////////////////-
            ;
            else if (petName == "Mountain Panda")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Bite" 			),	// Slot 1
			new AandC("Scratch" 		),	// Slot 1
			new AandC("Cute Face" 		),	// Slot 2
			new AandC("Rock Barrage" 	),	// Slot 2
			new AandC("Burrow" 			),	// Slot 3
			new AandC("Mudslide"		),	// Slot 3
		}
            ;
            else if (petName == "Ravager Hatchling")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Devour", () =>			hpEnemy < 0.20 ),	// Slot 3,  if( we kill the enemy with Devour, we restore health
			new AandC("Bite" 			),	// Slot 1
			new AandC("Rend" 			),	// Slot 1
			new AandC("Screech" 		),	// Slot 2
			new AandC("Sting" 			),	// Slot 2
			new AandC("Rampage"			),	// Slot 3
		}
            ;
            else if (petName == "Red Panda")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Bite" 			),	// Slot 1
			new AandC("Scratch" 		),	// Slot 1
			new AandC("Crouch" 			),	// Slot 2
			new AandC("Cute Face" 		),	// Slot 2
			new AandC("Perk Up" 		),	// Slot 3
			new AandC("Hibernate"		),	// Slot 3
		}
            ;
            else if (petName == "Snowy Panda")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Bite" 			),	// Slot 1
			new AandC("Snowball" 		),	// Slot 1
			new AandC("Cute Face" 		),	// Slot 2
			new AandC("Call Blizzard" 	),	// Slot 2
			new AandC("Crouch" 			),	// Slot 3
			new AandC("Ice Barrier"		),	// Slot 3
		}
            ;
            else if (petName == "Sunfur Panda")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Bite" 			),	// Slot 1
			new AandC("Scratch" 		),	// Slot 1
			new AandC("Hibernate" 		),	// Slot 2
			new AandC("Cute Face" 		),	// Slot 2
			new AandC("Sunlight" 		),	// Slot 3
			new AandC("Crouch"			),	// Slot 3
		}
            ;
            else if (petName == "Wind Rider Cub")
                beast_abilities = new List<AandC>() 
		{
			new AandC("Lift-Off"		),	// Slot 3
			new AandC("Bite" 			),	// Slot 1
			new AandC("Squawk" 			),	// Slot 1
			new AandC("Slicing Wind" 	),	// Slot 2
			new AandC("Adrenaline Rush" ),	// Slot 2
			new AandC("Flock" 			),	// Slot 3
		};
            //////////////////-
            //////////////////-
            else // Unknown beast
            {
                Logger.Alert("Unknown beast pet: " + petName);
                return null;
            }
            return beast_abilities;
        }
    }
}