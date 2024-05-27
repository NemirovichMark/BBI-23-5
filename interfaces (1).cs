using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_1.People
{
    interface ICountable
    {
        int Count();
        int Count(double value);
        int Percentage(double partialValue, double totalValue);
    }

    public interface IReportable
    {
        string GenerateReport();
    }
}

