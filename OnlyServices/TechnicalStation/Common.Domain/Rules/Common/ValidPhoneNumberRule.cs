using System.Text.RegularExpressions;

namespace Common.Domain.Rules.Common
{
    public class ValidPhoneNumberRule : IRule
    {
        private string phoneNumber;

        public ValidPhoneNumberRule(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        protected bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^([0-9]{10})$").Success;
        }

        public bool IsBroken() => !this.IsPhoneNumber(phoneNumber);

        public string Message => "Phone should be a valid form provided in a format 9999999999.";

    }
}
