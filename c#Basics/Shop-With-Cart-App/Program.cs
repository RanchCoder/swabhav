using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_With_Cart_App.model;
namespace Shop_With_Cart_App
{
    class Program
    {
        public static List<Guid> guidsAllocated = new List<Guid>();

        
        static void Main(string[] args)
        {
            
            Product product_Parle_Biscuit = new Product(GenerateRandomId(),"Parle Biscuit",10,0.2);
            Product product_Lays_Chip = new Product(GenerateRandomId(),"Lays Chips",10,0.05);
            Product product_Pepsi_SoftDrink = new Product(GenerateRandomId(),"Pepsi",25,0.2);
            Product product_Denim_Shirt = new Product(GenerateRandomId(), "Diesel Shirts", 1000, 0.5);
            Product product_Cricket_Bat = new Product(GenerateRandomId(), "Cricket Bat", 650, 0.2);
            Product product_Instant_Noodles = new Product(GenerateRandomId(), "Maggie Instant Noodles", 25, 0.1);

            List<Product> productList = new List<Product>();
            productList.Add(product_Parle_Biscuit);
            productList.Add(product_Lays_Chip);
            productList.Add(product_Pepsi_SoftDrink);
            productList.Add(product_Denim_Shirt);
            productList.Add(product_Cricket_Bat);
            productList.Add(product_Instant_Noodles);

            List<LineItem> finalProductList = new List<LineItem>();
            Customer customer1 = new Customer(GenerateRandomId(), "Vishal", "Mumbai");
            finalProductList = PerformTransaction(ref customer1,ref productList,ref finalProductList);
            if(finalProductList.Count > 0)
            {
                Console.Write($"\nProceed and buy Items in Cart.. \nPress y / yes to proceed\n Press q / quit to quit...");
                string userWishToProceedInput = Console.ReadLine();
                switch (userWishToProceedInput.ToLower())
                {
                    case "y":
                    case "yes": {
                            Order order = new Order(GenerateRandomId(), DateTime.Now);
                            foreach(LineItem itemInCart in finalProductList)
                            {
                                order.AddItem(itemInCart);
                            }

                            customer1.AddOrder(order);
                            PrintOrderSummary(order);
                        }
                        break;
                }
            }
            Console.ReadLine();
        }


        public static void PrintOrderSummary(Order order)
        {
            Console.WriteLine($"**************** Order Summary ********************");
            foreach(LineItem item in order.ItemsListForOrder)
            {
                Console.WriteLine($"\nProduct Name : {item.Product.NameOfProduct} || Product Quantity : {item.ItemQuantity} || Product price after discount :Rs{item.CalculateItemCost()}/- ");
            }
            Console.WriteLine($"\nFinal Amount : Rs{order.FinalCost()}/-");
        }

        public static int GetQuantityInputFromUser()
        {
            bool isProvidingQuantity = true;
            int result;

            while (isProvidingQuantity)
            {
                Console.Write($"\nEnter quantity : ");
                string inputFromUserForQuantity = Console.ReadLine();
                if (Int32.TryParse(inputFromUserForQuantity,out result))
                {
                    if(result > 0)
                    {
                        isProvidingQuantity = false;
                        return result;
                    }
                    else
                    {
                        isProvidingQuantity = true;
                        Console.WriteLine($"\nPlease enter an integer value for quantity greater than 0");
                    }

                }
                else
                {
                    isProvidingQuantity = true;
                    Console.WriteLine($"\nPlease enter an integer value for quantity");
                }
            }
            return -1;
        }



        public static Guid GenerateRandomId()
        {
            Guid guidToBeAllocated = Guid.NewGuid();
            if (guidsAllocated.Contains(guidToBeAllocated))
            {
                return Guid.NewGuid();
            }
            guidsAllocated.Add(guidToBeAllocated);
            return guidToBeAllocated;
        }

        public static void PrintListOfItems(ref List<Product> listOfProduct,string MessageForHeader)
        {
            Console.WriteLine($"\n\n{MessageForHeader}");
            foreach(Product product in listOfProduct)
            {
                Console.WriteLine($"\nId : {product.IdOfProduct}\nName of Product : {product.NameOfProduct}\nPrice : Rs.{product.PriceOfProduct}/- " +
                    $"\nDiscount : {product.DiscountPercent * 100}%" +
                    $"\nPrice After Discount : Rs.{product.TotalCost()}/-");
            }
        }

