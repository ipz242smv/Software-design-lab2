using System;
using System.Collections.Generic;

namespace Task5_Builder
{
    public class Character
    {
        public double Height { get; set; }
        public string BodyType { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Clothing { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();
        public List<string> Deeds { get; set; } = new List<string>();

        public void ShowInfo()
        {
            Console.WriteLine($"Зріст: {Height} см");
            Console.WriteLine($"Статура: {BodyType}");
            Console.WriteLine($"Колір волосся: {HairColor}");
            Console.WriteLine($"Колір очей: {EyeColor}");
            Console.WriteLine($"Одяг: {Clothing}");
            Console.WriteLine($"Інвентар: {string.Join(", ", Inventory)}");
            Console.WriteLine($"Справи: {string.Join(", ", Deeds)}");
        }
    }

    public interface ICharacterBuilder
    {
        ICharacterBuilder SetHeight(double height);
        ICharacterBuilder SetBodyType(string bodyType);
        ICharacterBuilder SetHairColor(string color);
        ICharacterBuilder SetEyeColor(string color);
        ICharacterBuilder SetClothing(string clothing);
        ICharacterBuilder AddInventoryItem(string item);
        ICharacterBuilder AddDeed(string deed);
        Character Build();
    }

    // Будівельник для Героя
    public class HeroBuilder : ICharacterBuilder
    {
        private Character _character = new Character();

        public ICharacterBuilder SetHeight(double height)
        {
            _character.Height = height;
            return this;
        }

        public ICharacterBuilder SetBodyType(string bodyType)
        {
            _character.BodyType = bodyType;
            return this;
        }

        public ICharacterBuilder SetHairColor(string color)
        {
            _character.HairColor = color;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string color)
        {
            _character.EyeColor = color;
            return this;
        }

        public ICharacterBuilder SetClothing(string clothing)
        {
            _character.Clothing = clothing;
            return this;
        }

        public ICharacterBuilder AddInventoryItem(string item)
        {
            _character.Inventory.Add(item);
            return this;
        }

        public ICharacterBuilder AddDeed(string deed)
        {
            _character.Deeds.Add("Добра справа: " + deed);
            return this;
        }

        public Character Build()
        {
            return _character;
        }
    }

    // Будівельник для Ворога
    public class EnemyBuilder : ICharacterBuilder
    {
        private Character _character = new Character();

        public ICharacterBuilder SetHeight(double height)
        {
            _character.Height = height;
            return this;
        }

        public ICharacterBuilder SetBodyType(string bodyType)
        {
            _character.BodyType = bodyType;
            return this;
        }

        public ICharacterBuilder SetHairColor(string color)
        {
            _character.HairColor = color;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string color)
        {
            _character.EyeColor = color;
            return this;
        }

        public ICharacterBuilder SetClothing(string clothing)
        {
            _character.Clothing = clothing;
            return this;
        }

        public ICharacterBuilder AddInventoryItem(string item)
        {
            _character.Inventory.Add(item);
            return this;
        }

        public ICharacterBuilder AddDeed(string deed)
        {
            _character.Deeds.Add("Зла справа: " + deed);
            return this;
        }

        public Character Build()
        {
            return _character;
        }
    }

    // Директор
    public class CharacterDirector
    {
        public Character ConstructHero(ICharacterBuilder builder)
        {
            return builder
                .SetHeight(185)
                .SetBodyType("Атлетична")
                .SetHairColor("Темно-русяве")
                .SetEyeColor("Карі")
                .SetClothing("Лицарські обладунки")
                .AddInventoryItem("Меч Справедливості")
                .AddInventoryItem("Щит Захисту")
                .AddDeed("Врятував село від дракона")
                .AddDeed("Допоміг мандрівникові")
                .Build();
        }

        public Character ConstructEnemy(ICharacterBuilder builder)
        {
            return builder
                .SetHeight(195)
                .SetBodyType("Могутня")
                .SetHairColor("Чорне")
                .SetEyeColor("Червоні")
                .SetClothing("Темна мантія")
                .AddInventoryItem("Отруєний кинджал")
                .AddInventoryItem("Книга темних заклинань")
                .AddDeed("Спалив місто")
                .AddDeed("Викрав королівну")
                .Build();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Завдання 5:");

            CharacterDirector director = new CharacterDirector();

            ICharacterBuilder heroBuilder = new HeroBuilder();
            Character hero = director.ConstructHero(heroBuilder);

            ICharacterBuilder enemyBuilder = new EnemyBuilder();
            Character enemy = director.ConstructEnemy(enemyBuilder);

            Console.WriteLine("Герой мрії");
            hero.ShowInfo();

            Console.WriteLine("\nНайзапекліший ворог");
            enemy.ShowInfo();

            Console.WriteLine("\nАльтернативне створення героя без директора");
            Character customHero = new HeroBuilder()
                .SetHeight(170)
                .SetBodyType("Струнка")
                .SetHairColor("Руде")
                .SetEyeColor("Зелені")
                .SetClothing("Магічна роба")
                .AddInventoryItem("Чарівна паличка")
                .AddDeed("Вилікувала хворого")
                .Build();
            customHero.ShowInfo();

            Console.ReadLine();
        }
    }
}