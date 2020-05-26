using Apstra.TestProject.DataAnalyzer;
using NUnit.Framework;
using System.Collections.Generic;

namespace Apstra.TestProject.Tests
{
    public class TestCases
    {
        public static TestCaseData TestCase1
        {
            get
            {
                var ipList = new string[] { "192.168.1.1", "192.168.1.2" };

                var result = "255.255.255.252";

                var testCase = new TestCase(ipList, result);

                return new TestCaseData(testCase);
            }
        }

        public static TestCaseData TestCase2
        {
            get
            {
                var ipList = new string[] { "192.168.2.1", "192.168.1.1" };

                var result = "255.255.252.0";

                var testCase = new TestCase(ipList, result);

                return new TestCaseData(testCase);
            }
        }

        public static TestCaseData TestCase3
        {
            get
            {
                var ipList = new string[] { "192.20.1.1", "192.168.1.1" };

                var result = "255.0.0.0";

                var testCase = new TestCase(ipList, result);

                return new TestCaseData(testCase);
            }
        }

        public static TestCaseData TestCase4
        {
            get
            {
                var ipList = new string[] { "192.20.1.1" };

                var result = "255.255.255.255";

                var testCase = new TestCase(ipList, result);

                return new TestCaseData(testCase);
            }
        }

        public static TestCaseData TestCase5
        {
            get
            {
                var ipList = new string[] { "192.201.1" };

                var result = ResultMessages.IncorrectFormatMessage;

                var testCase = new TestCase(ipList, result);

                return new TestCaseData(testCase);
            }
        }

        public static TestCaseData TestCase6
        {
            get
            {
                var ipList = new string[] { "192.201.1.1.1" };

                var result = ResultMessages.IncorrectFormatMessage;

                var testCase = new TestCase(ipList, result);

                return new TestCaseData(testCase);
            }
        }

        public static TestCaseData TestCase7
        {
            get
            {
                var ipList = new string[] { "192.201.100.300" };

                var result = ResultMessages.IncorrectFormatMessage;

                var testCase = new TestCase(ipList, result);

                return new TestCaseData(testCase);
            }
        }

        public static TestCaseData TestCase8
        {
            get
            {
                var ipList = new string[] { };

                var result = ResultMessages.IncorrectFormatMessage;

                var testCase = new TestCase(ipList, result);

                return new TestCaseData(testCase);
            }
        }

        public static TestCaseData TestCase9
        {
            get
            {
                string[] ipList = null;

                var result = ResultMessages.IncorrectFormatMessage;

                var testCase = new TestCase(ipList, result);

                return new TestCaseData(testCase);
            }
        }

        public static TestCaseData TestCase10
        {
            get
            {
                var ipList = new string[] { "1.1.1.1", "240.1.1.1" };

                var result = ResultMessages.NoResultMessage;

                var testCase = new TestCase(ipList, result);

                return new TestCaseData(testCase);
            }
        }
    }

    public class TestCase
    {
        public TestCase(IEnumerable<string> ipList, string result)
        {
            IpList = ipList;
            Result = result;
        }

        public IEnumerable<string> IpList { get; set; }

        public string Result { get; set; }
    }
}