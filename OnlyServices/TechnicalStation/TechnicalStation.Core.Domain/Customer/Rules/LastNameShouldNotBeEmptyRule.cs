using Common.Domain.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace TechnicalStation.Core.Domain.Customer.Rules
{
    public class LastNameShouldNotBeEmptyRule : IRule
    {
        private string firstName;

        public LastNameShouldNotBeEmptyRule(string firstName)
        {
            this.firstName = firstName;
        }

        public bool IsBroken() => string.IsNullOrEmpty(firstName);

        public string Message => "Last name should not be empty.";
    }
}
