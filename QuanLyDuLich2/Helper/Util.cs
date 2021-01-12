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

        public static bool Match(string one, string other)
        {
            if (one == null || one == "")
                return false;
            if (other == null || other == "")
                return false;
            string[] split1 = one.Split(' ');
            string[] split2 = other.Split(' ');

            foreach (string item1 in split1)
                foreach (string item2 in split2)
                    if (item1 == item2)
                        return true;

            return false;
        }
    }
}
