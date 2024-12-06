using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover
{
    public static class InputParser
    {
        public static void ParseInput(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input)) throw new ArgumentNullException();




                input = input.Replace("\r", "");
                string[] inputs = input.Split('\n');

                if (inputs.Length < 3) throw new ArgumentException();

                int instructionCount = inputs.Length - 1 / 2;


                List<string[]> instructions = [];
                foreach (string line in inputs)
                {
                    instructions.Add(line.Split(' '));
                }

                Plateau plateau = new Plateau(Int32.Parse(instructions[0][0]), Int32.Parse(instructions[0][1]));
                Enums.Orientation orientation = Enums.Orientation.E;

                for (int i = 1; i < instructionCount; i++)
                {
                    if (i % 2 != 0)
                    {

                        switch (instructions[i][2].ToLower())
                        {
                            case "n":
                                orientation = Enums.Orientation.N;
                                break;
                            case "s":
                                orientation = Enums.Orientation.S;
                                break;
                            case "e":
                                orientation = Enums.Orientation.E;
                                break;
                            case "w":
                                orientation = Enums.Orientation.W;
                                break;
                        }
                        plateau.AddRover(new Rover(Int32.Parse(instructions[i][0]), Int32.Parse(instructions[i][1]), orientation));

                    }
                    else
                    {
                        plateau.Rovers[i / 2 - 1].Pos.ReadMovement(String.Join("", instructions[i]));
                    }
                }
                plateau.PrintGrid();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
