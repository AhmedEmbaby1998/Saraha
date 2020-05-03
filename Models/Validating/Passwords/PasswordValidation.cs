using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SimpleSaraha.Models.Entities;

namespace Embaby.Models.Validating
{
    public abstract  class PasswordValidation:IPasswordValidator
    {
        protected ValidatingPasswordOptions Options { private set; get; }
        protected  User User;
        public  ArrayList Reports { protected set; get; }

        protected PasswordValidation(ValidatingPasswordOptions options)
        {
            Options = options;
            Reports=new ArrayList();
        }
        protected bool IsAscii()
        {
            var r= User.Password.All(c => c <= 128);
            if (!r)
            {
                Reports.Add("Non ASCII Password!");
            }

            return r;
        }

        protected bool HasDigits()
        {
            var r= !string.IsNullOrEmpty(new Regex(@"\d").Match(User.Password).Value);
            if (!r)
                Reports.Add("Password does not contain any numbers");
            return r;
        }

        protected bool HasUpperCharacters()
        {
            var r = User.Password.Any(c => char.IsUpper(c));
            if (!r)
                Reports.Add("Password does not contain any Upper Case character");
            return r;
        }

        protected bool HasCharacters()
        {
            var r= !string.IsNullOrEmpty(new Regex(@"[a-zA-Z]").Match(User.Password).Value);
            if (!r)
                Reports.Add("Passowrd does not contains any character!");
            return r;
        }

        protected bool HasSpeshialChars()
        {
            var r =!string.IsNullOrEmpty(new Regex(@"[~!@#$%^&*()=+?><{}]").Match(User.Password).Value);
            if (!r)
                Reports.Add("Passowrd does not contains any Spacial characters !");
            return r;
        }
        
        

        public virtual bool IsValid()
        {
            return  IsAscii()
                   && HasCharacters()
                   && HasDigits()
                   && HasUpperCharacters()
                   && HasSpeshialChars()
                   && CheckMinDigits()
                   && CheckMinUpperCaseChars()
                   && CheckMibSpechialChars()
                   && CheckMaxChars();
        }

        public void Validate(User user)
        {
            User = user;
        }


        protected virtual bool CheckMinDigits()
        {
            var l = new Regex(@"\d").Matches(User.Password).Count;
            var r =new Regex(@"\d").Matches(User.Password).Count>=Options.MinDigits;
            if (!r)
            {
                Reports.Add($"Password should contain at least {Options.MinDigits} digits of numbers!");
            }

            return r;
        }

        protected virtual bool CheckMinUpperCaseChars()
        {
            var count = User.Password.Count(ch => char.IsUpper(ch));

            var r = count >= Options.MinUpperChars;
            if (!r)
            {
                Reports.Add($"Password should contain at least {Options.MinUpperChars} digits of upper case characters");
            }

            return r;

        }

        protected virtual bool CheckMibSpechialChars()
        {
            var r =new Regex(@"[~!@#$%^&*()=\[\]><]").Matches(User.Password).Count>=Options.MinSpecialChars;
            if (!r)
            {
                Reports.Add($"Password should contain at least {Options.MinSpecialChars} digits of spacial characters !");
            }

            return r;
        }

        protected virtual bool CheckMaxChars()
        {
            var r = User.Password.Length <= Options.MaxChars;
            if (!r)
            {
                Reports.Add($"Password Exceeds the max size !");
            }

            return r;
        }

    }
}