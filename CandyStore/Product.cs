﻿using static CandyStore.Enums;

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
        //we later on made this abstract method when we added the new method from the ViewSingleProductChoice() inside the userInterface class. We autogenereted an abstract method which was placed inside this Product class. And then afterwards all the children classes will have to implement this new abstract method
        internal abstract string GetProductForPanel();  //will output a string of Product information.
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

        // returning a chocolate product and similar to the lolipop
        internal override string GetProductForPanel()
        {
              return $@"Id: {Id}
 Type: {Type}
 Name: {Name}
 Price: {Price}
 Coca Percentage: {CocoaPercentage}";
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

        internal override string GetProductForPanel()
        {
              return $@"Id: {Id}
Type: {Type}
Name: {Name}
Price: {Price}
Shape: {Shape}";
        }
    }
}
