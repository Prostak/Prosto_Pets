//////////-
// MAGIC //
//////////-

using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Magic : PetTacticsBase
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

            List<AandC> magic_abilities;



////////////
// DEMONS //
////////////
if( petName == "Minfernal" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Immolation", () => 		! buff("Immolation") ),	// Slot 2
			new AandC( "Crush" 			),	// Slot 1
			new AandC( "Immolate" 		),	// Slot 1
			new AandC( "Extra Plating" 	),	// Slot 2
			new AandC( "Meteor Strike" 	),	// Slot 3
			new AandC( "Explode" 		),	// Slot 3
		}
;else if(petName == "Mini Diablo" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Blast of Hatred" ),	// Slot 1
			new AandC( "Call of Darkness"),	// Slot 2
			new AandC( "Agony" 			),	// Slot 2
			new AandC( "Weakness" 		),	// Slot 3
			new AandC( "Bone Prison" 	),	// Slot 3
		}
;else if(petName == "Twilight Fiendling" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Leap", () => 			speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC( "Creepy Chomp" 	),	// Slot 1
			new AandC( "Rake" 			),	// Slot 1
			new AandC( "Creeping Ooze" 	),	// Slot 2
			new AandC( "Andrenal Glands" ),	// Slot 3
			new AandC( "Siphone Life" 	),	// Slot 3
		}
;else if(petName == "Lesser Voidcaller" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Curse of Doom" 	),	// Slot 3
			new AandC( "Shadow Shock" 	),	// Slot 1
			new AandC( "Nether Blast"	),	// Slot 1
			new AandC( "Siphon Life"		),	// Slot 2
			new AandC( "Prismatic Barrier"),	// Slot 2
			new AandC( "Drain Power" 	),	// Slot 3
		}
;else if(petName == "Netherspace Abyssal" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Crush"			),	// Slot 1
			new AandC( "Immolate"		),	// Slot 1
			new AandC( "Immolation"		),	// Slot 2
			new AandC( "Explode"			),	// Slot 2
			new AandC( "Meteor Strike" 	),	// Slot 3
			new AandC( "Nether Gate" 	),	// Slot 3
		}
////////////////////////
// JEWELED COMPANIONS //
////////////////////////
;else if(petName == "Jade Owl" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Cyclone", () =>			! debuff("Cyclone") ),	// Slot 3
			new AandC( "Hawk Eye",	() =>		! buff("Hawk Eye") ),	// Slot 2
			new AandC( "Lift-Off" 		),	// Slot 3
			new AandC( "Slicing Wind" 	),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Adrenaline Rush" ),	// Slot 2
		}
;else if(petName == "Jade Tiger" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Devour", () => 			hpEnemy < 0.20 ),	// Slot 3,  if( we kill the enemy with Devour, we restore health
			new AandC( "Jade Claw" 		),	// Slot 1
			new AandC( "Pounce" 			),	// Slot 1
			new AandC( "Rake" 			),	// Slot 2
			new AandC( "Jadeskin" 		),	// Slot 2
			new AandC( "Prowl" 			),	// Slot 3
		}
;else if(petName == "Onyx Panther" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Leap", () => 			speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 3
			new AandC( "Claw" 			),	// Slot 1
			new AandC( "Onyx Bite" 		),	// Slot 1
			new AandC( "Stoneskin" 		),	// Slot 2
			new AandC( "Roar" 			),	// Slot 2
			new AandC( "Stone Rush" 		),	// Slot 3
		}
;else if(petName == "Zipao Tiger" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Devour", () => 			hpEnemy < 0.20 ),	// Slot 3,  if( we kill the enemy with Devour, we restore health
			new AandC( "Onyx Bite" 		),	// Slot 1
			new AandC( "Pounce" 			),	// Slot 1
			new AandC( "Rake" 			),	// Slot 2
			new AandC( "Stoneskin" 		),	// Slot 2
			new AandC( "Prowl" 			),	// Slot 3
		}
////////////////////////
// LANTERNS && LAMPS //
////////////////////////
;else if(petName == "Enchanted Lantern" || petName == "Festival Lantern" || petName == "Lunar Lantern" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Beam" 			),	// Slot 1
			new AandC( "Burn" 			),	// Slot 1
			new AandC( "Illuminate" 		),	// Slot 2
			new AandC( "Flash" 			),	// Slot 2
			new AandC( "Soul Ward" 		),	// Slot 3
			new AandC( "Light" 			),	// Slot 3
		}
