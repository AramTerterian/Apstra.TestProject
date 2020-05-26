using Apstra.TestProject.DataAnalyzer.Interfaces;
using Ninject;
using System.Collections.Generic;

namespace Apstra.TestProject.DataAnalyzer
{
    public class Processor : IProcessor
    {
        private readonly IExtension _extension;
        private readonly IAnalyzer _analyzer;

        public Processor()
        {
            var ninjectKernel = new StandardKernel(new SimpleConfigModule());

            _extension = ninjectKernel.Get<IExtension>();
            _analyzer = ninjectKernel.Get<IAnalyzer>();
        }

        public string Process(IEnumerable<string> ipList)
        {
            var areCorrect = _extension.CheckIpList(ipList);

            if (!areCorrect)
            {
                return ResultMessages.IncorrectFormatMessage;
            }

            var binaryList = _extension.DecimalListToBinary(ipList);

            var binarySubsetMask = _analyzer.GetSubsetMask(binaryList);

            if (binarySubsetMask == null)
            {
                return ResultMessages.NoResultMessage;
            }

            var subsetMask = _extension.BinaryToDecimal(binarySubsetMask);

            return subsetMask;
        }
    }
}