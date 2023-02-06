using livrableMVC.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Models;

namespace livrableMVC.Model
{
    internal class ExecuteModel : IDisposable
    {
        public int top = 0;
        public int left = 0;
        public List<string> saves = new List<string>();
        public int Selected = 0;
        public List<int> SavesSelected = new List<int>();
        public bool Return = false;
        public ExecuteView view;

        public ExecuteModel()
        {
            view = new ExecuteView(this);
        }

        public ExecuteModel(int left, int top)
        {
            view = new ExecuteView(this);
            this.left = left;
            this.top = top;
        }

        public ExecuteModel(int left, int top, IEnumerable<string> saves) 
        {
            this.left = left;
            this.top = top;
            foreach(var save in saves)
            {
                this.saves.Add(save);
            }
            view = new ExecuteView(this);
        }

        public void Dispose()
        {
            view.Dispose();
        }

        public bool AddSave(string save)
        {
            try
            {
                this.saves.Add(save);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddSaves(IEnumerable<string> saves)
        {
            try
            {
                foreach(var save in saves)
                {
                    this.saves.Add(save);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<string> Start()
        {
            view.Render();
            Run();
            var result = new List<string>();
            foreach(var val in this.SavesSelected)
            {
                result.Add(saves[val]);
            }
            return result;
        }

        private void Run()
        {
            while (!Return)
            {
                Thread.Sleep(120);
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
                    if (Selected < saves.Count - 1)
                    {
                        view.RenderSelected(Selected, Selected + 1);
                        Selected++;
                    }
                }
                if (NativeKeyboard.IsKeyDown(KeyCode.Enter))
                {
                    Return = true;
                    break;
                }
                if(NativeKeyboard.IsKeyDown(KeyCode.Space))
                {
                    if(!SavesSelected.Contains(Selected))
                    {
                        SavesSelected.Add(Selected);
                        view.Select(Selected, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        SavesSelected.Remove(Selected);
                        view.UnSelect(Selected, ConsoleColor.Black, ConsoleColor.White);
                    }
                }
            }
        }

    }
}
