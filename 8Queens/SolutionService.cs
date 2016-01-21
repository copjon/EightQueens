using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public class SolutionService : ISolutionService
    {
        List<Board> solutions;
        Board board;

        public SolutionService()
        {
            solutions = new List<Board>();
        }

        public void FindSolutions()
        {
            Console.WriteLine("Finding next solution...");

            board = board ?? new Board();
            while (!board.IsSolution && !board.IsFinished)
            {
                if (!board.HasAttacks)
                {
                    Console.WriteLine(board.ToString());
                }

                board.Increment();
            }

            if (!board.IsFinished)
            {
                Console.WriteLine("Solution #{0} Found!", SolutionsFound);
                board.Increment();
                FindSolutions();
            }
        }


        public int SolutionsFound
        {
            get
            {
                return solutions.Count;
            }
        }

        public IEnumerable<Board> Solutions
        {
            get
            {
                return solutions;
            }
        }

    }
}
