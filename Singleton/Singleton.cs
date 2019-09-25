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
        
        // we need to protect this method somehow
        public static SingletonMagicBook Instance()
        {
            if (Count == 0)
            {
                uniqueInstance = new SingletonMagicBook();
                Count++;
                return uniqueInstance;
            }
            else return uniqueInstance;
            
        }
        
        public bool BorrowBook()
        {
            if (!IsBorrowed)  return IsBorrowed = true; 
            else  return false; 
        }

        public void ReturnBook()
        {
            if (IsBorrowed) IsBorrowed = false; 
        }
    }

    public interface IWizard
    {
        void BorrowMagicBook();
        void ReturnBook();
    }

    public class GoblinWizard : IWizard
    {
        public SingletonMagicBook Book;

        public void BorrowMagicBook()
        {
            Book = SingletonMagicBook.Instance();
            Console.WriteLine(Book.BorrowBook() ? "Book borrowed" : "Can't borrow");
        }

        public void ReturnBook()
        {
            Book.ReturnBook();
            Console.WriteLine("Book returned");

        }
    }

    public class ElfWizard : IWizard
    {
        public SingletonMagicBook Book;

        public void BorrowMagicBook()
        {
            Book = SingletonMagicBook.Instance();
            Console.WriteLine(Book.BorrowBook() ? "Book borrowed" : "Can't borrow");
        }
        

        public void ReturnBook()
        {
            Book.ReturnBook();
            Console.WriteLine("Book returned");
        }
    }

    
    [TestFixture]
    public class TestSingleton
    {
        [Test]
        public void TestSingletonPattern()
        {
            IWizard goblin = new GoblinWizard();
           
            IWizard elf = new ElfWizard();
            
            // Borrow the single book instance
            goblin.BorrowMagicBook();
            
            // Try to borrow the book instance 
            elf.BorrowMagicBook();
            
            // Return book instance 
            goblin.ReturnBook();
            
            // Try to borrow again 
            elf.BorrowMagicBook();
            
            
            //Output
            //Book borrowed
            //Can't borrow
            //Book returned
            //Book borrowed

            
        }
    }
}