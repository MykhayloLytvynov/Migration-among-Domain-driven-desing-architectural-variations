using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Application.Contract.Dal
{
    public interface IRepositoryBase : ICloneable
    {
        IDatabaseContext DatabaseContext { get; set; }
    }
}
