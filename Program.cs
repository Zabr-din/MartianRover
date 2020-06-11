using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TaskMartianRobots
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                MartianManager martianM = new MartianManager();
                InputManager inputM = new InputManager();

                inputM.TypeInfo();
                martianM.InitializeVariables(inputM.GetInputStrings());

                martianM.RunTask();

                Console.WriteLine(martianM.GetOutput());

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }

     
    }



    public enum Directions
    {
        N = 1,//North
        E = 2,//East
        S = 3,//South
        W = 4//West

    }
    public enum Commands
    {
        R = 1,//Right
        L = 2,//Left
        F = 3,//Forward

    }
}
