using Common.Domain.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace TechnicalStation.Core.Domain.Order.Rules
{
    public class FinishDateCannotBeEarlierThanStartDateRule : IRule
    {
        private readonly DateTime startDate;
        private readonly DateTime finishDate;

        public FinishDateCannotBeEarlierThanStartDateRule(DateTime startDate, DateTime finishDate)
        {
            this.startDate = startDate;
            this.finishDate = finishDate;
        }

        public bool IsBroken() => finishDate < startDate;

        public string Message => "Finish date cannot be earlier than the start date.";
    }
}
