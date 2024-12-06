namespace Mars_Rover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputToParse = """
                                    4 6
                                    1 2 N
                                    LMLMLMLMM
                                    3 3 E
                                    MMRMMRMRRM
                                    """;

            

            InputParser.ParseInput(inputToParse);
        }
    }
}
