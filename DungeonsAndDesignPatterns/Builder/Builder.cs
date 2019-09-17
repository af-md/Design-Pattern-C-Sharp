using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Builder
{
    public abstract class HighForrestBuilder
    {
        protected HighForrest forrest;

        public void CreateForrest()
        {
            forrest = new HighForrest();
        }

        public abstract void BuildLand();
        public abstract void BuildTrees();
        public abstract void BuildSpeciality();

        public HighForrest GetForrest()
        {
            return forrest;
        }
    }

    public class DragonHighForrestBuilder : HighForrestBuilder
    {
        
        public override void BuildLand()
        {
            
            Console.WriteLine("Land");
        }

        public override void BuildTrees()
        {
            Console.WriteLine("Built");
        }

        public override void BuildSpeciality()
        {
            Console.WriteLine("Sp");

        }
    }

    public class DinosaursHighForrestBuilder : HighForrestBuilder
    {
        public override void BuildLand()
        {
            forrest.Length = 5;   
            Console.WriteLine("Forrest land length: {0}" , forrest.Length);
        }

        public override void BuildTrees()
        {
            forrest.NumberOfTrees = 7; 
            Console.WriteLine("Trees built: {0}" , forrest.NumberOfTrees);
        }

        public override void BuildSpeciality()
        {
            forrest.SpecialFeature = "Dinosaurs populated";
            Console.WriteLine("Special feature of this forrest: {0}" , forrest.SpecialFeature);
        }
    }

    public class HighForrest
    {
        public int Length { get; set; } = 10;
        public int NumberOfTrees { get; set; } = 5;
        public string SpecialFeature { get; set; } = "";
    }
    
    public class Wizard
    {
        public void MakeForrest(HighForrestBuilder builder)
        {
            builder.CreateForrest();
            builder.BuildLand();
            builder.BuildTrees();
            builder.BuildSpeciality();
        }

        public HighForrest GetForrest(HighForrestBuilder builder)
        {
            return builder.GetForrest();
        }
    }

    [TestFixture]
    public class TestBuilder
    {
        [Test]
        public void BuilderTest()
        {
            Wizard wizard = new Wizard();
            DinosaursHighForrestBuilder dino = new DinosaursHighForrestBuilder();

            // Use make forest and dino to build the forrest with dinosaurs.
            wizard.MakeForrest(dino);

            HighForrest forrest = wizard.GetForrest(dino);
            
            Console.WriteLine("To test if right type of forrest. Forrest Length = {0}", forrest.SpecialFeature);
            
            //Output
            
            // Forrest land length: 5
            // Trees built: 7
            // Special feature of this forrest: Dinosaurs populated
            // To test if right type of forrest. Forrest Length = Dinosaurs populated

        }
    }

}
