namespace Embaby.Models.Validating
{
    public struct ValidateUserNameOptions
    {
      
            public readonly int MaxCharacters;
            public readonly ValidatingEnum HasSpaces;
            public readonly ValidatingEnum HasNumbers;
            public readonly ValidatingEnum  HasSpecialCharacter;

            public ValidateUserNameOptions(int maxCharacters,ValidatingEnum hasSpaces=ValidatingEnum.Must
                ,ValidatingEnum hasNumbers=ValidatingEnum.CanNot, ValidatingEnum hasSpecialCharacter=ValidatingEnum.CanNot)
            {
                MaxCharacters = maxCharacters;
                HasNumbers = hasNumbers;
                HasSpaces = hasSpaces;
                HasSpecialCharacter = hasSpecialCharacter;
            }
    }
}