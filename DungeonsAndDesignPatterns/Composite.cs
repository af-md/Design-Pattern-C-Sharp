using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DungeonsAndDesignPatterns
{
    interface IWeaponAttack
    {
        int Calculate();
    }
    
    class SwordAttack : IWeaponAttack
    {
        public int Calculate()
        {
            return 7;
        }
    }

    class FireAttack : IWeaponAttack
    {
        public int Calculate()
        {
            return 5;
        }
    }
    
    class ProficientAttack : IWeaponAttack
    {
        public int Calculate()
        {
            return 2;
        }
    }

    class CompositeAttack : IWeaponAttack
    {
        public List<IWeaponAttack> attacks { get; } = new List<IWeaponAttack>();
        
        public CompositeAttack(params IWeaponAttack[] weaponAttacks)
        {
            attacks.AddRange(weaponAttacks);
        }
        
        public int Calculate()
        {
            return attacks.Sum(x => x.Calculate());
        }

        public void Add(IWeaponAttack weaponAttack)
        {
            attacks.Add(weaponAttack);
        }
    }


    [TestFixture]
    public class Composite
    {
        [Test]
        public void Test1()
        {
            var swordAttack = new SwordAttack();
            Assert.AreEqual(7, swordAttack.Calculate());
            
            var fireAttack = new FireAttack();
            var compositeAttack = new CompositeAttack(swordAttack, fireAttack);
            
            Assert.AreEqual(12, compositeAttack.Calculate());

            var proficientAttack = new ProficientAttack();
            compositeAttack.Add(proficientAttack);
            Assert.AreEqual(14, compositeAttack.Calculate());
            
            
            var modifiers = new CompositeAttack(proficientAttack, fireAttack);
            var attack = new CompositeAttack(swordAttack, modifiers);
            Assert.AreEqual(14, attack.Calculate());
        }
    }
}