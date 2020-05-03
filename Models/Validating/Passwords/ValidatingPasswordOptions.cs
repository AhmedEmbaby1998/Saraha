using Microsoft.AspNetCore.Identity;

namespace Embaby.Models.Validating
{
    public struct ValidatingPasswordOptions
    {
        public readonly int MinDigits;
        public readonly int MinUpperChars;
        public readonly int MinSpecialChars;
        public readonly int MaxChars;

        public ValidatingPasswordOptions(int minDigits, int minUpperChars, int minSpecialChars, int maxChars=20)
        {
            MinDigits = minDigits;
            MinUpperChars = minUpperChars;
            MinSpecialChars = minSpecialChars;
            MaxChars = maxChars;
        }
    }
}