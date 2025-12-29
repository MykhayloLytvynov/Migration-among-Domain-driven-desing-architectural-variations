using System;
using System.Collections.Generic;
using System.Text;
using Common.Domain.Rules;

namespace TechnicalStation.Core.Domain.Customer.Rules
{

    public class FirstNameCannotBeLessThanTwoCharactersRule : IRule
    {
        private readonly string _name;

        public FirstNameCannotBeLessThanTwoCharactersRule(string name)
        {
            _name = name;
        }

        public bool IsBroken() => _name.Length < 2;

        public string Message => "Name cannot be less than two characters.";
    }
}
