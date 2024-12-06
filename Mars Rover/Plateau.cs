using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover
{
    public class Plateau
    {
        public char[,] Grid;
        public int X;
        public int Y;
        public List<Rover> Rovers = [];

        public Plateau(int x, int y)
        {
            X = x;
            Y = y;
            Grid = new char[x+1,y+1];
        }

        public void AddRover (Rover rover)
        {
            foreach (Rover _rover in Rovers)
            {
                if (_rover.Pos.X == rover.Pos.X && _rover.Pos.Y == rover.Pos.Y)
                {
                    Console.WriteLine("A rover is already occupying this position.");
                    break;
                }
            }
            rover.Pos.Plateau = this;
            Rovers.Add(rover);
        }
        public void AddRover(List<Rover> rovers)
        {
            foreach (Rover rover in rovers)
            {
                Rovers.Add(rover);
            }
        }
        public void PrintGrid()
        {
            Console.WriteLine("\n");

            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i, j] = '-';
                }
            }
            int count = 1;
            foreach (Rover rover in Rovers)
            {
                Grid[Grid.GetLength(0)-rover.Pos.Y-1, rover.Pos.X] = count.ToString()[0];
                count++;
            }

            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Console.Write($"  {Grid[i,j]} ");
                    
                }
                Console.WriteLine("\n");
            }
            
        }
    }
}
