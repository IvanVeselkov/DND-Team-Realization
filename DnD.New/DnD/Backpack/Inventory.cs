using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Backpack
{
    public class Inventory : Subject
    {
        public int Weight { get; set; }
        public bool IsWeapon { get; set; }

        public Inventory(string itemname, string discription, int weight,  bool isWeapon) : base(itemname, discription)
        {

            Weight = weight;
            IsWeapon = isWeapon;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
         
        }
    }

    

}
