namespace ConsoleApp1
{
    // Abstract class
    public abstract class Product
    {
        // Instance variables
        private string name;
        private double price;

        // Constructor
        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        // Instance methods
        public string GetName()
        {
            return name;
        }

        public double GetPrice()
        {
            return price;
        }

        // Abstract method
        public abstract double CalculateTax();
    }

    // Derived class
    public class Book : Product
    {
        // Constructor
        public Book(string name, double price) : base(name, price)
        {
        }

        // Implementation of abstract method
        public override double CalculateTax()
        {
            return GetPrice() * 0.1;
        }
    }

    // Derived class
    public class Electronics : Product
    {
        // Constructor
        public Electronics(string name, double price) : base(name, price)
        {
        }

        // Implementation of abstract method
        public override double CalculateTax()
        {
            return GetPrice() * 0.2;
        }
    }

    // Interface
    public interface IDiscountable
    {
        double ApplyDiscount(double discountPercentage);
    }

    // Derived class
    public class ShoppingCart : IDiscountable
    {
        // Instance variable
        private List<Product> products;

        // Constructor
        public ShoppingCart()
        {
            products = new List<Product>();
        }

        // Instance method
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        // Implementation of interface method
        public double ApplyDiscount(double discountPercentage)
        {
            double totalDiscount = 0;
            foreach (Product product in products)
            {
                double discount = product.GetPrice() * (discountPercentage / 100);
                totalDiscount += discount;
            }
            return totalDiscount;
        }

        // Instance method
        public double GetTotalPrice()
        {
            double totalPrice = 0;
            foreach (Product product in products)
            {
                totalPrice += product.GetPrice();
            }
            return totalPrice;
        }

        // Instance method
        public double GetTotalPriceAfterTax()
        {
            double totalTax = 0;
            foreach (Product product in products)
            {
                totalTax += product.CalculateTax();
            }
            return GetTotalPrice() + totalTax;
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Instantiating objects of derived classes
            Book book = new Book("The Alchemist", 10.99);
            Electronics electronics = new Electronics("Smartphone", 399.99);

            // Instantiating object of derived class
            ShoppingCart cart = new ShoppingCart();

            // Adding products to shopping cart
            cart.AddProduct(book);
            cart.AddProduct(electronics);

            // Calculating total price and total price after tax
            double totalPrice = cart.GetTotalPrice();
            double totalPriceAfterTax = cart.GetTotalPriceAfterTax();

            // Applying discount
            double discountPercentage = 10;
            double totalDiscount = cart.ApplyDiscount(discountPercentage);
            double discountedPrice = totalPriceAfterTax - totalDiscount;

            // Printing results
            Console.WriteLine($"Total price: {totalPrice:C}");
            Console.WriteLine($"Total price after tax: {totalPriceAfterTax:C}");
            Console.WriteLine($"Discounted price ({discountPercentage}% off): {discountedPrice:C}");
        }
    }
}