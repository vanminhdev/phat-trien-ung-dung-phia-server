namespace ConsoleApp2
{
    // Abstract class
    public abstract class Animal
    {
        // Abstract method
        public abstract void Speak();

        // Instance variable
        private string name;

        // Constructor
        public Animal(string name)
        {
            this.name = name;
        }

        // Instance method
        public void Move()
        {
            Console.WriteLine($"{name} is moving.");
        }

        // Static method
        public static void Sleep()
        {
            Console.WriteLine("All animals are sleeping.");
        }
    }

    // Interface
    public interface ICanFly
    {
        void Fly();
    }

    // Derived class
    public class Bird : Animal, ICanFly
    {
        // Constructor
        public Bird(string name) : base(name)
        {
        }

        // Implementation of abstract method
        public override void Speak()
        {
            Console.WriteLine("Chirp chirp!");
        }

        // Implementation of interface method
        public void Fly()
        {
            Console.WriteLine($"{this.GetType().Name} is flying.");
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Instantiating object of derived class
            Bird bird = new Bird("Tweety");

            // Calling instance method
            bird.Move();

            // Calling abstract method
            bird.Speak();

            // Calling interface method
            bird.Fly();

            // Calling static method
            Animal.Sleep();
        }
    }

}