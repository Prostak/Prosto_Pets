////////////
// UNDEAD //
////////////

using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Undead : PetTacticsBase
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

            List<AandC> undead_abilities;

//////////////////////-
// DISEASED CRITTERS //
//////////////////////-
            if (petName == "Blighted Squirrel")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Scratch" 		),	// Slot 1
			new AandC( "Woodchipper" 	),	// Slot 1
			new AandC( "Adrenaline Rush" ),	// Slot 2
			new AandC( "Crouch" 			),	// Slot 2
			new AandC( "Rabid Strike" 	),	// Slot 3
			new AandC( "Stampede" 		),	// Slot 3
		}
            ;
            else if (petName == "Blighthawk")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 3
			new AandC( "Lift-Off" 		),	// Slot 3
			new AandC( "Infected Claw" 	),	// Slot 1
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Consume Corpse" 	),	// Slot 2
			new AandC( "Ghostly Bite" 	),	// Slot 2
		}
            ;
            else if (petName == "Giant Bone Spider")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Bone Bite" 		),	// Slot 1
			new AandC( "Poison Spit" 	),	// Slot 1
			new AandC( "Sticky Web" 		),	// Slot 2
			new AandC( "Siphon Life" 	),	// Slot 2
			new AandC( "Leech Life" 		),	// Slot 3
			new AandC( "Death Grip" 		),	// Slot 3
		}
            ;
            else if (petName == "Infected Fawn")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Diseased Bite" 	),	// Slot 1
			new AandC( "Flurry" 			),	// Slot 1
			new AandC( "Adrenaline Rush" ),	// Slot 2
			new AandC( "Consume Corpse" 	),	// Slot 2
			new AandC( "Siphon Life" 	),	// Slot 3
			new AandC( "Death && Decay" ),	// Slot 3
		}
            ;
            else if (petName == "Infected Squirrel")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Diseased Bite" 	),	// Slot 1
			new AandC( "Creeping Fungus" ),	// Slot 1
			new AandC( "Rabid Strike" 	),	// Slot 2
			new AandC( "Stampede" 		),	// Slot 2
			new AandC( "Consume" 		),	// Slot 3
			new AandC( "Corpse Explosion" ),	// Slot 3
		}
            ;
            else if (petName == "Infested Bear Cub")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Diseased Bite" 	),	// Slot 1
			new AandC( "Roar" 			),	// Slot 1
			new AandC( "Bash" 			),	// Slot 2
			new AandC( "Hibernate" 		),	// Slot 2
			new AandC( "Maul" 			),	// Slot 3
			new AandC( "Corpse Explosion" ),	// Slot 3
		}
            ;
            else if (petName == "Mr. Bigglesworth")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Claw" 			),	// Slot 1
			new AandC( "Pounce" 			),	// Slot 1
			new AandC( "Ice Barrier" 	),	// Slot 2
			new AandC( "Frost Nova" 		),	// Slot 2
			new AandC( "Ice Tomb" 		),	// Slot 3
			new AandC( "Howling Blast" 	),	// Slot 3
		}
            ;
            else if (petName == "Scourged Whelpling")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Plagued Blood",     () =>	! debuff("Plagued Blood") ),	// Slot 3
			new AandC( "Death && Decay",    () =>   ! debuff("Death && Decay") ),	// Slot 2
			new AandC( "Dreadful Breath",   () =>     weather("Cleansing Rain") ),	// Slot 3
			new AandC( "Call Darkness",     () =>	! weather("Darkness") ),	// Slot 2
			new AandC( "Shadowflame" 	),	// Slot 1
			new AandC( "Tail Sweep" 		),	// Slot 1
		}
            ;
            else if (petName == "Stitched Pup")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Diseased Bite" 	),	// Slot 1
			new AandC( "Flurry" 			),	// Slot 1
			new AandC( "Rabid Strike" 	),	// Slot 2
			new AandC( "Howl" 			),	// Slot 2
			new AandC( "Consume Corpse" 	),	// Slot 3
			new AandC( "Plagued Blood" 	),	// Slot 3
		}
                    ////////////////////////-
                    // SKELETAL COMPANIONS //
                    ////////////////////////-
            ;
            else if (petName == "Fossilized Hatchling")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Ancient Blessing", () =>  ! buff("Ancient Blessing") || hp < 0.75 ),	// Slot 2
			new AandC( "Claw" 			),	// Slot 1
			new AandC( "Bone Bite" 		),	// Slot 1
			new AandC( "Death && Decay"	),	// Slot 2
			new AandC( "Bone Prison" 	),	// Slot 3
			new AandC( "BONESTORM" 		),	// Slot 3
		}
            ;
            else if (petName == "Frosty")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Shriek", () =>			! debuff("Attack Reduction") ),	// Slot 2
			new AandC( "Diseased Bite" 	),	// Slot 1
			new AandC( "Frost Breath" 	),	// Slot 1
			new AandC( "Call Blizzard" 	),	// Slot 2
			new AandC( "Ice Tomb" 		),	// Slot 3
			new AandC( "Blistering Cold" ),	// Slot 3
		}
            ;
            else if (petName == "Ghostly Skull")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Shadow Slash" 	),	// Slot 1
			new AandC( "Death Coil" 		),	// Slot 1
			new AandC( "Ghostly Bite" 	),	// Slot 2
			new AandC( "Spectral Strike"	),	// Slot 2
			new AandC( "Siphon Life" 	),	// Slot 3
			new AandC( "Unholy Ascension" ),	// Slot 3
		}
            ;
            else if (petName == "Landro's Lichling" || petName == "Lil' K.T.")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Shadow Slash" 	),	// Slot 1
			new AandC( "Howling Blast", () =>	debuff("Frost Nova") ),	// Slot 1
			new AandC( "Siphon Life" 	),	// Slot 2
			new AandC( "Death && Decay"	),	// Slot 2
			new AandC( "Frost Nova" 		),	// Slot 3
			new AandC( "Curse of Doom" 	),	// Slot 3
		}
                    ////////////////////-
                    // SPECTRAL BEINGS //
                    ////////////////////-
            ;
            else if (petName == "Lost of Lordaeron")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Curse of Doom", () =>	! debuff("Curse of Doom") ),	// Slot 3
			new AandC( "Shadow Slash" 	),	// Slot 1
			new AandC( "Absorb" 			),	// Slot 1
			new AandC( "Siphon Life" 	),	// Slot 2
			new AandC( "Arcane Explosion"),	// Slot 2
			new AandC( "Bone Prison" 	),	// Slot 3
		}
            ;
            else if (petName == "Restless Shadeling")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Shadow Shock" 	),	// Slot 1
			new AandC( "Arcane Blast" 	),	// Slot 1
			new AandC( "Plagued Blood" 	),	// Slot 2
			new AandC( "Death && Decay" ),	// Slot 2
			new AandC( "Death Coil" 		),	// Slot 3
			new AandC( "Phase Shift" 	),	// Slot 3
		}
            ;
            else if (petName == "Spirit Crab")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Shell Shield", 	() =>  ! buff("Shell Shield") ),	// Slot 3
			new AandC( "Snap" 			),	// Slot 1
			new AandC( "Amplify Magic" 	),	// Slot 1
			new AandC( "Surge" 			),	// Slot 2
			new AandC( "Whirlpool" 		),	// Slot 2
			new AandC( "Dark Simulacrum" ),	// Slot 3
		}
                    //////////////////////-
                    // VOODOO COMPANIONS //
                    //////////////////////-
            ;
            else if (petName == "Fetish Shaman" || petName == "Sen'jin Fetish" || petName == "Voodoo Figurine")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Shadow Slash" 	),	// Slot 1
			new AandC( "Flame Breath" 	),	// Slot 1
			new AandC( "Immolate" 		),	// Slot 2
			new AandC( "Wild Magic" 		),	// Slot 2
			new AandC( "Sear Magic" 		),	// Slot 3
			new AandC( "Dark Simulacrum" ),	// Slot 3
		}
                    //////////////////-
                    // MISCELLANEOUS //
                    //////////////////-
            ;
            else if (petName == "Crawling Claw")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Curse of Doom", () =>	! debuff("Curse of Doom") ),	// Slot 3
			new AandC( "Shadow Slash" 	),	// Slot 1
			new AandC( "Agony" 			),	// Slot 1
			new AandC( "Ancient" 		),	// Slot 2
			new AandC( "Death Grip" 		),	// Slot 2
			new AandC( "Dark Simulacrum" ),	// Slot 3
		}
            ;
            else if (petName == "Creepy Crate")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Devour", () => 			hpEnemy < 0.20 ),	// Slot 3,  if( we kill the enemy with Devour, we restore health
			new AandC( "Curse of Doom", () =>	! debuff("Curse of Doom") ),	// Slot 2
			new AandC( "Creepy Chomp" 	),	// Slot 1
			new AandC( "Agony" 			),	// Slot 1
			new AandC( "Death Grip" 		),	// Slot 2
			new AandC( "BONESTORM" 		),	// Slot 3
		}
            ;
            else if (petName == "Eye of the Legion")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Shadow Slash" 	),	// Slot 1
			new AandC( "Eyeblast" 		),	// Slot 1
			new AandC( "Agony" 			),	// Slot 2
			new AandC( "Gravity" 		),	// Slot 2
			new AandC( "Soul Ward" 		),	// Slot 3
			new AandC( "Dark Simulacrum" ),	// Slot 3
		}
            ;
            else if (petName == "Fungal Abomination")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Absorb" 			),	// Slot 1
			new AandC( "Consume" 		),	// Slot 1
			new AandC( "Creeping Fungus" ),	// Slot 2
			new AandC( "Leech Seed" 		),	// Slot 2
			new AandC( "Spore Shrooms" 	),	// Slot 3
			new AandC( "Stun Seed" 		),	// Slot 3
		}
            ;
            else if (petName == "Vampiric Batling")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Hawk Eye",	() =>	! buff("Hawk Eye") ),	// Slot 2
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Screech" 		),	// Slot 1
			new AandC( "Leech Life" 		),	// Slot 2
			new AandC( "Reckless Strike" ),	// Slot 3
			new AandC( "Nocturnal Strike" ),	// Slot 3
		}
            ;
            else if (petName == "Unborn Val'kyr")
                undead_abilities = new List<AandC>() 
		{
			new AandC( "Unholy Ascension", () =>  hp < 0.3 ),	// Slot 3
			new AandC( "Curse of Doom",    () => ! debuff("Curse of Doom") ),	// Slot 2
			new AandC( "Shadow Slash" 	),	// Slot 1
			new AandC( "Shadow Shock" 	),	// Slot 1
			new AandC( "Siphon Life" 	),	// Slot 2
			new AandC( "Haunt"			),	// Slot 3
		};
            //////////////////-
            else // Unknown undead
            {
                Logger.Alert("Unknown undead pet: " + petName);
                return null;
            }
            return undead_abilities;
        }
    }
}