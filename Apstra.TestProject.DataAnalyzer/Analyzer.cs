using Apstra.TestProject.DataAnalyzer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Apstra.TestProject.DataAnalyzer
{
    public class Analyzer : IAnalyzer
    {
        private const int BinaryIpLength = 32;

        public string GetSubsetMask(IEnumerable<string> ipList)
        {
            var firstItem = ipList.ToList().First();
            var maskLength = BinaryIpLength;

            for (int i = 0; i < BinaryIpLength; i++)
            {
                var currentItem = firstItem.Substring(0, maskLength);
                var isResult = true;

                foreach (var ip in ipList)
                {
                    if (!ip.StartsWith(currentItem))
                    {
                        isResult = false;
                        maskLength--;
                        break;
                    }
                }

                if (isResult)
                {
                    var result = GenerateSubsetMask(maskLength);

                    return result;
                }
            }

            return null;
        }

        private string GenerateSubsetMask(int maskLength)
        {
            var additionalLength = BinaryIpLength - maskLength;

            var result = new string('1', maskLength) + new string('0', additionalLength);

            return result;
        }
    }
}