namespace CandyStore
{
    internal class Product
    {
        
        public int Id { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        //constructor
        public Product(int id)
        {
            Id = id;
        }
        

    }//end product class
}
