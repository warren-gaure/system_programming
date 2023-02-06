using livrableMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.View
{
    internal class ExecuteView : IDisposable
    {
        ExecuteModel model;
        public ExecuteView(ExecuteModel model) 
        {
            this.model = model;
        }
        public void Dispose()
        {
            var buffer = " ";
            for (int i = 0; i < model.saves.Count; i++)
            {
                Console.SetCursorPosition(model.left, model.top + i);
                for (int j = 0; j < model.saves[i].Length + 4; j++)
                {
                    buffer += " ";
                }
                Console.Write(buffer);
            }
            Console.SetCursorPosition(model.left, model.top);
        }
        public void Render()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            if (model.saves != null && model.saves.Count != 0)
            {
                for (int i = 0; i < model.saves.Count; i++)
                {
                    Console.SetCursorPosition(model.left, model.top + i);
                    if (i == model.Selected)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine("[ ] " + model.saves[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            Console.SetCursorPosition(model.left, model.top);
        }

        public void Select(int index, ConsoleColor foregroundColor, ConsoleColor BackgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.SetCursorPosition(model.left + 1, model.top + index);
            Console.Write("*");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void UnSelect(int index, ConsoleColor foregroundColor, ConsoleColor BackgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.SetCursorPosition(model.left + 1, model.top + index);
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void RenderSelected(int Before, int After)
        {
            Console.SetCursorPosition(model.left, model.top + Before);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            if (model.SavesSelected.Contains(Before)) Console.Write("[*] " + model.saves[Before]);
            else Console.Write("[ ] " + model.saves[Before]);
            Console.SetCursorPosition(model.left, model.top + After);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            if(model.SavesSelected.Contains(After)) Console.Write("[*] " + model.saves[After]);
            else Console.Write("[ ] " + model.saves[After]);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
