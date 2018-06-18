using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Square
    {
        public string Content { get; set; }

        /// <summary>
        /// Creates a new instance of the Square class.
        /// </summary>
        /// <param name="content">The content of the square.</param>
        public Square(string content)
        {
            Content = content;
        }
    }
}
