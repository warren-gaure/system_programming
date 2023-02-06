using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.Model
{
    public class MenuModel
    {
        public readonly int left;
        public readonly int top;
        public List<string> menu = new List<string>();
        public int Selected = 0;
        public int Return = -1;

        public MenuModel(int left, int top)
        {
            this.left = left;
            this.top = top;
        }

        public void AddItem(string item)
        {
            menu.Add(item);
        }

        public void RemoveItem(string item)
        {
            menu.Remove(item);
        }
    }
}
