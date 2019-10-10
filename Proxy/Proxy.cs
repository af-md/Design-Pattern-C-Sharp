using System;
using NUnit.Framework;

namespace Proxy
{
    public interface IRoyals
    {
        void Talk();
        void Decide();
        
    }

    public class King : IRoyals
    {
        public void Talk() => Console.WriteLine("I am here. Kiss my hand");
        
        public void Decide()  => Console.WriteLine("We will never concede");
    }

    public class KingProxy : IRoyals
    {
        private King king;

        public King King 
        {
            get
            {
                if (king == null) king = new King();
                return king;
            }
        }

        public void Talk() => King.Talk();


        public void Decide() => King.Decide();

    }

    [TestFixture]
    public class ClientTest
    {
        [Test]
        public void ProxyTest()
        {
            var KingProxy = new KingProxy();
            KingProxy.Talk();
            KingProxy.Decide();
        }
    }
}