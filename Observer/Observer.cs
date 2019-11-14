using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Observer
{
    public interface IMazeObserver
    {
        void Update(IDictionary<int, int> mazeLocation);
        void Move();
        int Location { get; set; }
        int Id { get; set; }
        
        IDictionary<int, int> MazeState { get; set; }
    }

    public interface IMazeArchitectureSubject
    {
        void Attach(IMazeObserver mazeObserver);
        void Detach(IMazeObserver mazeObserver);
        void Notify();
        IDictionary<int, int> GetState();
        void SetState();
    }
    
    public class MazeArchitectureSubject : IMazeArchitectureSubject
    {
        private List<IMazeObserver> MazeObservers = new List<IMazeObserver>();
        private Dictionary<int, int> MazeState = new Dictionary<int, int>();

        public void Attach(IMazeObserver mazeObserver)
        {
            MazeObservers.Add(mazeObserver);
            MazeState.Add(mazeObserver.Id, mazeObserver.Location);
        }

        public void Detach(IMazeObserver mazeObserver)
        {
            MazeObservers.Remove(mazeObserver);
            MazeState.Remove(mazeObserver.Id);
        }

        public void Notify()
        {
            foreach (var maze in MazeObservers)
            {
                maze.Update(MazeState);
            }
        }

        public IDictionary<int, int> GetState()
        {
            return MazeState; 
        }

        public void SetState()
        {
            Console.WriteLine("Amended the walls in the dictionary");
            Notify();
        }
    }

    public class MazeObserver : IMazeObserver
    {
        public int Location { get; set; }
        public int Id { get; set; }
        
        public IDictionary<int, int> MazeState { get; set; }

        public MazeObserver(int location, int id)
        {
            Location = location;
            Id = id;
        }

        public void Update(IDictionary<int, int> mazeLocation)
        {
            Console.WriteLine("the location state has changed, so move other walls");
            MazeState = mazeLocation; 
            Move();
        }

        public void Move()
        {
            Console.WriteLine("Wall moved");
        }
    }

    [TestFixture]
    public class OberserverTest
    {
        [Test]
        public void MazeOberserTest()
        {
            // Create the maze "subject" which will hold the state
            IMazeArchitectureSubject maze = new MazeArchitectureSubject();
            
            // Create the walls "observers" to observe any changes
            var blueWall = new MazeObserver(1,1); 
            var yellowWall = new MazeObserver(1,1); 
            var orangeWall = new MazeObserver(1,1); 
            var brownWall = new MazeObserver(1,1); 
            
            // A maze runner steps into the maze. The maze follows the runner movements and changes the state each time. 
            maze.SetState();

        }
    }


}