using System;

namespace Common.Domain.Rules
{
    public class RuleValidationException : Exception
    {
        public IRule BrokenRule { get; }

        public string Details { get; }

        public RuleValidationException(IRule brokenRule)
            : base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
            this.Details = brokenRule.Message;
        }

        public override string ToString()
        {
            return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
        }
    }
}
