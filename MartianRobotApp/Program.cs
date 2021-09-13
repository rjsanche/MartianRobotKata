using MartianRobot;
using System;

namespace MartianRobotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, this is Martian Robot app!");
            Console.WriteLine("The surface of Mars can be modelled by a rectangular grid around which robots are\n" +
                              "able to move according to instructions provided from Earth");
            Console.WriteLine("Inputs are three lines:\n");
            Console.WriteLine("\tThe first line of input is the upper-right coordinates of the rectangular world, the");
            Console.WriteLine("\tlower - left coordinates are assumed to be 0, 0.");
            Console.WriteLine("\tThe remaining input consists of a sequence of robot positions and instructions (two");
            Console.WriteLine("\tlines per robot");
            Console.WriteLine("\tA position consists of two integers specifying the initial coordinates of the robot");
            Console.WriteLine("\tand an orientation(N, S, E, W), all separated by whitespace on one line");
            Console.WriteLine("\tA robot instruction is a string of the letters \"L\", \"R\", and \"F\" on one line");
            Console.WriteLine();
            Console.WriteLine("Press enter key after each line, i.e ");
            Console.WriteLine("\t5 3");
            Console.WriteLine("\t1 1 E");
            Console.WriteLine("\tRFRFRFRF");
            Console.WriteLine("Receive following otuput:");
            Console.WriteLine("\t3 2 N");
            Console.WriteLine("\tFRRFLLFFRRFLL");
            Console.WriteLine("Receive following otuput:");
            Console.WriteLine("\t3 3 N LOST");
            Console.WriteLine("\t0 3 W");
            Console.WriteLine("\tLLFFFRFLFL");
            Console.WriteLine("Receive following otuput:");
            Console.WriteLine("\t4 2 N");
            Console.WriteLine();
            Console.WriteLine();
            string gridCoordinates = Console.ReadLine();
            MartianRobotEngine robot = new MartianRobotEngine();
            robot.SetGridBounds(gridCoordinates);
            while (true)
            {
                string initialPosition = Console.ReadLine();
                string instructions = Console.ReadLine();
                robot.SetInitialPosition(initialPosition);
                robot.ProcessCommands(instructions);
                Console.WriteLine($"{robot.GetPosition()} {robot.GetOrientation()} {robot.GetLostValue()}");
            }

        }
    }
}