        //Display all the similar products based on user key input
        public static List<Product> ShowSimilarProducts(ref string choiceOfUser,ref List<Product> listOfProducts)
        {
            Console.WriteLine($"Products Similar to your choice.... ");
            List<Product> productsAsPerUserChoice = new List<Product>();
            int counter = 1;
            foreach(Product product in listOfProducts)
            {
                if (product.NameOfProduct.ToLower().Contains(choiceOfUser.ToLower()))
                {
                    productsAsPerUserChoice.Add(product);
                    Console.WriteLine($"{counter++}){product.NameOfProduct}");
                }
            }

            return productsAsPerUserChoice;
            

        }

        //Display all the similar products a user can choose from to add to his cart.
        public static void AddFromSimilarItemsToCart(ref List<Product> listOfSimilarProducts,ref List<LineItem> finalProductList)
        {
            int counter = 1;
            Console.WriteLine($"\n\nShowing similar items as per your choice.");
            Console.WriteLine($"\n\nPress Y | y to add item to cart \nPress N | n to not add item to the cart.");
            
            foreach (Product product in listOfSimilarProducts)
            {
                bool isShopping = true;
                string userChoiceToAddToCart = "";
                Console.WriteLine($"\n{counter++}){product.NameOfProduct}");
                while (isShopping)
                {
                    Console.Write($"\nDo you want to add {product.NameOfProduct} to cart : ");
                    userChoiceToAddToCart = Console.ReadLine();
                    switch (userChoiceToAddToCart.ToLower())
                    {                        
                        case "y":                         
                        case "yes": {
                                int QuatityInput = GetQuantityInputFromUser();
                                
                                if(QuatityInput != -1)
                                {
                                    LineItem itemSelected = new LineItem(GenerateRandomId(),QuatityInput,product);
                                    finalProductList.Add(itemSelected);
                                }
                                
                                Console.WriteLine($"Item Added to cart");
                            } 
                            break;                        
                        case "n": Console.WriteLine($"Item Added to cart"); break;                        
                        case "no": Console.WriteLine($"Item Added to cart"); break;
                        default: Console.WriteLine($"Not a valid choice"); break;
                    }
                    
                    isShopping = false;
                }
            }
        }

        public static void PrintCartItems(ref List<LineItem> itemsSelected)
        {
            foreach(LineItem item in itemsSelected)
            {
                Console.WriteLine($"\n{item.Product.NameOfProduct}\nQuantity : {item.ItemQuantity} \nItem total : Rs.{item.CalculateItemCost()}/-");
            }
        }

        public static List<LineItem> PerformTransaction(ref Customer customer,ref List<Product> listOfProduct,ref List<LineItem> finalProductList)
        {
            Console.WriteLine($"\n\n+++++++++++++ Welcome to Vertigo's Supermart ++++++++++++");
            Console.WriteLine($"\n----------- ITEM's CATALOGUE ------------");
            PrintListOfItems(ref listOfProduct,"");

            bool keepShopping = true;
            string choiceOfUser = "";
            while (keepShopping)
            {
                Console.Write($"\n\nEnter a keyword or item name you wish to add to your cart : ");
                choiceOfUser = Console.ReadLine();
                List<Product> productsSelected = ShowSimilarProducts(ref choiceOfUser,ref listOfProduct);

                //if no items matched from inventory,then no need to perform further actions or adding to cart
                if(productsSelected.Count > 0)
                {
                    Console.Write($"\nPress Y | y to proceed to cart or Press Q | q to quit : ");
                    string userChoiceForSimilarItems = Console.ReadLine();
                    if (userChoiceForSimilarItems.Equals("Y") | userChoiceForSimilarItems.Equals("y"))
                    {
                        AddFromSimilarItemsToCart(ref productsSelected, ref finalProductList);
                    }
                }
                    

                Console.Write($"\n\nDo you wish to continue :: Press Y | y to proceed to cart or Press Q | q to quit : ");
                string endOrContinueChoice = Console.ReadLine();
                switch (endOrContinueChoice.ToLower())
                {
                    
                    case "q":
                    case "quit": {
                            Console.WriteLine($"\nItems in Cart : {finalProductList.Count()}");
                            PrintCartItems(ref finalProductList);

                            keepShopping = false;
                    }
                    break;

                }
                
               
            }

            return finalProductList;
            

        }

        
    }
}
