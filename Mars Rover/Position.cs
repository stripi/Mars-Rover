using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover
{
    public class Position
    {
        public int X;
        public int Y;
        public Enums.Orientation Orientation;
        public Plateau Plateau;


        public Position(int x, int y, Enums.Orientation orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public string ReadMovement(string movements)
        {
            List<Enums.Instruction> instructions = [];
            movements = movements.ToLower();
            foreach (char _char in movements)
            {
                switch (_char)
                {
                    case 'l':
                        instructions.Add(Enums.Instruction.L);
                        break;
                    case 'r':
                        instructions.Add(Enums.Instruction.R);
                        break;
                    case 'm':
                        instructions.Add(Enums.Instruction.M);
                        break;
                    default:
                        break;
                }
            }

            foreach (Enums.Instruction instruction in instructions)
            {
                switch (instruction)
                {
                    case Enums.Instruction.L:
                    case Enums.Instruction.R:
                        Rotate(instruction);
                        break;
                    case Enums.Instruction.M:
                        Move();
                        break;
                }
            }
            return PrintPosition();
        }

        public void Rotate(Enums.Instruction rotation)
        {
            switch (rotation)
            {
                case Enums.Instruction.L:
                    switch (Orientation)
                    {
                        case Enums.Orientation.N:
                            //W
                            Orientation = Enums.Orientation.W;
                            break;
                        case Enums.Orientation.S:
                            //E
                            Orientation = Enums.Orientation.E;
                            break;
                        case Enums.Orientation.E:
                            //N
                            Orientation = Enums.Orientation.N;
                            break;
                        case Enums.Orientation.W:
                            //S
                            Orientation = Enums.Orientation.S;
                            break;
                    }
                    break;
                case Enums.Instruction.R:
                    switch (Orientation)
                    {
                        case Enums.Orientation.N:
                            //E
                            Orientation = Enums.Orientation.E;
                            break;
                        case Enums.Orientation.S:
                            //W
                            Orientation = Enums.Orientation.W;
                            break;
                        case Enums.Orientation.E:
                            //S
                            Orientation = Enums.Orientation.S;
                            break;
                        case Enums.Orientation.W:
                            //N
                            Orientation = Enums.Orientation.N;
                            break;
                    }
                    break;
            }

        }

        public void Move()
        {
            switch (Orientation)
            {
                case Enums.Orientation.N:
                    if (CheckValidMove(Enums.Direction.Y, 1))
                    {
                        Y++;

                    }
                    break;
                case Enums.Orientation.S:
                    if (CheckValidMove(Enums.Direction.Y, -1))
                    {
                        Y--;

                    }
                    break;
                case Enums.Orientation.E:
                    if (CheckValidMove(Enums.Direction.X, 1))
                    {
                        X++;

                    }
                    break;
                case Enums.Orientation.W:
                    if (CheckValidMove(Enums.Direction.X, -1))
                    {
                        X--;

                    }
                    break;
            }
        }

        public bool CheckValidMove(Enums.Direction dir, int amount)
        {
            switch (dir)
            {
                case Enums.Direction.X:
                    if (amount == 1)
                    {
                        if (X + 1 > Plateau.X) return false;
                        return true;
                    }
                    else if (amount == -1)
                    {
                        if (X - 1 < 0) return false;
                        return true;
                    }
                    break;
                case Enums.Direction.Y:
                    if (amount == 1)
                    {
                        if (Y + 1 > Plateau.Y) return false;
                        return true;
                    }
                    else if (amount == -1)
                    {
                        if (Y - 1 < 0) return false;
                        return true;
                    }
                    break;
            }
            return false;

        }

        public string PrintPosition()
        {
            string position = $"{X}, {Y}, {Orientation}";
            Console.WriteLine(position);
            return position;
        }
    }
}
