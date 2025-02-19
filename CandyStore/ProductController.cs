using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyStore
{
    internal class ProductController
    {
        //return a list of type List<Product> from the stored file in the docpath as soon as it's added to the 
        internal List<Product> GetProducts()
        {
            //create a new list of type <Product> ....this we will store the products inside this list of products
            var products = new List<Product>();

            //we will add a try/catch block to surround the StreamReader
            try
            {

                //we use the StreamReader here b/c we are reading the data
                //we will pass in the filename from the docPath which we well split by the comma
                using (StreamReader reader = new(Configuration.docPath))
                {
                    reader.ReadLine(); //this is to discard the first line
                    //this line which stores the docPath of the filesystem file is what will be returned when each line is read
                    var line = reader.ReadLine();


                    //while loop
                    while (line != null)
                    {
                        //THIS NEEDS TO BE MODIFIED BECAUSE WE CANNOT IMPLEMENT A PRODUCT OBJECT AS IT IS NOW AN ABSTRACT CLASS

                        //pass inside a comma to split the string each time a comma is found and return back into an array by using the .Split method
                        string[] parts = line.Split(",");

                        //create a new Product that is being created from the text file
                        //pass the id to the Product constructor and Parse it into an integer to the Product constructor
                        var product = new Product(int.Parse(parts[0]));
                        product.Name = parts[1];
                        product.Price = decimal.Parse(parts[2]); //parse into a decimal
                        
                        //add each line thats being read in from the docpath file to the products list
                        products.Add(product);
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
        
        // add an individual product from the user input
        internal void AddProduct(Product product)
        {
            // Call GetProducts method to know how many products we have so serve as our id
            var id = GetProducts().Count;


            try
            {
                // we use a bool of true at the end of the StreamWriter so products added to the file are appended and the file contents are not overwritten from everytime the program starts over
                using (StreamWriter outputFile = new StreamWriter(Configuration.docPath, true))
                {
                    // check if the file is empty with .BaseStream.Length <= 3 ....if the three header names do not exist for the csv file
                    if(outputFile.BaseStream.Length <= 3)
                    {   
                        //If the file is empty
                        //Write a line that contains the six header which are the names of the properties seperated by commas
                        outputFile.WriteLine("Id, Type, Name, Price, CocoaPercentage, Shape");
                    }
                    //pass the id from line 62 into the GetProductForCsv method
                    var csvLine = product.GetProductForCsv(id);
                        outputFile.WriteLine(csvLine);

                    Console.WriteLine("Products saved");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error saving products: " + ex.Message);
                Console.WriteLine(UserInterface.divide);
            }
        } // end AddProduct()

        //to add the products from the DataSeed class using the AddProducts() method
        internal void AddProducts(List<Product> products)
        {
            try
            {
                // open the file from the .docPath
                using (StreamWriter outputFile = new StreamWriter(Configuration.docPath))
                {
                    {   foreach (var product in products)
                        {                            
                            //write to the file from the docPath, each (product: Id, Name, Price)
                            outputFile.WriteLine($"{product.Id}, {product.Name}, {product.Price}");
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
        } //end AddProducts()

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
