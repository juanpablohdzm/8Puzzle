

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _8Puzzle
{

    class AStar
    {
        public static int MATRIX_SIZE = 3;

        public Dictionary<string, string> Parents = new Dictionary<string, string>();

        public string MoveUp(string State)
        {
            //Get the position of the white space
            int Position = State.IndexOf("B");
            int Row = Position / MATRIX_SIZE;
            int Col = Position % MATRIX_SIZE;

            //Move up...
            Row--;
            if (Row < 0)
                return  State = "";

            //Get the new position of the white space
            int NewPosition = Row * MATRIX_SIZE + Col;

            string FirstSection = State.Substring(0, NewPosition);
            string NewCharacter = State.Substring(NewPosition, 1);
            string MiddleSection = State.Substring(NewPosition+1, (Position - NewPosition-1));
            string Reminder = State.Substring(Position+1);

            State = FirstSection + "B" + MiddleSection + NewCharacter + Reminder;
            return State;
        }

        public string MoveDown(string State)
        {
            //Get the position of the white space
            int Position = State.IndexOf("B");
            int Row = Position / MATRIX_SIZE;
            int Col = Position % MATRIX_SIZE;

            //Move down...
            Row++;
            if (Row >= MATRIX_SIZE)
                return State = "";

            //Get the new position of the white space
            int NewPosition = Row * MATRIX_SIZE + Col;

            string FirstSection = State.Substring(0, Position);
            string NewCharacter = State.Substring(NewPosition, 1);
            string MiddleSection = State.Substring(Position + 1, (NewPosition - Position-1));
            string Reminder = State.Substring(NewPosition+1);

            State = FirstSection + NewCharacter + MiddleSection + "B" + Reminder;
            return State;
        }

        public string MoveLeft(string State)
        {
            //Get the position of the white space
            int Position = State.IndexOf("B");
            int Row = Position / MATRIX_SIZE;
            int Col = Position % MATRIX_SIZE;

            //Move down...
            Col--;
            if (Col < 0)
                return State = "";

            //Get the new position of the white space
            int NewPosition = Row * MATRIX_SIZE + Col;

            string FirstSection = State.Substring(0, NewPosition);
            string NewCharacter = State.Substring(NewPosition, 1);
            string Reminder = State.Substring(Position + 1);

            State = FirstSection + "B" + NewCharacter + Reminder;
            return State;
        }

        public string MoveRight(string State)
        {
            //Get the position of the white space
            int Position = State.IndexOf("B");
            int Row = Position / MATRIX_SIZE;
            int Col = Position % MATRIX_SIZE;

            //Move down...
            Col++;
            if (Col >= MATRIX_SIZE)
                return State = "";

            //Get the new position of the white space
            int NewPosition = Row * MATRIX_SIZE + Col;

            string FirstSection = State.Substring(0, Position);
            string NewCharacter = State.Substring(NewPosition, 1);
            string Reminder = State.Substring(NewPosition + 1);

            State = FirstSection + NewCharacter + "B" + Reminder;
            return State;
        }

       

        public void CheckWalkableNodes(Node CurrentNode, List<Node> WalkableNodes)
        {
            string PossibleState = "";

            PossibleState = MoveUp(CurrentNode.State);
            if(PossibleState!="")
            {
                Node node = new Node(PossibleState);
                node.AddAccumulateCost(CurrentNode.AccumulateCost);
                WalkableNodes.Add(node);
            }

            PossibleState = MoveDown(CurrentNode.State);
            if (PossibleState != "")
            {
                Node node = new Node(PossibleState);
                node.AddAccumulateCost(CurrentNode.AccumulateCost);
                WalkableNodes.Add(node);
            }

            PossibleState = MoveLeft(CurrentNode.State);
            if (PossibleState != "")
            {
                Node node = new Node(PossibleState);
                node.AddAccumulateCost(CurrentNode.AccumulateCost);
                WalkableNodes.Add(node);
            }

            PossibleState = MoveRight(CurrentNode.State);
            if (PossibleState != "")
            {
                Node node = new Node(PossibleState);
                node.AddAccumulateCost(CurrentNode.AccumulateCost);
                WalkableNodes.Add(node);
            }

        }

        public bool Search(Node Start,Node CurrentNode)
        {
            if (Parents.Count != 0) { Parents.Clear(); }

            //Keep track of visited
            LinkedList<string> Visited = new LinkedList<string>();

            //Create a list for A*
            List<Node> Agenda = new List<Node>();

            Agenda.Add(Start);
            Visited.AddLast(Start.State);

            while (Agenda.Count() !=0)
            {
                CurrentNode = Agenda[0];       
                Agenda.RemoveAt(0);    

                if (CurrentNode.State == Node.FinishSate)
                    return true;

                List<Node> WalkableNodes = new List<Node>();
                CheckWalkableNodes(CurrentNode,WalkableNodes);

                foreach(Node node in WalkableNodes)
                {
                    if(!Visited.Contains(node.State))
                    {
                        Visited.AddLast(node.State);

                        Parents.Add(node.State, CurrentNode.State);

                        Agenda.Add(node);

                    }
                }
                Agenda.Sort();

            }
            return false;
        }
    }
}
