////////////////
// MECHANICAL //
////////////////

using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Mechanical : PetTacticsBase
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

            List<AandC> mechanical_abilities;




////////////////////////
// LIFELIKE CREATIONS //
////////////////////////
if( petName == "Fluxfire Feline" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Overtune", () => 		speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC( "Claw" 			),	// Slot 1
			new AandC( "Pounce" 			),	// Slot 1
			new AandC( "Flux" 			),	// Slot 2
			new AandC( "Prowl" 			),	// Slot 3
			new AandC( "Supercharge" 	),	// Slot 3
		}
;else if(petName == "Lifelike Toad" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Repair", () => 			hp < 0.7 ),	// Slot 3
			new AandC( "Water Jet" 		),	// Slot 1
			new AandC( "Tongue Lash" 	),	// Slot 1
			new AandC( "Healing Wave" 	),	// Slot 2
			new AandC( "Cleansing Rain" 	),	// Slot 2
			new AandC( "Frog Kiss" 		),	// Slot 3
		}
;else if(petName == "Tranquil Mechanical Yeti" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Metal Fist" 		),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Call Lightning" 	),	// Slot 2
			new AandC( "Call Blizzard" 	),	// Slot 2
			new AandC( "Supercharge" 	),	// Slot 3
			new AandC( "Ion Cannon" 		),	// Slot 3
		}
////////////////////////-
// MECHANIZED CRITTERS //
////////////////////////-
;else if(petName == "Anodized Robo Cub" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Repair", () => 			hp < 0.7 ),	// Slot 2
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Demolish" 		),	// Slot 1
			new AandC( "Rebuild" 		),	// Slot 2
			new AandC( "Maul" 			),	// Slot 3
			new AandC( "Supercharge" 	),	// Slot 3
		}
