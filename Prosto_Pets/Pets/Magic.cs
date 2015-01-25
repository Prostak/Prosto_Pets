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

            switch (petName)
            {
                case "Abyssius":
                    /* Changelog:
                     * 2015-01-20: Meteor Strike is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60 for new pet coming in patch 6.1
                     * 
                     * Abilities
                     * Slot 1: Immolation   | Crush
                     * Slot 2: Flamethrower | Scorched Earth
                     * Slot 3: Volcano      | Meteor Strike
                     */
                    // immolation: horrible first attack..
                    magic_abilities = new List<AandC>() {
                        new AandC("Meteor Strike",  () => shouldIHide && speed >= speedEnemy), 
                        new AandC("Immolation",     () => ! buff("Immolation")),  
                        new AandC("Scorched Earth", () => ! weather("Scorched Earth")),
                        new AandC("Volcano",        () => hpEnemy > 0.4),
                        new AandC("Flamethrower"),
                        new AandC("Immolation"),  
                        new AandC("Crush"),
                    };
                    break;

                case "Arcane Eye":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Focused Beams        | Psychic Blast
                     * Slot 2: Eyeblast             | Drain Power
                     * Slot 3: Interrupting Gaze    | Mana Surge
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Interrupting Gaze",  () => speed > speedEnemy),
                        new AandC("Eyeblast",           () => ! debuff("Speed Reduction")),
                        new AandC("Drain Power",        () => ! buff("Attack Boost")),
                        new AandC("Mana Surge",         () => ! weak("Mana Surge") && hp > 0.5),
                        new AandC("Focused Beams"),
                        new AandC("Physic Blast"),
                    };
                    break;

                case "Baneling":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Bite                 | Trash
                     * Slot 2: Centrifugal Hooks    | Adrenal Glands
                     * Slot 3: Burrow               | Baneling Burst
                     * 
                     * TODO Reintroduce Baneling Burst - Needs to consider team status
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow",             () => shouldIHide && speed >= speedEnemy),
                        new AandC("Centrifugal Hooks",  () => speed < speedEnemy && ! buff("Centrifugal Hooks")),
                        new AandC("Adrenal Glands",     () => ! buff("Adrenal Glands")),
                        new AandC("Bite"),
                        new AandC("Thrash"),
                    };
                    break;

                case "Chaos Pup":
                    /* Changelog:
                     * 2015-01-19: Dreadful Breath is only used if pet health is over 40% (up from 0%) - Studio60
                     * 2015-01-18: Initial tactic by Studio60 for new pet coming in patch 6.1
                     * 
                     * Abilities
                     * Slot 1: Bite | Eyeblast
                     * Slot 2: Dreadful Breath | Consume Corpse
                     * Slot 3: Enrage | Nethergate
                     * 
                     * TODO: Consume Corpse needs to detect own team status
                     * TODO: Nether Gate needs to detect enemy team status
                     */
                    magic_abilities = new List<AandC>() {
                        new AandC("Dreadful Breath",    () => weather("Cleansing Rain") && hp > 0.4),
                        new AandC("Enrage",             () => ! buff("Enrage")),  
                        new AandC("Bite"),
                        new AandC("Eyeblast"),
                        new AandC("Consume Corpse"),  
                        new AandC("Nether Gate"), 
                    };
                    break;

                case "Coilfang Stalker":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Laser            | Focused Beams
                     * Slot 2: Gravity          | Illusionary Barrier 
                     * Slot 3: Surge of Power   | Amplify Magic
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Illusionary Barrier",    () => shouldIHide && speed >= speedEnemy),
                        new AandC("Amplify Magic",          () => ! buff("Amplify Magic") && hpEnemy > 0.2),
                        new AandC("Surge of Power",         () => hpEnemy < 0.3),
                        new AandC("Gravity"),
                        new AandC("Laser"),
                        new AandC("Focused Beams"),
                    };
                    break;

                case "Darkmoon Eye":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Laser            | Focused Beams
                     * Slot 2: Eyeblast         | Inner Vision
                     * Slot 3: Darkmoon Curse   | Interrupting Gaze
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Interrupting Gaze",  () => speed > speedEnemy),
                        new AandC("Eyeblast",           () => speed < speedEnemy && ! debuff("Speed Reduction")),
                        new AandC("Darkmoon Curse",     () => ! debuff("Attack Reduction")),
                        new AandC("Inner Vision"),
                        new AandC("Laser"),
                        new AandC("Focused Beams"),
                    };
                    break;

                case "Disgusting Oozeling":
                case "Jade Oozeling":
                case "Oily Slimeling":
                case "Toxic Wasteling":
                    /* Abilities
                     * Slot 1: Ooze Touch   | Absorb
                     * Slot 2: Corrosion    | Creeping Ooze
                     * Slot 3: Expunge      | Acidic Goo
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Acidic Goo",     () => ! debuff("Acidic Goo")),
                        new AandC("Corrosion",      () => ! debuff("Corrosion")),
                        new AandC("Creeping Ooze",  () => ! debuff("Creeping Ooze")),
                        new AandC("Expunge"),
                        new AandC("Ooze Touch"),
                        new AandC("Absorb"),
                    };
                    break;


                case "Elekk Plushie":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Rawr!        | Cute As A Button
                     * Slot 2: Nap Time     | Who's The Best Elekk In The Whole World?
                     * Slot 3: Plushie Rush | Itchin' for a Stitchin'
                     * 
                     * Tactic Information
                     * Doesn't really matter, they have no effect
                     */
                    magic_abilities = new List<AandC>() {
                        new AandC("Rawr!"),
                        new AandC("Cute As A Button"),
                        new AandC("Nap Time"),
                        new AandC("Who's The Best Elekk In The Whole World?"),
                        new AandC("Plushie Rush"),
                        new AandC("Itchin' for a Stitchin'"), 
                    };
                    break;

                case "Enchanted Broom":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Broom        | Batter
                     * Slot 2: Sandstorm    | Sweep
                     * Slot 3: Clean-Up     | Wind-Up
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Sandstorm",  () => ! weather("Sandstorm")),
                        new AandC("Sweep",      () => strong("Sweep")),
                        new AandC("Clean-Up",   () => debuff("Decoy") || debuff("Turret") || strong("Clean-Up")),
                        new AandC("Wind-Up",    () => ! buff("Wind-Up")),
                        new AandC("Wind-Up",    () => buff("Wind-Up") && strong("Wind-Up")),
                        new AandC("Broom"),
                        new AandC("Batter"),
                    };
                    break;

                case "Enchanted Lantern":
                case "Festival Lantern":
                case "Lunar Lantern":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Beam         | Burn
                     * Slot 2: Illuminate   | Flash
                     * Slot 3: Soul Ward    | Light
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Soul Ward",  () => shouldIHide && speed >= speedEnemy),
                        new AandC("Light",      () => enemyIsBlinded),
                        new AandC("Illuminate", () => ! weather("Sunlight")),
                        new AandC("Flash",      () => ! debuff("Partially Blinded")),
                        new AandC("Beam"),
                        new AandC("Burn"),
                    };
                    break;

                case "Ethereal Soul-Trader":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Punch        | Beam
                     * Slot 2: Soul Ward    | Inner Vision
                     * Slot 3: Soulrush     | Life Exchange
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Soul Ward",      () => shouldIHide && speed >= speedEnemy),
                        new AandC("Inner Vision"),
                        new AandC("Soulrush"),
                        new AandC("Life Exchange",  () => hp * 2.5 < hpEnemy),
                        new AandC("Punch"),
                        new AandC("Beam"),
                    };
                    break;

                case "Eye of Observation":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Arcane Blast | Eyeblast
                     * Slot 2: Counterspell | Lens Flare
                     * Slot 3: Blinkstrike  | Powerball
                     * 
                     * TODO: Create some decision process for Counterspell
                     */
                    magic_abilities = new List<AandC>() {
                        new AandC("Lens Flare",     () => ! debuff("Partially Blinded")), 
                        new AandC("Blinkstrike"), 
                        new AandC("Powerball"),
                        new AandC("Arcane Blast"),
                        new AandC("Eyeblast"),
                        new AandC("Counterspell",   () => speed > speedEnemy),  
                    };
                    break;

                case "Filthling":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Dreadful Breath  | Absorb
                     * Slot 2: Stench           | Expunge
                     * Slot 3: Corrosion        | Creeping Ooze
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Stench",             () => ! debuff("Stench")),
                        new AandC("Expunge",            () => ! weak("Expunge")),
                        new AandC("Corrosion",          () => ! debuff("Corrosion")),
                        new AandC("Creeping Ooze",      () => ! debuff("Creeping Ooze")),
                        new AandC("Dreadful Breath"),
                        new AandC("Absorb"),
                    };
                    break;

                case "Gusting Grimoire":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Fel Immolate     | Shadow Shock
                     * Slot 2: Agony            | Amplify Magic
                     * Slot 3: Meteor Strike    | Curse of Doom
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Meteor Strike",  () => shouldIHide && speed >= speedEnemy),
                        new AandC("Agony",          () => ! debuff("Agony")),
                        new AandC("Amplify Magic",  () => ! debuff("Amplify Magic")),
                        new AandC("Curse of Doom",  () => ! debuff("Curse of Doom") && hpEnemy > 0.5),
                        new AandC("Fel Immolate"),
                        new AandC("Shadow Shock"),
                    };
                    break;

                case "Harmonious Porcupette":
                    /* Changelog:
                     * 2015-01-19: Lens Flare is no longer used if the enemy is "Partially Blinded" - Studio60
                     * 	           Hibernate is only used if pet health is between 30% and 60% (changed from 40% - 54%) - Studio60
                     * 	           Hibernate is only used if the enemy's health is above 15% (up from 0%) - Studio60
                     * 	           Tranquility is only used if the enemy's health is above 15% (up from 0%) - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Scratch              | Claw
                     * Slot 2: Celestial Blessing   | Moonfire
                     * Slot 3: Hibernate            | Tranquility
                     * 
                     * TODO: Celestial Blessing needs to check on team pets
                     */
                    magic_abilities = new List<AandC>() {
                        new AandC("Moonfire",           () => ! weather("Moonlight")),  
                        new AandC("Hibernate",          () => ! buff("Celestial Blessing") && hp > 0.3 && hp < 0.6 && hpEnemy > 0.15), 
                        new AandC("Tranquility",        () => hp < 0.8 && ! buff("Tranquility") && hpEnemy > 0.15),  
                        new AandC("Scratch"), 
                        new AandC("Claw"),
                        new AandC("Celestial Blessing"),  
                    };
                    break;

                case "Hyjal Wisp":
                    /* Changelog:
                     * 2015-01-20: Evanescence is now used to hide from huge attacks it it is faster or if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Feedback     | Arcane Blast
                     * Slot 2: Evanescence  | Sear Magic
                     * Slot 3: Wish         | Amplify Magic
                     * 
                     * TODO: Sear Magic needs to distinguish positive/negative auras
                     */
                    magic_abilities = new List<AandC>() {
                        new AandC("Evanescence",    () => shouldIHide && speed >= speedEnemy),
                        new AandC("Wish",           () => hp < 0.5),
                        new AandC("Amplify Magic",  () => ! buff("Amplify Magic")),
                        new AandC("Feedback"),
                        new AandC("Arcane Blast"),
                        new AandC("Sear Magic"),  
                    };
                    break;

                case "Jade Owl":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind     | Thrash
                     * Slot 2: Adrenaline Rush  | Hawk Eye
                     * Slot 3: Lift-Off         | Cyclone
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Adrenaline Rush",    () => ! buff("Adrenaline") && speed < speedEnemy),
                        new AandC("Adrenaline Rush",    () => strong("Adrenaline Rush")),
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")),
                        new AandC("Slicing Wind"),
                        new AandC("Thrash"),
                    };
                    break;

                case "Jade Tiger":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Jade Claw    | Pounce
                     * Slot 2: Rake         | Jadeskin
                     * Slot 3: Devour       | Prowl
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Devour",     () => hpEnemy < 0.2),
                        new AandC("Devour",     () => strong("Devour") && hpEnemy < 0.3),
                        new AandC("Jadeskin",   () => ! buff("Jadeskin")),
                        new AandC("Jadeskin",   () => buffLeft("Jadeskin") == 1 && speed < speedEnemy),
                        new AandC("Prowl",      () => speed * 0.7 > speedEnemy),
                        new AandC("Rake"),
                        new AandC("Jade Claw"),
                        new AandC("Pounce"),
                    };
                    break;

                /* not on PTR yet
                case "K'ute":
                    magic_abilities = new List<AandC>() {
                        new AandC(""),
                        new AandC(""),
                        new AandC(""),
                        new AandC(""),
                        new AandC(""),
                        new AandC(""),
                    };
                    break;
                 */  

                case "Legs":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Laser            | Pump
                     * Slot 2: Surge of Power   | Gravity
                     * Slot 3: Focused Beams    | Whirlpool
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Whirlpool",          () => hpEnemy > 0.4),
                        new AandC("Surge of Power",     () => hpEnemy < 0.4),
                        new AandC("Gravity"),
                        new AandC("Focused Beams"),
                        new AandC("Laser"),
                        new AandC("Pump"),
                    };
                    break;

                case "Lesser Voidcaller":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Shadow Shock     | Nether Blast
                     * Slot 2: Siphon Life      | Prismatic Barrier
                     * Slot 3: Curse of Doom    | Drain Power
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Prismatic Barrier",  () => shouldIHide && speed > speedEnemy),
                        new AandC("Curse of Doom",      () => ! debuff("Curse of Doom") && hp > 0.5),
                        new AandC("Siphon Life",        () => ! debuff("Siphon Life") && hp < 0.8),
                        new AandC("Drain Power",        () => ! buff("Attack Boost")),
                        new AandC("Shadow Shock"),
                        new AandC("Nether Blast"),
                    };
                    break;

                case "Lil' Leftovers":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Absorb       | Chew
                     * Slot 2: Stench       | Crouch
                     * Slot 3: High Fiber   | Food Coma
                     * 
                     * TODO: High Fiber needs to distinguis positive/negative auras
                     */
                    magic_abilities = new List<AandC>() {
                        new AandC("Stench",     () => ! debuff("Stench")),
                        new AandC("Crouch",     () => ! buff("Crouch")),  
                        new AandC("Food Coma"),
                        new AandC("Absorb"),  
                        new AandC("Chew"),
                        new AandC("High Fiber"),  
                    };
                    break;

                case "Living Fluid":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Ooze Touch   | Absorb
                     * Slot 2: Corrosion    | Acidic Goo
                     * Slot 3: Expunge      | Evolution
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Acidic Goo", () => ! debuff("Acidic Goo")),
                        new AandC("Corrosion",  () => ! debuff("Corrosion")),
                        new AandC("Evolution",  () => ! weak("Evolution") && hpEnemy < 0.3),
                        new AandC("Expunge"),
                        new AandC("Ooze Touch"),
                        new AandC("Absorb"),
                    };
                    break;

                case "Lofty Libram":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Arcane Blast     | Shadow Shock
                     * Slot 2: Arcane Explosion | Amplify Magic
                     * Slot 3: Inner Vision     | Curse of Doom
                     * 
                     * TODO: Reintroduce Arcane Explosion - Needs to consider enemy team status
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Amplify Magic",  () => ! debuff("Amplify Magic")),
                        new AandC("Curse of Doom",  () => ! debuff("Curse of Doom") && hpEnemy > 0.5),
                        new AandC("Inner Vision"),
                        new AandC("Arcane Blast"),
                        new AandC("Shadow Shock"),
                    };
                    break;

                case "Magic Lamp":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Beam         | Arcane Blast
                     * Slot 2: Sear Magic   | Gravity
                     * Slot 3: Soul Ward    | Wish
                     * 
                     * TODO: Reintroduce Sear Magic - Needs to consider pet auras
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Wish",           () => hp < 0.5),
                        new AandC("Soul Ward",      () => shouldIHide && speed >= speedEnemy),
                        new AandC("Gravity"),
                        new AandC("Beam"),
                        new AandC("Arcane Blast"),
                    };
                    break;

                case "Mana Wyrmling":
                case "Shimmering Wyrmling":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Feedback     | Flurry
                     * Slot 2: Drain Power  | Amplify Magic
                     * Slot 3: Mana Surge   | Deflection
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Deflection",     () => shouldIHide),
                        new AandC("Drain Power",    () => ! buff("Attack Boost")),
                        new AandC("Amplify Magic",  () => ! debuff("Amplify Magic")),
                        new AandC("Mana Surge",     () => ! weak("Mana Surge")),
                        new AandC("Feedback"),
                        new AandC("Flurry"),
                    };
                    break;

                case "Minfernal":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Crush            | Immolate
                     * Slot 2: Immolation       | Extra Plating
                     * Slot 3: Meteor Strike    | Explode
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Explode",        () => hp < 0.1 && hpEnemy > 0.4),
                        new AandC("Meteor Strike",  () => shouldIHide && speed >= speedEnemy),
                        new AandC("Immolation",     () => ! buff("Immolation")),
                        new AandC("Immolate",       () => ! debuff("Immolate")),
                        new AandC("Extra Plating",  () => ! buff("Extra Plating")),
                        new AandC("Extra Plating",  () => buffLeft("Extra Plating") == 1 && speed < speedEnemy),
                        new AandC("Crush"),
                        new AandC("Immolate"),
                    };
                    break;

                case "Mini Diablo":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn             | Blast of Hatred
                     * Slot 2: Call Darkness    | Agony
                     * Slot 3: Weakness         | Bone Prison
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Call Darkness",      () => ! weather("Darkness")),
                        new AandC("Agony",              () => ! debuff("Agony")),
                        new AandC("Weakness",           () => ! debuff("Weakness")),
                        new AandC("Bone Prison",        () => ! weak("Bone Prison")),
                        new AandC("Burn"),
                        new AandC("Blast of Hatred"),
                    };
                    break;

                case "Mini Mindslayer":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Eyeblast             | Mana Surge
                     * Slot 2: Amplify Magic        | Inner Vision
                     * Slot 3: Interrupting Gaze    | Life Exchange
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Amplify Magic",      () => ! debuff("Amplify Magic")),
                        new AandC("Interrupting Gaze",  () => speed >= speedEnemy),
                        new AandC("Life Exchange",      () => hp * 2.5 < hpEnemy),
                        new AandC("Inner Vision"),
                        new AandC("Eyeblast"),
                        new AandC("Mana Surge"),
                    };
                    break;

                case "Netherspace Abyssal":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Crush            | Immolate
                     * Slot 2: Immolation       | Explode
                     * Slot 3: Meteor Strike    | Nether Gate
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Explode",        () => hp < 0.1 && hpEnemy > 0.3),
                        new AandC("Meteor Strike",  () => shouldIHide && speed >= speedEnemy),
                        new AandC("Immolate",       () => ! debuff("Immolate")),
                        new AandC("Immolation",     () => ! buff("Immolation")),
                        new AandC("Nether Gate"),
                        new AandC("Crush"),
                        new AandC("Immolate"),
                    };
                    break;

                case "Netherspawn, Spawn of Netherspawn":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Nether Blast     | Absorb
                     * Slot 2: Consume Magic    | Expunge
                     * Slot 3: Poison Spit      | Creeping Ooze
                     * 
                     * TODO: Consume Magic needs to distinguish positive/negative auras
                     */
                    magic_abilities = new List<AandC>() {
                        new AandC("Expunge"), 
                        new AandC("Poison Spit",    () => ! debuff("Poisoned")), 
                        new AandC("Creeping Ooze",  () => ! debuff("Creeping Ooze")),  
                        new AandC("Nether Blast"),
                        new AandC("Absorb"),  
                        new AandC("Consume Magic"),
                    };
                    break;

                case "Nordrassil Wisp":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Beam         | Light
                     * Slot 2: Flash        | Arcane Blast
                     * Slot 3: Soul Ward    | Arcane Explosion
                     * 
                     * TODO: Reintroduce Arcane Explosion - Needs to consider enemy team status
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Soul Ward",      () => shouldIHide && speed >= speedEnemy),
                        new AandC("Light",          () => enemyIsBlinded),
                        new AandC("Flash",          () => ! enemyIsBlinded),
                        new AandC("Arcane Blast"),
                        new AandC("Beam"),
                        new AandC("Light"),
                    };
                    break;

                case "Onyx Panther":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Claw         | Onyx Bite
                     * Slot 2: Stoneskin    | Roar
                     * Slot 3: Leap         | Stone Rush
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Leap",       () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Stoneskin",  () => ! buff("Stoneskin") && hpEnemy > 0.2),
                        new AandC("Stoneskin",  () => buffLeft("Stoneskin") == 1 && speed <= speedEnemy && hpEnemy > 0.2),
                        new AandC("Roar",       () => ! buff("Attack Boost")),
                        new AandC("Stone Rush"),
                        new AandC("Claw"),
                        new AandC("Onyx Bite"),
                    };
                    break;

                case "Servant of Demidos":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Magic Sword      | Arcane Explosion
                     * Slot 2: Clean-Up         | Siphon Anima
                     * Slot 3: Lightning Shield | Soulrush
                     */
                    // pretty basic tactic
                    magic_abilities = new List<AandC>() {
                        new AandC("Clean-Up",           () => debuff("Decoy") || debuff("Turret")) ,
                        new AandC("Siphon Anima",       () => hp < 0.75),
                        new AandC("Lightning Shield",   () => ! buff("Lightning Shield")),  
                        new AandC("Soulrush"),
                        new AandC("Magic Sword"), 
                        new AandC("Arcane Explosion"),
                    };
                    break;

                case "Spectral Cub":
                case "Spectral Tiger Cub":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Claw         | Rend
                     * Slot 2: Evanescence  | Spectral Strike
                     * Slot 3: Leap         | Prowl
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Evanescence",        () => shouldIHide && speed >= speedEnemy),
                        new AandC("Leap",               () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Spectral Strike",    () => myPetIsLucky),
                        new AandC("Prowl",              () => speed * 0.7 > speedEnemy),
                        new AandC("Claw"),
                        new AandC("Rend"),
                    };
                    break;

                case "Spectral Porcupette":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Bite                 | Powerball
                     * Slot 2: Spectral Strike      | Spirit Spikes
                     * Slot 3: Illusionary Barrier  | Spectral Spine
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Illusionary Barrier",    () => shouldIHide && speed >= speedEnemy),
                        new AandC("Spectral Strike",        () => myPetIsLucky),
                        new AandC("Spirit Spikes"),
                        new AandC("Spectral Spine"),
                        new AandC("Bite"),
                        new AandC("Powerball"),
                    };
                    break;

                case "Syd the Squid":
                    /* Changelog:
                     * 2015-01-20: Bubble is now used to hide from huge attacks if it is faster or both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Water Jet    | Tidal Wave
                     * Slot 2: Bubble       | Healing Stream
                     * Slot 3: Whirlpool    | Cleansing Rain
                     */
                    magic_abilities = new List<AandC>() {
                        new AandC("Bubble",         () => shouldIHide && speed >= speedEnemy),
                        new AandC("Healing Stream", () => hp < 0.8),  
                        new AandC("Whirlpool",      () => hpEnemy > 0.5),  
                        new AandC("Cleansing Rain", () => ! weather("Cleansing Rain")),
                        new AandC("Water Jet"),
                        new AandC("Tidal Wave"),  
                    };
                    break;

                case "Trunks":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: When Elekks Fly | Smash
                     * Slot 2: Ethereal | Moonfire
                     * Slot 3: Headbutt | Avalanche
                     */
                    magic_abilities = new List<AandC>() {
                        new AandC("Ethereal",           () => shouldIHide), 
                        new AandC("Moonfire",           () => ! weather("Moonlight")),  
                        new AandC("Headbutt"),
                        new AandC("Avalanche"),
                        new AandC("When Elekks Fly"), 
                        new AandC("Smash"),
                    };
                    break;

                case "Twilight Fiendling":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Creepy Chomp     | Rake
                     * Slot 2: Leap             | Creeping Ooze
                     * Slot 3: Adrenal Glands   | Siphon Life
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Leap",               () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Siphon Life",        () => ! debuff("Siphon Life") && hp < 0.8),
                        new AandC("Andrenal Glands",    () => ! buff("Adrenal Glands")),
                        new AandC("Creeping Ooze",      () => ! debuff("Creeping Ooze")),
                        new AandC("Creepy Chomp"),
                        new AandC("Rake"),
                    };
                    break;

                case "Viscidus Globule":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Ooze Touch   | Acid Touch
                     * Slot 2: Weakness     | Poison Spit
                     * Slot 3: Expunge      | Creeping Ooze
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Expunge"), 
                        new AandC("Poison Spit",    () => ! debuff("Poisoned")), 
                        new AandC("Creeping Ooze",  () => ! debuff("Creeping Ooze")),  
                        new AandC("Weakness"),
                        new AandC("Ooze Touch"),
                        new AandC("Acid Touch"),
                    };
                    break;

                case "Viscous Horror":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Ooze Touch   | Absorb
                     * Slot 2: Corrosion    | Plagued Blood
                     * Slot 3: Expunge      | Evolution
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Expunge"),
                        new AandC("Corrosion",      () => ! debuff("Corrosion")),
                        new AandC("Plagued Blood",  () => ! debuff("Plagued")),
                        new AandC("Evolution",      () => hpEnemy < 0.4),
                        new AandC("Ooze Touch"),
                        new AandC("Absorb"),
                    };
                    break;

                case "Willy":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Tongue Lash          | Focused Beams
                     * Slot 2: Interrupting Gaze    | Eyeblast
                     * Slot 3: Agony                | Rot
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Interrupting Gaze",  () => speed > speedEnemy),
                        new AandC("Eye Blast",          () => ! debuff("Speed Reduction") && speed <= speedEnemy),
                        new AandC("Agony",              () => ! debuff("Agony")),
                        new AandC("Dark Simulacrum"),
                        new AandC("Tongue Lash"),
                        new AandC("Focused Beams"),
                    };
                    break;

                case "Zergling":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Bite             | Flank
                     * Slot 2: Metabolic Boost  | Adrenal Glands
                     * Slot 3: Consume          | Zergling Rush
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Metabolic Boost",    ()  => speed < speedEnemy && ! buff("Metabolic Boost")),
                        new AandC("Adrenal Glands",     () => ! buff("Adrenal Glands")),
                        new AandC("Consume",            () => ! weak("Consume") && hp < 0.8),
                        new AandC("Zergling Rush",      () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Bite"),
                        new AandC("Flank"),
                    };
                    break;

                case "Zipao Tiger":
                    /* Changelog:
                     * 2015-01-25: Viable base tactics designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Onyx Bite    | Pounce
                     * Slot 2: Rake         | Stoneskin
                     * Slot 3: Devour       | Prowl
                     */
                    magic_abilities = new List<AandC>() 
                    {
                        new AandC("Devour",     () => hpEnemy < 0.2),
                        new AandC("Devour",     () => strong("Devour") && hpEnemy < 0.3),
                        new AandC("Stoneskin",  () => ! buff("Stoneskin")),
                        new AandC("Stoneskin",  () => buffLeft("Stoneskin") == 1 && speed < speedEnemy),
                        new AandC("Prowl",      () => speed * 0.7 > speedEnemy),
                        new AandC("Rake"),
                        new AandC("Onyx Bite"),
                        new AandC("Pounce"),
                    };
                    break;

                default:
                    ///////////////////////
                    // Unknown Magic Pet //
                    ///////////////////////
                    Logger.Alert("Unknown magic pet: " + petName);
                    magic_abilities = null;
                    break;
            }

            return magic_abilities;



        }
    }
}

