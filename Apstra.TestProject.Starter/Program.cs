using Apstra.TestProject.DataAnalyzer;
using Apstra.TestProject.DataAnalyzer.Interfaces;
using Ninject;
using System;

namespace Apstra.TestProject.IP
{
    internal class Program
    {
        private static readonly IProcessor _processor;
        private static readonly ILoader _loader;

        private static readonly string InputFileName = "input.txt"; // Look into bin\Debug folder
        private static readonly string OutputFileName = "output.txt"; // Look into bin\Debug folder

        static Program()
        {
            var ninjectKernel = new StandardKernel(new SimpleConfigModule());

            _processor = ninjectKernel.Get<IProcessor>();
            _loader = ninjectKernel.Get<ILoader>();
        }

        private static void Main()
        {
            Start();
        }

        private static void Start()
        {
            try
            {
                var ipList = _loader.LoadIpList(InputFileName);

                var subsetMask = _processor.Process(ipList);

                _loader.WiteResult(OutputFileName, subsetMask);
            }
            catch (Exception ex)
            {
                _loader.WiteResult(OutputFileName, ResultMessages.UnexpectedErrorMessage);
            }

            return;
        }
    }
}