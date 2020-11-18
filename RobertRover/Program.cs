using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertRover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Give the Command to move the Rover (ex. R1R9L2 - R = Right, L = Left, Digits => Number of stpes to be moved)  =>\t");
                string command = Console.ReadLine();
                IRoverPosition p = new RoverPosition();
                Console.Write("Final position based on given command => " + p.Move(command) + " (First X cordinate, Second Y cordinate and Last Direction N = North, S = South, E = East and W = West");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Write("Error Occured : - " + ex.Message) ;
            }

            Console.ReadKey();
        }
    }
}
