using System;

namespace AbstractFactory
{
    public class Room : AbstractRooms
    {
        public Room()
        {
            BuildRoom();
        }

        public void BuildRoom()
        {
            Console.WriteLine("Room Built");
        }
    }
}