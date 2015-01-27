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

            switch (petName)
            {
                case "Ancient Nest Guardian":
                    /* Changelog:
                     * 2015-01-15: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Metal Fist       | Batter
                     * Slot 2: Extra Plating    | Entangling Roots
                     * Slot 3: Feathered Frenzy | Wind-Up
                     * 
                     * Tactic Information:
                     * Feathered Frenzy is prioritized against elemental or aquatic enemies
                     * Entangling Roots is prioritized against elemental or aquatic enemies
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Feathered Frenzy",   () => weak("Metal Fist") || strong("Feathered Frenzy")),
                        new AandC("Extra Plating",      () => ! buff("Extra Plating")),
                        new AandC("Entangling Roots",   () => weak("Metal Fist") || strong("Entangling Roots")),
                        new AandC("Wind-Up",            () => hpEnemy > 0.5),
                        new AandC("Metal Fist"),
                        new AandC("Batter"),
                    };
                    break;

                case "Anodized Robo Cub":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Bite     | Demolish
                     * Slot 2: Repair   | Rebuild
                     * Slot 3: Maul     | Supercharge
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Repair",         () => hp < 0.7 && ! buff("Supercharged")),
                        new AandC("Rebuild",        () => hp < 0.6 && ! buff("Supercharged")),
                        new AandC("Demolish",       () => myPetIsLucky),
                        new AandC("Maul",           () => buff("Supercharged")),
                        new AandC("Supercharge",    () => hp > 0.4),
                        new AandC("Maul"),
                        new AandC("Bite"),
                        new AandC("Demolish"),
                    };
                    break;

                case "Blackfuse Bombling":
                    /* Changelog:
                     * 2015-01-20: Bombing Run is now only used if the enemy's health is above 40% (up from 0%) - Studio60
                     * 2015-01-15: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn         | Zap
                     * Slot 2: Bombing Run  | Flame Jet
                     * Slot 3: Explode      | Armageddon
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Bombing Run", () => hpEnemy > 0.4),
                        new AandC("Flame Jet"),
                        new AandC("Explode", () => hp < 0.1),
                        new AandC("Armageddon", () => hp < 0.1),
                        new AandC("Burn"),
                        new AandC("Zap"),
                    };
                    break;


                case "Blue Clockwork Rocket Bot":
                case "Clockwork Rocket Bot":
                case "Lil' Smoky":
                case "Mini Thor":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Missile          | Batter
                     * Slot 2: Toxic Smoke      | Minefield
                     * Slot 3: Sticky Grenade   | Launch Rocket
                     * 
                     * TODO: Reintroduce Minefield - Needs to consider enemy team status
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Sticky Grenade", () => ! debuff("Sticky Grenade") && hpEnemy > 0.4),
                        new AandC("Toxic Smoke",    () => ! debuff("Toxic Smoke")),
                        new AandC("Launch Rocket",  () => buff("Setup Rocket") || hpEnemy > 0.4),
                        new AandC("Missile"),
                        new AandC("Batter"),
                    };
                    break;

                case "Clock'em":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Jab      | Haymaker 
                     * Slot 2: Overtune | Counterstrike
                     * Slot 3: Kick     | Dodge
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Dodge",          () => shouldIHide && speed >= speedEnemy),
                        new AandC("Overtune",       () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Kick",           () => speed >= speedEnemy),
                        new AandC("Counterstrike",  () => speed <= speedEnemy),
                        new AandC("Jab"),
                        new AandC("Haymaker",       () => myPetIsLucky),
                    };
                    break;

                case "Clockwork Gnome":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Metal Fist   | Railgun
                     * Slot 2: Repair       | Blitz
                     * Slot 3: Build Turret | Launch Turret
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Repair",         () => hp < 0.7),
                        new AandC("Launch Rocket",  () => buff("Setup Rocket")),
                        new AandC("Build Turret"),
                        new AandC("Blitz",          () => myPetHasAbility("Metal Fist") && ! strong("Metal Fist") && ! weak("Blitz") && speed > speedEnemy),
                        new AandC("Blitz",          () => myPetHasAbility("Railgun") && ! strong("Railgun") && ! weak("Blitz") && speed > speedEnemy),
                        new AandC("Launch Rocket",  () => hpEnemy > 0.4),
                        new AandC("Metal Fist"),
                        new AandC("Railgun"),
                    };
                    break;

                case "Cogblade Raptor":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Bite             | Batter
                     * Slot 2: Overtune         | Screech
                     * Slot 3: Exposed Wounds   | Repair
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Repair",         () => hp < 0.7),
                        new AandC("Exposed Wounds", () => ! debuff("Exposed Wounds")),
                        new AandC("Overtune",       () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Screech",        () => speed < speedEnemy && ! buff("Speed Reduction")),
                        new AandC("Bite"),
                        new AandC("Batter"),
                    };
                    break;

                case "Darkmoon Tonk":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Missile          | Charge
                     * Slot 2: Shock and Awe    | Minefield
                     * Slot 3: Lock-On          | Ion Cannon
                     * 
                     * TODO: Reintroduce Minefield - Needs to consider enemy team status
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Lock-On",        () => buff("Locked On")),
                        new AandC("Ion Cannon",     () => hp < 0.35),
                        new AandC("Shock and Awe"),
                        new AandC("Lock-On",        () => hpEnemy > 0.4),
                        new AandC("Missile"),
                        new AandC("Charge"),
                    };
                    break;

                case "Darkmoon Zeppelin":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Missile      | Flyby
                     * Slot 2: Bombing Run  | Explode
                     * Slot 3: Thunderbolt  | Decoy
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Explode",        () => buff("Failsafe")),
                        new AandC("Decoy",          () => shouldIHide && speed >= speedEnemy),
                        new AandC("Flyby",          () => debuff("Weakened Defenses")),
                        new AandC("Thunderbolt"),
                        new AandC("Bombing Run",    () => hpEnemy > 0.5),
                        new AandC("Missile"),
                        new AandC("Flyby"),
                    };
                    break;

                case "De-Weaponized Mechanical Companion":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Metal Fist   | Thrash
                     * Slot 2: Overtune     | Extra-Plating
                     * Slot 3: Demolish     | Repair
                     */
                    mechanical_abilities = new List<AandC>()
                    {
                        new AandC("Repair",         () => hp < 0.7),
                        new AandC("Extra Plating",  () => ! buff("Extra Plating")),
                        new AandC("Overtune",       () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Demolish",       () => myPetIsLucky),
                        new AandC("Metal Fist"),
                        new AandC("Thrash"),
                    };
                    break;

                case "Draenei Micro Defender":
                    /* Changelog:
                     * 2015-01-20: Shield Block is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Metal Fist           | Batter
                     * Slot 2: Reflective Shield    | Shield Block
                     * Slot 3: Explode              | Ion Cannon
                     */
                    mechanical_abilities = new List<AandC>() {
                        new AandC("Shield Block",       () => shouldIHide && speed >= speedEnemy),
                        new AandC("Batter",             () => speed > speedEnemy && strong("Batter")),
                        new AandC("Reflective Shield",  () => ! buff("Reflective Shield") || (speed < speedEnemy && buffLeft("Reflective Shield") == 1)),
                        new AandC("Explode",            () => hpEnemy < 0.1),
                        new AandC("Ion Cannon"),
                        new AandC("Metal Fist"),
                        new AandC("Batter"),
                    };
                    break;

                case "Fluxfire Feline":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Claw     | Pounce
                     * Slot 2: Flux     | Overtune
                     * Slot 3: Prowl    | Supercharge
                     * 
                     * TODO: Reintroduce Flux - Needs to consider enemy team status
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Overtune",   () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Prowl",      () => ! debuff("Prowl") && speed * 0.7 > speedEnemy),
                        new AandC("Supercharge"),
                        new AandC("Claw"),
                        new AandC("Pounce"),
                    };
                    break;

                case "Iron Starlette":
                    /* Abilities
                     * Slot 1: Wind-Up      | Demolish
                     * Slot 2: Powerball    | Toxic Smoke
                     * Slot 3: Supercharge  | Explode
                     * 
                     * TODO: Explode needs to check the chances to win conventionally
                     */
                    mechanical_abilities = new List<AandC>() {
                        new AandC("Explode",        () => hp < 0.1), 
                        new AandC("Demolish",       () => myPetIsLucky),
                        new AandC("Powerball",      () => speed <= speedEnemy), 
                        new AandC("Toxic Smoke" ,   () => ! buff("Toxic Smoke")),
                        new AandC("Wind-Up",        () => ! buff("Wind-Up")),
                        new AandC("Supercharge",    () => shouldIHide),
                        new AandC("Wind-Up",        () => buff("Wind-Up") && buff("Supercharge") && ! shouldIHide),
                        new AandC("Demolish"),
                        new AandC("Powerball"), 
                    };
                    break;

                case "Landro's Lil' XT":
                case "Lil' XT":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Zap              | Thrash
                     * Slot 2: Repair           | Heartbroken
                     * Slot 3: XE-321 Boombot   | Tympanic Tantrum
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Repair",             () => hp < 0.7),
                        new AandC("Tympanic Tantrum",   () => buff("Heartbroken")),
                        new AandC("XE-321 Boombot",     () => hpEnemy > 0.5),
                        new AandC("Heartbroken",        () => ! buff("Heartbroken")),
                        new AandC("Zap"),
                        new AandC("Thrash"),
                    };
                    break;

                case "Lifelike Mechanical Frostboar":
                    /* Changelog:
                     * 2015-01-18: Rebuild is used when below 75% health (up from 50%) - Studio60
                     * 2015-01-15: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Charge   | Missile
                     * Slot 2: Rebuild  | Pig Out
                     * Slot 3: Decoy    | Headbutt
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Decoy"),
                        new AandC("Headbutt"),
                        new AandC("Rebuild",    () => hp < 0.75),
                        new AandC("Pig Out",    () => hp < 0.75),
                        new AandC("Charge"),
                        new AandC("Missile"),
                    };
                    break;

                case "Lifelike Toad":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Water Jet    | Tongue Lash
                     * Slot 2: Healing Wave | Cleansing Rain
                     * Slot 3: Frog Kiss    | Repair
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Cleansing Rain", () => ! weather("Cleansing Rain")),
                        new AandC("Healing Wave",   () => hp < 0.7),
                        new AandC("Repair",         () => hp < 0.7),
                        new AandC("Frog Kiss",      () => ! enemyIsResilient),
                        new AandC("Water Jet"),
                        new AandC("Tongue Lash"),
                    };
                    break;

                case "Lil' Bling":
                    /* Changelog
                     * 2015-01-15: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: SMCKTHAT.EXE             | Inflation
                     * Slot 2: Blingtron Gift Package   | Extra Plating
                     * Slot 3: Make it Rain             | Launch Rocket
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Launch Rocket",          () => buff("Setup Rocket")),
                        new AandC("Extra Plating",          () => !buff("Extra Plating")),
                        new AandC("Inflation",              () => debuff("Make it Rain")),
                        new AandC("Blingtron Gift Package", () => hp < 0.75),
                        new AandC("Make it Rain",           () => !debuff("Make it Rain")),
                        new AandC("Launch Rocket",          () => hpEnemy > 0.25),
                        new AandC("SMCKTHAT.EXE"),
                        new AandC("Inflation"),
                    };
                    break;

                case "Mechanical Chicken":
                case "Robo-Chick":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Peck         | Batter
                     * Slot 2: Overtune     | Rebuild
                     * Slot 3: Supercharge  | Wind-Up
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Rebuild",        () => hp < 0.7),
                        new AandC("Wind-Up",        () => ! buff("Wind-Up")),
                        new AandC("Overtune",       () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Supercharge",    () => hpEnemy > 0.4),
                        new AandC("Peck"),
                        new AandC("Batter"),
                    };
                    break;

                case "Mechanical Pandaren Dragonling":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Breath       | Flyby
                     * Slot 2: Bombing Run  | Thunderbolt
                     * Slot 3: Explode      | Decoy
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Explode",        () => buff("Failsafe")),
                        new AandC("Decoy",          () => shouldIHide && speed >= speedEnemy),
                        new AandC("Flyby",          () => ! debuff("Weakened Defenses")),
                        new AandC("Bombing Run",    () => hpEnemy > 0.5),
                        new AandC("Thunderbolt"),
                        new AandC("Breath"),
                        new AandC("Flyby"),
                    };
                    break;

                case "Mechanical Scorpid":
                    /* Changelog:
                     * 2015-01-20: Puncture Wound is now checking for all poison effects - Studio60
                     * 2015-01-19: Black Claw is only used if the enemy's health is above 15% (up from 0%) - Studio60
                     * 2015-01-15: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Barbed Stinger   | Wind-Up
                     * Slot 2: Blinding Poison  | Puncture Wound
                     * Slot 3: Black Claw       | Extra Plating
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Extra Plating",      () => !buff("Extra Plating")),
                        new AandC("Puncture Wound",     () => enemyIsPoisoned),
                        new AandC("Black Claw",         () => ! debuff("Black Claw") && hpEnemy > 0.15),
                        new AandC("Blinding Poison",    () => ! debuff("Blinding Poison")),
                        new AandC("Puncture Wound"),
                        new AandC("Barbed Stinger"),
                        new AandC("Wind-Up"),                    
                    };
                    break;

                case "Mechanical Squirrel":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Metal Fist   | Trash
                     * Slot 2: Overtune     | Extra Plating
                     * Slot 3: Wind-Up      | Repair
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Repair",         () => hp < 0.7),
                        new AandC("Extra Plating",  () => ! buff("Extra Plating")),
                        new AandC("Wind-Up",        () => ! buff("Wind-Up")),
                        new AandC("Overtune",       () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Metal Fist"),
                        new AandC("Thrash"),
                    };
                    break;

                case "Mechanopeep":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Peck     | Rebuild
                     * Slot 2: Batter   | Overtune
                     * Slot 3: Wind-Up  | Repair
                     * 
                     * Tactic Information:
                     * Batter/Overtune at the end as a fallback to avoid passing turns
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Repair",     () => hp < 0.7),
                        new AandC("Rebuild",    () => hp < 0.7),
                        new AandC("Wind-Up",    () => ! buff("Wind-Up")),
                        new AandC("Overtune",   () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Batter"),
                        new AandC("Peck"),
                    };
                    break;

                case "Menagerie Custodian":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Zap              | Overtune
                     * Slot 2: Shock and Awe    | Demolish
                     * Slot 3: Lock-On          | Ion Cannon
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Ion Cannon",     () => hp < 0.35),
                        new AandC("Lock-On",        () => ! buff("Locked On")),
                        new AandC("Shock and Awe"),
                        new AandC("Demolish",       () => myPetIsLucky),
                        new AandC("Lock-On",        () => hpEnemy > 0.4),
                        new AandC("Zap"),
                        new AandC("Overtune"),
                    };
                    break;

                case "Personal World Destroyer":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Metal Fist       | Trash
                     * Slot 2: Repair           | Supercharge
                     * Slot 3: Screeching Gears | Quake
                     * 
                     * TODO: Reintroduce Quake - Needs to consider enemy team status
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Repair",             () => hp < 0.7),
                        new AandC("Screeching Gears",   () => ! enemyIsStunned),
                        new AandC("Supercharge"),
                        new AandC("Metal Fist"),
                        new AandC("Thrash"),
                    };
                    break;

                case "Pet Bombling":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Zap              | Batter
                     * Slot 2: Minefield        | Toxic Smoke
                     * Slot 3: Screeching Gears | Explode
                     * 
                     * TODO: Reintroduce Minefield - Needs to consider enemy team status
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Explode",            () => buff("Failsafe")),
                        new AandC("Toxic Smoke",        () => ! debuff("Toxic Smoke")),
                        new AandC("Screeching Gears",   () => ! enemyIsStunned),
                        new AandC("Zap"),
                        new AandC("Batter"),
                    };
                    break;

                case "Pierre":
                    /* Changelog:
                     * 2015-01-15: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Chop         | Frying Pan
                     * Slot 2: Stench       | Heat Up
                     * Slot 3: High Fiber   | Food Coma
                     */
                    // High Fiber should only be cast if a negative aura is on our team and Heat Up is not active
                    // Should be changed, if required condition check becomes available
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Stench",     () => ! debuff("Stench")),
                        new AandC("Food Coma",  () => ! debuff("Asleep")),
                        new AandC("Heat Up"),
                        new AandC("High Fiber", () => !buff("Heat Up")), 
                        new AandC("Chop"),
                        new AandC("Frying Pan")
                    };
                    break; 

                case "Pocket Reaver":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Metal Fist   | Trash
                     * Slot 2: Repair       | Quake
                     * Slot 3: Fel Immolate | Supercharge
                     * 
                     * TODO: Reintroduce Quake - Needs to consider enemy team status
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Repair",         () => hp < 0.7),
                        new AandC("Fel Immolate",   () => ! debuff("Fel Immolate")),
                        new AandC("Supercharge"),
                        new AandC("Metal Fist"),
                        new AandC("Thrash"),
                    };
                    break;

                case "Rabid Nut Varmint 5000":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Metal Fist   | Trash
                     * Slot 2: Overtune     | Extra Plating
                     * Slot 3: Rabid Strike | Repair
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Repair",         () => hp < 0.7),
                        new AandC("Overtune",       () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Extra Plating",  () => ! buff("Extra Plating")),
                        new AandC("Rabid Strike",   () => ! debuff("Rabies")),
                        new AandC("Metal Fist"),
                        new AandC("Thrash"),
                    };
                    break;


                case "Race MiniZep":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60 for new pet coming in patch 6.1
                     * 
                     * Abilities
                     * Slot 1: Missile          | Flyby
                     * Slot 2: Bombing Run      | Decoy
                     * Slot 3: Darkmoon Curse   | Overtune
                     */
                    mechanical_abilities = new List<AandC>() {
                        new AandC("Bombing Run",    () => hpEnemy > 0.5),
                        new AandC("Decoy",          () => ! buff("Decoy")),
                        new AandC("Darkmoon Curse", () => ! debuff("Attack Reduction")),
                        new AandC("Overtune",       () => ! buff("Speed Boost")),
                        new AandC("Missile"),
                        new AandC("Flyby"),
                    };
                    break;

                case "Rascal-Bot":
                    /* Changelog:
                     * 2015-01-20: Lens Flare is now checking for all blindness effects - Studio60
                     *             Amber Prison is now checking for all stun effects - Studio60
                     * 2015-01-19: Lens Flare is no longer used if the enemy is "Partially Blinded" (Studio60)
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Phaser       | Plot Twist
                     * Slot 2: Lens Flare   | Amber Prison
                     * Slot 3: Armageddon   | Reboot
                     */
                    mechanical_abilities = new List<AandC>()     // Studio60
                    {    
                        new AandC("Lens Flare",     () => ! enemyIsBlinded),
                        new AandC("Amber Prison",   () => ! enemyIsStunned),                  
                        new AandC("Armageddon",     () => hp < 0.1),
                        new AandC("Phaser"),
                        new AandC("Plot Twist"),              
                        new AandC("Reboot"),
                    };
                    break;

                case "Rocket Chicken":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Missile          | Peck
                     * Slot 2: Squawk           | Toxic Smoke
                     * Slot 3: Extra Plating    | Launch
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Launch",         () => shouldIHide && speed >= speedEnemy),
                        new AandC("Squawk",         () => ! debuff("Attack Reduction")),
                        new AandC("Toxic Smoke",    () => ! debuff("Toxic Smoke")),
                        new AandC("Extra Plating",  () => ! buff("Extra Plating")),
                        new AandC("Missile"),
                        new AandC("Peck"),
                    };
                    break;

                case "Sky-Bo":
                    /* Changelog:
                     * 2015-01-20: Launch is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Sticky Grenade is not used against enemies below 40% health - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Flamethrower     | Screeching Gears
                     * Slot 2: Sticky Grenade   | Reboot
                     * Slot 3: Launch           | Decoy
                     */
                    // launch: if we are faster, then launch should protect us from huge attacks
                    mechanical_abilities = new List<AandC>() {
                        new AandC("Launch",             () => shouldIHide && speed >= speedEnemy),  
                        new AandC("Sticky Grenade",     () => ! debuff("Sticky Grenade") && hpEnemy >= 0.4),                
                        new AandC("Decoy",              () => ! buff("Decoy")),
                        new AandC("Flamethrower"),
                        new AandC("Screeching Gears"),
                        new AandC("Launch"), 
                        new AandC("Reboot"),
                    };
                    break;

                case "Son of Animus":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Metal Fist       | Batter
                     * Slot 2: Siphon Anima     | Touch of the Animus
                     * Slot 3: Extra Plating    | Interrupting Jolt
                     */
                    mechanical_abilities = new List<AandC>() {
                        new AandC("Extra Plating",          () => ! buff("Extra Plating")),
                        new AandC("Siphon Anima",           () => hp < 0.75),
                        new AandC("Batter",                 () => speed > speedEnemy && strong("Batter")),
                        new AandC("Touch of the Animus"),
                        new AandC("Interrupting Jolt"),
                        new AandC("Metal Fist"),
                        new AandC("Batter"),
                    };
                    break;

                case "Stonegrinder":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Changelog:
                     * 2015-01-15: Initial tactic by Studio60
                     * Abilities
                     * Slot 1: Screeching Gears | Woodchipper
                     * Slot 2: Thunderbolt      | Supercharge
                     * Slot 3: Clean-Up         | Rebuild
                     * 
                     * TODO: Clean-Up needs to correctly check for battlefield objects
                     */
                    mechanical_abilities = new List<AandC>() 
                    {    
                        new AandC("Clean-Up",           () => debuff("Turret") || debuff("Decoy")),
                        new AandC("Supercharge"),    
                        new AandC("Thunderbolt"),
                        new AandC("Rebuild",            () => hp < 0.75),               
                        new AandC("Screeching Gears"),
                        new AandC("Woodchipper"),                       
                    };
                    break;

                case "Sunblade Micro-Defender":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60 for new pet coming in patch 6.1
                     * 
                     * Abilities
                     * Slot 1: Zap                  | Haywire
                     * Slot 2: Interrupting Jolt    | Repair
                     * Slot 3: Shock and Awe        | Armageddon
                     * 
                     * TODO: Use Armageddon only during Failsafe (Untested)
                     */
                    mechanical_abilities = new List<AandC>() {
                        new AandC("Armageddon",         () => buff("Failsafe")),
                        new AandC("Interrupting Jolt"),
                        new AandC("Repair",             () => hp < 0.5),
                        new AandC("Shock and Awe"),
                        new AandC("Zap"),
                        new AandC("Haywire"),
                    };
                    break;

                case "Sunreaver Micro-Sentry":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Laser            | Fel Immolate
                     * Slot 2: Extra Plating    | Haywire
                     * Slot 3: Call Lightning   | Supercharge
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Call Lightning", () => ! weather("Lightning Storm")),
                        new AandC("Extra Plating",  () => ! buff("Extra Plating")),
                        new AandC("Supercharge"),
                        new AandC("Haywire",        () => hpEnemy > 0.4),
                        new AandC("Laser"),
                        new AandC("Fel Immolate"),
                    };
                    break;

                case "Tiny Harvester":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Metal Fist   | Thrash
                     * Slot 2: Overtune     | Extra Plating
                     * Slot 3: Demolish     | Repair
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Repair",         () => hp < 0.7),
                        new AandC("Extra Plating",  () => ! buff("Extra Plating")),
                        new AandC("Overtune",       () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Demolish",       () => myPetIsLucky),
                        new AandC("Metal Fist"),
                        new AandC("Thrash"),
                    };
                    break;

                case "Tranquil Mechanical Yeti":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Metal Fist       | Thrash
                     * Slot 2: Call Lightning   | Call Blizzard
                     * Slot 3: Supercharge      | Ion Cannnon
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Ion Cannon",     () => hpEnemy < 0.4),
                        new AandC("Call Lightning", () => ! weather("Lightning Storm")),
                        new AandC("Call Blizzard",  () => ! weather("Blizzard")),
                        new AandC("Supercharge"),
                        new AandC("Metal Fist"),
                        new AandC("Thrash"),
                    };
                    break;

                case "Warbot":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Missile          | Batter
                     * Slot 2: Toxic Smoke      | Minefield 
                     * Slot 3: Extra Plating    | Launch Rocket
                     * 
                     * TODO: Reintroduce Minefield - Needs to consider enemy team status
                     */
                    mechanical_abilities = new List<AandC>() 
                    {
                        new AandC("Launch Rocket",  () => buff("Setup Rocket")),
                        new AandC("Toxic Smoke",    () => ! debuff("Toxic Smoke")),
                        new AandC("Extra Plating",  () => ! buff("Extra Plating")),
                        new AandC("Launch Rocket",  () => hpEnemy > 0.4),
                        new AandC("Missile"),
                        new AandC("Batter"),
                    };
                    break;

                default:
                    ////////////////////////////
                    // Unknown Mechanical Pet //
                    ////////////////////////////
                    Logger.Alert("Unknown mechanical pet: " + petName);
                    mechanical_abilities = null;
                    break;
            }

            return mechanical_abilities;
        }
    }
}