;else if(petName == "Magic Lamp" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Beam" 			),	// Slot 1
			new AandC( "Arcane Blast" 	),	// Slot 1
			new AandC( "Sear Magic" 		),	// Slot 2
			new AandC( "Gravity" 		),	// Slot 2
			new AandC( "Soul Ward" 		),	// Slot 3
			new AandC( "Wish" 			),	// Slot 3
		}
//////////////////////
// OOZES && SLIMES //
//////////////////////
;else if(petName == "Jade Oozeling" || petName == "Oily Slimeling" || petName == "Toxic Wasteling" || petName == "Disgusting Oozeling" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Acidic Goo",  () =>	! debuff("Acidic Goo") ),	// Slot 3
			new AandC( "Ooze Touch" 		),	// Slot 1
			new AandC( "Absorb" 			),	// Slot 1
			new AandC( "Corrosion" 		),	// Slot 2
			new AandC( "Creeping Ooze" 	),	// Slot 2
			new AandC( "Expunge" 		),	// Slot 3
		}
;else if(petName == "Viscidus Globule" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Ooze Touch" 		),	// Slot 1
			new AandC( "Acid Touch" 		),	// Slot 1
			new AandC( "Weakness" 		),	// Slot 2
			new AandC( "Poison Spit" 	),	// Slot 2
			new AandC( "Expunge" 		),	// Slot 3
			new AandC( "Creeping Ooze" 	),	// Slot 3
		}
;else if(petName == "Filthling" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Dreadful Breath" ),	// Slot 1
			new AandC( "Absorb" 			),	// Slot 1
			new AandC( "Stench" 			),	// Slot 2
			new AandC( "Expunge" 		),	// Slot 2
			new AandC( "Corrosion" 		),	// Slot 3
			new AandC( "Creeping Ooze" 	),	// Slot 3
		}
;else if(petName == "Living Fluid" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Acidic Goo",  () =>	! debuff("Acidic Goo") ),	// Slot 2
			new AandC( "Ooze Touch" 		),	// Slot 1
			new AandC( "Absorb" 			),	// Slot 1
			new AandC( "Corrosion" 		),	// Slot 2
			new AandC( "Expunge" 		),	// Slot 3
			new AandC( "Evolution"		),	// Slot 3
		}
;else if(petName == "Viscous Horror" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Ooze Touch" 		),	// Slot 1
			new AandC( "Absorb" 			),	// Slot 1
			new AandC( "Corrosion" 		),	// Slot 2
			new AandC( "Plagued Blood" 	),	// Slot 2
			new AandC( "Expunge" 		),	// Slot 3
			new AandC( "Evolution" 		),	// Slot 3
		}
//////////////-
// WYRMLINGS //
//////////////-
;else if(petName == "Mana Wyrmling" || petName == "Shimmering Wyrmling" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Feedback" 		),	// Slot 1
			new AandC( "Flurry" 			),	// Slot 1
			new AandC( "Drain Power" 	),	// Slot 2
			new AandC( "Amplify Magic" 	),	// Slot 2
			new AandC( "Mana Surge" 		),	// Slot 3
			new AandC( "Deflection" 		),	// Slot 3
		}
//////////////////-
// MISCELLANEOUS //
//////////////////-
;else if(petName == "Arcane Eye" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Focused Beams" 	),	// Slot 1
			new AandC( "Physic Blast" 	),	// Slot 1
			new AandC( "Eyeblast" 		),	// Slot 2
			new AandC( "Drain Power" 	),	// Slot 2
			new AandC( "Interrupting Gaze"),	// Slot 3
			new AandC( "Mana Surge" 		),	// Slot 3
		}
;else if(petName == "Darkmoon Eye" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Laser" 			),	// Slot 1
			new AandC( "Focused Beams" 	),	// Slot 1
			new AandC( "Eyeblast" 		),	// Slot 2
			new AandC( "Inner Vision" 	),	// Slot 2
			new AandC( "Darkmoon Curse" 	),	// Slot 3
			new AandC( "Interrupting Gaze"),	// Slot 3
		}
;else if(petName == "Enchanted Broom" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Broom" 			),	// Slot 1
			new AandC( "Batter" 			),	// Slot 1
			new AandC( "Sandstorm" 		),	// Slot 2
			new AandC( "Sweep" 			),	// Slot 2
			new AandC( "Clean-Up" 		),	// Slot 3
			new AandC( "Wind-Up" 		),	// Slot 3
		}
;else if(petName == "Ethereal Soul-Trader" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Punch" 			),	// Slot 1
			new AandC( "Beam" 			),	// Slot 1
			new AandC( "Soul Ward" 		),	// Slot 2
			new AandC( "Inner Vision" 	),	// Slot 2
			new AandC( "Soulrush" 		),	// Slot 3
			new AandC( "Life Exchange" 	),	// Slot 3
		}
