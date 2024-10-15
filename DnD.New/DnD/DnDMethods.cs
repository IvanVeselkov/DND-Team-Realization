using DnD.Backpack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    public class DnDMethods
    {
        List<CharacterSheet> characters = new List<CharacterSheet>();
        private string FileСharaters = "characters.txt";
        
        public DnDMethods() 
        {
            characters = new List<CharacterSheet>();
            LoadFile();
        }

        public void AddCharacters(CharacterSheet character)
        {
            characters.Add(character);
            SaveFile();
        }

        public void FindCharacters(int id)
        {
            var character = characters.Find(i => i.Id == id);
            if (character != null)
            {
                Console.WriteLine($"Персонаж {character.Name} Расы {character.Race} существует");
            }
            else
            {
                Console.WriteLine("Такого персонажа не существует");
            }
        }

        public CharacterSheet FindCharacterById(int id)
        {
            return characters.Find(i => i.Id == id);
        }

        public void AddItem(int id, Inventory item)
        {
            
            var character = characters.Find(i => i.Id == id);

            
            if (character == null)
            {
                Console.WriteLine($"Персонаж с id {id} не найден.");
                return;
            }

            //Добавление веса рюкзака, подпись оружия
            int weaponCount = character.Items.Count(i => i.IsWeapon);
            double backpackWeigt = character.Items.Sum(i => i.Weight) + item.Weight;

            if (backpackWeigt > 20)
            {
                Console.WriteLine("Рюкзак персонажа переполнен");
                return;
            }

            
            if (item.IsWeapon && weaponCount >= 2) 
            {
                Console.WriteLine($"У персонажа {character.Name} уже два оружия, добавление не возможно");
                return;
            }

            
            if (character.Items.Exists(i => i.ItemName == item.ItemName))
            {
                Console.WriteLine($"Предмет {item.ItemName} уже есть у персонажа {character.Name}.");
            }
            else
            {
               
                character.Items.Add(item);
                Console.WriteLine($"Предмет {item.ItemName} успешно добавлен персонажу {character.Name}.");
                Console.WriteLine($"Текущий вес рюкзака: {character.Items.Sum(i => i.Weight)}");
    
            }
        }

        public void RemoveItem(int id, Inventory item)
        {
            var character = characters.Find(i => i.Id == id);

            if (character == null)
            {
                Console.WriteLine($"Персонаж с id {id} не найден.");
                return;
            }

            var itemToRemove = character.Items.Find(i => i.ItemName == item.ItemName);

            if (itemToRemove != null)
            {
                character.Items.Remove(itemToRemove);
                Console.WriteLine($"Предмет {item.ItemName} удален у персонажа {character.Name}.");
            }
            else
            {
                Console.WriteLine($"Предмет {item.ItemName} не найден у персонажа {character.Name}.");
            }
        }




        public void DisplayItems(CharacterSheet character)
        {
            if (character.Items.Count == 0)
            {
                Console.WriteLine($"{character.Name} не имеет предметов.");
            }
            else
            {
                Console.WriteLine($"Инвентарь персонажа {character.Name}:");
                string itemsList = string.Join(", ", character.Items.Select(item =>
                $"{item.ItemName}{(item.IsWeapon ? "(Оружие)" : " " )}")); //Теперь все инструменты из класса используются и выводится красиво
                Console.WriteLine(itemsList);
                double backpackWeigtForDisplay = character.Items.Sum(i => i.Weight);
                Console.WriteLine($"Общий вес рюкзака: {backpackWeigtForDisplay}");
            }
        }
    


    private void SaveFile()
        {
            using (var writer = new StreamWriter(FileСharaters))
            {
                foreach (var character in characters)
                {
                    writer.WriteLine($"{character.Id};{character.Name};{character.Race};{character.Strenght};{character.Dexterity};{character.Сonstitution};" +
                        $"{character.Intelligence};{character.Wisdom};{character.Charisma};{character.HitPoints};{character.ArmorClass};{character.Speed}; {character.Items} ");
                }
            }
        }


        private void LoadFile()
        {
            if (File.Exists(FileСharaters))
            {
                var lines = File.ReadAllLines(FileСharaters);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length >= 13)
                    {
                        
                        string itemsString = parts[12];
                        List<Inventory> items = itemsString.Split(',')
                            .Select(itemName => new Inventory(itemName.Trim(), "", 0, false)) 
                            .ToList();

                        var character = new CharacterSheet(
                            Convert.ToInt32(parts[0]),
                            parts[1],
                            parts[2],
                            Convert.ToInt32(parts[3]),
                            Convert.ToInt32(parts[4]),
                            Convert.ToInt32(parts[5]),
                            Convert.ToInt32(parts[6]),
                            Convert.ToInt32(parts[7]),
                            Convert.ToInt32(parts[8]),
                            Convert.ToInt32(parts[9]),
                            Convert.ToInt32(parts[10]),
                            Convert.ToInt32(parts[11]),
                            items 
                        );

                       
                    }
                }
            }
        }
    }
     
 }

