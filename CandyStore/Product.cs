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
            //assign the ProductType when empty constructor is called
            Type = ProductType.ChcolateBar;
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
            //assign the ProductType when empty constructor is called
            Type = ProductType.Lolipop;
        }

        // inherited constructor from base Product class
        internal Lolipop(int id) : base(id)
        {
            Type = ProductType.Lolipop;
        }

        internal override string GetProductForCsv(int id)
        {
            //we are casting the {(int)Type} so we can get the number and not the Name of the type itself from the enum class
            //we also need a second comma next to {Price},, so ensure we are not out of bounds for index values because {Shape} is number 5 when we access it in the GetProducts() of the ProductController it's parts.Shape = parts[5]...so this extra comma makes {Shape} here index 5 and not 4
            return $"{id}, {(int)Type}, {Name}, {Price},, {Shape}";
        }
    }
}
