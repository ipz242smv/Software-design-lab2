namespace Task2
{
    public interface ILaptop
    {
        void DisplaySpecs();
    }

    public interface INetbook
    {
        void DisplaySpecs();
    }

    public interface IEBook
    {
        void DisplaySpecs();
    }

    public interface ISmartphone
    {
        void DisplaySpecs();
    }

    // IProne
    public class IProneLaptop : ILaptop
    {
        public void DisplaySpecs() => Console.WriteLine("IProne Laptop: 16GB RAM, 512GB SSD, M2 чип");
    }

    public class IProneNetbook : INetbook
    {
        public void DisplaySpecs() => Console.WriteLine("IProne Netbook: 8GB RAM, 256GB SSD, 12 дюймів");
    }

    public class IProneEBook : IEBook
    {
        public void DisplaySpecs() => Console.WriteLine("IProne EBook: 6-дюймовий e-ink дисплей, 16GB");
    }

    public class IProneSmartphone : ISmartphone
    {
        public void DisplaySpecs() => Console.WriteLine("IProne Smartphone: 6.1 дюймів, 128GB, потрійна камера");
    }

    // Kiaomi
    public class KiaomiLaptop : ILaptop
    {
        public void DisplaySpecs() => Console.WriteLine("Kiaomi Laptop: 32GB RAM, 1TB SSD, Ryzen 7");
    }

    public class KiaomiNetbook : INetbook
    {
        public void DisplaySpecs() => Console.WriteLine("Kiaomi Netbook: 8GB RAM, 128GB SSD, 11.6 дюймів");
    }

    public class KiaomiEBook : IEBook
    {
        public void DisplaySpecs() => Console.WriteLine("Kiaomi EBook: 7.8 дюймів, підсвітка, 32GB");
    }

    public class KiaomiSmartphone : ISmartphone
    {
        public void DisplaySpecs() => Console.WriteLine("Kiaomi Smartphone: 6.7 дюймів, 256GB, 108MP камера");
    }

    // Balaxy
    public class BalaxyLaptop : ILaptop
    {
        public void DisplaySpecs() => Console.WriteLine("Balaxy Laptop: 16GB RAM, 512GB SSD, Intel i7");
    }

    public class BalaxyNetbook : INetbook
    {
        public void DisplaySpecs() => Console.WriteLine("Balaxy Netbook: 4GB RAM, 64GB eMMC, 10.1 дюймів");
    }

    public class BalaxyEBook : IEBook
    {
        public void DisplaySpecs() => Console.WriteLine("Balaxy EBook: 6 дюймів, 8GB, простий e-ink");
    }

    public class BalaxySmartphone : ISmartphone
    {
        public void DisplaySpecs() => Console.WriteLine("Balaxy Smartphone: 6.5 дюймів, 64GB, подвійна камера");
    }

    public interface ITechFactory
    {
        ILaptop CreateLaptop();
        INetbook CreateNetbook();
        IEBook CreateEBook();
        ISmartphone CreateSmartphone();
    }

    public class IProneFactory : ITechFactory
    {
        public ILaptop CreateLaptop() => new IProneLaptop();
        public INetbook CreateNetbook() => new IProneNetbook();
        public IEBook CreateEBook() => new IProneEBook();
        public ISmartphone CreateSmartphone() => new IProneSmartphone();
    }

    public class KiaomiFactory : ITechFactory
    {
        public ILaptop CreateLaptop() => new KiaomiLaptop();
        public INetbook CreateNetbook() => new KiaomiNetbook();
        public IEBook CreateEBook() => new KiaomiEBook();
        public ISmartphone CreateSmartphone() => new KiaomiSmartphone();
    }

    public class BalaxyFactory : ITechFactory
    {
        public ILaptop CreateLaptop() => new BalaxyLaptop();
        public INetbook CreateNetbook() => new BalaxyNetbook();
        public IEBook CreateEBook() => new BalaxyEBook();
        public ISmartphone CreateSmartphone() => new BalaxySmartphone();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Завдання 2");

            ITechFactory factory = new IProneFactory();
            factory.CreateLaptop().DisplaySpecs();
            factory.CreateNetbook().DisplaySpecs();
            factory.CreateEBook().DisplaySpecs();
            factory.CreateSmartphone().DisplaySpecs();

            factory = new KiaomiFactory();
            Console.WriteLine("\n");
            factory.CreateLaptop().DisplaySpecs();
            factory.CreateNetbook().DisplaySpecs();
            factory.CreateEBook().DisplaySpecs();
            factory.CreateSmartphone().DisplaySpecs();

            factory = new BalaxyFactory();
            Console.WriteLine("\n");
            factory.CreateLaptop().DisplaySpecs();
            factory.CreateNetbook().DisplaySpecs();
            factory.CreateEBook().DisplaySpecs();
            factory.CreateSmartphone().DisplaySpecs();

            Console.ReadLine();
        }
    }
}