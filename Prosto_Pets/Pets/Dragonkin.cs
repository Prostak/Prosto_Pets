///////////////
// DRAGONKIN //
///////////////

using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Dragonkin : PetTacticsBase
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

            List<AandC> dragonkin_abilities;

            switch (petName)
            {

                case "Albino Chimaeraling":
                    /* Changelog:
                     * 2015-01-20: Lift-Off has had its defensive priority increased - Studio60
                     *             Lift-Off is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Shadowflame  | Tail Sweep
                     * Slot 2: Roar         | Call Darkness
                     * Slot 3: Lift-Off     | Deep Breath
                     * 
                     * Tactic Information:
                     * Deep Breath does more dmg vs magic, but magic-pets can't receive more dmg than 35% of their hp
                     * Deep Breath tends to miss... 
                     */
                    dragonkin_abilities = new List<AandC>() {
                        new AandC("Lift-Off",       () => shouldIHide && speed >= speedEnemy),
                        new AandC("Roar",           () => ! buff("Attack Boost")),
                        new AandC("Call Darkness",  () => ! weather("Darkness")),
                        new AandC("Lift-Off",       () => strong("Lift-Off")),
                        new AandC("Shadowflame"),
                        new AandC("Tail Sweep"),
                        new AandC("Deep Breath"),
                    };
                    break;

                case "Azure Whelpling":
                    /* Changelog: 
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Claw             | Breath
                     * Slot 2: Arcane Storm     | Wild Magic
                     * Slot 3: Surge of Power   | Ice Tomb
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Surge of Power", () => debuff("Shattered Defenses")),
                        new AandC("Wild Magic",     () => ! debuff("Wild Magic")),
                        new AandC("Ice Tomb",       () => ! debuff("Ice Tomb")),
                        new AandC("Arcane Storm",   () => ! weather("Arcane Winds")),
                        new AandC("Arcane Storm",   () => ! myPetHasAbility("Claw") && (weak("Claw") || strong("Arcane Storm"))),
                        new AandC("Arcane Storm",   () => ! myPetHasAbility("Breath") && (weak("Breath") || strong("Arcane Storm"))),
                        new AandC("Surge of Power", () => hpEnemy < 0.4),
                        new AandC("Claw"),
                        new AandC("Breath"),
                    };
                    break;

                case "Blue Dragonhawk Hatchling":
                case "Golden Dragonhawk Hatchling":
                case "Red Dragonhawk Hatchling":
                case "Silver Dragonhawk Hatchling":
                    /* Abilities:
                     * Slot 1: Claw         | Quills
                     * Slot 2: Rake         | Conflagrate
                     * Slot 3: Flame Breath | Flamethrower
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Flamethrower",   () => ! debuff("Flamethrower")),
                        new AandC("Conflagrate",    () => enemyIsBurning),
                        new AandC("Flame Breath",   () => ! debuff("Flame Breath")),
                        new AandC("Rake",           () => ! weak("Rake")),
                        new AandC("Claw"),
                        new AandC("Quills"),
                    };
                    break;

                case "Bronze Whelpling":
                    /* Change Log:
                     * 2015-01-15: Initial design by Valpsjuk
                     * 
                     * Abilities:
                     * Slot 1: Arcane Slash     | Tail Sweep
                     * Slot 2: Early Advantage  | Crystal Prison
                     * Slot 3: Lift-Off         | Arcane Storm
                     */
                    dragonkin_abilities = new List<AandC>()
                    {
                        new AandC("Arcane Slash",       () => hpEnemy < 0.2),
                        new AandC("Arcane Storm",       () => buffLeft("Arcane Storm") < 2),
                        new AandC("Early Advantage",    () => hpEnemy < hp),
                        new AandC("Tail Sweep"),
                        new AandC("Arcane Slash"),
                        new AandC("Crystal Prison"),
                    };
                    break;

                case "Celestial Dragon":
                    /* Abilities:
                     * Slot 1: Flamethrower     | Roar 
                     * Slot 2: Ancient Blessing | Arcane Storm
                     * Slot 3: Moonfire         | Starfall
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Ancient Blessing",   () => ! buff("Ancient Blessing") || hp < 0.75),
                        new AandC("Moonfire",           () => ! weather("Moonlight")),
                        new AandC("Starfall",           () => ! weather("Moonlight")),
                        new AandC("Roar",               () => ! buff("Attack Boost")),
                        new AandC("Flamethrower"),
                        new AandC("Arcane Storm"),
                    };
                    break;

                case "Chrominius":
                    /* Changelog:
                     * 2015-01-24: Existing tactic revised
                     * 
                     * Abilities:
                     * Slot 1: Bite     | Arcane Explosion
                     * Slot 2: Howl     | Ancient Blessing
                     * Slot 3: Ravage   | Surge of Power
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Ancient Blessing",   () => ! buff("Ancient Blessing") || hp < 0.75 ),
                        new AandC("Howl",               () => ! debuff("Shattered Defenses")),
                        new AandC("Ravage",             () => hp < 0.2),
                        new AandC("Ravage",             () => strong("Ravage") && hp < 0.3),
                        new AandC("Surge of Power",     () => debuff("Shattered Defenses")),
                        new AandC("Bite"),
                        new AandC("Arcane Explosion"),
                    };
                    break;

                case "Crimson Whelpling":
                case "Onyxian Whelpling":
                case "Spawn of Onyxia":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Breath           | Tail Sweep
                     * Slot 2: Healing Flame    | Scorched Earth
                     * Slot 3: Lift-Off         | Deep Breath
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",       () => shouldIHide && speed <= speedEnemy),
                        new AandC("Healing Flame",  () => hp < 0.75),
                        new AandC("Scorched Earth", () => ! weather("Scorched Earth") && ! famEnemy(PF.Elemental)),
                        new AandC("Deep Breath",    () => hpEnemy > 0.5),
                        new AandC("Breath"),
                        new AandC("Tail Sweep"),
                    };
                    break;

                case "Dark Whelpling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Shadowflame  | Tail Sweep
                     * Slot 2: Roar         | Call Darkness
                     * Slot 3: Lift-Off     | Deep Breath
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",       () => shouldIHide && speed >= speedEnemy),
                        new AandC("Roar",           () => ! buff("Attack Boost")),
                        new AandC("Call Darkness",  () => ! weather("Darkness")),
                        new AandC("Deep Breath",    () => hpEnemy > 0.5),
                        new AandC("Shadowflame"),
                        new AandC("Tail Sweep"),
                    };
                    break;

                case "Death Talon Whelpguard":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Blitz        | Shadowflame
                     * Slot 2: Whirlwind    | Spiked Skin
                     * Slot 3: Darkflame    | Clobber
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Clobber",        () => ! enemyIsStunned && ! enemyIsResilient),
                        new AandC("Spiked Skin",    () => ! buff("Spiked Skin")),
                        new AandC("Spiked Skin",    () => buffLeft("Spiked Skin") == 1 && speed < speedEnemy),
                        new AandC("Darkflame",      () => ! debuff("Healing Reduction")),
                        new AandC("Whirlwind"),
                        new AandC("Blitz"),
                        new AandC("Shadowflame"),
                    };
                    break;

                case "Emerald Proto-Whelp":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Breath           | Emerald Bite
                     * Slot 2: Ancient Blessing | Emerald Presence 
                     * Slot 3: Proto-Strike     | Emerald Dream
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Proto-Strike",       () => shouldIHide && speed <= speedEnemy),
                        new AandC("Emerald Dream",      () => hp < 0.5 && hpEnemy > 0.3),
                        new AandC("Ancient Blessing",   () => ! buff("Ancient Blessing") || hp < 0.75),
                        new AandC("Emerald Presence",   () => ! buff("Emerald Presence")),
                        new AandC("Emerald Presence",   () => buffLeft("Emerald Presence") == 1 || speed < speedEnemy),
                        new AandC("Breath"),
                        new AandC("Emerald Bite"),
                    };
                    break;

                case "Essence of Competition":
                case "Spirit of Competition":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Breath           | Tail Sweep
                     * Slot 2: Ancient Blessing | Competitive Spirit
                     * Slot 3: Lift-Off         | Flamethrower
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Ancient Blessing",   () => ! buff("Ancient Blessing") || hp < 0.75),
                        new AandC("Competitive Spirit", () => ! buff("Competitive Spirit")),
                        new AandC("Flamethrower",       () => ! debuff("Flamethrower")),
                        new AandC("Flamethrower",       () => weak("Breath") || strong("Flamethrower")),
                        new AandC("Breath"),
                        new AandC("Tail Sweep"),
                    };
                    break;

                case "Emerald Whelpling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Breath       | Emerald Bite
                     * Slot 2: Moonfire     | Emerald Presence
                     * Slot 3: Tranquility  | Emerald Dream
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Emerald Dream",      () => hp < 0.5 && hpEnemy > 0.2),
                        new AandC("Moonfire",           () => ! weather("Moonlight")),
                        new AandC("Moonfire",           () => myPetHasAbility("Breath") && (weak("Breath") || strong("Moonfire"))),
                        new AandC("Tranquility",        () => ! buff("Tranquility") && hp < 0.8),
                        new AandC("Emerald Presence",   () => ! buff("Emerald Presence")),
                        new AandC("Emerald Presence",   () => buffLeft("Emerald Presence") == 1 && speed < speedEnemy),
                        new AandC("Breath"),
                        new AandC("Emerald Bite"),
                    };
                    break;

                case "Infinite Whelpling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Tail Sweep       | Sleeping Gas
                     * Slot 2: Healing Flame    | Weakness
                     * Slot 3: Early Advantage  | Darkflame
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Healing Flame",      () => hp < 0.75),
                        new AandC("Early Advantage",    () => hpEnemy < hp),
                        new AandC("Early Advantage",    () => weak("Tail Sweep") || strong("Early Advantage")),
                        new AandC("Darkflame"),
                        new AandC("Weakness",           () => weak("Tail Sweep") || strong("Weakness")),
                        new AandC("Tail Sweep"),
                        new AandC("Sleeping Gas"),
                    };
                    break;

                case "Lanticore Spawnling":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Triple Snap      | Sleeping Gas
                     * Slot 2: Cataclysm        | Corrosion
                     * Slot 3: Ancient Blessing | Devour
                     * 
                     * Tactics Information:
                     * Cataclysm's hit chance makes it too unreliable without other hit chance buff
                     * Devour can be used earlier against critters
                     */
                    dragonkin_abilities = new List<AandC>() {
                        new AandC("Devour",             () => hpEnemy < 0.25 || (famEnemy(PF.Critter) && hpEnemy > 0.4)),
                        new AandC("Cataclysm",          () => myPetIsLucky),
                        new AandC("Ancient Blessing",   () => hp < 0.8 && ! buff("Ancient Blessing")),
                        new AandC("Corrosion",          () => ! debuff("Corrosion")),
                        new AandC("Triple Snap"),
                        new AandC("Sleeping Gas"),
                        new AandC("Cataclysm"),
                    };
                    break;

                case "Lil' Deathwing":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Shadowflame      | Tail Sweep
                     * Slot 2: Call Darkness    | Roll
                     * Slot 3: Elementium Bolt  | Cataclysm
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Call Darkness",      () => ! weather("Darkness")),
                        new AandC("Elementium Bolt",    () => hpEnemy > 0.6),
                        new AandC("Roll",               () => ! buff("Attack Boost")),
                        new AandC("Cataclysm",          () => myPetIsLucky),
                        new AandC("Shadowflame"),
                        new AandC("Tail Sweep"),
                    };
                    break;

                case "Lil' Tarecgosa":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Breath           | Arcane Blast
                     * Slot 2: Surge of Power   | Wild Magic
                     * Slot 3: Arcane Storm     | Arcane Explosion
                     * 
                     * TODO: Reintroduce Arcane Explosion - Needs to check enemy team status
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Wild Magic",         () => ! debuff("Wild Magic")),
                        new AandC("Arcane Storm",       () => ! weather("Arcane Winds")),
                        new AandC("Surge of Power",     () => hpEnemy < 0.4),
                        new AandC("Breath"),
                        new AandC("Arcane Blast"),
                    };
                    break;

                case "Nether Faerie Dragon":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Slicing Wind | Arcane Blast
                     * Slot 2: Evanescence  | Life Exchange
                     * Slot 3: Moonfire     | Cyclone
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Evanescence",    () => shouldIHide && speed >= speedEnemy),
                        new AandC("Life Exchange",  () => ((hpValue + hpValueEnemy) / 2) > hpMax * 0.25 && hp < 0.75),
                        new AandC("Life Exchange",  () => ((hpValue + hpValueEnemy) / 2) > hpMax * 0.5),
                        new AandC("Moonfire",       () => ! weather("Moonlight")),
                        new AandC("Cyclone",        () => ! debuff("Cyclone")),
                        new AandC("Slicing Wind"),
                        new AandC("Arcane Blast"),
                    };
                    break;

                case "Netherwhelp":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Breath       | Nether Blast
                     * Slot 2: Phase Shift  | Accuracy
                     * Slot 3: Instability  | Soulrush
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Phase Shift",    () => shouldIHide && speed >= speedEnemy),
                        new AandC("Accuracy",       () => ! buff("Accuracy")),
                        new AandC("Instability",    () => myPetIsLucky),
                        new AandC("Soulrush"),
                        new AandC("Breath"),
                        new AandC("Nether Blast"),
                    };
                    break;

                case "Nexus Whelpling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Tail Sweep | Frost Breath
                     * Slot 2: Sear Magic | Mana Surge
                     * Slot 3: Wild Magic | Arcane Storm
                     * 
                     * TODO: Reintroduce Sear Magic - Needs to evaluate self auras
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Wild Magic",     () => ! debuff("Wild Magic")),                        
                        new AandC("Arcane Storm",   () => ! weather("Arcane Winds")),
                        new AandC("Arcane Storm",   () => ! weak("Tail Sweep") || strong("Arcane Storm")),
                        new AandC("Mana Surge",     () => weather("Arcane Winds")),
                        new AandC("Tail Sweep"),
                        new AandC("Frost Breath"),
                    };
                    break;

                case "Proto-Drake Whelp":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Breath       | Bite
                     * Slot 2: Flamethrower | Ancient Blessing
                     * Slot 3: Proto-Strike | Roar
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Proto-Strike",       () => shouldIHide && speed >= speedEnemy),
                        new AandC("Ancient Blessing",   () => ! buff("Ancient Blessing") || hp < 0.75),
                        new AandC("Roar",               () => ! buff("Attack Boost") ),
                        new AandC("Flamethrower",       () => ! debuff("Flamethrower")),
                        new AandC("Flamethrower",       () => myPetHasAbility("Breath") && (weak("Breath") || strong("Flamethrower"))),
                        new AandC("Flamethrower",       () => myPetHasAbility("Bite") && (weak("Bite") || strong("Flamethrower"))),
                        new AandC("Breath"),
                        new AandC("Bite"),
                    };
                    break;

                case "Phoenix Hawk Hatchling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Claw         | Quills
                     * Slot 2: Rake         | Flyby
                     * Slot 3: Flame Breath | Lift-Off
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",       () => shouldIHide && speed >= speedEnemy),
                        new AandC("Rake",           () => myPetHasAbility("Quills") && (weak("Quills") || strong("Rake"))), 
                        new AandC("Flame Breath",   () => ! debuff("Flame Breath")),
                        new AandC("Flyby",          () => ! debuff("Weakened Defenses")),
                        new AandC("Flyby",          () => myPetHasAbility("Claw") && (weak("Claw") || strong("Flyby"))),
                        new AandC("Flame Breath",   () => myPetHasAbility("Quills") && (weak("Quills") || strong("Flame Breath"))),
                        new AandC("Flame Breath",   () => myPetHasAbility("Claw") && (weak("Claw") || strong("Flame Breath"))),
                        new AandC("Claw"),
                        new AandC("Quills"),
                    };
                    break;

                case "Sprite Darter Hatchling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Slicing Wind | Arcane Blast
                     * Slot 2: Evanescence  | Life Exchange
                     * Slot 3: Moonfire     | Cyclone
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Evanescence",    () => shouldIHide && speed >= speedEnemy),
                        new AandC("Life Exchange",  () => hp * 2.5 < hpEnemy),
                        new AandC("Cyclone",        () => ! debuff("Cyclone")),
                        new AandC("Moonfire",       () => ! weather("Moonlight")),
                        new AandC("Moonfire",       () => myPetHasAbility("Slicing Wind") && (weak("Slicing Wind") ||strong("Moonfire"))),
                        new AandC("Slicing Wind"),
                        new AandC("Arcane Blast"),
                    };
                    break;

                case "Soul of the Aspects":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Claw             | Breath
                     * Slot 2: Sunlight         | Deflection
                     * Slot 3: Surge of Light   | Solar Beam
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Deflection",         () => shouldIHide),
                        new AandC("Sunlight",           () => ! weather("Sunlight")),
                        new AandC("Surge of Light"),
                        new AandC("Solar Beam",         () => hpEnemy < 0.4),
                        new AandC("Claw"),
                        new AandC("Breath"),
                    };
                    break;

                case "Thundering Serpent Hatchling":
                case "Tiny Green Dragon":
                case "Tiny Red Dragon":
                case "Wild Golden Hatchling":
                case "Wild Jade Hatchling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Breath           | Tail Sweep
                     * Slot 2: Call Lightning   | Roar
                     * Slot 3: Cyclone          | Lift-OFf
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Roar",               () => ! buff("Attack Boost")),
                        new AandC("Call Lightning",     () => ! weather("Lightning Storm")),
                        new AandC("Breath"),
                        new AandC("Tail Sweep"),
                    };
                    break;

                case "Untamed Hatchling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Claw         | Tail Sweep
                     * Slot 2: Roar         | Spiked Skin
                     * Slot 3: Instability  | Healing Flame
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Healing Flame",  () => hp < 0.75),
                        new AandC("Roar",           () => ! buff("Attack Boost")),
                        new AandC("Spiked Skin",    () => ! buff("Spiked Skin")),
                        new AandC("Instability",    () => myPetIsLucky),
                        new AandC("Claw"),
                        new AandC("Tail Sweep"),
                    };
                    break;

                case "Wild Crimson Hatchling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Breath           | Tail Sweep
                     * Slot 2: Healing Flame    | Scorched Earth
                     * Slot 3: Lift-Off         | Deep Breath
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",       () => shouldIHide && speed >= speedEnemy),
                        new AandC("Healing Flame",  () => hp < 0.75),
                        new AandC("Scorched Earth", () => ! weather("Scorched Earth")),
                        new AandC("Deep Breath",    () => hpEnemy > 0.4),
                        new AandC("Breath"),
                        new AandC("Tail Sweep"),
                    };
                    break;

                case "Yu'la, Broodling of Yu'lon":
                    /* Changelog:
                     * 2015-01-20: Lift-Off is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Breath           | Jadefire Lightning
                     * Slot 2: Emerald Presence | Celestial Blessing
                     * Slot 3: Lift-Off         | Life Exchange
                     * 
                     * TODO: Clestial Blessing does only make sense with another pet and immediate swapout
                     * TODO: Life Exchange needs absolute hp values to be used right, might mess things up on ringer-pets otherwise
                     * TODO: Lift-Off should be used aggressively if the enemy has no shouldIHide-attacks
                     */
                    dragonkin_abilities = new List<AandC>() {
                        new AandC("Emerald Presence",       () => ! buff("Emerald Presence")),
                        new AandC("Lift-Off",               () => strong("Lift-Off")),
                        new AandC("Lift-Off",               () => shouldIHide && speed >= speedEnemy),
                        new AandC("Breath"),
                        new AandC("Jadefire Lightning"),
                        new AandC("Celestial Blessing"),
                        new AandC("Life Exchange"),
                    };
                    break;

                default:
                    ///////////////////////////
                    // Unknown Dragonkin Pet //
                    ///////////////////////////
                    Logger.Alert("Unknown dragonkin pet: " + petName);
                    dragonkin_abilities = null;
                    break;
            }

            return dragonkin_abilities;
        }
    }
}
