namespace AbstractFactory
{
    public class TestDungeons
    {
        
        public void Test()
        {
            // Create the Dungeon. The constructor will run the factory methods.  
            
            Dungeon d1 = new Dungeon();
            d1.CreateCorridors();
            d1.CreateRooms();

            // create a different factory class; execute it's functions;   
            
            DungeonWithTrapsInRoom dr = new DungeonWithTrapsInRoom();
            dr.CreateRooms();
            dr.CreateCorridors();
            
            // create a different factory class; execute it's functions; 
            // I have also used "Dungeon" to show the benefits of polymoriphism
            Dungeon dungeonInvisibleEnemies = new DungeonsWithInvisibleEnemies();
            dungeonInvisibleEnemies.CreateRooms();
            dungeonInvisibleEnemies.CreateCorridors();
            
        }
    }
}