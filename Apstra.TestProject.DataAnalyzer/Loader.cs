using Apstra.TestProject.DataAnalyzer.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace Apstra.TestProject.DataAnalyzer
{
    public class Loader : ILoader
    {
        public IEnumerable<string> LoadIpList(string fileName)
        {
            var result = new List<string>();

            using (var reader = new StreamReader(fileName))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }

            return result;
        }

        public void WiteResult(string fileName, string result)
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.WriteLine(result);
            }
        }
    }
}