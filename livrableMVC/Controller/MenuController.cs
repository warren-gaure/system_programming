using livrableMVC.Model;
using livrableMVC.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Models;

namespace livrableMVC.ControllerSpace
{
    internal class MenuController : IDisposable
    {
        private MenuModel model;
        private MenuView view;

        public MenuController()
        {
            this.model = new MenuModel(0, 0);
            this.view = new MenuView(this.model);
        }

        public MenuController(int left, int top)
        {
            this.model = new MenuModel(left, top);
            this.view = new MenuView(this.model);
        }

        public int Start()
        {
            view.Render();
            Run();
            return model.Return;
        }

        public void AddItem(string item)
        {
            model.AddItem(item);
        }

        public void RemoveItem(string item)
        {
            model.RemoveItem(item);
        }
        public void Dispose()
        {
            view.Dispose();
        }

        private void Run()
        {
            while (model.Return == -1)
            {
                Thread.Sleep(150);
                if (NativeKeyboard.IsKeyDown(KeyCode.Up))
                {
                    if (model.Selected > 0)
                    {
                        view.RenderSelected(model.Selected, model.Selected - 1);
                        model.Selected--;
                    }
                }
                if (NativeKeyboard.IsKeyDown(KeyCode.Down))
                {
                    if (model.Selected < model.menu.Count - 1)
                    {
                        view.RenderSelected(model.Selected, model.Selected + 1);
                        model.Selected++;
                    }
                }
                if (NativeKeyboard.IsKeyDown(KeyCode.Enter))
                {
                    model.Return = model.Selected;
                    break;
                }
            }
        }

    }
}
