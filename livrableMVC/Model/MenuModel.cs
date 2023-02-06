using livrableMVC.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Models;

namespace livrableMVC.Model
{
    public class MenuModel : IDisposable
    {
        public readonly int left;
        public readonly int top;
        public List<string> menu = new List<string>();
        public int Selected = 0;
        public int Return = -1;
        private MenuView view;

        public MenuModel(int left, int top)
        {
            this.left = left;
            this.top = top;
            this.view = new MenuView(this);
        }

        public void AddItem(string item)
        {
            menu.Add(item);
        }

        public void RemoveItem(string item)
        {
            menu.Remove(item);
        }

        public int Start()
        {
            view.Render();
            Run();
            return Return;
        }

        public void Dispose()
        {
            view.Dispose();
        }

        private void Run()
        {
            while (Return == -1)
            {
                Thread.Sleep(150);
                if (NativeKeyboard.IsKeyDown(KeyCode.Up))
                {
                    if (Selected > 0)
                    {
                        view.RenderSelected(Selected, Selected - 1);
                        Selected--;
                    }
                }
                if (NativeKeyboard.IsKeyDown(KeyCode.Down))
                {
                    if (Selected < menu.Count - 1)
                    {
                        view.RenderSelected(Selected, Selected + 1);
                        Selected++;
                    }
                }
                if (NativeKeyboard.IsKeyDown(KeyCode.Enter))
                {
                    Return = Selected;
                    break;
                }
            }
        }
    }
}
