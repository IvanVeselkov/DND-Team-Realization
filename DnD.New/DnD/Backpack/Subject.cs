using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Backpack
{
    public abstract class Subject
    {
        public string ItemName { get; set; }

        public string Description { get; set; }

        public Subject(string itemname, string description)
        {
            ItemName = itemname;
            Description = description;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Name: {ItemName}");
            Console.WriteLine($"Description: {Description}");

        }
    }
}
