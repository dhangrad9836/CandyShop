namespace CandyStore;

internal class DataSeed
{

    //seed data will be processed to alist
    string[] candyNames = { "Rainbow Lollipop", "Cotton Candy Clouds", "Choco-Caramel", "Gummy Bear Bonanza", "Minty Chocolate Truffles", "Jellybean Jamboree", "Fruity Taffy Twists", "Sour Patch Surprise", "Crispy Peanut Butter Cups", "Rocky Candy Crystals" };

    public void SeedData()
    {
        ////create a list of type <Product>()
        //var products = new List<Product>
        //{
        //    //note remember that the Product has three fields: Id, Name, Price
        //    //so here we have the product id as Product(1), the name is added from the candyNames array above by candyNames[0] ...accessess each individual element
        //    //and price is manually added here Price = 10m

        //    //new Product(1) { Name = candyNames[0], Price = 10m},
        //    //new Product(2) { Name = candyNames[1], Price = 10m},
        //    //new Product(3) { Name = candyNames[2], Price = 10m},
        //    //new Product(4) { Name = candyNames[3], Price = 10m},
        //    //new Product(5) { Name = candyNames[4], Price = 10m},
        //    //new Product(6) { Name = candyNames[5], Price = 10m},
        //    //new Product(7) { Name = candyNames[6], Price = 10m},
        //    //new Product(8) { Name = candyNames[7], Price = 10m},
        //    //new Product(9) { Name = candyNames[8], Price = 10m},
        //    //new Product(10) { Name = candyNames[9], Price = 10m},
        //};

        ////instantiate a new ProductController() object so we can add the Product from above to the controller
        //var productController = new ProductController();

        ////add the products from the List<Product>() above
        //productController.AddProducts(products);



    } // end SeedData()

} // end DataSeed
