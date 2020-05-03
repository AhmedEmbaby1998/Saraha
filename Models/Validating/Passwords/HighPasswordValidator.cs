using System;
using System.Collections.Generic;
using System.Text;
using SimpleSaraha.Models.Entities;

namespace Embaby.Models.Validating
{
    public class HighPasswordValidator:PasswordValidation
    {
        public HighPasswordValidator(ValidatingPasswordOptions options) : base( options)
        {
        }

        public override bool IsValid()
        {
            return base.IsValid()
                   && NotContainsEmailOrUserName()
                   && CheckFrequentForWords();

        }

        private bool NotContainsEmailOrUserName()
        {
            var r= !User.Password.Contains(User.Email)
                   && !User.Password.Contains(User.Name);
            if (!r) Reports.Add("Password should not contains a user Name or Password!");
            return r;
        }

        private bool CheckFrequentForWords()
        {
            var map = new Dictionary<string,int>();
            for (var i = 0; i < User.Password.Length-1; i++)
            {
                var builder = new StringBuilder();
                for (var j = i; j < User.Password.Length; j++)
                {
                    builder.Append(User.Password[j]);
                    var str = builder.ToString();
                    if (!map.ContainsKey(str))
                    {
                        map.Add(str,1);
                    }
                    else
                    {
                        map[str]++;
                        if ((str.Length <= 2 || map[str] <= 1) && (str.Length <= 0 || map[str] <= 3)) continue;
                        Reports.Add($"{str} is repeated {map[str]} times in the passwords");
                        return false;
                    }
                }
            }

            return true;
        }
        
        
    }
}