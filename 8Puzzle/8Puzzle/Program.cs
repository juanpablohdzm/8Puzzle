using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            AStar aStar = new AStar();

            //Node StartNode = new Node("123B46758");
            Node StartNode = new Node("7245B6831");
            Node CurrentNode = new Node("12345678B");
            Dictionary<string, string> Parents = aStar.Parents;
            string CurrentState = "";

            if(aStar.Search(StartNode, CurrentNode))
            {
                Console.WriteLine("Solution\n");
                CurrentState = CurrentNode.State;
                while(CurrentState != StartNode.State)
                {

                    Console.WriteLine(CurrentState);
                    Console.WriteLine();
                    CurrentState = Parents[CurrentState];
                }
                Console.WriteLine(CurrentState);
            }

            Console.ReadKey();



        }
    }
}
