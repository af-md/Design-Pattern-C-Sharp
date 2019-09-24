using System;

namespace AbstractFactory
{
    public class DungeonsWithInvisibleEnemies : Dungeon
    {
        public override void CreateCorridors()
        {
            Console.WriteLine("Corridors with invisible enemies created");
        }
    }
}