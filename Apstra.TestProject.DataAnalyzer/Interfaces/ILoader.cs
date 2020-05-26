using System.Collections.Generic;

namespace Apstra.TestProject.DataAnalyzer.Interfaces
{
    public interface ILoader
    {
        IEnumerable<string> LoadIpList(string fileName);

        void WiteResult(string fileName, string result);
    }
}