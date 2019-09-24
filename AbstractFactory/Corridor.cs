using System;

namespace AbstractFactory
{
    public class Corridor : AbstractCorridors
    {
        public Corridor()
        {
            BuildCorridor();
        }

        public void BuildCorridor()
        {
            Console.WriteLine("Corridor built");
        }
    }
}