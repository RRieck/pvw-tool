using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Frontend
{
    class TUI
    {
        /// <summary>
        /// @J Lo => Kannst alles aus Initialize weghauen wenn du magst. Wollte erstmal was zum Testen für für die Struktur haben ; )
        /// </summary>
        public TUI()
        {
            Initialize();
            Console.ReadLine();
        }

        // ReSharper disable once MemberCanBeMadeStatic.Local
        void Initialize()
        {
            while (true)
            {
                        Console.Clear();
                        Console.WriteLine("Starting TUI.");
                        System.Threading.Thread.Sleep(500);

                        Console.Clear();
                        Console.WriteLine("Starting TUI. .");
                        System.Threading.Thread.Sleep(500);

                        Console.Clear();
                        Console.WriteLine("Starting TUI. . .");
                        System.Threading.Thread.Sleep(500);
                }
        }
    }
}
