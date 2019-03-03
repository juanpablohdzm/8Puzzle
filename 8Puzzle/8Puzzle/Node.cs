using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Puzzle
{
    class Node :  IComparable
    {
        public static string FinishSate = "12345678B";
        public static float Porcentage = 0.5f;

        public string State;
        public int Cost;
        public int AccumulateCost;

        public Node(string State)
        {
            this.State = State;
            Cost = 1;
            AccumulateCost = Cost;
        }

        public int CalculateHeurisitcCost()
        {
            int _Cost = 0;
            int Position=0;
            for (int i = 0; i < State.Length; i++)
            {
                if (State[i] != FinishSate[i])
                    _Cost++;

            }

           return _Cost;
        }

        public void AddAccumulateCost(int value)
        {
            AccumulateCost += value;
        }

        

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Node other = obj as Node;
            if (other != null)
            {
                if ((this.AccumulateCost+this.CalculateHeurisitcCost()) < other.AccumulateCost+other.CalculateHeurisitcCost())
                    return -1;
                if ((this.AccumulateCost + this.CalculateHeurisitcCost()) > other.AccumulateCost + other.CalculateHeurisitcCost())
                    return 1;
                else
                    return 0;
            }
            else
                throw new ArgumentException("Object is not a Node");


        }
    }
}
