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

            switch (petName)
            {
                case "Blighted Squirrel":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Scratch          | Woodchipper
                     * Slot 2: Adrenaline Rush  | Crouch
                     * Slot 3: Rabid Strike     | Stampede
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Adrenaline Rush",    () => speed < speedEnemy && ! buff("Adrenaline")),
                        new AandC("Crouch",             () => ! buff("Crouch")),
                        new AandC("Crouch",             () => buffLeft("Crouch") == 1 && speed < speedEnemy),
                        new AandC("Rabid Strike",       () => ! debuff("Rabies")),
                        new AandC("Rabid Strike",       () => debuffLeft("Rabies") == 1 && speed < speedEnemy),
                        new AandC("Stampede",           () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Scratch"),
                        new AandC("Woodchipper"),
                    };
                    break;

                case "Blighthawk":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Infected Claw    | Slicing Wind
                     * Slot 2: Consume Corpse   | Ghostly Bite
                     * Slot 3: Lift-Off         | Cyclone
                     * 
                     * TODO: Reintroduce Consume Corpse: Needs to consider team status
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",       () => shouldIHide && speed >= speedEnemy),
                        new AandC("Cyclone",        () => ! debuff("Cyclone")),
                        new AandC("Ghostly Bite"),
                        new AandC("Infected Claw"),
                        new AandC("Slicing Wind"),
                    };
                    break;

                case "Crawling Claw":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Shadow Slash     | Agony
                     * Slot 2: Ancient Blessing | Death Grip
                     * Slot 3: Curse of Doom    | Rot
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Curse of Doom",      () => ! debuff("Curse of Doom")),
                        new AandC("Ancient Blessing",   () => ! buff("Ancient Blessing") && hp < 0.8),
                        new AandC("Death Grip",         () => myPetHasAbility("Agony")),
                        new AandC("Rot",                () => ! debuff("Rot") && famEnemy(PF.Aquatic)),
                        new AandC("Shadow Slash"),
                        new AandC("Agony"),
                    };
                    break;

                case "Creepy Crate":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Creepy Chomp | Agony
                     * Slot 2: Death Grip   | Curse of Doom
                     * Slot 3: Devour       | BONESTORM
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Devour",         () => hpEnemy < 0.2),
                        new AandC("Devour",         () => strong("Devour") && hpEnemy < 0.3),
                        new AandC("Curse of Doom",  () => ! debuff("Curse of Doom") && hp > 0.5),
                        new AandC("Agony",          () => ! debuff("Agony")),
                        new AandC("Death Grip",     () => myPetHasAbility("Agony")),
                        new AandC("BONESTORM",      () => hp > 0.3),
                        new AandC("Creepy Chomp"),
                        new AandC("Agony"),
                    };
                    break;

                case "Cursed Birman":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Pounce           | Spirit Claws
                     * Slot 2: Call Darkness    | Spirit Spikes
                     * Slot 3: Devour           | Prowl
                     */
                    undead_abilities = new List<AandC>() {
                        new AandC("Devour",         () => hpEnemy < 0.25 || (famEnemy(PF.Critter) && hpEnemy > 0.4)),
                        new AandC("Call Darkness",  () => ! weather("Darkness")),
                        new AandC("Spirit Spikes"),
                        new AandC("Prowl"),
                        new AandC("Pounce"),
                        new AandC("Spirit Claws"),
                    };
                    break;

                case "Eye of the Legion":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Shadow Slash | Eyeblast
                     * Slot 2: Agony        | Gravity
                     * Slot 3: Soul Ward    | Rot
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Soul Ward",          () => shouldIHide && speed >= speedEnemy),
                        new AandC("Agony",              () => ! debuff("Agony")),
                        new AandC("Gravity"),
                        new AandC("Rot",                () => ! debuff("Rot") && famEnemy(PF.Aquatic)),
                        new AandC("Eyeblast"),
                        new AandC("Shadow Slash"),
                    };
                    break;

                case "Fetish Shaman":
                case "Sen'jin Fetish":
                case "Voodoo Figurine":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Shadow Slash | Flame Breath
                     * Slot 2: Immolate     | Wild Magic
                     * Slot 3: Sear Magic   | Rot
                     * 
                     * TODO: Reintroduce Sear Magic - Needs to consider auras
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Immolate",       () => ! debuff("Immolate")),
                        new AandC("Wild Magic",     () => ! debuff("Wild Magic")),
                        new AandC("Rot",            () => ! debuff("Rot") && famEnemy(PF.Aquatic)),
                        new AandC("Shadow Slash"),
                        new AandC("Flame Breath"),
                    };
                    break;

                case "Fossilized Hatchling":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Claw             | Bone Bite
                     * Slot 2: Ancient Blessing | Death and Decay
                     * Slot 3: Bone Prison      | BONESTORM
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Ancient Blessing",   () => ! buff("Ancient Blessing") || hp < 0.75 ),
                        new AandC("Death and Decay",    () => ! debuff("Death and Decay")),
                        new AandC("BONESTORM",          () => hp > 0.3),
                        new AandC("Bone Prison"),
                        new AandC("Claw"),
                        new AandC("Bone Bite"),
                    };
                    break;

                case "Fragment of Anger":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60 for new pet coming in patch 6.1
                     * 
                     *  Abilities
                     * Slot 1: Spiritfire Bolt  | Seethe
                     * Slot 2: Spiritfire Beam  | Enrage
                     * Slot 3: Soulrush         | Spirit Spikes
                     * 
                     * TODO: Spiritfire Beam needs to check the state of the enemy team
                     */
                    undead_abilities = new List<AandC>() {
                        new AandC("Enrage",             () => ! buff("Enrage")),
                        new AandC("Soulrush"),
                        new AandC("Spirit Spikes"),
                        new AandC("Spiritfire Bolt"),
                        new AandC("Seethe"),
                        new AandC("Spiritfire Beam"),
                    };
                    break;

                case "Fragment of Desire":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60 for new pet coming in patch 6.1
                     * 
                     * Abilities
                     * Slot 1: Spiritfire Bolt      | Arcane Blast
                     * Slot 2: Reflective Shield    | Soul Ward
                     * Slot 3: Soulrush             | Soothe
                     */
                    undead_abilities = new List<AandC>() {
                        new AandC("Soul Ward",          () => shouldIHide && speed >= speedEnemy),
                        new AandC("Reflective Shield",  () => ! buff("Reflective Shield")),
                        new AandC("Soulrush"),
                        new AandC("Spiritfire Bolt"),
                        new AandC("Arcane Blast"),
                        new AandC("Soothe"),
                    };
                    break;

                case "Fragment of Suffering":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60 for new pet coming in patch 6.1
                     * 
                     * Abilities
                     * Slot 1: Arcane Blast | Spiritfire Bolt
                     * Slot 2: Darkflame    | Breath of Sorrow
                     * Slot 3: Drain Power  | Soulrush
                     */
                    undead_abilities = new List<AandC>() {
                        new AandC("Drain Power",        () => ! debuff("Attack Reduction")),
                        new AandC("Darkflame",          () => ! debuff("Healing Reduction")),
                        new AandC("Breath of Sorrow",   () => ! debuff("Healing Reduction")),
                        new AandC("Soulrush"),
                        new AandC("Arcane Blast"),
                        new AandC("Spiritfire Bolt"),
                    };
                    break;

                case "Frostwolf Ghostpup":
                    /* Changelog:
                     * 2015-01-20: Frolicking is now used more regularly - Studio60
                     *             Refuge is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Scratch  | Sneak Attack
                     * Slot 2: Refuge   | Haunting Song
                     * Slot 3: Frolick  | Ghostly Bite
                     */
                    undead_abilities = new List<AandC>() {
                        new AandC("Refuge",         () => shouldIHide && speed >= speedEnemy),
                        new AandC("Haunting Song",  () => hp < 0.8),
                        new AandC("Frolick",        () => ! buff("Frolicking")),
                        new AandC("Ghostly Bite"),
                        new AandC("Scratch"),
                        new AandC("Sneak Attack"),
                    };
                    break;

                case "Frosty":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Diseased Bite    | Frost Breath
                     * Slot 2: Call Blizzard    | Shriek
                     * Slot 3: Ice Tomb         | Blistering Cold
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Shriek",             () => ! debuff("Attack Reduction")),
                        new AandC("Call Blizzard",      () => ! weather("Blizzard")),
                        new AandC("Ice Tomb",           () => ! debuff("Ice Tomb")),
                        new AandC("Blistering Cold",    () => ! debuff("Blistering Cold")),
                        new AandC("Diseased Bite"),
                        new AandC("Frost Breath"),
                    };
                    break;

                case "Fungal Abomination":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Absorb           | Consume
                     * Slot 2: Creeping Fungus  | Leech Seed
                     * Slot 3: Spore Shrooms    | Stun Seed
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Consume",            () => ! weak("Consume") && hp < 0.7),
                        new AandC("Creeping Fungus",    () => ! debuff("Creeping Fungus")),
                        new AandC("Leech Seed",         () => ! debuff("Leech Seed") && hp < 0.8),
                        new AandC("Spore Shrooms",      () => ! debuff("Spore Shrooms")),
                        new AandC("Stun Seed",          () => ! debuff("Stun Seed") && hpEnemy > 0.5),
                        new AandC("Absorb"),
                        new AandC("Consume"),
                    };
                    break;

                case "Ghastly Kid":
                    /* Changelog:
                     * 2015-01-20: Ghostly Bite is now longer used if pet health is below 40% (up from 0%) - Studio60
                     * 2015-01-19: Consume Magic is now used when below 60% health (changed from 0%) - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Hoof             | Diseased Bite
                     * Slot 2: Consume Magic    | Ethereal
                     * Slot 3: Ghostly Bite     | Haunt
                     * 
                     * TODO: Consume Magic needs to consider buffs/debuffs
                     * TODO: Haunt needs to check if other pets are available
                     */
                    undead_abilities = new List<AandC>() {
                        new AandC("Ethereal",       () => shouldIHide),
                        new AandC("Consume Magic",  () => hp < 0.6),
                        new AandC("Ghostly Bite",   () => hp < 0.4),
                        new AandC("Hoof"),
                        new AandC("Diseased Bite"),
                        new AandC("Haunt"),
                    };
                    break;

                case "Ghostly Skull":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Shadow Slash | Death Coil
                     * Slot 2: Ghostly Bite | Spectral Strike
                     * Slot 3: Siphon Life  | Unholy Ascension
                     * 
                     * TODO: Reintroduce Unholy Ascension with team mechanics
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Siphon Life",        () => ! debuff("Siphon Life") && hp < 0.8),
                        new AandC("Spectral Strike",    () => strong("Spectral Strike") || enemyIsBlinded || enemyIsLucky),
                        new AandC("Ghostly Bite"),
                        new AandC("Shadow Slash"),
                        new AandC("Death Coil"),
                    };
                    break;

                case "Giant Bone Spider":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Bone Bite    | Poison Spit
                     * Slot 2: Sticky Web   | Siphon Life
                     * Slot 3: Leech Life   | Death Grip
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Sticky Web",     () => ! debuff("Sticky Web")),
                        new AandC("Leech Life",     () => enemyIsWebbed && hp < 0.7),
                        new AandC("Siphon Life",    () => ! debuff("Siphon Life") && hp < 0.8),
                        new AandC("Death Grip"),
                        new AandC("Bone Bite"),
                        new AandC("Poison Spit"),
                    };
                    break;

                case "Grotesque":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Gargoyle Strike  | Shadow Shock
                     * Slot 2: Ravage           | Agony
                     * Slot 3: Stone Form       | Ghostly Bite
                     */
                    undead_abilities = new List<AandC>() {
                        new AandC("Ravage",             () => hpEnemy < 0.25 || (famEnemy(PF.Critter) && hpEnemy > 0.4)),
                        new AandC("Agony",              () => ! debuff("Agony")),
                        new AandC("Stone Form",         () => hp < 0.4),
                        new AandC("Ghostly Bite"),
                        new AandC("Gargoyle Strike"),
                        new AandC("Shadow Shock"),
                    };
                    break;

                case "Infected Fawn":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Diseased Bite    | Flurry
                     * Slot 2: Adrenaline Rush  | Consume Corpse
                     * Slot 3: Siphon Life      | Death and Decay
                     * 
                     * TODO: Reintroduce Consume Corpse - Needs to consider team status
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Siphon Life",        () => ! debuff("Siphon Life") && hp < 0.8),
                        new AandC("Adrenaline Rush",    () => ! buff("Adrenaline")),
                        new AandC("Death and Decay",    () => ! debuff("Death and Decay")),
                        new AandC("Diseased Bite"),
                        new AandC("Flurry"),
                    };
                    break;

                case "Infected Squirrel":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Diseased Bite    | Stampede
                     * Slot 2: Rabid Strike     | Creeping Fungus
                     * Slot 3: Consume          | Corpse Explosion
                     * 
                     * TODO: Reintroduce Corpse Explosion - Needs to consider team status
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Consume",            () => hp < 0.8),
                        new AandC("Creeping Fungus",    () => ! debuff("Creeping Fungus")),
                        new AandC("Rabid Strike",       () => ! debuff("Rabies")),
                        new AandC("Diseased Bite"),
                        new AandC("Stampede"),
                    };
                    break;

                case "Infested Bear Cub":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Diseased Bite    | Roar
                     * Slot 2: Bash             | Hibernate
                     * Slot 3: Maul             | Corpse Explosion
                     * 
                     * TODO: Reintroduce Corpse Explosion - Needs to consider team status
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Hibernate",      () => hp < 0.5),
                        new AandC("Roar",           () => ! buff("Attack Boost")),
                        new AandC("Bash",           () => ! enemyIsResilient && ! enemyIsStunned),
                        new AandC("Maul"),
                        new AandC("Diseased Bite"),
                        new AandC("Roar"),
                    };
                    break;

                case "Landro's Lichling":
                case "Lil' K.T.":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Shadow Slash | Howling Blast
                     * Slot 2: Siphon Life  | Death and Decay
                     * Slot 3: Frost Nova   | Curse of Doom
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Curse of Doom",      () => ! debuff("Curse of Doom") && hp > 0.6),
                        new AandC("Siphon Life",        () => ! debuff("Siphon Life") && hp < 0.8),
                        new AandC("Death and Decay",    () => ! debuff("Death and Decay")),
                        new AandC("Frost Nova"),
                        new AandC("Shadow Slash"),
                        new AandC("Howling Blast"),
                    };
                    break;

                case "Lost of Lordaeron":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Shadow Slash | Absorb
                     * Slot 2: Siphon Life  | Arcane Explosion
                     * Slot 3: Bone Prison  | Curse of Doom
                     * 
                     * TODO: Reintroduce Arcane Explosion - Needs to consider enemy team status
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Absorb",             () => hp < 0.6),
                        new AandC("Curse of Doom",      () => ! debuff("Curse of Doom") && hp > 0.6),
                        new AandC("Siphon Life",        () => ! debuff("Siphon Life")),
                        new AandC("Bone Prison"),
                        new AandC("Shadow Slash"),
                        new AandC("Absorb"),
                    };
                    break;

                case "Macabre Marionette":
                    /* Changelog:
                     * 2015-01-20: Siphon Life is no longer health dependent and is cast if it is not already active - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Macabre Maraca   | Bone Bite
                     * Slot 2: Death and Decay  | Siphon Life
                     * Slot 3: Dead Man's Party | Bone Barrage
                     */
                    undead_abilities = new List<AandC>() {
                        new AandC("Death and Decay",    () => ! debuff("Death and Decay")),
                        new AandC("Siphon Life",        () => ! debuff("Siphon Life")),
                        new AandC("Dead Man's Party",   () => ! debuff("Shattered Defenses")),
                        new AandC("Bone Barrage",       () => ! debuff("Bone Barrage")),
                        new AandC("Macabre Maraca"),
                        new AandC("Bone Bite"),
                    };
                    break;

                case "Mr. Bigglesworth":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Claw         | Pounce
                     * Slot 2: Ice Barrier  | Frost Nova
                     * Slot 3: Ice Tomb     | Howling Blast
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Ice Barrier",    () => shouldIHide && speed >= speedEnemy),
                        new AandC("Frost Nova",     () => ! debuff("Frost Nova")),
                        new AandC("Ice Tomb",       () => ! debuff("Ice Tomb")),
                        new AandC("Howling Blast"),
                        new AandC("Claw"),
                        new AandC("Pounce"),
                    };
                    break;

                case "Restless Shadeling":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Shadow Shock     | Arcane Blast
                     * Slot 2: Plagued Blood    | Death and Decay
                     * Slot 3: Death Coil       | Phase Shift
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Phase Shift",        () => shouldIHide && speed >= speedEnemy),
                        new AandC("Plagued Blood",      () => ! debuff("Plagued Blood")),
                        new AandC("Death and Decay",    () => ! debuff("Death and Decay")),
                        new AandC("Death Coil",         () => ! weak("Death Coil") && hp < 0.7),
                        new AandC("Shadow Shock"),
                        new AandC("Arcane Blast"),
                    };
                    break;

                case "Scourged Whelpling":
                    /* Changelog:
                     * 2015-01-25: Corrected Death and Decay typo - Studio60
                     * 
                     * Abilities
                     * Slot 1: Shadowflame      | Tail Sweep
                     * Slot 2: Call Darkness    | Death and Decay
                     * Slot 3: Plagued Blood    | Dreadful Breath
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Plagued Blood",     () => ! debuff("Plagued Blood")),
                        new AandC("Death and Decay",   () => ! debuff("Death and Decay")),
                        new AandC("Dreadful Breath",   () => weather("Cleansing Rain")),
                        new AandC("Call Darkness",     () => ! weather("Darkness")),
                        new AandC("Shadowflame"),
                        new AandC("Tail Sweep"),
                    };
                    break;

                case "Son of Sethe":
                    /* Changelog:
                     * 2015-01-20: Hiss is now used with a higher priority - Studio60
                     *             Lift-Off is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Absorb       | Plagued Blood
                     * Slot 2: Hiss         | Touch of the Animus
                     * Slot 3: Drain Blood  | Lift-Off
                     * 
                     * Tactic Information:
                     * Hiss is only worth using if it makes us faster than the enemy
                     */
                    undead_abilities = new List<AandC>() {
                        new AandC("Lift-Off",               () => shouldIHide && speed >= speedEnemy),
                        new AandC("Plagued Blood",          () => ! debuff("Plagued")),
                        new AandC("Hiss",                   () => (speed <= speedEnemy && ! debuff("Speed Reduction")) || strong("Hiss")),
                        new AandC("Touch of the Animus",    () => ! debuff("Plagued")),
                        new AandC("Drain Blood",            () => hp < 0.6),
                        new AandC("Lift-Off"),
                        new AandC("Hiss",                   () => ! debuff("Speed Reduction") && ! weak("Hiss")),
                        new AandC("Absorb"),
                        new AandC("Plagued Blood"),
                    };
                    break;

                case "Spirit Crab":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Snap         | Amplify Magic
                     * Slot 2: Surge        | Whirlpool
                     * Slot 3: Shell Shield | Rot
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Shell Shield",       () => ! buff("Shell Shield")),
                        new AandC("Amplify Magic",      () => ! debuff("Amplify Magic")),
                        new AandC("Whirlpool",          () => ! debuff("Whirlpool") && hpEnemy > 0.5),
                        new AandC("Rot",                () => strong("Rot")),
                        new AandC("Surge"),
                        new AandC("Snap"),
                    };
                    break;

                case "Stitched Pup":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Diseased Bite    | Flurry
                     * Slot 2: Rabid Strike     | Howl
                     * Slot 3: Consume Corpse   | Plagued Blood
                     * 
                     * TODO: Reintroduce Consume Corpse - Needs to consider team status
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Rabid Strike",   () => ! debuff("Rabies")),
                        new AandC("Howl",           () => ! debuff("Shattered Defenses")),
                        new AandC("Plagued Blood",  () => ! debuff("Plagued")),
                        new AandC("Diseased Bite"),
                        new AandC("Flurry"),
                    };
                    break;

                case "Stinkrot":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60 for new pet coming in patch 6.1
                     * 
                     * Abilities
                     * Slot 1: Diseased Bite    | Infected Claw
                     * Slot 2: Rot              | Plagued Blood
                     * Slot 3: Corpse Explosion | Digest Brains
                     * 
                     * Tactic Information:
                     * Rot should not be used against humans
                     * 
                     * TODO: Corpse Explosion needs to detect own team status
                     */
                    undead_abilities = new List<AandC>() {
                        new AandC("Rot",            () => ! debuff("Rot") && ! famEnemy(PF.Humanoid)),
                        new AandC("Plagued Blood",  () => ! debuff("Plagued")),
                        new AandC("Digest Brains",  () => hp < 0.6),
                        new AandC("Diseased Bite"),
                        new AandC("Infected Claw"),
                        new AandC("Corpse Explosion"),
                    };
                    break;

                case "Unborn Val'kyr":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Shadow Slash | Shadow Stock
                     * Slot 2: Siphon Life  | Curse of Doom
                     * Slot 3: Haunt        | Unholy Ascension
                     * 
                     * TODO: Reintroduce Haunt - Needs to consider team status
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Siphon Life",        () => ! debuff("Siphon Life")),
                        new AandC("Unholy Ascension",   () => hp < 0.1 ),
                        new AandC("Curse of Doom",      () => ! debuff("Curse of Doom")),
                        new AandC("Shadow Slash"),
                        new AandC("Shadow Shock"),
                    };
                    break;

                case "Vampiric Batling":
                    /* Changelog:
                     * 2015-01-25: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Bite             | Screech
                     * Slot 2: Leech Life       | Hawk Eye
                     * Slot 3: Reckless Strike  | Nocturnal Strike
                     */
                    undead_abilities = new List<AandC>() 
                    {
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")),
                        new AandC("Leech Life",         () => ! weak("Leech Life") && hp < 0.8),
                        new AandC("Reckless Strike",    () => hpEnemy < 0.25),
                        new AandC("Nocturnal Strike",   () => enemyIsBlinded || enemyIsLucky),
                        new AandC("Bite"),
                        new AandC("Screech"),
                    };
                    break;

                case "Weebomination":
                    /* Changelog:
                     * 2015-01-20: Corpse Explosion - Fixed an ability typo (thanks to Valpsjuk) - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Cleave           | Diseased Bite
                     * Slot 2: Consume Corpse   | Death Grip
                     * Slot 3: Corpse Explosion | Haymaker
                     * 
                     * TODO: Consume Corpse needs to check own team status
                     * TODO: Death Grip needs to check own team status
                     * TODO: Corpse Explosion needs to check own team status
                     */
                    undead_abilities = new List<AandC>() {
                        new AandC("Haymaker",           () => strong("Haymaker") || myPetIsLucky),
                        new AandC("Cleave"),
                        new AandC("Diseased Bite"),
                        new AandC("Consume Corpse"),
                        new AandC("Death Grip"),
                        new AandC("Corpse Explosion"),
                    };
                    break;

                case "Widget the Departed":
                    /* Changelog:
                     * 2015-01-20: Spectral Strike is now checking for all blindness effects - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Pounce           | Spirit Clawss
                     * Slot 2: Devour           | Spectral Strike
                     * Slot 3: Call Darkness    | Prowl
                     */
                    // prowl: trying to only use it, if we stay faster after using it
                    undead_abilities = new List<AandC>() {
                        new AandC("Devour",             () => hpEnemy < 0.25 || (famEnemy(PF.Critter) && hpEnemy > 0.4)),
                        new AandC("Spectral Strike",    () => enemyIsBlinded || myPetIsLucky),
                        new AandC("Call Darkness",      () => ! weather("Darkness")),
                        new AandC("Prowl",              () => speed * 0.7 > speedEnemy),
                        new AandC("Pounce"),
                        new AandC("Spirit Claws"),
                    };
                    break;

                case "Zomstrok":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Infected Claw    | Creeping Fungus
                     * Slot 2: Shell Shield     | Rot
                     * Slot 3: Carpnado         | Toxic Skin
                     */
                    undead_abilities = new List<AandC>() {
                        new AandC("Shell Shield",       () => ! buff("Shell Shield")),
                        new AandC("Rot",                () => ! debuff("Rot")),
                        new AandC("Carpnado"),
                        new AandC("Toxic Skin",         () => ! buff("Toxic Skin")),
                        new AandC("Infected Claw"),
                        new AandC("Creeping Fungus"),
                    };
                    break;

                default:
                    ////////////////////////
                    // Unknown Undead Pet //
                    ////////////////////////
                    Logger.Alert("Unknown undead pet: " + petName);
                    undead_abilities = null;
                    break;
            }

            return undead_abilities;

        }
    }
}