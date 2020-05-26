using System.Collections.Generic;

namespace Apstra.TestProject.DataAnalyzer.Interfaces
{
    public interface IExtension
    {
        bool CheckIpList(IEnumerable<string> ipList);

        IEnumerable<string> DecimalListToBinary(IEnumerable<string> ipList);

        string BinaryToDecimal(string binaryFormat);
    }
}