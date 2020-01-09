using System.Collections.Generic;
using NUnit.Framework;

namespace DungeonsAndDesignPatterns.Prototype
{
    public abstract class ReplicatingWeapon
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Damage { get; set; }

        public ReplicatingWeapon()
        {
            
        }

        public ReplicatingWeapon(ReplicatingWeapon replicatingWeapon)
        {
            Name = replicatingWeapon.Name;
            Weight = replicatingWeapon.Weight;
            Damage = replicatingWeapon.Damage;
        }

        public abstract ReplicatingWeapon Clone();
    }

    public class SwordOfLight : ReplicatingWeapon
    {
        public int Brightness { get; set; }

        public SwordOfLight()
        {
            
        }

        public SwordOfLight(SwordOfLight sword) : base(sword)
        {
            Brightness = sword.Brightness;
        }

        public override ReplicatingWeapon Clone()
        {
            return new SwordOfLight(this);
        }
    }

    public class MaceOfHealing : ReplicatingWeapon
    {
        public int HealingFactor { get; set; }

        public MaceOfHealing()
        {
            
        }
        public MaceOfHealing(MaceOfHealing mace) : base(mace)
        {
            HealingFactor = mace.HealingFactor;
        }

        public override ReplicatingWeapon Clone()
        {
            return new MaceOfHealing(this);
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            var weapons = new List<ReplicatingWeapon>();
            
            var swordOL = new SwordOfLight();
            swordOL.Brightness = 100;
            swordOL.Damage = 10;
            swordOL.Name = "Dave";
            swordOL.Weight = 5;
            
            weapons.Add(swordOL);
            weapons.Add(swordOL.Clone());
            
            var maceOH = new MaceOfHealing();
            maceOH.HealingFactor = 2;
            maceOH.Damage = 10;
            maceOH.Name = "Dave";
            maceOH.Weight = 5;
        }
    }
    
}