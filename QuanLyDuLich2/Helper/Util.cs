using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyDuLich2.Helper
{
    class Util
    {
        public static void ShowMessage(string message,
        [CallerLineNumber] int lineNumber = 0,
        [CallerMemberName] string caller = null)
        {
            Console.WriteLine(message + " at line " + lineNumber + " (" + caller + ")");
        }
        public static void ShowTodoMessage(
        [CallerLineNumber] int lineNumber = 0,
        [CallerMemberName] string caller = null)
        {
            Console.WriteLine("TODO at line " + lineNumber + " (" + caller + ")");
        }
    }
}
