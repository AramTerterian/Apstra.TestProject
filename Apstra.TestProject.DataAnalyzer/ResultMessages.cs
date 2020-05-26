using System.ComponentModel;

namespace Apstra.TestProject.DataAnalyzer
{
    public static class ResultMessages
    {
        public static string UnexpectedErrorMessage => "Unexpected error";

        public static string IncorrectFormatMessage => "Incorrect format of IP adresses or an empty input data. \n" +
                                                       "You should add at least one IP address. \n\n" +
                                                       "A correct example:\n" +
                                                       "192.168.1.1\n" +
                                                       "192.168.1.98";

        public static string NoResultMessage => "The program can not find an subset mask for this list of IP adresses";
    }
}