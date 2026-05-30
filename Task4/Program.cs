namespace Task4_Prototype
{
    public class Virus : ICloneable
    {
        public double Weight { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public List<Virus> Children { get; private set; }

        public Virus(double weight, int age, string name, string species)
        {
            Weight = weight;
            Age = age;
            Name = name;
            Species = species;
            Children = new List<Virus>();
        }

        private Virus(Virus original)
        {
            Weight = original.Weight;
            Age = original.Age;
            Name = original.Name;
            Species = original.Species;
            Children = original.Children.Select(child => (Virus)child.Clone()).ToList();
        }

        public void AddChild(Virus child)
        {
            Children.Add(child);
        }

        public object Clone()
        {
            return new Virus(this);
        }

        public void ShowFamily(int level = 0)
        {
            string indent = new string(' ', level * 2);
            Console.WriteLine($"{indent}Вірус: {Name} (Вид: {Species}, Вага: {Weight}, Вік: {Age})");
            foreach (var child in Children)
            {
                child.ShowFamily(level + 1);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Завдання 4:");

            Virus grandParent = new Virus(150.5, 10, "AlphaVirus", "Coronaviridae");
            Virus parent1 = new Virus(80.3, 5, "BetaVirus", "Coronaviridae");
            Virus parent2 = new Virus(90.1, 4, "GammaVirus", "Coronaviridae");
            Virus child1 = new Virus(30.2, 1, "DeltaChild", "Coronaviridae");
            Virus child2 = new Virus(28.7, 1, "EpsilonChild", "Coronaviridae");
            Virus child3 = new Virus(35.0, 1, "ZetaChild", "Coronaviridae");

            grandParent.AddChild(parent1);
            grandParent.AddChild(parent2);
            parent1.AddChild(child1);
            parent1.AddChild(child2);
            parent2.AddChild(child3);

            Console.WriteLine("Оригінальне сімейство вірусів:");
            grandParent.ShowFamily();

            Virus clonedGrandParent = (Virus)grandParent.Clone();
            clonedGrandParent.Name = "AlphaVirus_Clone";

            Console.WriteLine("\nКлоноване сімейство вірусів (всі діти також скопійовані):");
            clonedGrandParent.ShowFamily();

            Console.WriteLine("\nПеревірка: оригінал не змінився після зміни клону");
            grandParent.ShowFamily();

            Console.ReadLine();
        }
    }
}