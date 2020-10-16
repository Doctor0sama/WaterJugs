using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WaterJugs
{
    class Jug
    {
        int value;
        int capacity;

        public Jug(int capacity)
        {
            Value = 0;
            this.Capacity = capacity;
        }

        public int Value { get => value; set => this.value = value; }
        public int Capacity { get => capacity; set => capacity = value; }

       
    }
    class Program
    {
        public struct Node
        {
            public int x;
            public int y;
        }

        public Node newNode()
        {
            Node n = new Node();
            n.x = 0;
            n.y = 0;
            return n;
        }

        public static Node fillX(Node n)
        {
            n.x = 4;
            return n;
        }

        public static Node fillY(Node n)
        {
            n.y = 3;
            return n;
        }

        public static Node emptyX(Node n)
        {
            n.x = 0;
            return n;
        }

        public static Node emptyY(Node n)
        {
            n.y = 0;
            return n;
        }

        public static Node transferfromX(Node n)
        {
            int old_value = n.y;
            n.y += n.x;
            n.y = n.y > 3 ? 3 : n.y;

            n.x = n.x - (n.y - old_value);
            return n;
        }

        public static Node transferfromY(Node n)
        {
            int old_value = n.x;
            n.x += n.y;
            n.x = n.x > 4 ? 4 : n.x;

            n.y = n.y - (n.x - old_value);
            return n;
        }

        static List<Node> visited = new List<Node>();

        public static Boolean Solver(Node n)
        {
            if(n.x == 1 && n.y == 0)
            {
                Console.WriteLine(n.x + ", " + n.y);
                return true;
            }

            if (visited.Contains(n) == false)
            {
                Console.WriteLine(n.x + ", " + n.y);
                visited.Add(n);
                return Solver(fillX(n)) || Solver(fillY(n)) || Solver(emptyX(n)) || Solver(emptyY(n)) || Solver(transferfromX(n)) || Solver(transferfromY(n));
            }

            else
                return false;


        }

        static void Main(string[] args)
        {
            Node root = new Node();
            root.x = 0;
            root.y = 0;

            if (Solver(root))
            {
                Console.WriteLine("Successsssss!!!!!");
            }

            else
                Console.WriteLine("epic Faaaaaaaaaaaaaaaaail!!");

            Console.ReadKey();
        }
    }
}
