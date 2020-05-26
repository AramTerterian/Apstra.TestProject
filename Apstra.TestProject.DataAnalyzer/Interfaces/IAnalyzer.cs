using System.Collections.Generic;

namespace Apstra.TestProject.DataAnalyzer.Interfaces
{
    public interface IAnalyzer
    {
        string GetSubsetMask(IEnumerable<string> ipList);
    }
}