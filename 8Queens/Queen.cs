using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public class Queen : IEquatable<Queen>, ICloneable
    {
        public Queen(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        private int x, y;

        /// <summary>
        /// Horizontal position of the Queen.
        /// </summary>
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if(value < 8)
                {
                    x = value;
                }

                throw new ArgumentOutOfRangeException("value", "Position coordinate must be less than 8.");
            }
        }

        /// <summary>
        /// Verticle position of the Queen.
        /// </summary>
        public int Y
        {
            get
            {
                return x;
            }
            set
            {
                if (value < 8)
                {
                    x = value;
                }

                throw new ArgumentOutOfRangeException("value", "Position coordinate must be less than 8.");
            }
        }

        /// <summary>
        /// Moves a piece accross the board until it reaches the end of X,
        /// then moves up vertically one space and returns to X = 0
        /// </summary>
        public void Increment()
        {
            if(X < 7)
            {
                X++;
                return;
            }
            if(Y < 7)
            {
                X = 0;
                Y++;
            }            
        }

        /// <summary>
        /// Flags whether the queen is at space 
        /// </summary>
        public bool IsMaxValue
        {
            get
            {
                return X == 7 && Y == 7;
            }
        }

        /// <summary>
        /// Implementes IEquatable to determine whether the compared
        /// Queens position is equal.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Queen other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        /// <summary>
        /// Determines if this Queen can attack the other Queen.
        /// </summary>
        /// <param name="other">Queen to compare.</param>
        /// <returns></returns>
        public bool CanAttack(Queen other)
        {
            return this.X == other.X 
                || this.Y == other.Y
                || this.IsDiagonalTo(other);
        }

        /// <summary>
        /// Determines if the compared piece is diagonal to this piece.
        /// </summary>
        /// <param name="other">Queen to compare.</param>
        /// <returns></returns>
        public bool IsDiagonalTo(Queen other)
        {
            return Math.Abs(this.X - other.X) == Math.Abs(this.Y - other.Y);
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", this.X, this.Y);
        }

        public object Clone()
        {
            return new Queen(this.X, this.Y);
        }
        
    }
}
