using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DungeonsAndDesignPatterns
{
    public static class DiceHelper
    {
        private static Random _random { get; set; }
        public static Random Random
        {
            get
            {
                if (_random == null)
                    _random = new Random();
                return _random;
            }
            set { _random = value; }
        }

        public static int Roll4D4AndDropLowest()
        {
            var rolls = new List<int>()
            {
                RollD4(),
                RollD4(),
                RollD4(),
                RollD4()
            };

            rolls = rolls.OrderBy(x => x).ToList();

            return rolls[1] + rolls[2] + rolls[3];
        }

        private static int RollD4()
        {
            return Random.Next(1,5);
        }
    }
    
    public class Character
    {
        public int Intelligence { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Charisma { get; set; }
        public int Wisdom { get; set; }
        public int Constitution { get; set; }
    }

    public class CharacterCreator
    {
        public Character CreateCharacter()
        {
            return new Character()
            {
                Intelligence = getIntelligence(),
                Strength = getStrength(),
                Dexterity = getDexterity(),
                Charisma = getCharisma(),
                Wisdom = getWisdom(),
                Constitution = getConstitution()
            };
        }

        protected virtual int getConstitution()
        {
            return DiceHelper.Roll4D4AndDropLowest();
        }

        protected virtual int getWisdom()
        {
            return DiceHelper.Roll4D4AndDropLowest();
        }

        protected virtual int getCharisma()
        {
            return DiceHelper.Roll4D4AndDropLowest();
        }

        protected virtual int getDexterity()
        {
            return DiceHelper.Roll4D4AndDropLowest();
        }

        protected virtual int getStrength()
        {
            return DiceHelper.Roll4D4AndDropLowest();
        }

        protected virtual int getIntelligence()
        {
            return DiceHelper.Roll4D4AndDropLowest();
        }
    }
    
    public class HillDwarfCreator : CharacterCreator
    {
        protected override int getWisdom()
        {
            return base.getWisdom() + 1;
        }

        protected override int getConstitution()
        {
            return base.getConstitution() + 2;
        }
    }
    
    public class FactoryMethod
    {
        [SetUp]
        public void SetUp()
        {
            DiceHelper.Random = new Random(1);
        }
        
        
        [Test]
        public void BasicCharacter()
        {
            var characterCreator = new CharacterCreator();
            var character = characterCreator.CreateCharacter();
            Console.Write(JsonConvert.SerializeObject(character, Formatting.Indented));
//            {
//                "Intelligence": 7,
//                "Strength": 9,
//                "Dexterity": 5,
//                "Charisma": 10,
//                "Wisdom": 9,
//                "Constitution": 7
//            }
        }

        [Test]
        public void Dwarf()
        {
            var dwarfCreator = new HillDwarfCreator();
            var character = dwarfCreator.CreateCharacter();
            Console.Write(JsonConvert.SerializeObject(character, Formatting.Indented));
//            {
//                "Intelligence": 7,
//                "Strength": 9,
//                "Dexterity": 5,
//                "Charisma": 10,
//                "Wisdom": 10,
//                "Constitution": 9
//            }
        }
    }

}