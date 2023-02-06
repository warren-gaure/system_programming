using livrableMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Models;

namespace livrableMVC.View
{
    internal class MenuView : IDisposable
    {
        private MenuModel menuModel;
        public MenuView(MenuModel menuModel)
        {
            this.menuModel = menuModel; 
        }

        public void Dispose()
        {
            var buffer = " ";
            for (int i = 0; i < menuModel.menu.Count; i++)
            {
                Console.SetCursorPosition(menuModel.left, menuModel.top + i);
                for (int j = 0; j < menuModel.menu[i].Length; j++)
                {
                    buffer += " ";
                }
                Console.Write(buffer);
            }
            Console.SetCursorPosition(menuModel.left, menuModel.top);
        }

        public void Render()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            if (menuModel.menu != null && menuModel.menu.Count != 0)
            {
                for (int i = 0; i < menuModel.menu.Count; i++)
                {
                    Console.SetCursorPosition(menuModel.left, menuModel.top + i);
                    if (i == menuModel.Selected)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(menuModel.menu[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            Console.SetCursorPosition(menuModel.left, menuModel.top);
        }

        public void RenderSelected(int Before, int After)
        {
            Console.SetCursorPosition(menuModel.left, menuModel.top + Before);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(menuModel.menu[Before]);
            Console.SetCursorPosition(menuModel.left, menuModel.top + After);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(menuModel.menu[After]);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
