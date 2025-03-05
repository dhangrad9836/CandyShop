using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CandyStore.Enums;

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

                        //we can no longer implement a Product object as its abstract so we will identify from the csv the id and match wether its a chocolatebar or lolipop
                        //we are comparing the parts[1] which is the ProductType to the == (int)ProductType.ChocolatBar...so we need to parse the string element and cast the ProductType (int)ProductType.ChcolateBar to compare both sides
                        if (int.Parse(parts[1]) == (int)ProductType.ChcolateBar)
                        {
                            var product = new ChocolateBar(int.Parse(parts[0]));
                            product.Name = parts[2];
                            product.Price = decimal.Parse(parts[3]);
                            product.CocoaPercentage = int.Parse(parts[4]); // this is element 4 which is where cocoapercentage is in the csv file
                            products.Add(product); //add the product back to the products list
                        }
                        else
                        {
                            var product = new Lolipop(int.Parse(parts[0]));
                            product.Name = parts[2];
                            product.Price = decimal.Parse(parts[3]);
                            product.Shape = parts[5]; //this is elemet 5 which is where shape is in the csv file
                            products.Add(product); //add the product back to the products list
                        }
                        
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
            var id = GetProducts().Count + 1;   //we added +1 to the count so our index will not be duplicated whenever we add a new product


            try
            {
                // we use a bool of true at the end of the StreamWriter so products added to the file are appended and the file contents are not overwritten from everytime the program starts over
                using (StreamWriter outputFile = new StreamWriter(Configuration.docPath, true))
                {
                    // check if the file is empty with .BaseStream.Length <= 3 ....if the three header names do not exist for the csv file
                    if(outputFile.BaseStream.Length <= 6)
                    {   
                        //If the file is empty
                        //Write a line that contains the six header which are the names of the properties seperated by commas
                        outputFile.WriteLine("Id, Type, Name, Price, CocoaPercentage, Shape");
                    }
                    //pass the id from line 62 into the GetProductForCsv method
                    var csvLine = product.GetProductForCsv(id);
                        outputFile.WriteLine(csvLine);
                    
                }
                Console.WriteLine("Products saved");
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
                    //Everytime data is seeded we will add a new header
                    //Write a line that contains the six header which are the names of the properties seperated by commas
                    outputFile.WriteLine("Id, Type, Name, Price, CocoaPercentage, Shape");
                    {   foreach (var product in products)
                        {
                            //and new line will be written to the csv file
                            //pass the id from line 62 into the GetProductForCsv 
                            var csvLine = product.GetProductForCsv(product.Id);
                            outputFile.WriteLine(csvLine);  //the details are printed once we pass in the csvLine
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

        //pass in the product object with all the properties to be deleted
        internal void DeleteProduct(Product product)
        {
            //get all products
            var products = GetProducts();
            //update or store all the products in updatedProducts variable as long as it does not equal the id of the product being passed in
            var updatedProducts = products.Where(p => p.Id != product.Id).ToList();

            //add back the updatedProducts list
            AddProducts(updatedProducts);
        }

        //now we take in a Product object with all the properties that we updated
        internal void UpdateProduct(Product product)
        {
            //get all products
            var products = GetProducts();

            var updatedProducts = products.Where(p => p.Id != product.Id).ToList(); //only select the product id that were not updated
            updatedProducts.Add(product);   //add all the products back to the list

            AddProducts(updatedProducts);
        }

       

      

    }// end Class ProductController
}
