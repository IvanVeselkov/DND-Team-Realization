using DnD.Backpack;
using System;

namespace DnD
{
    public class Program
    {

        static void Main(string[] args)
        {
            DnDMethods dnDMethods = new DnDMethods();
            List<Inventory> items = new List<Inventory>
            {
                new Inventory("Секира", "Страшная ржавая секира", 6, true),
                new Inventory("Меч","Блестящий меч", 5, true ),
                new Inventory("Монета", "Золотая монета", 1, false),
                new Inventory("Куртка", "Куртка замшевая", 4, false),
                new Inventory("Магнитофон", "Магнитофон отечественный", 2, false)
            };

            while (true)
            {
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Добавить персонажа");
                Console.WriteLine("2. Получить персонажа по id");
                Console.WriteLine("3. Подготовить лист персонажа в PDF формате");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите Id персонажа: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите имя персонажа: ");
                        string name = Console.ReadLine();

                        string[] races = { "Человек", "Эльф", "Гном", "Хоббит", "Дварф", "Орк", "Гоблин", "Удмурт", "Татарин" };
                        Console.WriteLine("Выберите расу персонажа:");
                        for (int i = 0; i < races.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {races[i]}");
                        }
                        int raceChoice;
                        do
                        {
                            Console.Write("Введите номер расы: ");
                            raceChoice = Convert.ToInt32(Console.ReadLine());
                        } while (raceChoice < 1 || raceChoice > races.Length);
                        string race = races[raceChoice - 1];

                        Console.Write("Введите значение силы: ");
                        int strength = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение ловкости: ");
                        int agility = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение телосложения: ");
                        int physique = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение интеллекта: ");
                        int intelligence = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение мудрости: ");
                        int wisdom = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение харизмы: ");
                        int charisma = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение хитов: ");
                        int hitPoints = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение класса брони: ");
                        int armorClass = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение скорости: ");
                        int speed = Convert.ToInt32(Console.ReadLine());

                        dnDMethods.AddCharacters(new CharacterSheet(id, name, race, strength, agility, physique, intelligence, wisdom, charisma, hitPoints, armorClass,speed));
                        Console.WriteLine($"Персонаж {name} добавлен");

                        break;

                    case 2:
                        Console.WriteLine("Введите id персонажа");
                        int findId = Convert.ToInt32(Console.ReadLine());
                        dnDMethods.FindCharacters(findId);
                        break; 
                }

               
            }

        }
    }
}



