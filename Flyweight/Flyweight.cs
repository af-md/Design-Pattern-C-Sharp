using System;
using System.Collections.Generic;
using System.Transactions;
using NUnit.Framework;

namespace DungeonsAndDesignPatterns.Flyweight
{

    public abstract class Enemy
    {
        public string Race { get; set; }
        public int MaxHP { get; set; }
        public string Name { get; set; }

        public abstract int GetMaxHealth();
    }
    
    class Boblin : Enemy
    {
        public Boblin()
        {
            Race = "Goblin";
            MaxHP = 12;
            Name = "Boblin";
        }
        public override int GetMaxHealth()
        {
            return MaxHP;
        }
    }
    
    class Fizzard : Enemy
    {
        public Fizzard()
        {
            Race = "Lizardfolk";
            MaxHP = 60;
            Name = "Fizzard the lizard-wizard";
        }
        public override int GetMaxHealth()
        {
            return MaxHP;
        }
    }
    
    class Steve : Enemy
    {
        public Steve()
        {
            Race = "Human";
            MaxHP = 1;
            Name = "Steve (just a regular dude)";
        }
        
        public override int GetMaxHealth()
        {
            return MaxHP;
        }
    }

    public class EnemyFactory
    {
        private Dictionary<char, Enemy> Enemies = new Dictionary<char, Enemy>();

        public EnemyFactory()
        {
            Enemies.Add('B', new Boblin());
            Enemies.Add('F', new Fizzard());
            Enemies.Add('S', new Steve());
        }

        public Enemy GetEnemy(char code)
        {
            return Enemies[code];
        }
    }

    public class Test
    {
        [Test]
        public void Method()
        {
            var fac = new EnemyFactory();

            var enemiesToCheck = "BF";
            Console.WriteLine("Check enemy health:");

            foreach (var code in enemiesToCheck)
            {
                var enemy = fac.GetEnemy(code);
                Console.WriteLine(enemy.GetMaxHealth());
            }
            
            // Check enemy health:
            // 12
            // 60

            var checkSteve = "S";
            Console.WriteLine("Check steves health:");

            foreach (var code in checkSteve)
            {
                var enemy = fac.GetEnemy(code);
                Console.WriteLine(enemy.GetMaxHealth());
            }
            
            // Check steves health:
            // 1
        }
    }
}