using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using Timer = MicrowaveOvenClasses.Boundary.Timer;


namespace TestApplikation
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ObjectCreation

            var pB = new Button();
            var tB = new Button();
            var scB = new Button();
            var door = new Door();
            var output = new Output();
            var display = new Display(output);
            var light = new Light(output);
            var timer = new Timer();
            var pt = new PowerTube(output);
            var cC = new CookController(timer, display, pt);
            var uI = new UserInterface(pB, tB, scB, door, display, light, cC);
            cC.UI = uI;



            #endregion


            #region TestUseCase
            Console.WriteLine("Tast enter når applikationen skal afsluttes");
            Console.WriteLine("");
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
              Console.WriteLine("asd");  
                
            }

            


            #endregion



            

        }
    }
}
