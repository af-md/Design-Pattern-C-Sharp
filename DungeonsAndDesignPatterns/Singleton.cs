using System;
using System.Linq.Expressions;
using System.Threading;
using System.Transactions;
using NUnit.Framework;


namespace Singleton
{
    public class SingletonMagicBook
    {
        private static SingletonMagicBook uniqueInstance;

        private static int Count { get; set; } = 0;

        private bool IsBorrowed { get; set; } = false;

        public void SingletonOperation()
        {
            // return something 
        }

        public void GetSingletonData()
        {
            //return SingletonData = "Test";
        }
        
        // we need to protect this method somehow
        public static SingletonMagicBook Instance()
        {
            if (Count == 0)
            {
                uniqueInstance = new SingletonMagicBook();
                Count++;
                return uniqueInstance;
            }
            else
            {
                return uniqueInstance;
            }
        }

        public bool BorrowBook()
        {
            if (IsBorrowed == false)
            {
                IsBorrowed = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public interface IWizard
    {
        void BorrowMagicBook();
    }

    public class GoblinWizard : IWizard
    {
        public SingletonMagicBook Book;

        public void BorrowMagicBook()
        {
            Book = SingletonMagicBook.Instance();
            Book.BorrowBook();
            Console.WriteLine("Book borrowed");
        }
    }

    public class ElfWizard : IWizard
    {

        public void BorrowMagicBook()
        {
            
        }
    }

    
    [TestFixture]
    public class TestSingleton
    {
        [Test]
        public void TestSingletonPattern()
        {
            IWizard goblin = new GoblinWizard();
            goblin.BorrowMagicBook();
        }
    }
}