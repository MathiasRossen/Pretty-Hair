using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairUI
{
    class MainProgram
    {
        public void Run()
        {
            //string parOne = "This";
            //string parTwo = "is";
            //string parThree = "a";
            //string parFour = "message!";

            //WriteSomething("Hi there!");
            //WriteSomething("{1} {2} {0} {3}", parOne, parTwo, parThree, parFour);

            decimal price = 17.8m;

            string formattet = string.Format("{0:C4}" ,price);

            Console.WriteLine(formattet);
            //Console.WriteLine("{0,-15}{1,-15}{2,-3}", "Hans", "Ole", 27);
            //Console.WriteLine("{0,-15}{1,-15}{2,-3}", "Kim", "Petersen", 20);
            //Console.WriteLine("{0,-15}{1,-15}{2,-3}", "Ib", "Hansen", 80);
            //Console.WriteLine("{0,-15}{1,-15}{2,-3}", "Signe", "Arnoldson", 129);
            Console.ReadLine();
        }

        private void WriteSomething(object par)
        {
            Console.WriteLine(par.ToString());
        }

        private void WriteSomething(string format, params object[] args)
        {
            string newFormat = "";
            newFormat = String.Format(format, args);
            Console.WriteLine(newFormat);
        }
    }
}
