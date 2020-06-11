using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TaskMartianRobots
{
    class InputManager
    {
        private List<Regex> regxs = new List<Regex>() {
            new Regex(@"^\d{1,2}\ \d{1,2}"),
            new Regex(@"^\d{1,2}\ \d{1,2}\ [NSEW]", RegexOptions.IgnoreCase),
            new Regex(@"^[RLF]+", RegexOptions.IgnoreCase)};

        
        public void TypeInfo()
        {
            Console.Clear();
            Console.WriteLine(
                "1 line: the upper-right coordinates\n" +
                "2,4,6... lines: robot n position\n" +
                "3,5,7... lines: robot n instructions\n" +
                "Type \"run\" to begin" +
                "Upper/lower cases are ignored");
        }
        public List<string> GetInputStrings()
        {
            TypeInfo();
            string types;
            string input;
            List<string> output = new List<string>();


            while (true)
            {
                try {

                    types = Console.ReadLine();


                    if (types.ToLower() != "run")
                    {
                        if (output.Count == 0)
                        {
                            input = GetLine(types, regxs[0]);//1 line

                            output.Add(input);
                        }
                        else
                        {
                            switch (output.Count % 2)
                            {
                                case (1):
                                    input = GetLine(types, regxs[1]);//2,4,6 line

                                    output.Add(input);
                                    break;
                                case (0):
                                    input = GetLine(types, regxs[2]);//3,5,7 line

                                    output.Add(input);
                                    break;
                            }
                        }

                    }
                    else
                    {
                        if (output.Count >= 3)
                        {
                            break;
                        }
                        else
                        {
                            switch (output.Count)
                            {
                                case (0):
                                    Console.WriteLine("You should type surface size first");
                                    break;
                                default:
                                   Console.WriteLine("There must be at least one robot and one commands line");
                                    break;
                            }
                          
                        }
                    }
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine(aex.Message);
                }
                }
            return output;
        }
        private static string GetLine(string input, Regex r)
        {
            

                input = input.Trim();
                if (r.IsMatch(input) && input.Length <= 100)
                {

                    if (input.Length > r.Match(input).Length)
                    {
                        Console.WriteLine($"Do you mean this?: {input.Substring(0, r.Match(input).Length)}\n(type y or press Enter as Yes/n or whatewer else as No)");

                        string input2 = Console.ReadLine();
                        if (input2.ToLower() == "y" || input2 == "")
                        {
                            input = input.Substring(0, r.Match(input).Length);
                            Console.WriteLine(input);
                            return input;

                        }
                        else
                        {
                            if (input2.ToLower() == "n")
                            {
                                //TypeInfo();
                                throw new ArgumentException("Input string is not valid");
                            }
                            else
                            {
                                //TypeInfo();
                                throw new ArgumentException("Input string is not valid");
                            }
                        }
                    }
                    else
                    {
                        //TypeInfo();
                        return input;
                    }

                }
                else
                {
                    throw new ArgumentException("Input string is not valid");
                    
                }
        }
    }
}
