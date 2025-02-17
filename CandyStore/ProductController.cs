using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyStore
{
    internal class ProductController
    {
        //return type of List
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
                        
                        //add each line thats being read in from the docpath file to the products list
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
            try
            {

                using (StreamWriter outputFile = new StreamWriter(Configuration.docPath))
                {
                    //foreach (KeyValuePair<int, string> product in products)
                    {
                        // write to the text file
                        // we changed from product.key to product.Trim() to remove any leading spaces and added a second argument of true which will prevent the file from being overrided and it will just append to the file, and each time we add a product it moves it to the bottom of file
                        outputFile.WriteLine(product.Trim(), true);
                    }
                    Console.WriteLine("Products saved");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error saving products: " + ex.Message);
                Console.WriteLine(UserInterface.divide);
            }
        }

        //to add products from the seed data
        internal void AddProducts(List<string> products)
        {
            //Console.WriteLine("Product name:");
            //var product = Console.ReadLine();
            try
            {

                using (StreamWriter outputFile = new StreamWriter(Configuration.docPath))
                {
                    //foreach (KeyValuePair<int, string> product in products) ..this was b/f
                    {   foreach (string product in products)
                        {
                            //outputFile.WriteLine($"{product.Key}, {product.Value}");
                            // we changed from product.key to product.Trim() to remove any leading spaces 
                            //write to the file
                            outputFile.WriteLine(product.Trim(), true);
                        }
                        
                    }
                    Console.WriteLine("Products saved");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error saving products: " + ex.Message);
                Console.WriteLine(UserInterface.divide);
            }
        }

        internal void DeleteProduct(string message)
        {
            Console.WriteLine(message);
        }

        internal void UpdateProduct(string message)
        {
            Console.WriteLine(message);
        }

       

      

    }// end Class ProductController
}
