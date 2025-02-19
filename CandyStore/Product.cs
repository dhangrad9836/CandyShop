using static CandyStore.Enums;

namespace CandyStore
{
    internal abstract class Product
    {
        //properties of Product
        public int Id { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        internal ProductType Type { get; set; }

        //empty constructor
        internal Product()
        {
            
        }

        //constructor ...will be required from inheriting child classes below
        internal Product(int id)
        {
            Id = id;
        }

        //abstract method which child classes will implement
        internal abstract string GetProductForCsv(int id);
        

    }//end product class

    // ChocolateBar class
    internal class ChocolateBar : Product
    {
        //properties of ChcolateBar
        internal int CocoaPercentage { get; set; }

        internal ChocolateBar()
        {
            
        }

        // inherited constructor from base Product class
        internal ChocolateBar(int id) : base(id)
        {
            Type = ProductType.ChcolateBar;
        }

        internal override string GetProductForCsv(int id)
        {
            //we are casting the {(int)Type} so we can get the number and not the Name of the type itself from the enum class
            return $"{id}, {(int)Type}, {Name}, {Price}, {CocoaPercentage}";
        }
    }// end ChocolateBar class

    internal class Lolipop : Product
    {
        //properties of Lolipop 
        internal string Shape { get; set; }

        internal Lolipop()
        {
            
        }

        // inherited constructor from base Product class
        internal Lolipop(int id) : base(id)
        {
            Type = ProductType.Lolipop;
        }

        internal override string GetProductForCsv(int id)
        {
            //we are casting the {(int)Type} so we can get the number and not the Name of the type itself from the enum class
            return $"{id}, {(int)Type}, {Name}, {Price}, {Shape}";
        }
    }
}
