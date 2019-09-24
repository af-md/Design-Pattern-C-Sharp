namespace AbstractFactory
{
    public class DungeonWithTrapsInRoom : Dungeon
    {

        public override void CreateRooms()
        {
            RoomWithTraps r1 = new RoomWithTraps();
        }
    }
}