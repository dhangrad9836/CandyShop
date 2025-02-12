using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyStore
{
    internal class ProductController
    {
        internal List<string> GetProducts()
        {
            var products = new List<string>();

            //we will add a try/catch block to surround the StreamReader
            try
            {

                //we use the StreamReader here b/c we are reading the data
                //we will pass in the filename from the docPath which we well split by the comma
                using (StreamReader reader = new(Configuration.docPath))
                {
                    //this line which stores the docPath of the filesystem file is what will be returned when each line is read
                    var line = reader.ReadLine();


                    //while loop
                    while (line != null)
                    {
                        //pass inside a comma to split the string each time a comma is found and return back into an array by using the .Split method
                        string[] parts = line.Split(",");

                        //we need to parse the first element which is our index (or key) to an integer b/c the data coming from the docPath is a string
                        products.Add(line);
                        line = reader.ReadLine();
                    }
                }
            } //end try block
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(UserInterface.divide);
            }

            return products;

        } // end GetProducts()
        

        internal void AddProduct()
        {
            Console.WriteLine("Product name:");
            var product = Console.ReadLine();
            //add index so we can access the index of each product
            var index = products.Count(); //So when a product is added we will take the count and added it as its index number
                                          //added .Trim() so leading spaces are not added to file
            products.Add(index, product.Trim());
        }

        internal void DeleteProduct(string message)
        {
            Console.WriteLine(message);
        }

        internal void UpdateProduct(string message)
        {
            Console.WriteLine(message);
        }

        internal void SaveProducts()
        {
            try
            {

                using (StreamWriter outputFile = new StreamWriter(Configuration.docPath))
                {
                    foreach (KeyValuePair<int, string> product in products)
                    {
                        outputFile.WriteLine($"{product.Key}, {product.Value}");
                    }
                    Console.WriteLine("Products saved");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error saving products: " + ex.Message);
                Console.WriteLine(divide);
            }
        }

        internal void LoadData()
        {
            //we will add a try/catch block to surround the StreamReader
            try
            {

                //we use the StreamReader here b/c we are reading the data
                //we will pass in the filename from the docPath which we well split by the comma
                using (StreamReader reader = new(Configuration.docPath))
                {
                    //this line which stores the docPath of the filesystem file is what will be returned when each line is read
                    var line = reader.ReadLine();


                    //while loop
                    while (line != null)
                    {
                        //pass inside a comma to split the string each time a comma is found and return back into an array by using the .Split method
                        string[] parts = line.Split(",");

                        //we need to parse the first element which is our index (or key) to an integer b/c the data coming from the docPath is a string
                        products.Add(int.Parse(parts[0]), parts[1]);
                        line = reader.ReadLine();
                    }
                }
            } //end try block
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(divide);
            }
        } // end LoadData()

    }// end Class ProductController
}
