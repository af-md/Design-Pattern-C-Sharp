using System;

namespace AbstractFactory
{
    public class Enemies
    
    {
        public int CountEnemies { get; set; }

        public Enemies(int enemies)
        {
            CountEnemies = enemies;
            Console.WriteLine("Enemies in the corridor are:" + CountEnemies);
        }
    }
}