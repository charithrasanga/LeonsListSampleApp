using System;
using System.Collections.Generic;
using System.Text;

namespace LeonsList.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
