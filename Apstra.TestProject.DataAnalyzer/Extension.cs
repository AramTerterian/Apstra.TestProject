using Apstra.TestProject.DataAnalyzer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Apstra.TestProject.DataAnalyzer
{
    public class Extension : IExtension
    {
        private string IpFormat = @"^((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.){3}(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]?)$";

        public bool CheckIpList(IEnumerable<string> ipList)
        {
            if (ipList == null || !ipList.ToList().Any())
            {
                return false;
            }

            var regex = new Regex(IpFormat);

            foreach (var ip in ipList)
            {
                if (!regex.IsMatch(ip))
                {
                    return false;
                }
            }

            return true;
        }

        public IEnumerable<string> DecimalListToBinary(IEnumerable<string> ipList)
        {
            var result = new List<string>();

            foreach (var ip in ipList)
            {
                var binaryFormat = GetBinaryFormat(ip);
                result.Add(binaryFormat);
            }

            return result;
        }

        public string BinaryToDecimal(string binaryFormat)
        {
            var result = new StringBuilder();
            var splittedLine = Split(binaryFormat, 8);

            foreach (var block in splittedLine)
            {
                var decimalBlock = GetDecimalFormat(block);
                result.Append(decimalBlock);
                result.Append('.');
            }

            result.Remove(result.Length - 1, 1);

            return result.ToString();
        }

        private IEnumerable<string> Split(string text, int size)
        {
            for (var i = 0; i < text.Length; i += size)
            {
                yield return text.Substring(i, Math.Min(size, text.Length - i));
            }
        }

        private string GetBinaryFormat(string ip)
        {
            var result = new StringBuilder();

            var ipBlocks = ip.Split('.');

            for (int i = 0; i < ipBlocks.Length; i++)
            {
                var decimalFormat = int.Parse(ipBlocks[i]);
                var binaryCode = Convert.ToString(decimalFormat, 2).PadLeft(8, '0');

                result.Append(binaryCode);
            }

            return result.ToString();
        }

        private string GetDecimalFormat(string binery)
        {
            int big = 0;
            foreach (var c in binery)
            {
                big <<= 1;
                big += c - '0';
            }

            return big.ToString();
        }
    }
}