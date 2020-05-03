using Embaby.Models.Validating;
using Microsoft.Extensions.Options;
using SimpleSaraha.Models.Entities;

namespace Embaby.Models.BusinessLogic.Accounts
{
    public abstract class ValidateUser
    {
        private User User;

        public bool IsValid { get; private set; }
        
        protected readonly ValidateUserNameOptions _userNameOptions;
        
        protected readonly IPasswordValidator _passwordValidator;

        protected ValidateUser( ValidateUserNameOptions userNameOptions, IPasswordValidator passwordValidator)
        {
            _userNameOptions = userNameOptions;
            _passwordValidator = passwordValidator;
        }

        protected ValidateUser ValidateEmail()
        {
            IsValid = EmailValidating.IsValidEmail(User.Email);
            return this;
        }

        protected ValidateUser ValidateName()
        {
            IsValid=new NameValidating(User.Name,_userNameOptions ).IsValidName();
            return this;
        }

        protected ValidateUser ValidatePassword()
        {
            _passwordValidator.Validate(User);
            IsValid = _passwordValidator.IsValid();
            return this;
        }

        public void Validate(User user)
        {
            User = user;
            ValidateWhich();
        }
        
        protected abstract void ValidateWhich();
        
        

    }
}