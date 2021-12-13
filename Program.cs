using System;
using System.Data.SqlClient;

namespace NuzlockeHelper
{
    class Program
    {
        static void Main()
        {
            /*
             * The Nuzlocke Helper should take a state of current Nuzlocke challenge and reveal useful information to the player.
             * The Nuzlocke Helper should also take input from user about the current state of the game to change the information displayed.
             *
             * Features/information displayed should include:
             * - Max level your Pokémon can have in this part of the game.
             * - What routes the player has locked.
             * - A list of rules you can print out on the screen and add to or remove from.
             * - A way to store this information between sessions in a database (low priority).
             */

            SClassReference.Instance = new SClassReference();

            var game = new Game();
        }
    }
}
