using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_BoatsToSavePeople_CSharp
{
    public class Boat
    {
        public Boat(int _limit, int passenger)
        {
            limit = _limit;
            passengers = new List<int> { passenger };
        }
        private List<int> passengers { get; set; }
        private int limit { get; set; }
        public int GetAvailability()
        {
            if(passengers.Count == 2)
            {
                return 0;
            }

            int totalWeight = 0;
            foreach(var passenger in passengers)
            {
                totalWeight += passenger;
            }

            return limit-totalWeight;
        }

        public void AddPassenger(int passenger)
        {
            passengers.Add(passenger);
        }

        public void PrintPassengers()
        {
            if(passengers?.Count() > 0)
            {
                Console.Write("(");
                for(int i=0; i<passengers.Count; i++)
                {
                    Console.Write($"{passengers[i]}");
                    if (i < (passengers.Count - 1))
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write(")");
            }
        }
    }
}
