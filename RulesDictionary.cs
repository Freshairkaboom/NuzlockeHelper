using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    public static class RulesDictionary
    {
        [SuppressMessage("ReSharper", "StringLiteralTypo")]

        public const int CoreRulesDescriptionsLength = 6;

        public static readonly Dictionary<byte, string> CoreRuleDescriptions = new()
        {
            {
                0, 
                "You can only catch the first non-shiny Pokémon seen on each route. Legendary Pokémon can always be caught."
            },
            {
                1, 
                "Any Pokémon that faints can never be used again, either in battle or using HMs. Box or release as you see fit."
            },
            {
                2, 
                "You MUST nickname all of your Pokémon to form stronger emotional bonds to them."
            },
            {
                3, 
                "You MUST be the original trainer of every Pokémon you use. Trading your Pokémon to evolve and trading back is allowed."
            },
            {
                4, 
                "You can only load a save if it doesn't delete any progress."
            },
            {
                5, 
                "Your Pokémon's level can not exceed the strongest Pokémon of the next gymleader's ace."
            },
        };

        [SuppressMessage("ReSharper", "StringLiteralTypo")]

        public static readonly Dictionary<byte, string> ExpertRuleDescriptions = new()
        {
            {
                0,
                "The player's starter Pokémon must be randomly chosen. (This app provides the starter based on random logic)."
            },
            {
                1,
                "A black/whiteout is considered game over."
            },
            {
                2,
                "You can only catch the first Pokémon encountered after every gymleader. (Note: This rule replaces the route core rule.)"
            },
            {
                3,
                "The player must use the same number of Pokémon as the opponent uses during a Gym battle or rival battle (information is provided by app)."
            },
            {
                4,
                "The battle style must be changed to \"set\" in the options menu."
            },
            {
                5,
                "The player's Starter Pokémon must be released or permanently put into a PC box after the first wild Pokémon is caught."
            },
            {
                6,
                "Potions and status-healing items may not be used, so the player may only use Pokémon Centers for healing."
            },
        };
    }
}
