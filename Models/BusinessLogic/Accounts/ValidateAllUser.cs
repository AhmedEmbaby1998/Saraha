using Embaby.Models.Validating;

namespace Embaby.Models.BusinessLogic.Accounts
{
    public class ValidateAllUser:ValidateUser
    {
        public ValidateAllUser(ValidateUserNameOptions userNameOptions, IPasswordValidator passwordValidator) : base(userNameOptions, passwordValidator)
        {
        }

     

        protected override void ValidateWhich()
        {
            ValidateEmail();
            ValidateName();
            ValidatePassword();        }
    }
}