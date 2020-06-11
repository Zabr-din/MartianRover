using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TaskMartianRobots
{
    class MartianManager
    {
        public Surface Surface { get; set; }
        public List<Robot> Robots { get; set; }
        public List<List<Commands>> RobotsCommands { get; set; }
        private List<Position> BlackListPositions { get; set; }

        private Position CurrentPosition { get; set; }

        public string GetOutput()
        {
            string output = "";
            foreach (var robot in Robots)
            {
                output += robot.Position.ToString();
                if (robot.IsLost)
                {
                    output += " LOST\n";
                }
                else
                {
                    output += "\n";
                }
            }
            return output;
        }
        public void RunTask()
        {
            BlackListPositions = new List<Position>();
            
            for (int i = 0; i < Robots.Count; i++)
            {
                foreach (var command in RobotsCommands[i])
                {
                    SaveCurrentPosition(Robots[i].Position);
                    Robots[i].Move(command, BlackListPositions);
                    if (Robots[i].Position.X > Surface.XAxisMax || Robots[i].Position.X < 0
                        || Robots[i].Position.Y > Surface.YAxisMax || Robots[i].Position.Y < 0)
                    {
                        Robots[i].IsLost = true;
                        Robots[i].Position = CurrentPosition;
                        BlackListPositions.Add(CurrentPosition);
                        break;
                    }

                }
                
            }
            
        }
        private void SaveCurrentPosition(Position p)
        {
            CurrentPosition = new Position(p.X, p.Y, p.Direction);
        }
        public void InitializeVariables(List<string> input)
        {
        
            Surface = new Surface(
            Convert.ToInt32(input[0].Split(' ')[0]),
            Convert.ToInt32(input[0].Split(' ')[1]));

            Robots = new List<Robot>();
            

            RobotsCommands = new List<List<Commands>>();
            

            for (int i = 1; i < input.Count; i+=2)
            {
                Robot robot = new Robot();
                robot.Position = new Position();
                robot.Position.X = Convert.ToInt32(input[i].Split(' ')[0]);
                robot.Position.Y = Convert.ToInt32(input[i].Split(' ')[1]);
                switch (input[i].Split(' ')[2].ToUpper())
                {
                    case ("N"):
                        robot.Position.Direction = Directions.N;
                        break;
                    case ("E"):
                        robot.Position.Direction = Directions.E;
                        break;
                    case ("S"):
                        robot.Position.Direction = Directions.S;
                        break;
                    case ("W"):
                        robot.Position.Direction = Directions.W;
                        break;
                }//Set a robot direction
                Robots.Add(robot);

                List<Commands> commandLine = new List<Commands>();
                foreach (var item in input[i+1].ToUpper().ToCharArray())
                {
                    switch (item)
                    {
                        case ('R'):
                            commandLine.Add(Commands.R);
                            break;
                        case ('L'):
                            commandLine.Add(Commands.L);
                            break;
                        case ('F'):
                            commandLine.Add(Commands.F);
                            break;
                    }//Commands parse

                }
                RobotsCommands.Add(commandLine);
            }

     


        }

       
    }
}
