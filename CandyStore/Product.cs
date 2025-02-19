using static CandyStore.Enums;

namespace CandyStore
{
    internal class Product
    {
        //properties of Product
        public int Id { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        internal ProductType Type { get; set; }

        //constructor ...will be required from inheriting child classes below
        public Product(int id)
        {
            Id = id;
        }
        

    }//end product class

    // ChocolateBar class
    internal class ChocolateBar : Product
    {
        //properties of ChcolateBar
        internal int CocoaPercentage { get; set; }
        
        // inherited constructor from base Product class
        public ChocolateBar(int id) : base(id)
        {
            Type = ProductType.ChcolateBar;
        }
    }// end ChocolateBar class

    internal class Lolipop : Product
    {
        //properties of Lolipop 
        internal string Shape { get; set; }

        // inherited constructor from base Product class
        public Lolipop(int id) : base(id)
        {
            Type = ProductType.Lolipop;
        }
    }
}
