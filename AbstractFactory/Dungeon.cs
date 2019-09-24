namespace AbstractFactory
{
    public class Dungeon : AbstractFactoryDungeon
    {

        
        public virtual void CreateRooms()
        {
            Room r1 = new Room();
        }

        public virtual void CreateCorridors()
        {
            Corridor c1 = new Corridor();
        }
    }
}