;else if(petName == "Gusting Grimoire" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Fel Immolate" 	),	// Slot 1
			new AandC( "Shadow Shock" 	),	// Slot 1
			new AandC( "Agony" 			),	// Slot 2
			new AandC( "Amplify Magic" 	),	// Slot 2
			new AandC( "Meteor Strike" 	),	// Slot 3
			new AandC( "Curse of Doom" 	),	// Slot 3
		}
;else if(petName == "Legs" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Laser" 			),	// Slot 1
			new AandC( "Pump" 			),	// Slot 1
			new AandC( "Surge of Power" 	),	// Slot 2
			new AandC( "Gravity" 		),	// Slot 2
			new AandC( "Focused Beams" 	),	// Slot 3
			new AandC( "Whirlpool" 		),	// Slot 3
		}
;else if(petName == "Lofty Libram" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Arcane Blast" 	),	// Slot 1
			new AandC( "Shadow Shock" 	),	// Slot 1
			new AandC( "Arcane Explosion"),	// Slot 2
			new AandC( "Amplify Magic" 	),	// Slot 2
			new AandC( "Inner Vision" 	),	// Slot 3
			new AandC( "Curse of Doom" 	),	// Slot 3
		}
;else if(petName == "Mini Mindslayer" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Eyeblast" 		),	// Slot 1
			new AandC( "Mana Surge" 		),	// Slot 1
			new AandC( "Amplify Magic" 	),	// Slot 2
			new AandC( "Inner Vision" 	),	// Slot 2
			new AandC( "Interrupting Gaze"),	// Slot 3
			new AandC( "Life Exchange" 	),	// Slot 3
		}
;else if(petName == "Nordrassil Wisp" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Beam" 			),	// Slot 1
			new AandC( "Light" 			),	// Slot 1
			new AandC( "Flash" 			),	// Slot 2
			new AandC( "Arcane Blast" 	),	// Slot 2
			new AandC( "Soul Ward" 		),	// Slot 3
			new AandC( "Arcane Explosion"),	// Slot 3
		}
;else if(petName == "Spectral Cub" || petName == "Spectral Tiger Cub" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Leap", () => 			speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 3
			new AandC( "Claw" 			),	// Slot 1
			new AandC( "Rend" 			),	// Slot 1
			new AandC( "Evanescence" 	),	// Slot 2
			new AandC( "Spectral Strike" ),	// Slot 2
			new AandC( "Prowl" 			),	// Slot 3
		}
;else if(petName == "Spectral Porcupette" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Powerball" 		),	// Slot 1
			new AandC( "Spectral Strike" ),	// Slot 2
			new AandC( "Spirit Spikes" 	),	// Slot 2
			new AandC( "Illusionary Barrier" ),	// Slot 3
			new AandC( "Spectral Spine" 	),	// Slot 3
		}
;else if(petName == "Willy" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Tongue Lash" 	),	// Slot 1
			new AandC( "Focused Beams" 	),	// Slot 1
			new AandC( "Interrupting Gaze"),	// Slot 2
			new AandC( "Eye Blast" 		),	// Slot 2
			new AandC( "Agony" 			),	// Slot 3
			new AandC( "Dark Simulacrum" ),	// Slot 3
		}
;else if(petName == "Coilfang Stalker" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Laser" 			),	// Slot 1
			new AandC( "Focused Beams" 	),	// Slot 1
			new AandC( "Gravity"			),	// Slot 2
			new AandC( "Illusionary Barrier"),	// Slot 2
			new AandC( "Surge of Power" 	),	// Slot 3
			new AandC( "Amplify Magic"	),	// Slot 3
		}
////////////////////-
// ZERG COMPANIONS //
////////////////////-
;else if(petName == "Baneling" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Centrifugal Hooks"),	// Slot 2
			new AandC( "Adrenal Glands" 	),	// Slot 2
			new AandC( "Burrow" 			),	// Slot 3
			new AandC( "Baneling Burst" 	),	// Slot 3
		}
;else if(petName == "Zergling" )
	magic_abilities = new List<AandC>() 
		{
			new AandC( "Metabolic Boost", () =>		speed < speedEnemy && ! buff("Metabolic Boost") ),	// Slot 2
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Flank" 			),	// Slot 1
			new AandC( "Adrenal Glands" 	),	// Slot 2
			new AandC( "Consume" 		),	// Slot 3
			new AandC( "Zergling Rush" 	),	// Slot 3
		};
//////////////////-

else // Unknown pet
{
    Logger.Alert("Unknown magic pet: " + petName);
    return null;
}
return magic_abilities;
        }
    }
}

