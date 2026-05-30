namespace Task1
{
    public abstract class Subscription
    {
        public abstract decimal MonthlyFee { get; }
        public abstract int MinimumPeriodMonths { get; }
        public abstract List<string> Channels { get; }
        public abstract List<string> Features { get; }

        public void ShowDetails()
        {
            Console.WriteLine($"Тип підписки: {GetType().Name}");
            Console.WriteLine($"Щомісячна плата: {MonthlyFee} грн");
            Console.WriteLine($"Мінімальний період: {MinimumPeriodMonths} міс.");
            Console.WriteLine($"Канали: {string.Join(", ", Channels)}");
            Console.WriteLine($"Можливості: {string.Join(", ", Features)}");
            Console.WriteLine();
        }
    }

    public class DomesticSubscription : Subscription
    {
        public override decimal MonthlyFee => 150;
        public override int MinimumPeriodMonths => 1;
        public override List<string> Channels => new List<string> { "1+1", "2+2", "ICTV", "СТБ", "Новини 24" };
        public override List<string> Features => new List<string> { "Перегляд до 3 пристроїв", "Українська підтримка" };
    }

    public class EducationalSubscription : Subscription
    {
        public override decimal MonthlyFee => 99;
        public override int MinimumPeriodMonths => 6;
        public override List<string> Channels => new List<string> { "Наука", "Discovery", "National Geographic", "Освіта UA" };
        public override List<string> Features => new List<string> { "Доступ до архіву лекцій", "Знижка для студентів", "Без реклами" };
    }

    public class PremiumSubscription : Subscription
    {
        public override decimal MonthlyFee => 499;
        public override int MinimumPeriodMonths => 1;
        public override List<string> Channels => new List<string> { "Всі канали", "Спорт 1-10", "Кіно", "Premier", "HBO" };
        public override List<string> Features => new List<string> { "4K якість", "Без реклами", "Сімейний доступ (до 5 пристроїв)", "Завантаження контенту" };
    }

    public abstract class SubscriptionCreator
    {
        public abstract Subscription CreateSubscription();
    }

    public class WebSite : SubscriptionCreator
    {
        public override Subscription CreateSubscription()
        {
            Console.WriteLine("Оформлення підписки через веб-сайт...");
            return new PremiumSubscription();
        }
    }

    public class MobileApp : SubscriptionCreator
    {
        public override Subscription CreateSubscription()
        {
            Console.WriteLine("Оформлення підписки через мобільний додаток...");
            return new EducationalSubscription();
        }
    }

    public class ManagerCall : SubscriptionCreator
    {
        public override Subscription CreateSubscription()
        {
            Console.WriteLine("Оформлення підписки через менеджера...");
            return new DomesticSubscription();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Завдання 1");

            SubscriptionCreator creator;

            creator = new WebSite();
            Subscription sub1 = creator.CreateSubscription();
            sub1.ShowDetails();

            creator = new MobileApp();
            Subscription sub2 = creator.CreateSubscription();
            sub2.ShowDetails();

            creator = new ManagerCall();
            Subscription sub3 = creator.CreateSubscription();
            sub3.ShowDetails();

            Console.ReadLine();
        }
    }
}