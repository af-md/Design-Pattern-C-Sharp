using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DungeonsAndDesignPatterns.Visitor
{
    interface IVisitor
    {
        void Visit(Element element);
    }
    
    abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }

    class Character : Element
    {
        public string Name { get; set; }
        public int HealthPoints { get; set; }

        public Character(string name, int baseHP)
        {
            Name = name;
            HealthPoints = baseHP;
        }
        
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    
    class FireballVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Character c = element as Character;

            c.HealthPoints -= 5;
        }
    }

    class HealingWordVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Character c = element as Character;

            c.HealthPoints += 3;
        }
    }
    
    
    class Characters
    {
        private List<Character> _character = new List<Character>();

        public void Attach(Character character)
        {
            _character.Add(character);
        }

        public void Detach(Character character)
        {
            _character.Remove(character);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Character e in _character)
            {
                e.Accept(visitor);
            }
            Console.WriteLine();
        }
    }
    
    class Goblin : Character
    {
        public Goblin() : base("Boblin", 5)
        {
        }
    }
    
    class Wizard : Character
    {
        public Wizard() : base("Wizzy", 30)
        {
        }
    }

    public class Tests
    {
        [Test]
        public void Test()
        {
            var characters = new Characters();
            var goblin = new Goblin();
            characters.Attach(goblin);
            var wizard = new Wizard();
            characters.Attach(wizard);
            
            characters.Accept(new FireballVisitor());

            Assert.AreEqual(goblin.HealthPoints, 0);
            Assert.AreEqual(wizard.HealthPoints, 25);
            
            characters.Accept(new HealingWordVisitor());

            Assert.AreEqual(goblin.HealthPoints, 3);
            Assert.AreEqual(wizard.HealthPoints, 28);
        }
    }
}