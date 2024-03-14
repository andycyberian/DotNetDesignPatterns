using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public interface IVisitor
    {
        void VisitBook(Book book);
        void VisitVinyl(Vinyl vinyl);
        void Print();
    }

    public interface IVisitableElement
    {
        void Accept(IVisitor visitor);
    }

    public class DiscountVisitor : IVisitor
    {
        private double _savings = 0.00;

        public void VisitBook(Book book)
        {
            if(book.Price < 20.00)
            {
                var discount = book.GetDiscount(0.10);
                Console.WriteLine($"DISCOUNTED: Book #{book.Id} is now ${Math.Round(book.Price - discount, 2)}");
                _savings += discount;
            }
            else
            {
                Console.WriteLine($"FULL PRICE: Book #{book.Id} is ${book.Price}");
            }
        }

        public void VisitVinyl(Vinyl vinyl)
        {
            var discount = vinyl.GetDiscount(0.15);
            Console.WriteLine($"SUPER SAVINGS: Vinyl #{vinyl.Id} is now ${Math.Round(vinyl.Price - discount, 2)}");
            _savings += discount;
        }

        public void Print()
        {
            Console.WriteLine($"\nYou saved a total of ${Math.Round(_savings, 2)} on today's order");
        }

        public void Reset()
        {
            _savings = 0.00;
        }
    }

    public class SalesVisitor : IVisitor
    {
        private int BookCount = 0;
        private int VinylCount = 0;


        public void Print()
        {
            Console.WriteLine($"Books sold: {BookCount} \nVinyl sold: {VinylCount}");
            Console.WriteLine($"The store sold {BookCount + VinylCount} units today");
        }

        public void VisitBook(Book book)
        {
            BookCount++;
        }

        public void VisitVinyl(Vinyl vinyl)
        {
           VinylCount++;
        }
    }
}
