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
                    /* Abilities:
                     * Slot 1: Claw             | Breath
                     * Slot 2: Arcane Storm     | Wild Magic
                     * Slot 3: Surge of Power   | Ice Tomb
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Claw"),
                        new AandC("Breath"),
                        new AandC("Arcane Storm"),
                        new AandC("Wild Magic"),
                        new AandC("Surge of Power"),
                        new AandC("Ice Tomb"),
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
                        new AandC("Claw"),
                        new AandC("Quills"),
                        new AandC("Rake"),
                        new AandC("Conflagrate"),
                        new AandC("Flame Breath"),
                        new AandC("Flamethrower"),
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
                        new AandC("Moonfire",           () => ! weather("Moonlight")),
                        new AandC("Starfall",           () => ! weather("Moonlight")),
                        new AandC("Ancient Blessing",   () => buff("Ancient Blessing") || hp < 0.75),
                        new AandC("Roar",               () => ! buff("Attack Boost")),
                        new AandC("Flamethrower"),
                        new AandC("Arcane Storm"),
                    };
                    break;

                case "Chrominius":
                    /* Abilities:
                     * Slot 1: Bite     | Arcane Explosion
                     * Slot 2: Howl     | Ancient Blessing
                     * Slot 3: Ravage   | Surge of Power
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Ancient Blessing",   () => !buff("Ancient Blessing") || hp < 0.75 ),
                        new AandC("Howl"),
                        new AandC("Surge of Power"),
                        new AandC("Bite"),
                        new AandC("Arcane Explosion"),
                        new AandC("Ravage"),
                    };
                    break;

                case "Crimson Whelpling": 
                case "Onyxian Whelpling": 
                case "Spawn of Onyxia":
                    /* Abilities:
                     * Slot 1: Breath           | Tail Sweep
                     * Slot 2: Healing Flame    | Scorched Earth
                     * Slot 3: Lift-Off         | Deep Breath
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Healing Flame",      () => hp < 0.75),
                        new AandC("Lift-Off"),
                        new AandC("Breath"),
                        new AandC("Tail Sweep"),
                        new AandC("Scorched Earth"),
                        new AandC("Deep Breath"),
                    };
                    break;

                case "Dark Whelpling":
                    /* Abilities:
                     * Slot 1: Shadowflame  | Tail Sweep
                     * Slot 2: Roar         | Call Darkness
                     * Slot 3: Lift-Off     | Deep Breath
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Roar",           () => ! buff("Attack Boost")),
                        new AandC("Lift-Off"),
                        new AandC("Shadowflame"),
                        new AandC("Tail Sweep"),
                        new AandC("Call Darkness"),
                        new AandC("Deep Breath"),
                    };
                    break;

                case "Death Talon Whelpguard":
                    /* Abilities:
                     * Slot 1: Blitz        | Shadowflame
                     * Slot 2: Whirlwind    | Spiked Skin
                     * Slot 3: Darkflame    | Clobber
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Blitz"),
                        new AandC("Shadowflame"),
                        new AandC("Whirlwind"),
                        new AandC("Spiked Skin"),
                        new AandC("Darkflame"),
                        new AandC("Clobber"),
                    };
                    break;

                case "Emerald Proto-Whelp":
                    /* Abilities:
                     * Slot 1: Breath           | Emerald Bite
                     * Slot 2: Ancient Blessing | Emerald Presence 
                     * Slot 3: Proto-Strike     | Emerald Dream
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Ancient Blessing",   () => buff("Ancient Blessing") || hp < 0.75),
                        new AandC("Breath"),
                        new AandC("Emerald Bite"),
                        new AandC("Emerald Presence"),
                        new AandC("Proto-Strike"),
                        new AandC("Emerald Dream"),
                    };
                    break;

                case "Essence of Competition":
                case "Spirit of Competition":
                    /* Abilities:
                     * Slot 1: Breath           | Tail Sweep
                     * Slot 2: Ancient Blessing | Competitive Spirit
                     * Slot 3: Lift-Off         | Flamethrower
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Ancient Blessing",       () => buff("Ancient Blessing") || hp < 0.75),
                        new AandC("Lift-Off"),
                        new AandC("Breath"),
                        new AandC("Tail Sweep"),
                        new AandC("Competitive Spirit"),
                        new AandC("Flamethrower"),
                    };
                    break;

                case "Emerald Whelpling":
                    /* Abilities:
                     * Slot 1: Breath       | Emerald Bite
                     * Slot 2: Moonfire     | Emerald Presence
                     * Slot 3: Tranquility  | Emerald Dream
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Moonfire",           () => ! weather("Moonlight")),
                        new AandC("Breath"),
                        new AandC("Emerald Bite"),
                        new AandC("Emerald Presence"),
                        new AandC("Tranquility"),
                        new AandC("Emerald Dream"),
                    };
                    break;

                case "Infinite Whelpling":
                    /* Abilities:
                     * Slot 1: Tail Sweep       | Sleeping Gas
                     * Slot 2: Healing Flame    | Weakness
                     * Slot 3: Early Advantage  | Darkflame
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Healing Flame",      () => hp < 0.75),
                        new AandC("Tail Sweep"),
                        new AandC("Sleeping Gas"),
                        new AandC("Weakness"),
                        new AandC("Early Advantage"),
                        new AandC("Darkflame"),
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
                        new AandC("Ancient Blessing",   () => hp < 0.8 && ! buff("Ancient Blessing")),
                        new AandC("Corrosion",          () => ! debuff("Corrosion")),
                        new AandC("Triple Snap"),
                        new AandC("Sleeping Gas"),
                        new AandC("Cataclysm"),
                    };
                    break;

                case "Lil' Deathwing":
                    /* Abilities:
                     * Slot 1: Shadowflame      | Tail Sweep
                     * Slot 2: Call Darkness    | Roll
                     * Slot 3: Elementium Bolt  | Cataclysm
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Shadowflame"),
                        new AandC("Tail Sweep"),
                        new AandC("Call Darkness"),
                        new AandC("Roll"),
                        new AandC("Elementium Bolt"),
                        new AandC("Cataclysm"),
                    };
                    break;

                case "Lil' Tarecgosa":
                    /* Abilities:
                     * Slot 1: Breath           | Arcane Blast
                     * Slot 2: Surge of Power   | Wild Magic
                     * Slot 3: Arcane Storm     | Arcane Explosion
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Breath"),
                        new AandC("Arcane Blast"),
                        new AandC("Surge of Power"),
                        new AandC("Wild Magic"),
                        new AandC("Arcane Storm"),
                        new AandC("Arcane Explosion"),
                    };
                    break;    

                case "Nether Faerie Dragon":
                    /* Abilities:
                     * Slot 1: Slicing Wind | Arcane Blast
                     * Slot 2: Evanescence  | Life Exchange
                     * Slot 3: Moonfire     | Cyclone
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Moonfire",       () => ! weather("Moonlight")),
                        new AandC("Cyclone",        () => ! debuff("Cyclone")),
                        new AandC("Slicing Wind"),
                        new AandC("Arcane Blast"),
                        new AandC("Evanescence"),
                        new AandC("Life Exchange"),
                    };
                    break;

                case "Netherwhelp":
                    /* Abilities:
                     * Slot 1: Breath       | Nether Blast
                     * Slot 2: Phase Shift  | Accuracy
                     * Slot 3: Instability  | Soulrush
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Breath"),
                        new AandC("Nether Blast"),
                        new AandC("Phase Shift"),
                        new AandC("Accuracy"),
                        new AandC("Instability"),
                        new AandC("Soulrush"),
                    };
                    break;

                case "Nexus Whelpling":
                    /* Abilities:
                     * Slot 1: Tail Sweep | Frost Breath
                     * Slot 2: Sear Magic | Mana Surge
                     * Slot 3: Wild Magic | Arcane Storm
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Arcane Storm", ()=> ! weather("Arcane Storm")),
                        new AandC("Mana Surge"),
                        new AandC("Tail Sweep"),
                        new AandC("Frost Breath"),
                        new AandC("Sear Magic"),
                        new AandC("Wild Magic"),
                    };
                    break;

                case "Proto-Drake Whelp":
                    /* Abilities:
                     * Slot 1: Breath       | Bite
                     * Slot 2: Flamethrower | Ancient Blessing
                     * Slot 3: Proto-Strike | Roar
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Ancient Blessing",   () => buff("Ancient Blessing") || hp < 0.75),
                        new AandC("Roar",               () => ! buff("Attack Boost") ),
                        new AandC("Breath"),
                        new AandC("Bite"),
                        new AandC("Flamethrower"),
                        new AandC("Proto-Strike"),
                    };
                    break;

                case "Phoenix Hawk Hatchling":
                    /* Abilities:
                     * Slot 1: Claw         | Quills
                     * Slot 2: Rake         | Flyby
                     * Slot 3: Flame Breath | Lift-Off
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off"),
                        new AandC("Claw"),
                        new AandC("Quills"),
                        new AandC("Rake"),
                        new AandC("Flyby"),
                        new AandC("Flame Breath"),
                    };
                    break;

                case "Sprite Darter Hatchling":
                    /* Abilities:
                     * Slot 1: Slicing Wind | Arcane Blast
                     * Slot 2: Evanescence  | Life Exchange
                     * Slot 3: Moonfire     | Cyclone
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Moonfire",       () => ! weather("Moonlight")),
                        new AandC("Cyclone",        () => ! debuff("Cyclone")),
                        new AandC("Slicing Wind"),
                        new AandC("Arcane Blast"),
                        new AandC("Evanescence"),
                        new AandC("Life Exchange"),
                    };
                    break;

                case "Soul of the Aspects":
                    /* Abilities:
                     * Slot 1: Claw             | Breath
                     * Slot 2: Sunlight         | Deflection
                     * Slot 3: Surge of Light   | Solar Beam
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Claw"),
                        new AandC("Breath"),
                        new AandC("Sunlight"),
                        new AandC("Deflection"),
                        new AandC("Surge of Light"),
                        new AandC("Solar Beam"),
                    };
                    break;

                case "Thundering Serpent Hatchling": 
                case "Tiny Green Dragon": 
                case "Tiny Red Dragon": 
                case "Wild Golden Hatchling": 
                case "Wild Jade Hatchling":
                    /* Abilities:
                     * Slot 1: Breath           | Tail Sweep
                     * Slot 2: Call Lightning   | Roar
                     * Slot 3: Cyclone          | Lift-OFf
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Roar",               () => ! buff("Attack Boost")),
                        new AandC("Lift-Off"),
                        new AandC("Breath"),
                        new AandC("Tail Sweep"),
                        new AandC("Call Lightning"),
                    };
                    break;

                case "Untamed Hatchling":
                    /* Abilities:
                     * Slot 1: Claw         | Tail Sweep
                     * Slot 2: Roar         | Spiked Skin
                     * Slot 3: Instability  | Healing Flame
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Healing Flame",  () => hp < 0.75),
                        new AandC("Roar",           () => ! buff("Attack Boost")),
                        new AandC("Claw"),
                        new AandC("Tail Sweep"),
                        new AandC("Spiked Skin"),
                        new AandC("Instability"),
                    };
                    break;

                case "Wild Crimson Hatchling":
                    /* Abilities:
                     * Slot 1: Breath           | Tail Sweep
                     * Slot 2: Healing Flame    | Scorched Earth
                     * Slot 3: Lift-Off         | Deep Breath
                     */
                    dragonkin_abilities = new List<AandC>() 
                    {
                        new AandC("Healing Flame",  () => hp < 0.75),
                        new AandC("Lift-Off"),
                        new AandC("Breath"),
                        new AandC("Tail Sweep"),
                        new AandC("Scorched Earth"),
                        new AandC("Deep Breath"),
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
