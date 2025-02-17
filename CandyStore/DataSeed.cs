namespace CandyStore;

internal class DataSeed
{

    //seed data will be processed to alist
    string[] candyNames = { "Rainbow Lollipop", "Cotton Candy Clouds", "Choco-Caramel", "Gummy Bear Bonanza", "Minty Chocolate Truffles", "Jellybean Jamboree", "Fruity Taffy Twists", "Sour Patch Surprise", "Crispy Peanut Butter Cups", "Rocky Candy Crystals" };

    public void SeedData()
    {
        // instantiantiate from the ProductController class
        var productsController = new ProductController();

        //transfrom the candyNames list to a list
        productsController.AddProducts(candyNames.ToList());
        //for (int i = 0; i < candyNames.Length; i++)
        //{
        //    // dictionary products...we are .Add (index and candyName)
        //    products.Add(i, candyNames[i]);
        //}
    }

} // end DataSeed
