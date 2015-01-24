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

            switch (petName)
            {
                case "Amberbarb Wasp":
                case "Bloodsting Wasp":
                case "Bone Wasp":
                case "Twilight Wasp": 
                case "Wood Wasp":
                    /* Changelog:
                     * 2015-01-20: Puncture Wound is now checking for all poison effects - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Barbed Stinger   | Bite
                     * Slot 2: Focus            | Predatory Strike
                     * Slot 3: Puncture Wound   | Ravage
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Ravage",             () => hpEnemy < 0.25 || (famEnemy(PF.Critter) && hpEnemy > 0.4)),
                        new AandC("Barbed Stinger",     () => ! debuff("Poisoned")), 
                        new AandC("Puncture Wound",     () => enemyIsPoisoned()),
                        new AandC("Focus",              () => ! buff("Focused")),
                        new AandC("Predatory Strike",   () => hpEnemy < 0.25),
                        new AandC("Puncture Wound"),
                        new AandC("Barbed Stinger"),
                        new AandC("Bite"),
                    };
                    break;

                case "Amber Moth":
                case "Blue Moth":
                case "Crimson Moth":
                case "Forest Moth":
                case "Fungal Moth":
                case "Garden Moth":
                case "Gilded Moth":
                case "Grey Moth":
                case "Luyu Moth":
                case "Oasis Moth":
                case "Red Moth":
                case "Silky Moth":
                case "Swamp Moth":
                case "Tainted Moth":
                case "White Moth":
                case "Yellow Moth":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind     | Alpha Strike
                     * Slot 2: Cocoon Strike    | Adrenaline Rush
                     * Slot 3: Moth Balls       | Moth Dust
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Cocoon Strike",      () => shouldIHide && speed >= speedEnemy),
                        new AandC("Adrenaline Rush",    () => ! buff("Adrenaline")),
                        new AandC("Moth Balls",         () => buff("Uncanny Luck")),
                        new AandC("Moth Dust"),
                        new AandC("Slicing Wind"),
                        new AandC("Alpha Strike"),
                    };
                    break;

                case "Ancona Chicken":
                case "Chicken":
                case "Szechuan Chicken":
                case "Westfall Chicken":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Peck         | Slicing Wind
                     * Slot 2: Squawk       | Adrenaline Rush
                     * Slot 3: Egg Barrage  | Flock
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Adrenaline Rush",    () => ! buff("Adrenaline")),
                        new AandC("Squawk",             () => ! debuff("Attack Reduction")),  
                        new AandC("Egg Barrage",        () => ! debuff("Egg Barrage")),
                        new AandC("Flock",              () => ! debuff("Shattered Defenses")),
                        new AandC("Peck"),
                        new AandC("Slicing Wind"),
                    };
                    break;

                case "Ashwing Moth":
                    /* Changelog:
                     * 2015-01-20: Cocoon Strike is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Alpha Strike | Wild Winds
                     * Slot 2: Nimbus       | Cocoon Strike
                     * Slot 3: Moth Balls   | Moth Dust
                     *
                     * Tactic Information
                     * Moth balls deal unreliable damage, but become useful if we are faster than the enemy
                     * 
                     * TODO: Add Uncanny Luck to Moth Balls
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Nimbus", () => ! buff("Nimbus")),
                        new AandC("Cocoon Strike", () => shouldIHide && speed >= speedEnemy),
                        new AandC("Moth Balls", () => ! debuff("Speed Reduction") && speed < speedEnemy && speed > speedEnemy * 0.75),
                        new AandC("Moth Dust"),
                        new AandC("Alpha Strike"),
                        new AandC("Wild Winds"),
                    };
                    break;

                case "Axebeak Hatchling":
                case "Fruit Hunter":
                case "Junglebeak":
                    /* Changelog:
                     * 2015-01-20: Nocturnal Strike is now checking for all blindness effects - Studio60
                     *             Lift-Off is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-19: Rain Dance is only used if the enemy's health is above 15% (up from 0%) - Studio60
                     *             Rain Dance is only used if pet health is below 80% (down from 100%) - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind | Peck
                     * Slot 2: Rain Dance   | Flyby
                     * Slot 3: Lift-Off     | Nocturnal Strike
                     * 
                     * TODO: Add Uncanny Luck to Nocturnal Strike
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Lift-Off",           () => strong("Lift-Off") || (shouldIHide && speed >= speedEnemy)),
                        new AandC("Nocturnal Strike",   () => enemyIsBlinded()),
                        new AandC("Rain Dance",         () => ! buff("Rain Dance")  && hp < 0.8 && hpEnemy > 0.15),
                        new AandC("Flyby",              () => ! debuff("Weakened Defenses")),
                        new AandC("Nocturnal Strike"),
                        new AandC("Slicing Wind"),
                        new AandC("Peck"),
                    };
                    break;

                case "Azure Crane Chick":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Quills           | Flock
                     * Slot 2: Cleansing Rain   | Healing Stream
                     * Slot 3: Reckless Strike  | Surge
                     *
                     * Tactic Information:
                     * Reckless Strike is risky if used against magic pets due to incoming spiky magic damage
                     */             
                    flying_abilities = new List<AandC>() {
                        new AandC("Cleansing Rain",     () => ! buff("Cleansing Rain")),
                        new AandC("Surge",              () => famEnemy(PF.Elemental) || famEnemy(PF.Dragonkin) || buff("Cleansing Rain")),
                        new AandC("Quills",             () => speed > speedEnemy),
                        new AandC("Healing Stream",     () => hp < 0.8),
                        new AandC("Reckless Strike",    () => ! famEnemy(PF.Magic)),
                        new AandC("Quills"),
                        new AandC("Flock"),
                    };
                    break;

                case "Bat":
                case "Tirisfal Batling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Bite             | Leech Life
                     * Slot 2: Screech          | Hawk Eye
                     * Slot 3: Reckless Strike  | Nocturnal Strike
                     * 
                     * TODO: High Priority for Leech Life if enemy is Webbed
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")),
                        new AandC("Screech",            () => ! debuff("Speed Reduction") && speed <= speedEnemy),
                        new AandC("Reckless Strike",    () => hp > hpEnemy || strong("Reckless Strike")),
                        new AandC("Nocturnal Strike",   () => enemyIsBlinded() || buff("Uncanny Luck")),
                        new AandC("Bite"),
                        new AandC("Leech Life"),
                    };
                    break;

                case "Blue Mini Jouster":
                case "Dragonbone Hatchling":
                case "Fledgling Buzzard":
                case "Gold Mini Jouster":
                case "Imperial Eagle Chick":
                case "Tickbird Hatchling": 
                case "White Tickbird Hatchling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind | Thrash
                     * Slot 2: Hawk Eye     | Adrenaline Rush
                     * Slot 3: Lift-Off     | Cyclone
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")),
                        new AandC("Adrenaline Rush",    () => ! buff("Adrenaline")),
                        new AandC("Slicing Wind"),
                        new AandC("Thrash"),
                    };
                    break;

                case "Brilliant Bloodfeather":
                    /* Changelog:
                     * 2015-01-20: Quills is now also used with high priority if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Quills           | Peck
                     * Slot 2: Hawk Eye         | Accuracy
                     * Slot 3: Reckless Strike  | Drain Blood
                     *
                     * Tactic Information:
                     * Reckless Strike is isky if used against magic pets due to incoming spiky magic damage
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Accuracy",           () => buff("Blinded")),
                        new AandC("Quills",             () => speed >= speedEnemy),
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")),
                        new AandC("Reckless Strike",    () => ! famEnemy(PF.Magic)),
                        new AandC("Drain Blood",        () => hp < 0.6),
                        new AandC("Quills"),
                        new AandC("Peck"),
                    };
                    break;

                case "Brilliant Kaliri":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Peck             | Quills
                     * Slot 2: Shriek           | Cyclone
                     * Slot 3: Nocturnal Strike | Predatory Strike
                     * 
                     * TODO: Add Uncanny Luck to Nocturnal Strike
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Predatory Strike",   () => hpEnemy < 0.25),
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Shriek",             () => ! debuff("Attack Reduction")),
                        new AandC("Nocturnal Strike"),
                        new AandC("Peck"),
                        new AandC("Quills"),
                    };
                    break;

                case "Brilliant Spore":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Reckless Strike  | Creeping Fungus
                     * Slot 2: Spiked Skin      | Blinding Powder
                     * Slot 3: Spore Shrooms    | Explode
                     * 
                     * Tactic Information:
                     * Reckless Strike is low priority but always used, because it might be the only available attack
                     * 
                     * TODO: Use Blinding Powder if big attack is anticipated
                     * TODO: Spore Shrooms should be used if more than one enemy pet is alive
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Explode",            () => hp < 0.1),
                        new AandC("Creeping Fungus",    () => ! debuff("Creeping Fungus") && weather("Moonlight")),  
                        new AandC("Spiked Skin",        () => ! buff("Spiked Skin")),
                        new AandC("Spore Shrooms",      () => hpEnemy > 0.6),
                        new AandC("Reckless Strike"),
                        new AandC("Creeping Fungus",    () => ! debuff("Creeping Fungus")),                    
                        new AandC("Blinding Powder"),
                    };
                    break;

                case "Cenarion Hatchling":
                case "Hippogryph Hatchling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Peck             | Quills
                     * Slot 2: Screech          | Rush
                     * Slot 3: Reckless Strike  | Lift-Off
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Rush",               () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Screech",            () => ! debuff("Speed Reduction") && speed < speedEnemy),
                        new AandC("Reckless Strike",    () => hp > hpEnemy),
                        new AandC("Peck"),
                        new AandC("Quills"),
                    };
                    break;

                case "Chi-Chi, Hatchling of Chi-Ji":
                    /* Changelog:
                     * 2015-01-19: Tranquility is not used if it is already active - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Fire Quills  | Alpha Strike
                     * Slot 2: Tranquility  | Wild Magic
                     * Slot 3: Ethereal     | Feign Death
                     * 
                     * TODO: Use Feign Death if we have another pet available
                     * TODO: Recast Wild Magic earlier if we are slower
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Ethereal",       () => shouldIHide),
                        new AandC("Tranquility",    () => hp < 0.8 && ! buff("Tranquility") && hpEnemy > 0.15),
                        new AandC("Wild Magic",     () => ! debuff ("Wild Magic")),
                        new AandC("Fire Quills"),
                        new AandC("Alpha Strike"),
                        new AandC("Feign Death"),
                    };
                    break;

                case "Cockatiel":
                case "Green Wing Macaw":
                case "Hyacinth Macaw":
                case "Parrot":
                case "Polly":
                case "Senegal":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind | Thrash
                     * Slot 2: Hawk Eye     | Adrenaline Rush
                     * Slot 3: Lift-Off     | Cynclone
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")),
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Adrenaline Rush",    () => ! buff("Adrenaline")),
                        new AandC("Slicing Wind"),
                        new AandC("Thrash"),
                    };
                    break;

                case "Crested Owl":
                case "Great Horned Owl":
                case "Hawk Owl":
                case "Snowy Owl":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Peck             | Quills
                     * Slot 2: Shriek           | Cyclone
                     * Slot 3: Nocturnal Strike | Predatory Strike
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Predatory Strike",   () => hpEnemy < 0.25),
                        new AandC("Shriek",             () => ! debuff("Attack Reduction")),
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Nocturnal Strike",   () => enemyIsBlinded() || buff("Uncanny Luck")),
                        new AandC("Peck"),
                        new AandC("Quills"),
                    };
                    break;

                case "Crimson Spore":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Sting            | Creeping Fungus
                     * Slot 2: Blinding Powder  | Spiked Skin
                     * Slot 3: Spore Shrooms    | Explode
                     * 
                     * TODO: Use Blinding Powder if big attack is anticipated
                     * TODO: Spore Shrooms should be used if more than one enemy pet is alive
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Explode",            () => hp < 0.1),
                        new AandC("Creeping Fungus",    () => ! debuff("Creeping Fungus") && weather("Moonlight")),  
                        new AandC("Spiked Skin"),
                        new AandC("Spore Shrooms",      () => hpEnemy > 0.6),
                        new AandC("Sting"),
                        new AandC("Creeping Fungus"),
                        new AandC("Blinding Powder"),
                    };
                    break;

                case "Crow":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Peck     | Alpha Strike
                     * Slot 2: Squawk   | Call Darkness
                     * Slot 3: Murder   | Nocturnal Strike
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Call Darkness",      () => ! weather("Darkness")),
                        new AandC("Nocturnal Strike",   () => enemyIsBlinded() || buff("Uncanny Lucky")),
                        new AandC("Squawk",             () => ! debuff("Attack Reduction")),                    
                        new AandC("Murder",             () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Peck"),
                        new AandC("Alpha Strike"),
                    };
                    break;

                case "Darkmoon Glowfly":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Scratch          | Slicing Wind
                     * Slot 2: Glowing Toxin    | Sting
                     * Slot 3: Confusing Sting  | Dazzling Dance
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Dazzling Dance",     () => speed <= speedEnemy && ! buff("Dazzling Dance")),
                        new AandC("Glowing Toxin",      () => ! debuff("Glowing Toxin")),
                        new AandC("Sting",              () => ! debuff("Sting")),
                        new AandC("Confusing Sting",    () => ! debuff("Confusing Sting")),
                        new AandC("Scratch"),
                        new AandC("Slicing Wind"),
                    };
                    break;

                case "Dragon Kite":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Breath           | Tail Sweep
                     * Slot 2: Call Lightning   | Roar 
                     * Slot 3: Volcano          | Lift-Off
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Call Lightning",     () => ! weather("Lightning Storm")),
                        new AandC("Roar",               () => ! buff("Attack Boost")),
                        new AandC("Volcano",            () => ! debuff("Volcano") && hpEnemy > 0.4),
                        new AandC("Breath"),
                        new AandC("Tail Sweep"),
                    };
                    break;

                case "Dread Hatchling":
                    /* Changelog:
                     * 2015-01-20: Nocturnal Strike is now checking for all blindness effect - Studio60
                     *             Nocturnal Strike is now used more often - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Peck             | Shadow Talon
                     * Slot 2: Call Darkness    | Consume Corpse
                     * Slot 3: Nocturnal Strike | Anzu's Blessing
                     * 
                     * TODO: Nocturnal Strike should check if pet has selected Call Darkness
                     * TODO: Consume Corpse needs to check for dead allies
                     * TODO: Add Uncanny Luck to Nocturnal Strike
                     */
                    // (missing condition) nocturnal strike: should check if pet has skill darkness
                    // (missing condition) consume corpse: requires e.g. "deadAllies > 0"
                    // nocturnal strike: only during darkness
                    flying_abilities = new List<AandC>() {
                        new AandC("Nocturnal Strike",   () => enemyIsBlinded()),
                        new AandC("Anzu's Blessing",    () => ! buff("Attack Boost")),
                        new AandC("Call Darkness",      () => ! weather("Darkness")),
                        new AandC("Nocturnal Strike"),
                        new AandC("Peck"),
                        new AandC("Shadow Talon"),
                        new AandC("Consume Corpse"),
                    };
                    break;

                case "Everbloom Peachick":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Quills           | Peck
                     * Slot 2: Hawk Eye         | Accuracy
                     * Slot 3: Reckless Strike  | Squawk
                     * 
                     * Tactic Information:
                     * Accuracy is not that important for this pet
                     * Reckless strike is risky if used against magic pets due to incoming spiky magic damage
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")),
                        new AandC("Quills",             () => speed > speedEnemy),
                        new AandC("Squawk",             () => ! debuff("Attack Reduction")),                    
                        new AandC("Reckless Strike",    () => ! famEnemy(PF.Magic)),
                        new AandC("Quills"),
                        new AandC("Peck"),
                        new AandC("Accuracy"),
                    };
                    break;

                case "Effervescent Glowfly":
                case "Firefly":
                case "Mei Li Sparkler":
                case "Shrine Fly":
                    /* Changelog:
                     * 2015-01-24: Cocoon Strike is now used to hide from big attacks - Studio60
                     * 
                     * Abilities
                     * Slot 1: Scratch          | Slicing Wind
                     * Slot 2: Confusing Sting  | Cocoon Strike
                     * Slot 3: Swarm            | Glowing Toxin
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Cocoon Strike",      () => shouldIHide && speed >= speedEnemy),
                        new AandC("Confusing Sting",    () => debuff("Confusing Sting")),
                        new AandC("Swarm",              () => ! debuff("Shattered Defenses")),
                        new AandC("Glowing Toxin",      () => ! debuff("Glowing Toxin")),
                        new AandC("Scratch"),
                        new AandC("Slicing Wind"),
                    };
                    break;

                case "Firewing":
                    /* Changelog:
                     * 2015-01-20: Deep Burn is now checking for all burn effects - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Alpha Strike | Deep Burn 
                     * Slot 2: Scorched Earth | Sunlight
                     * Slot 3: Healing Flame | Murder
                     * 
                     * Tactic Information:
                     * Alpha Strike is not wasted on Dragonkin
                     * Deep Burn is prioritizes if the enemy is burning
                     * Healing Flame is used later in Sunlight, because it heals more
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Deep Burn",      () => enemyIsBurning()),
                        new AandC("Scorched Earth", () => ! weather("Scorched Earth")),
                        new AandC("Sunlight",       () => ! weather("Sunny Day")),
                        new AandC("Healing Flame",  () => (weather("Sunny Day") && hp < 0.5) || (! weather("Sunny Day") && hp < 0.75)),
                        new AandC("Alpha Strike",   () => speed > speedEnemy && ! famEnemy(PF.Dragonkin)),
                        new AandC("Murder"),
                        new AandC("Alpha Strike"),
                        new AandC("Deep Burn"),
                    };
                    break;

                case "Flamering Moth":
                    /* Changelog:
                     * 2015-01-20: Cocoon Strike is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn             | Alpha Strike
                     * Slot 2: Cocoon Strike    | Healing Flame
                     * Slot 3: Nimbus           | Moth Dust
                     * 
                     * Tactic Information:
                     * Nimbus is usually not important for this pet
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Cocoon Strike",  () => shouldIHide && speed >= speedEnemy),
                        new AandC("Healing Flame",  () => hp < 0.75),
                        new AandC("Moth Dust"),
                        new AandC("Burn"),
                        new AandC("Alpha Strike"),
                        new AandC("Nimbus",         () => ! buff("Nimbus")),
                    };
                    break;

                case "Fledgling Nether Ray":
                case "Nether Ray Fry":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Bite         | Arcane Blast
                     * Slot 2: Tail Sweep   | Slicing Wind
                     * Slot 3: Shadow Shock | Lash
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Tail Sweep",     () => strong("Tail Sweep")),
                        new AandC("Slicing Wind",   () => strong("Slicing Wind")),
                        new AandC("Shadow Shock",   () => strong("Shadow Shock")),
                        new AandC("Lash",           () => strong("Lash")),
                        new AandC("Bite"),
                        new AandC("Arcane Blast"),
                    };
                    break;

                case "Gilnean Raven":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Peck             | Alpha Strike
                     * Slot 2: Darkflame        | Call Darkness
                     * Slot 3: Nocturnal Strike | Nevermore
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Darkflame",          () => strong("Darkflame") || ! debuff("Healing Reduction")),
                        new AandC("Call Darkness",      () => ! weather("Darkness")),
                        new AandC("Nocturnal Strike",   () => enemyIsBlinded() || buff("Uncanny Luck")),
                        new AandC("Nevermore"),
                        new AandC("Peck"),
                        new AandC("Alpha Strike"),
                    };
                    break;

                case "Golden Dawnfeather":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Quills           | Peck
                     * Slot 2: Sunlight         | Hawk Eye
                     * Slot 3: Reckless Strike  | Love Potion
                     * 
                     * Tactic Information:
                     * Reckless Strike is risky if used against magic pets due to incoming spiky magic damage
                     * Love Potion is stronger during Sunlight so we can heal later
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Sunlight",           () => ! weather("Sunny Day")),
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")),
                        new AandC("Reckless Strike",    () => ! famEnemy(PF.Magic)),
                        new AandC("Love Potion",        () => (weather("Sunny Day") && hp < 0.5) || (! weather("Sunny Day") && hp < 0.75)),
                        new AandC("Quills"),
                        new AandC("Peck"),
                    };
                    break;

                case "Gryphon Hatchling":
                case "Wildhammer Gryphon Hatchling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Peck     | Slicing Wind
                     * Slot 2: Squawk   | Adrenaline Rush
                     * Slot 3: Flock    | Lift-Off
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Squawk",             () => ! debuff("Attack Reduction")),
                        new AandC("Adrenaline Rush",    () => ! buff("Adrenaline")),
                        new AandC("Flock",              () => ! debuff("Shattered Defenses")),
                        new AandC("Peck"),
                        new AandC("Slicing Wind"),
                    };
                    break;

                case "Guardian Cub":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind     | Onyx Bite
                     * Slot 2: Roar             | Wild Winds
                     * Slot 3: Reckless Strike  | Cyclone
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Roar",               () => ! buff("Attack Boost")),
                        new AandC("Wild Winds",         () => ! debuff("Wild Winds")),
                        new AandC("Reckless Strike",    () => hp > hpEnemy),
                        new AandC("Slicing Wind"),
                        new AandC("Onyx Bite"),
                    };
                    break;

                case "Highlands Turkey":
                case "Plump Turkey":
                case "Turkey":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Peck         | Slicing Wind
                     * Slot 2: Squawk       | Gobble Strike
                     * Slot 3: Food Coma    | Flock
                     * 
                     * TODO: Reintroduce Food Coma if a use case is found
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Squawk",         () => ! debuff("Attack Reduction")),
                        new AandC("Gobble Strike",  () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Flock",          () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Peck"),
                        new AandC("Slicing Wind"),
                    };
                    break;

                case "Ikky":
                    /* Changelog:
                     * 2015-01-20: Nocturnal Strike is now only used against blinded enemies - Studio60
                     * 2015-01-19: Black Claw is only used if the enemy's health is above 15% (up from 0%) - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Savage Talon | Quills
                     * Slot 2: Black Claw   | Nocturnal Strike
                     * Slot 3: Flock        | Cyclone
                     * 
                     * Tactic Information:
                     * Quills are prioritized after Flock to finish the enemy off
                     * Flock is used in Black Claw combo
                     * 
                     * TODO: Add Uncanny Luck to Nocturnal Strike
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Black Claw",         () => ! debuff("Black Claw") && hpEnemy > 0.15),
                        new AandC("Nocturnal Strike",   () => enemyIsBlinded()),
                        new AandC("Quills",             () => debuff("Black Claw") && debuff("Shattered Defenses")),
                        new AandC("Flock",              () => debuff("Black Claw")),
                        new AandC("Savage Talon"),
                        new AandC("Quills"),
                    };
                    break;

                case "Imperial Moth":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind     | Wild Winds
                     * Slot 2: Cocoon Strike    | Moth Balls
                     * Slot 3: Moth Dust        | Cyclone
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Cocoon Strike",  () => shouldIHide && speed >= speedEnemy),
                        new AandC("Cyclone",        () => ! debuff("Cyclone")),
                        new AandC("Moth Balls",     () => buff("Uncanny Luck")),
                        new AandC("Moth Dust"),
                        new AandC("Slicing Wind"),
                        new AandC("Wild Winds"),
                    };
                    break;

                case "Jade Crane Chick":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind | Thrash
                     * Slot 2: Hawk Eye     | Jadeskin
                     * Slot 3: Cyclone      | Flock
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Cyclone",        () => ! debuff("Cyclone")),
                        new AandC("Hawk Eye",       () => ! buff("Hawk Eye")),
                        new AandC("Jadeskin",       () => ! buff("Jadeskin")),
                        new AandC("Jadeskin",       () => buffLeft("Jadeskin") == 1 && speed <= speedEnemy),
                        new AandC("Flock",          () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Slicing Wind"),
                        new AandC("Thrash"),
                    };
                    break;

                case "Ji-Kun Hatchling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind | Peck
                     * Slot 2: Wild Winds   | Acidic Goo
                     * Slot 3: Flock        | Caw
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Acidic Goo",     () => ! debuff("Acidic Goo")),
                        new AandC("Flock",          () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Wild Winds",     () => ! debuff("Wild Winds")),
                        new AandC("Caw",            () => ! buff("Caw")),
                        new AandC("Slicing Wind"),
                        new AandC("Peck"),
                    };
                    break;

                case "Kaliri Hatchling":
                    /* Changelog:
                     * 2015-01-20: Nocturnal Strike is now checking for all blindness effects - Studio60
                     * 2015-01-19: Nocturnal Strike is now sometimes used without the enemy being blinded - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Peck             | Quills
                     * Slot 2: Wild Winds       | Hawk Eye
                     * Slot 3: Nocturnal Strike | Predatory Strike
                     * 
                     * Tactic Information:
                     * Predatory Strike is used as a finisher
                     * 
                     * TODO: Nocturnal Strike should be used more often, if no team pet can cause Blindness
                     * TODO: Add Uncanny Luck to Nocturnal Strike
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Predatory Strike",   () => hpEnemy < 0.25),
                        new AandC("Nocturnal Strike",   () => enemyIsBlinded()),
                        new AandC("Wild Winds",         () => ! debuff("Wild Winds")),
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")),
                        new AandC("Nocturnal Strike"),
                        new AandC("Peck"),
                        new AandC("Quills"),
                    };
                    break;

                case "Mechanical Axebeak":
                    /* Changelog:
                     * 2015-01-20: Lift-Off is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     *             Haywire is now used whenever it is strong against an enemy, not only if the enemy is a critter - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Alpha Strike     | Peck
                     * Slot 2: Hawk Eye         | Haywire
                     * Slot 3: Decoy            | Lift-Off
                     * 
                     * Tactic Information:
                     * Haywire is only used against Critters
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Lift-Off",       () => shouldIHide && speed >= speedEnemy),
                        new AandC("Hawk Eye",       () => ! buff("Hawk Eye")),
                        new AandC("Haywire",        () => strong("Haywire")),
                        new AandC("Decoy",          () => ! buff("Decoy")),
                        new AandC("Lift-Off"),
                        new AandC("Alpha Strike"),
                        new AandC("Peck"),
                    };
                    break;

                case "Miniwing":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Peck             | Quills
                     * Slot 2: Shriek           | Cyclone
                     * Slot 3: Nocturnal Strike | Predatory Strike
                     * 
                     * TODO: Add Uncanny Luck to Nocturnal Strike
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Predatory Strike",   () => hpEnemy < 0.25),
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Shriek",             () => ! debuff("Attack Reduction")),
                        new AandC("Nocturnal Strike",   () => enemyIsBlinded() || buff("Uncanny Luck")),
                        new AandC("Peck"),
                        new AandC("Quills"),
                    };
                    break;

                case "Pterrordax Hatchling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind     | Flyby
                     * Slot 2: Ancient Blessing | Apocalypse
                     * Slot 3: Lift-Off         | Feign Death
                     * 
                     * Tactic Information:
                     * Deactivated Apocalypse as it would be suicidal
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Ancient Blessing",   () => !buff("Ancient Blessing") || hp < 0.75 ),
                        new AandC("Feign Death"),
                        new AandC("Slicing Wind"),
                        new AandC("Flyby"),
                    };
                    break;

                case "Royal Moth":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind | Alpha Strike
                     * Slot 2: Counterspell | Hawk Eye
                     * Slot 3: Moth Dust    | Predatory Strike
                     * 
                     * TODO: Use Counterspell selectively
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Predatory Strike",   () => hpEnemy < 0.25),
                        new AandC("Counterspell",       () => speed > speedEnemy),
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")),
                        new AandC("Moth Dust"),
                        new AandC("Slicing Wind"),
                        new AandC("Alpha Strike"),
                    };
                    break;

                case "Royal Peacock":
                    /* Changelog:
                     * 2015-01-19: Rain Dance is only used if the enemy's health is above 15% (up from 0%) - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Quills           | Savage Talon
                     * Slot 2: Dazzling Dance   | Arcane Storm
                     * Slot 3: Rain Dance       | Feign Death
                     * 
                     * TODO: Feign Death needs to check for living team pets
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Dazzling Dance",     () => ! buff("Dazzling Dance")),
                        new AandC("Arcane Storm"),
                        new AandC("Rain Dance",         () => ! buff("Rain Dance") && hp < 0.8 && hpEnemy > 0.15),
                        new AandC("Quills"),
                        new AandC("Savage Talon"),
                        new AandC("Feign Death"),
                    };
                    break;

                case "Rustberg Gull":
                case "Sandy Petrel":
                case "Sea Gull":
                    /* Changelog:
                     * 2015-01-24: Lift-Off is now used defensively - Studio60
                     * 
                     * Abilities 
                     * Slot 1: Slicing Wind | Thrash
                     * Slot 2: Cyclone      | Adrenaline Rush
                     * Slot 3: Hawk Eye     | Lift-Off
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")),
                        new AandC("Adrenaline Rush",    () => ! buff("Adrenaline")),
                        new AandC("Slicing Wind"),
                        new AandC("Thrash"),
                    };
                    break;

                case "Sentinel's Companion":
                    /* Changelog:
                     * 2015-01-20: Nocturnal Strike is now checking for all blindness effects - Studio60
                     *             Nocturnal Strike is now used with a higher priority - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Peck             | Dark Talon
                     * Slot 2: Nocturnal Strike | Soulrush
                     * Slot 3: Moonfire         | Ethereal
                     * 
                     * TODO: Add Uncanny Luck to Nocturnal Strike
                     */
                    // ethereal: can always dodge shouldIHide attacks
                    flying_abilities = new List<AandC>() {
                        new AandC("Ethereal",           () => shouldIHide),
                        new AandC("Nocturnal Strike",   () => enemyIsBlinded()),
                        new AandC("Soulrush"),
                        new AandC("Moonfire"),
                        new AandC("Nocturnal Strike"),
                        new AandC("Peck"),
                        new AandC("Dark Talon"),
                    };
                    break;

                case "Shadow Sporebat":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind     | Shadow Stash
                     * Slot 2: Creeping Fungus  | Leech Seed
                     * Slot 3: Spore Shrooms    | Barbed Stinger
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Creeping Fungus",    () => ! debuff("Creeping Fungus")),
                        new AandC("Leech Seed",         () => ! debuff("Leech Seed")),
                        new AandC("Spore Shrooms",      () => ! debuff("Spore Shrooms")),
                        new AandC("Barbed Stinger"),
                        new AandC("Slicing Wind"),
                        new AandC("Shadow Slash"),
                    };
                    break;

                case "Sky Fry":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Bite             | Arcane Blast
                     * Slot 2: Vicious Slice    | Alpha Strike
                     * Slot 3: Tail Sweep       | Shadow Shock
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Vicious Slice",  () => strong("Vicious Slice")),
                        new AandC("Alpha Strike",   () => strong("Alpha Strike")),
                        new AandC("Tail Sweep",     () => strong("Tail Sweep")),
                        new AandC("Shadow Shock",   () => strong("Shadow Shock")),
                        new AandC("Bite",           () => strong("Bite")),
                        new AandC("Arcane Blast",   () => strong("Arcane Blast")),
                        new AandC("Bite"),
                        new AandC("Arcane Blast"),
                        new AandC("Vicious Slice"),
                        new AandC("Alpha Strike"),
                        new AandC("Tail Sweep"),
                        new AandC("Shadow Shock"),
                    };
                    break;

                case "Skywisp Moth":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind     | Reckless Strike
                     * Slot 2: Cocoon Strike    | Counterspell
                     * Slot 3: Moth Dust        | Call Lightning
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Cocoon Strike",      () => shouldIHide && speed >= speedEnemy),
                        new AandC("Call Lightning",     () => ! weather("Lightning Storm")),
                        new AandC("Counterspell",       () => speed > speedEnemy ),
                        new AandC("Moth Dust"),
                        new AandC("Slicing Wind"),
                        new AandC("Reckless Strike"),
                    };
                    break;

                case "Stormwing":
                    /* Changelog:
                     * 2015-01-20: Lift-Off is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Alpha Strike     | Quills
                     * Slot 2: Call Lightning   | Lift-Off
                     * Slot 3: Thunderbolt      | Flock
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Lift-Off",       () => shouldIHide && speed >= speedEnemy),
                        new AandC("Call Lightning", () => ! weather("Lightning Storm")),
                        new AandC("Thunderbolt"),
                        new AandC("Lift-Off"),
                        new AandC("Flock"),
                        new AandC("Alpha Strike"),
                        new AandC("Quills"),
                    };
                    break;

                case "Sunfire Kaliri":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Deep Burn    | Fire Quills
                     * Slot 2: Shriek       | Scorched Earth
                     * Slot 3: Cauterize    | Predatory Strike
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Predatory Strike",   () => hpEnemy < 0.25),
                        new AandC("Shriek",             () => ! debuff("Attack Reduction")),
                        new AandC("Scorched Earth",     () => ! weather("Scorched Earth")),
                        new AandC("Cauterize",          () => hp < 0.75),
                        new AandC("Deep Burn"),
                        new AandC("Fire Quills"),
                    };
                    break;

                case "Swamplighter Firefly":
                    /* Changelog:
                     * 2015-01-20: Lift-Off is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     *             Puncture Wound is now checking for all poison effects - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Barbed Stinger   | Alpha Strike
                     * Slot 2: Lift-Off         | Puncture Wound
                     * Slot 3: Flyby            | Nimbus
                     */
                    // nimbus: don't need accuracy increase
                    // lift-off: used defensively if we are fast enough
                    flying_abilities = new List<AandC>() {
                        new AandC("Lift-Off",       () => shouldIHide && speed >= speedEnemy),
                        new AandC("Puncture Wound", () => enemyIsPoisoned()),
                        new AandC("Flyby",          () => ! debuff("Weakened Defenses")),
                        new AandC("Barbed Stinger"),
                        new AandC("Alpha Strike"),
                        new AandC("Lift-Off"),
                        new AandC("Nimbus"),
                    };
                    break;

                case "Teroclaw Hatchling":
                    /* Changelog:
                     * 2015-01-20: Dodge is now used to hide from huge attacks if it is faster or both bets have equal speed - Studio60
                     * 2015-01-19: Nature's Ward conditions have been updated (Studio60)
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Claw     | Alpha Strike
                     * Slot 2: Hawk Eye | Dodge
                     * Slot 3: Ravage   | Nature's Ward
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Dodge",          () => shouldIHide && speed >= speedEnemy),
                        new AandC("Hawk Eye",       () => ! buff("Hawk Eye")),
                        new AandC("Ravage",         () => (! famEnemy(PF.Critter) && hp < 0.2)  || (famEnemy(PF.Critter) && hp < 0.4)),
                        new AandC("Nature's Ward",  () => hp < 0.9 && ! famEnemy(PF.Aquatic) && ! buff("Nature's Ward")),
                        new AandC("Claw"),
                        new AandC("Alpha Strike"),
                    };
                    break;

                case "Tiny Flamefly":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn     | Alpha Strike
                     * Slot 2: Immolate | Hiss
                     * Slot 3: Swarm    | Adrenaline Rush
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Immolate",           () => ! debuff("Immolate")),
                        new AandC("Adrenaline Rush",    () => ! buff("Adrenaline")),
                        new AandC("Hiss",               () => ! debuff("Speed Reduction")),
                        new AandC("Swarm",              () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Burn"),
                        new AandC("Alpha Strike"),
                    };
                    break;

                case "Tiny Sporebat":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind     | Shadow Slash
                     * Slot 2: Creeping Fungus  | Leech Seed
                     * Slot 3: Spore Shrooms    | Confusing Sting
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Creeping Fungus",    () => ! debuff("Creeping Fungus")),
                        new AandC("Leech Seed",         () => ! debuff("Leech Seed")),
                        new AandC("Spore Shrooms",      () => ! debuff("Spore Shroooms") && hpEnemy > 0.4),
                        new AandC("Confusing Sting",    () => ! debuff("Confusing Sting")),
                        new AandC("Slicing Wind"),
                        new AandC("Shadow Slash"),
                    };
                    break;

                case "Tuskarr Kite":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind | Frost Shock
                     * Slot 2: Wild Winds   | Cyclone
                     * Slot 3: Flyby        | Reckless Strike
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Wild Winds",         () => ! debuff("Wild Winds")),
                        new AandC("Flyby",              () => ! debuff("Attack Reduction")),
                        new AandC("Reckless Strike",    () => hp > hpEnemy),
                        new AandC("Slicing Wind"),
                        new AandC("Frost Shock"),
                    };
                    break;

                case "Umbrafen Spore":
                    /* Changelog:
                     * 2015-01-20: Spore Shrooms is no longer recast too early - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Confusing Sting  | Creeping Fungus
                     * Slot 2: Spiked Skin      | Blinding Powder
                     * Slot 3: Spore Shrooms    | Explode
                     * 
                     * TODO: Explode needs to check if a backup pet is available
                     */
                    flying_abilities = new List<AandC>() {
                        new AandC("Explode",            () => hp < 0.1),
                        new AandC("Spiked Skin",        () => ! buff("Spiked Skin")),
                        new AandC("Blinding Powder"),
                        new AandC("Spore Shrooms",      () => ! debuff("Spore Shrooms")),
                        new AandC("Confusing Sting"),
                        new AandC("Creeping Fungus"),
                    };
                    break;

                case "Veilwatcher Hatchling":
                    /* Changelog:
                     * 2015-01-20: Nocturnal Strike is now checking for all blindness effects - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Peck             | Quills
                     * Slot 2: Wild Winds       | Flock
                     * Slot 3: Nocturnal Strike | Predatory Strike
                     * 
                     * TODO: Add Uncanny Luck to Nocturnal Strike
                     */
                    // nocturnal strike: only if enemy is blinded
                    flying_abilities = new List<AandC>() {
                        new AandC("Predatory Strike",   () => hpEnemy < 0.25),
                        new AandC("Wild Winds",         () => ! debuff("Wild Winds")),
                        new AandC("Nocturnal Strike",   () => enemyIsBlinded()),
                        new AandC("Flock",              () => ! debuff("Shattered Defenses")),
                        new AandC("Peck"),
                        new AandC("Quills"),
                    };
                    break;

                case "Waterfly":
                    /* Changelog:
                     * 2015-01-24: Small tactic revision - Studio60
                     * 
                     * Abilities
                     * Slot 1: Barbed Stinger   | Alpha Strike
                     * Slot 2: Healing Stream   | Puncture Wound
                     * Slot 3: Lift-Off         | Dodge
                     */
                    flying_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Dodge",              () => shouldIHide && speed >= speedEnemy),
                        new AandC("Healing Stream",     () => hp < 0.7),
                        new AandC("Barbed Stinger",     () => ! debuff("Poisoned")),
                        new AandC("Alpha Strike",       () => speed > speedEnemy),
                        new AandC("Puncture Wound",     () => debuff("Poisoned")),
                        new AandC("Barbed Stinger"),
                        new AandC("Alpha Strike"),
                    };
                    break;                

                default:
                    ////////////////////////
                    // Unknown Flying Pet //
                    ////////////////////////
                    Logger.Alert("Unknown flying pet: " + petName);
                    flying_abilities = null;
                    break;
            }

            return flying_abilities;
        }
    }
}
