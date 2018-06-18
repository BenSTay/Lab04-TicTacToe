using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        public string Marker { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Creates a new instance of the Player class.
        /// </summary>
        /// <param name="marker">The player's marker.</param>
        public Player(string marker)
        {
            Marker = marker;
        }
    }
}
