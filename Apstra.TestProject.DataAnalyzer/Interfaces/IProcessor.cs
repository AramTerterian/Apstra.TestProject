using System.Collections.Generic;

namespace Apstra.TestProject.DataAnalyzer.Interfaces
{
    public interface IProcessor
    {
        string Process(IEnumerable<string> ipList);
    }
}