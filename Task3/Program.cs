namespace Task3
{
    public sealed class Authenticator
    {
        private static readonly Lazy<Authenticator> _instance =
            new Lazy<Authenticator>(() => new Authenticator(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        private Authenticator()
        {
            Console.WriteLine("Створено єдиний екземпляр Authenticator");
            AuthenticatedUser = "Гість";
        }

        public static Authenticator Instance => _instance.Value;

        public string AuthenticatedUser { get; private set; }

        public void Login(string username)
        {
            AuthenticatedUser = username;
            Console.WriteLine($"Користувач '{username}' увійшов у систему");
        }

        public void Logout()
        {
            Console.WriteLine($"Користувач '{AuthenticatedUser}' вийшов");
            AuthenticatedUser = "Гість";
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Поточний користувач: {AuthenticatedUser}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Завдання 3");

            Authenticator auth1 = Authenticator.Instance;
            Authenticator auth2 = Authenticator.Instance;

            Console.WriteLine($"auth1 == auth2: {ReferenceEquals(auth1, auth2)}");

            auth1.Login("Олександр");
            auth2.ShowStatus();
            auth1.Logout();

            Console.ReadLine();
        }
    }
}