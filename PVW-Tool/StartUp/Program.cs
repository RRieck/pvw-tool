using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using StartUp.Frontend;

namespace StartUp
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Open TUI here 
            var tui = new TUI();

            //Open GUI Here
            new Application().Run(new GUI());
        }
    }
}
