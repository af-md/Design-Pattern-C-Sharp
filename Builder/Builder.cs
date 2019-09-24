using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Builder
{
    public abstract class ForestBuilder
    {
        protected Forest Forest;

        public void CreateForest()
        {
            Forest = new Forest();
        }

        public abstract void BuildLand();
        public abstract void BuildTrees();
        public abstract void BuildSpeciality();

        public Forest GetForest()
        {
            return Forest;
        }
    }

    public class DragonForestBuilder : ForestBuilder
    {
        
        public override void BuildLand()
        {
            
            Forest.Size = 8;   
            Console.WriteLine("Forest land length: {0}" , Forest.Size);
        }

        public override void BuildTrees()
        {
            Forest.NumberOfTrees = 10; 
            Console.WriteLine("Trees built: {0}" , Forest.NumberOfTrees);
        }

        public override void BuildSpeciality()
        {
            Forest.SpecialFeature = "Dragons populated";
            Console.WriteLine("Special feature of this forest: {0}" , Forest.SpecialFeature);

        }
    }

    public class DinosaursForestBuilder : ForestBuilder
    {
        public override void BuildLand()
        {
            Forest.Size = 5;   
            Console.WriteLine("Forest land length: {0}" , Forest.Size);
        }

        public override void BuildTrees()
        {
            Forest.NumberOfTrees = 7; 
            Console.WriteLine("Trees built: {0}" , Forest.NumberOfTrees);
        }

        public override void BuildSpeciality()
        {
            Forest.SpecialFeature = "Dinosaurs populated";
            Console.WriteLine("Special feature of this forest: {0}" , Forest.SpecialFeature);
        }
    }

    public class Forest
    {
        public int Size { get; set; } = 10;
        public int NumberOfTrees { get; set; } = 5;
        public string SpecialFeature { get; set; } = "";
    }
    
    public class Wizard
    {
        public void MakeForest(ForestBuilder builder)
        {
            builder.CreateForest();
            builder.BuildLand();
            builder.BuildTrees();
            builder.BuildSpeciality();
        }
    }

    [TestFixture]
    public class TestBuilder
    {
        [Test]
        public void BuilderTest()
        {
            Wizard wizard = new Wizard();
            DinosaursForestBuilder dino = new DinosaursForestBuilder();
            DragonForestBuilder dragon = new DragonForestBuilder();
            
            // Use make forest and dino to build the forest with dinosaurs.
            Console.WriteLine("Dinosaurs forest builder output");
            wizard.MakeForest(dino);

            // Use make forest and dragons to build the forest with dragons.
            Console.WriteLine("Dragon forest builder");
            wizard.MakeForest(dragon);

            // Retrieve the composite/constructed object
            Forest forestWithDinosaurs = dino.GetForest();
            Forest forestWithDragon = dragon.GetForest();
            
            //output
            //Dinosaurs forest builder output
            //Forest land length: 5
            //Trees built: 7
            //Special feature of this forest: Dinosaurs populated
            //Dragon forest builder
            //Forest land length: 8
            //Trees built: 10
            //Special feature of this forest: Dragons populated

        }
    }

}
