using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Eight Queens Solution Finder!");
            Console.WriteLine("Press Enter to start finding solutions...");
            Console.ReadLine();
            var start = DateTime.Now;

            var solutionService = new SolutionService();
            solutionService.FindSolutions();

            var time = DateTime.Now - start;
            Console.WriteLine("{0} total solutions found in {1}!", time.ToString());
            foreach (var solution in solutionService.Solutions)
            {
                Console.WriteLine(solution);
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}
