using System.Text.RegularExpressions;

namespace Embaby.Models.Validating
{
    public class NameValidating
    {
        private readonly ValidateUserNameOptions _nameOptions;
        private readonly string _name;

        public NameValidating(string name )
        {
            _name = name;
            _nameOptions=new ValidateUserNameOptions(30);
        }
        public NameValidating(string name ,ValidateUserNameOptions nameOptions)
        {
            _name = name;
            _nameOptions = nameOptions;
        }
        public  bool IsValidName()
        {
            return ValidateSize()
                   && ValidateHasNumbers()
                   && ValidateHasSpaces()
                   && ValidateHasSpecialsCharacters();
        }

        private  bool  ValidateSize()
        {
            return _name.Length <= _nameOptions.MaxCharacters;
        }
        private  bool  ValidateHasSpaces()
        {
            var regex = new Regex(@"\s");
            var hasSpaces = !string.IsNullOrEmpty(regex.Match(_name).Value);
            return _nameOptions.HasSpaces == ValidatingEnum.Must && hasSpaces
                   || _nameOptions.HasSpaces == ValidatingEnum.CanNot && !hasSpaces
                   || _nameOptions.HasSpaces == ValidatingEnum.May;
        }
        private  bool  ValidateHasNumbers()
        {
            var regex = new Regex(@"\d");
            var hasNumbers = !string.IsNullOrEmpty(regex.Match(_name).Value);
            return _nameOptions.HasNumbers == ValidatingEnum.Must && hasNumbers
                   || _nameOptions.HasNumbers == ValidatingEnum.CanNot && !hasNumbers
                   || _nameOptions.HasNumbers == ValidatingEnum.May;
        }
        private  bool  ValidateHasSpecialsCharacters()
        {
            var regex = new Regex(@"[$&%^*()@~#*+/.?><'{}]");
            var hasSpacial = !string.IsNullOrEmpty(regex.Match(_name).Value);
            return _nameOptions.HasSpecialCharacter == ValidatingEnum.Must && hasSpacial
                   || _nameOptions.HasSpecialCharacter == ValidatingEnum.CanNot && !hasSpacial
                   || _nameOptions.HasSpecialCharacter == ValidatingEnum.May;
        }
        
        
        
       

     
    }

   
    
}