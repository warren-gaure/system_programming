using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Models
{
    internal enum KeyCode : int
    //https://learn.microsoft.com/fr-fr/dotnet/api/system.windows.forms.keys?view=windowsdesktop-7.0
    {
        Enter = 13,
        Left = 37,
        Up,
        Right,
        Down
    }

    internal static class NativeKeyboard
    {
        private const int KeyPressed = 0x8000;
        public static bool IsKeyDown(KeyCode key)
        {
            return (GetKeyState((int)key) & KeyPressed) != 0;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(int key);
    }
}
