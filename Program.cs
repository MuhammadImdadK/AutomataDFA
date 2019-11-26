using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTB8653
{
    class States
    {

        public string Name;
        public bool initial;
        public bool final;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of states");
           int NoOfStates=Convert.ToInt32( Console.ReadLine());

            List<States> states;
            states = new List<States>();
            for (int i = 0; i < NoOfStates; i++)
            {
                states.Add(new States());
            }
            for (int i = 0; i < states.Count; i++)
            {
                states[i].Name = "State " + (i);
            }
            for (int i = 0; i < states.Count; i++)
            {
                states[i].final = false;
                states[i].initial = false;
            }
                string s ="select initial state by choosing from the following states\n";
            for (int i = 0; i < states.Count; i++)
            {
              
                if (i%3==0)
                {
                    s += "\n";
                }
                s += "press " + i + " for " + states[i].Name + "\t";
            }
            Console.WriteLine(s);
            int initialindex=Convert.ToInt32(Console.ReadLine());
            States nowState = new States();
            nowState = states[initialindex];
            Console.WriteLine("Enter comma seprated Final states");
            string[] finals = Console.ReadLine().Split(',');
           
            
            for (int i = 0; i < finals.Length; i++)
            {
                states[Convert.ToInt32(finals[i])].final = true;
            }
            Console.WriteLine("Enter comma seprated language");
            string[] Language=Console.ReadLine().Split(',');
            int[,] graph = new int[states.Count, Language.Length];
            for (int i = 0; i < states.Count; i++)
            {
                for (int j = 0; j < Language.Length; j++)
                {
                    Console.WriteLine("On transition "+Language[j]+" when on  "+states[i].Name+", \nstate will be changed to?\n(enter 0 for state 0, 1 for state 1 and so on so forth ) ");
                    graph[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            string choice = "a";

            do
            {
                Console.WriteLine("Enter comma seprated inputs");
                string[] input = Console.ReadLine().Split(',');
                int tracki = initialindex;
                int trackj = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < Language.Length; j++)
                    {
                        if (Language[j] == input[i])
                        {
                            trackj = j;
                        }

                    }
                    tracki = graph[tracki, trackj];

                }
                if (states[tracki].final)
                {
                    Console.WriteLine("Accepted");
                }
                else
                {
                    Console.WriteLine("Rejected");
                }
                Console.WriteLine("press an key to continue and X to exit");
                choice = Console.ReadLine().ToLower();
            } while (choice != "x");
            Console.ReadLine();
        }
    }
}
