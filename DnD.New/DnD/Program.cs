using DnD.Backpack;

namespace DnD
{
    public class Program
    {
        static void Main(string[] args)
        {
            DnDMethods dnDMethods = new DnDMethods();
            List<Inventory> items = new List<Inventory>
            {
                new Inventory("Секира", "Страшная ржавая секира", 10, true),
                new Inventory("Меч","Блестящий меч", 15, true ),
                new Inventory("Монета", "Золотая монета", 1, false),
                new Inventory("Куртка", "Куртка замшевая", 4, false),
                new Inventory("Магнитофон", "Магнитофон отечественный", 2, false),
                new Inventory("Кинокамера", "Кинокамера заграничная", 3, false)
            };

            while (true)
            {
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Добавить персонажа");
                Console.WriteLine("2. Получить персонажа по id");
                Console.WriteLine("3. Добавить инвентарь персонажу");
                Console.WriteLine("4. Показать инвентарь персонажа");
                Console.WriteLine("5. Удалить предмет у персонажа");
                Console.WriteLine("6. Подготовить лист персонажа в PDF формате");

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


                        dnDMethods.AddCharacters(new CharacterSheet(id, name, race, strength, agility, physique,
                            intelligence, wisdom, charisma, hitPoints, armorClass, speed));

                        Console.WriteLine($"Персонаж {name} добавлен");

                        break;

                    case 2:
                        Console.WriteLine("Введите id персонажа");
                        int findId = Convert.ToInt32(Console.ReadLine());
                        dnDMethods.FindCharacters(findId);
                        break;


                    case 3:
                        Console.Write("Введите id персонажа для добавления предметов: ");
                        int characterId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Выберите предметы для персонажа(Общий вес рюкзака не может превышать 20. Оружий максимум 2:");
                        for (int i = 0; i < items.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {items[i].ItemName} - {items[i].Description}, {items[i].Weight}");
                        }


                        Console.WriteLine("Введите номера предметов через запятую (например, 1,3):");
                        string[] itemChoices = Console.ReadLine().Split(',');
                        var selectedItems = new List<Inventory>();

                        foreach (string itemChoice in itemChoices)
                        {
                            if (int.TryParse(itemChoice, out int itemIndex))
                            {
                                itemIndex--;
                                if (itemIndex >= 0 && itemIndex < items.Count)
                                {
                                    dnDMethods.AddItem(characterId, items[itemIndex]);

                                }
                                else
                                {
                                    Console.WriteLine($"Предмет с номером {itemIndex + 1} не существует.");
                                }
                            }
                        }


                        break;



                    case 4:
                        Console.WriteLine("Введите id персонажа для отображения инвентаря:");
                        int displayId = Convert.ToInt32(Console.ReadLine());

                        var characterToDisplay = dnDMethods.FindCharacterById(displayId);
                        if (characterToDisplay != null)
                        {
                            dnDMethods.DisplayItems(characterToDisplay); // Выводим инвентарь персонажа
                        }
                        else
                        {
                            Console.WriteLine("Персонаж с таким id не найден.");
                        }
                        break;




                    case 5:
                        Console.WriteLine("Введите id персонажа:");
                        int idToRemoveItem = Convert.ToInt32(Console.ReadLine());
                        var characterToRemoveItem = dnDMethods.FindCharacterById(idToRemoveItem);

                        if (characterToRemoveItem != null)
                        {
                            Console.WriteLine("Выберите предмет для удаления:");
                            for (int i = 0; i < characterToRemoveItem.Items.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {characterToRemoveItem.Items[i].ItemName} - {characterToRemoveItem.Items[i].Description}");
                            }

                            Console.WriteLine("Введите номер предмета для удаления:");
                            int itemIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (itemIndex >= 0 && itemIndex < characterToRemoveItem.Items.Count)
                            {
                                dnDMethods.RemoveItem(idToRemoveItem, characterToRemoveItem.Items[itemIndex]);
                            }
                            else
                            {
                                Console.WriteLine("Неправильный выбор предмета.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Персонаж не найден.");
                        }
                        break;


                }


            }

        }
    }
}



