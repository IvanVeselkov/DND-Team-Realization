using DnD.Backpack;

namespace DnD
{
    public class CharacterSheet
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Сonstitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int HitPoints { get; set; }
        public int ArmorClass { get; set; }
        public int Speed { get; set; }
        public List<Inventory> Items { get; set; }

        public CharacterSheet(int id, string name, string race, int strenght, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int hitPoints, int armorClass, int speed)
        {
            this.Id = id;
            this.Name = name;
            this.Race = race;
            this.Strenght = strenght;
            this.Dexterity = dexterity;
            this.Сonstitution = constitution;
            this.Intelligence = intelligence;
            this.Wisdom = wisdom;
            this.Charisma = charisma;
            this.HitPoints = hitPoints;
            this.ArmorClass = armorClass;
            this.Speed = speed;
            this.Items = new List<Inventory>();
        }

        public CharacterSheet(int id, string name, string race, int strenght, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int hitPoints, int armorClass, int speed, List<Inventory> items)
            : this(id, name, race, strenght, dexterity, constitution, intelligence, wisdom, charisma, hitPoints, armorClass, speed)
        {
            this.Items = items;
        }
    }
}