;else if(petName == "Cogblade Raptor" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Repair", () => 			hp < 0.7 ),	// Slot 3
			new AandC( "Overtune", () =>		speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC( "Bite" 			),	// Slot 1
			new AandC( "Batter" 			),	// Slot 1
			new AandC( "Screech" 		),	// Slot 2
			new AandC( "Exposed Wounds" 	),	// Slot 3
		}
;else if(petName == "De-Weaponized Mechanical Companion" )
	mechanical_abilities = new List<AandC>()
		{
			new AandC( "Repair", () => 			hp < 0.7 ),	// Slot 3
			new AandC( "Overtune", () => 		speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC( "Metal Fist" 		),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Extra Plating" 	),	// Slot 2
			new AandC( "Demolish" 		),	// Slot 3
		}
;else if(petName == "Mechanical Chicken" || petName == "Robo-Chick" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Overtune", () => 		speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Batter" 			),	// Slot 1
			new AandC( "Rebuild" 		),	// Slot 2
			new AandC( "Supercharge" 	),	// Slot 3
			new AandC( "Wind-Up" 		),	// Slot 3
		}
;else if(petName == "Mechanical Pandaren Dragonling" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Breath" 			),	// Slot 1
			new AandC( "Thunderbolt" 	),	// Slot 1
			new AandC( "Flyby" 			),	// Slot 2
			new AandC( "Decoy" 			),	// Slot 2
			new AandC( "Bombing Run" 	),	// Slot 3
			new AandC( "Explode" 		),	// Slot 3
		}
;else if(petName == "Mechanical Squirrel" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Repair", () => 			hp < 0.7 ),	// Slot 3
			new AandC( "Overtune", () => 		speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC( "Metal Fist" 		),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Extra Plating" 	),	// Slot 2
			new AandC( "Wind-Up" 		),	// Slot 3
		}
;else if(petName == "Mechanopeep" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Repair", () => 			hp < 0.7 ),	// Slot 3
			new AandC( "Overtune", () => 		speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Rebuild" 		),	// Slot 1
			new AandC( "Batter" 			),	// Slot 2
			new AandC( "Wind-Up" 		),	// Slot 3
		}
;else if(petName == "pet Bombling" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Zap" 			),	// Slot 1
			new AandC( "Batter" 			),	// Slot 1
			new AandC( "Minefield" 		),	// Slot 2
			new AandC( "Toxic Smoke" 	),	// Slot 2
			new AandC( "Screeching Gears"),	// Slot 3
			new AandC( "Explode" 		),	// Slot 3
		}
;else if(petName == "Rabid Nut Varmint 5000" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Repair", () => 			hp < 0.7 ),	// Slot 3
			new AandC( "Overtune", () => 		speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC( "Metal Fist" 		),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Extra Plating" 	),	// Slot 2
			new AandC( "Rabid Strike" 	),	// Slot 3
		}
;else if(petName == "Rocket Chicken" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Missile" 		),	// Slot 1
			new AandC( "Peck" 			),	// Slot 1
			new AandC( "Squawk" 			),	// Slot 2
			new AandC( "Toxic Smoke" 	),	// Slot 2
			new AandC( "Extra Plating" 	),	// Slot 3
			new AandC( "Launch" 			),	// Slot 3
		}
////////////
// ROBOTS //
////////////
;else if(petName == "Blue Clockwork Rocket Bot" || petName == "Clockwork Rocket Bot" || petName == "Lil' Smoky" || petName == "Mini Thor" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Missile" 		),	// 
			new AandC( "Batter" 			),	// 
			new AandC( "Toxic Smoke" 	),	// 
			new AandC( "Minefield" 		),	// 
			new AandC( "Sticky Grenade" 	),	// 
			new AandC( "Launch Rocket" 	),	// 
		}
;else if(petName == "Clock'em" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Overtune", () => 		speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC( "Kick" 			),	// Slot 3
			new AandC( "Jab" 			),	// Slot 1
			new AandC( "Haymaker" 		),	// 
			new AandC( "Counterstrike" 	),	// 
			new AandC( "Dodge" 			),	// 
		}
;else if(petName == "Clockwork Gnome" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Repair", () => 			hp < 0.7 ),	// Slot 2
			new AandC( "Build Turret" 	),	// Slot 3
			new AandC( "Metal Fist" 		),	// Slot 1
			new AandC( "Railgun" 		),	// Slot 1
			new AandC( "Blitz" 			),	// Slot 2
			new AandC( "Launch Rocket" 	),	// Slot 3
		}
;else if(petName == "Landro's Lil' XT" || petName == "Lil' XT" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Repair", () => 			hp < 0.7 ),	// Slot 2
			new AandC( "Zap" 			),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Heartbroken" 	),	// Slot 2
			new AandC( "XE-321 Boombot" 	),	// Slot 3
			new AandC( "Tympanic Tantrum" ),	// Slot 3
		}	
;else if(petName == "Personal World Destroyer" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Repair", () => 			hp < 0.7 ),	// Slot 2
			new AandC( "Metal Fist" 		),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Supercharge" 	),	// Slot 2
			new AandC( "Screeching Gears" ),	// Slot 3
			new AandC( "Quake" 			),	// Slot 3
		}
;else if(petName == "Son of Animus" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Metal Fist" 		),	// 
			new AandC( "Batter" 			),	// 
			new AandC( "Siphon Anima" 	),	// 
			new AandC( "Touch of the Animus" ),	// 
			new AandC( "Extra Plating" 	),	// 
			new AandC( "Interrupting Jolt" ),	// 
		}
;else if(petName == "Sunreaver Micro-Sentry" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Call Lightning", ()=> !weather("Lightning Storm") 	),	// 
			new AandC( "Extra Plating" 	),	// 
			new AandC( "Laser" 			),	// 
			new AandC( "Fel Immolate" 	),	// 
			new AandC( "Haywire" 		),	// 
			new AandC( "Supercharge" 	),	// 
		}
;else if(petName == "Tiny Harvester" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Repair", () => 			hp < 0.7 ),	// Slot 3
			new AandC( "Overtune", () => 		speed < speedEnemy && ! buff("Speed Boost") ),	// Slot 2
			new AandC( "Metal Fist" 		),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Extra Plating" 	),	// Slot 2
			new AandC( "Demolish" 		),	// Slot 3
		}
;else if(petName == "Warbot" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Missile" 		),	// Slot 1
			new AandC( "Batter" 			),	// Slot 1
			new AandC( "Toxic Smoke" 	),	// Slot 2
			new AandC( "Minefield" 		),	// Slot 2
			new AandC( "Extra Plating" 	),	// Slot 3
			new AandC( "Launch Rocket" 	),	// Slot 3
		}	
;else if(petName == "Menagerie Custodian" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Ion Cannon", ()=>	hp < 0.35 ),	// Slot 3
			new AandC( "Shock && Awe" 	),	// Slot 2
			new AandC( "Zap" 			),	// Slot 1
			new AandC( "Overtune" 		),	// Slot 1
			new AandC( "Demolish" 		),	// Slot 2
			new AandC( "Lock-On"			),	// Slot 3
		}	
;else if(petName == "Pocket Reaver" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Repair", () => 			hp < 0.7 ),	// Slot 2
			new AandC( "Metal Fist" 		),	// Slot 1
			new AandC( "Thrash" 			),	// Slot 1
			new AandC( "Fel Immolate" 	),	// Slot 3
			new AandC( "Supercharge"		),	// Slot 3
			new AandC( "Quake" 			),	// Slot 2
		}

//////////////////-
// MISCELLANEOUS //
//////////////////-
;else if(petName == "Darkmoon Tonk" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Ion Cannon",  () =>	hp < 0.35 ),	// Slot 3
			new AandC( "Shock && Awe" 	),	// Slot 2
			new AandC( "Minefield" 		),	// Slot 2
			new AandC( "Missile" 		),	// Slot 1
			new AandC( "Charge" 			),	// Slot 1
			new AandC( "Lock-On" 		),	// Slot 3
		}	
;else if(petName == "Darkmoon Zeppelin" )
	mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Missile" 		),	// Slot 1
			new AandC( "Thunderbolt" 	),	// Slot 1
			new AandC( "Flyby" 			),	// Slot 2
			new AandC( "Decoy" 			),	// Slot 2
			new AandC( "Bombing Run" 	),	// Slot 3
			new AandC( "Explode" 		),	// Slot 3
		};	
//////////////////-

            else // Unknown pet
            {
                Logger.Alert("Unknown humanoid pet: " + petName);
                return null;
            }
            return mechanical_abilities;
        }
    }
}
