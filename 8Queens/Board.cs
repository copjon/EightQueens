using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public class Board : IEquatable<Board>, ICloneable
    {
        public Board() : this(InitialBoardFactoy())
        {

        }

        public Board(IEnumerable<Queen> queens)
        {
            Queens = queens.ToList();
        }



        /// <summary>
        /// List of queens that make up the board
        /// </summary>
        public List<Queen> Queens { get; private set; }
        
        public void Increment()
        {
            //TODO: Figure out how to increment
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether any pieces overlap 
        /// which would make the board invalid.
        /// </summary>
        public bool IsValid
        {
            get
            {
                //Spin through all pieces (but the last piece) and match against all other pieces.
                //The last piece has already been matched against.
                for (int i = 0; i < 7; i++)
                {
                    for (int j = i+1; j < 8; j++)
                    {
                        if(Queens[i].Equals(Queens[j]))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }


        /// <summary>
        /// Signifies whether any pieces have an attack.
        /// </summary>
        public bool HasAttacks
        {
            get
            {
                //Spin through all pieces (but the last piece) and match against all other pieces.
                //The last piece has already been matched against all other pieces. If no piece
                //can attack it, it can't attack another piece.
                for (int i = 0; i < this.Queens.Count -1; i++)
                {
                    for (int j = i + 1; j < this.Queens.Count; j++)
                    {
                        if (Queens[i].CanAttack(Queens[j]))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// Signifies whether the board is a solution where 8 queens
        /// are on the board and none can attack.
        /// </summary>
        public bool IsSolution
        {
            get
            {
                return IsValid && Queens.Count == 8 && !HasAttacks;
            }
        }


        /// <summary>
        /// Signifies whether all possible valid combinations have been attempted 
        /// with the current number of queens on the board.
        /// (All placed queens are at the end of Y=7)
        /// </summary>
        public bool IsRunThrough
        {
            get
            {
                foreach (var queen in this.Queens)
                {
                    if (!queen.IsMaxValue) return false;
                }

                return true;
            }
        }

        public bool IsFinished
        {
            get
            {
                return this.Queens.Count == 8 && IsRunThrough;
            }
        }

        /// <summary>
        /// Initializes a board with two queens at positions (0,0) and (1,0)
        /// </summary>
        /// <returns></returns>
        private static List<Queen> InitialBoardFactoy()
        {
            return new List<Queen>
                {
                    new Queen (0,0),
                    new Queen (1,0)
                };
        }

        /// <summary>
        /// Determines whether two boards have equivalent placing of Queens regardless of order.
        /// </summary>
        /// <param name="other">Board to compare.</param>
        /// <returns></returns>
        public bool Equals(Board other)
        {
            if (this.Queens.Count != other.Queens.Count) return false;

            var matches = 0;
            for (int i = 0; i < this.Queens.Count; i++)
            {
                bool hasMatch = false;
                for (int j = 0; j < other.Queens.Count; j++)
                {
                    if (this.Queens[i].Equals(other.Queens[j]))
                    {
                        matches++;
                        hasMatch = true;
                        break;
                    }
                }

                if (!hasMatch)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            var s = string.Format("{0} | ",this.Queens[0]);
            for (int i = 1; i < this.Queens.Count; i++)
            {
                s = string.Format("{0} | {1}", s, Queens[i]);
            }

            return s;
        }

        public object Clone()
        {
            return new Board(this.Queens.Select(q=>(Queen)q.Clone()));
        }
    }
}
