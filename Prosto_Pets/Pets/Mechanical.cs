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

            if (petName == "Iron Starlette")
                mechanical_abilities = new List<AandC>() 
		{
			new AandC( "Explode",       () =>   hp < 0.1 	),	        // Slot 3 TODO: check the chances to win conventionally
			new AandC( "Powerball",     () => 	speed <= speedEnemy),	// Slot 2  against Undead
			new AandC( "Toxic Smoke" ,  () =>   ! buff("Toxic Smoke")			),	// Slot 2
			new AandC( "Wind-Up",       () =>   ! buff("Wind-Up") 		),	// Slot 1
			new AandC( "Supercharge",   () =>   shouldIHide ),	            // Slot 2
			new AandC( "Wind-Up",       () =>   buff("Wind-Up") && buff("Supercharge") && ! shouldIHide ),	// Slot 1
			new AandC( "Demolish" 			    ),	// Slot 1
			new AandC( "Powerball"              ),	// Slot 2  against Undead
		};

////////////////////////
// LIFELIKE CREATIONS //
////////////////////////
else if( petName == "Fluxfire Feline" )
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
            else if (petName == "Pierre")       // Studio60
            
                // High Fiber should only be cast if a negative aura is on our team and Heat Up is not active
                // Should be changed, if required condition check becomes available
                mechanical_abilities = new List<AandC>() 
                {
                    
                    new AandC("Stench",     () => !debuff("Stench")), // Slot 2
                    new AandC("Food Coma",  () => !debuff("Asleep")), // Slot 3
                    new AandC("Heat Up"                            ), // Slot 2
                    new AandC("High Fiber", () => !buff("Heat Up") ), // Slot 3 
                    new AandC("Chop"     ), // Slot 1
                    new AandC("Frying Pan") // Slot 1
                };
            

            else if (petName == "Ancient Nest Guardian")    // Studio60
            
                // Feathered Frenzy is a fallback spell for elemental or aquatic enemies
                // Entangling Roots is a fallback spell for elemental or mechanical enemies
                mechanical_abilities = new List<AandC>() 
                {
                    new AandC("Feathered Frenzy", () => weak("Metal Fist") || strong("Feathered Frenzy")), // Slot 3
                    new AandC("Extra Plating",    () => !buff("Extra Plating")), // Slot 2
                    new AandC("Entangling Roots", () => weak("Metal Fist") || strong("Entangling Roots")), // Slot 2
                    new AandC("Wind-Up",          () => hpEnemy > 0.5), // Slot 3
                    new AandC("Metal Fist"), // Slot 1
                    new AandC("Batter"    ), // Slot 1
                };

            else if (petName == "Blackfuse Bombling")    // Studio60
            {
                mechanical_abilities = new List<AandC>() 
    {
        new AandC("Bombing Run"), // Slot 2
        new AandC("Flame Jet"), // Slot 2
        new AandC("Explode", () => hp < 0.1), // Slot 3
        new AandC("Armageddon", () => hp < 0.1), // Slot 3
        new AandC("Burn"), // Slot 1
        new AandC("Zap"), // Slot 1
    };
            }

            else if (petName == "Lifelike Mechanical Frostboar")    // Studio60
            {
                mechanical_abilities = new List<AandC>() 
    {
        new AandC("Decoy"), // Slot 3
        new AandC("Headbutt"), // Slot 3
        new AandC("Rebuild", () => hp < 0.5), // Slot 2
        new AandC("Pig Out", () => hp < 0.75), // Slot 2
        new AandC("Charge"), // Slot 1
        new AandC("Missile"), // Slot 1
    };
            }

            else if (petName == "Lil' Bling")    // Studio60
            {
                mechanical_abilities = new List<AandC>() 
    {
        new AandC("Launch Rocket", () => buff("Setup Rocket")), // Slot 3
        new AandC("Extra Plating", () => !buff("Extra Plating")), // Slot 2
        new AandC("Inflation", () => debuff("Make it Rain")), // Slot 1
        new AandC("Blingtron Gift Package", () => hp < 0.75), // Slot 2
        new AandC("Make it Rain", () => !debuff("Make it Rain")), // Slot 3
        new AandC("Launch Rocket", () => hpEnemy > 0.25), // Slot 3
        new AandC("SMCKTHAT.EXE"), // Slot 1
        new AandC("Inflation"), // Slot 1
    };
            }

            else if (petName == "Mechanical Scorpid")    // Studio60
            {
                mechanical_abilities = new List<AandC>() 
    {
        new AandC("Extra Plating", () => !buff("Extra Plating")), // Slot 3
        new AandC("Puncture Wound", () => debuff("Poisoned")), // Slot 2
        new AandC("Black Claw", () => ! debuff("Black Claw")), // Slot 3
        new AandC("Blinding Poison", () => ! debuff("Blinding Poison") && ! shouldIHide), // Slot 2
        new AandC("Puncture Wound"), // Slot 2
        new AandC("Barbed Stinger"), // Slot 1
        new AandC("Wind-Up"), // Slot 1                   
    };
            }

            else if (petName == "Rascal-Bot")
            {
                mechanical_abilities = new List<AandC>()     // Studio60
    {    
        new AandC("Lens Flare", () => ! debuff("Blind")), // Slot 2
        new AandC("Amber Prison", () => ! debuff("Stunned")), // Slot 2                  
        new AandC("Armageddon", () => hp < 0.1), // Slot 3
        new AandC("Phaser"), // Slot 1
        new AandC("Plot Twist"), // Slot 1              
        new AandC("Reboot"), // Slot 3
    };
            }

            else if (petName == "Stonegrinder")    // Studio60
            {
                mechanical_abilities = new List<AandC>() 
    {    
        new AandC("Clean-Up", () => debuff("Turret") || debuff("Decoy")), // Slot 3
        new AandC("Supercharge"), // Slot 2    
        new AandC("Thunderbolt"), // Slot 2
        new AandC("Rebuild", () => hp < 0.75), // Slot 3               
        new AandC("Screeching Gears"), // Slot 1
        new AandC("Woodchipper"), // Slot 1                       
    };
            }
            
//////////////////-

            else // Unknown pet
            {
                Logger.Alert("Unknown mechanical pet: " + petName);
                return null;
            }
            return mechanical_abilities;
        }
    }
}
