using System;

namespace Common.Domain
{
    public interface ITraceable
    {
        string GetTrace(int tabs = 0);
    }
}
