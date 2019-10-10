namespace Proxy
using System;
using NUnit.Framework;

{
    public interface IRoyals
    {
        void Talk();
        void Decide();
        
    }

    public class King : IRoyals
    {
        // The constructor is to show the implementation of the pattern
        public King()
        {
            
        }

        public void Talk() => Console.WriteLine("I am here. Kiss my hand");
        
        public void Decide()  => Console.WriteLine("We will never concede");
    }

    public class KingProxy : IRoyals
    {

        public King King;

        public KingProxy()
        {
            // you don't necessarily need to assign the object here
            King = new King();
        }

        public void Talk() => King.Talk();


        public void Decide() => King.Decide();

    }


    public class Enemy
    {
        protected KingProxy KingProxy;

        public void UseProxy()
        {
            KingProxy = new KingProxy();
            KingProxy.Talk();
            KingProxy.Decide();
        }
    }
    [TestFixture]
    public class ClientTest
    {
        [Test]
        public void ProxyTest()
        {
            Enemy client = new Enemy();
            client.UseProxy();
        }
    }
}