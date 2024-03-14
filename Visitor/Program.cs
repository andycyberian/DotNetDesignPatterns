// See https://aka.ms/new-console-template for more information
using Visitor;

var items = new List<IVisitableElement>
{
    new Book(12345, 11.99),
    new Book(78910, 22.79),
    new Vinyl(11198, 17.99),
    new Book(63254, 9.79)
};

var cart = new ObjectStructure(items);

var discountVisitor = new DiscountVisitor();
//foreach (var item in items)
//{
//    item.Accept(discountVisitor);
//}

//discountVisitor.Print();

var salesVisitor = new SalesVisitor();
//foreach (var item in items)
//{
//    item.Accept(salesVisitor);
//}

//salesVisitor.Print();

cart.ApplyVisitor(discountVisitor);
cart.ApplyVisitor(salesVisitor);

discountVisitor.Reset();
cart.RemoveItem(items[2]);
cart.ApplyVisitor(discountVisitor);


