using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public static class StageInfo
    {


        /**Gets message from Messages dictionary. Returns no value if key is not found. */
        public static int GetMaxLevel(byte key)
        {
            var hasKey = MaxLevels.TryGetValue(key, out int value);
            return hasKey ? value : -1;
        }

        public static readonly Dictionary<byte, int> MaxLevels = new() {
            {
                0,0
            },
            {
                1,14
            },
            {
                2,21
            },
            {
                3,24
            },
            {
                4,29
            },
            {
                5,43
            },
            {
                6,43
            },
            {
                7,47
            },
            {
                8,50
            },
            {
                9,65
            },

        };

        /**Gets message from Messages dictionary. Returns no value if key is not found. */
        public static string GetMessage(byte key)
        {
            var hasKey = Messages.TryGetValue(key, out string value);
            return hasKey ? value : "This stage does not exist.";
        }

        public static readonly Dictionary<byte, string> Messages = new()
        {
            {
                0,
                "Type \"startgame\" and press Enter to begin a new Nuzlocke challenge. Type \"help\" to get a list of available commands."
            },
            {
                1,
                $"Your current challenge is Brock. His ace is level {MaxLevels[1]}."
            },
            {
                2,
                $"Your current challenge is Misty. Her ace is level {MaxLevels[2]}."
            },
            {
                3,
                $"Your current challenge is Lt. Surge. His ace is level {MaxLevels[3]}."
            },
            {
                4,
                $"Your current challenge is Erika. Her ace is level {MaxLevels[4]}."
            },
            {
                5,
                $"Your current challenge is Koga. His ace is level {MaxLevels[5]}."
            },
            {
                6,
                $"Your current challenge is Sabrina. Her ace is level {MaxLevels[6]}."
            },
            {
                7,
                $"Your current challenge is Blane. His ace is level {MaxLevels[7]}."
            },
            {
                8,
                $"Your current challenge is Giovanni. His ace is level {MaxLevels[8]}."
            },
            {
                9,
                $"Your current challenge is The Elite Four. Their ace is level {MaxLevels[9]}."
            },

        };
    }
}
