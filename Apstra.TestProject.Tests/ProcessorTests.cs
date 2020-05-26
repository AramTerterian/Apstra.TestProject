using Apstra.TestProject.DataAnalyzer;
using Apstra.TestProject.DataAnalyzer.Interfaces;
using Ninject;
using NUnit.Framework;
using System.Collections;

namespace Apstra.TestProject.Tests
{
    [TestFixture]
    public class ProcessorTests
    {
        private readonly IProcessor _processor;

        public ProcessorTests()
        {
            var ninjectKernel = new StandardKernel(new SimpleConfigModule());
            _processor = ninjectKernel.Get<IProcessor>();
        }

        public static IEnumerable TestCasesList
        {
            get
            {
                yield return TestCases.TestCase1;
                yield return TestCases.TestCase2;
                yield return TestCases.TestCase3;
                yield return TestCases.TestCase4;
                yield return TestCases.TestCase5;
                yield return TestCases.TestCase6;
                yield return TestCases.TestCase7;
                yield return TestCases.TestCase8;
                yield return TestCases.TestCase9;
                yield return TestCases.TestCase10;
            }
        }

        [Test]
        [TestCaseSource("TestCasesList")]
        public void ProcessTest(TestCase testCase)
        {
            //arrange

            //act
            var result = _processor.Process(testCase.IpList);

            //assert
            Assert.AreEqual(result, testCase.Result);
        }
    }
}