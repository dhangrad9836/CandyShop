namespace CandyStore
{
    internal class Product
    {
        //fields
        private string name;


        internal string Name
        {
            get
            {
                return name.ToUpper();
            }

            set
            {
                //check if input is not null or it not empty
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    //alert to user that input must not be empty
                    Console.WriteLine("Invalid name, Must be a non-empty value");
                }
            }
        }

        
    }
}
