namespace Mars_Rover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputToParse =   """
                                    5 5
                                    1 1 N
                                    MMM
                                    2 2 E
                                    MMMM
                                    """;

            InputParser.ParseInput(inputToParse);
        }
    }
}
