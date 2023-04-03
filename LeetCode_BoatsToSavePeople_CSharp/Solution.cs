using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_BoatsToSavePeople_CSharp
{
    public class Solution
    {
        public int NumRescueBoats(int[] people, int limit)
        {
            Dictionary<int, Queue<int>> manifest = GetPassengerManifest(people, limit);
            List<Boat> boats = new();

            // load up the AT LIMIT passengers onto boats
            if (manifest.ContainsKey(limit))
            {
                while (manifest[limit].Count > 0)
                {
                    boats.Add(new Boat(limit, manifest[limit].Dequeue()));   
                }
            }

            // start general pairing
            for(int weight = limit-1; weight > 0; weight--)
            {
                if (manifest.ContainsKey(weight) && manifest[weight].Count > 0)
                {
                    LoadPassengerClass(weight, limit, manifest, boats);
                }
            }

            PrintBoats(boats);
            return boats.Count;
        }

        public Dictionary<int, Queue<int>> GetPassengerManifest(int[] people, int limit)
        {
            Dictionary<int, Queue<int>> manifest = new Dictionary<int, Queue<int>>();
            foreach(var person in people)
            {
                if (!manifest.ContainsKey(person))
                {
                    manifest.Add(person, new Queue<int>());
                }

                manifest[person].Enqueue(person);
            }

            return manifest;
        }

        public void LoadPassengerClass(int weight, int limit, Dictionary<int, Queue<int>> manifest, List<Boat> boats)
        {
            if (!manifest.ContainsKey(weight))
            {
                return;
            }
            else
            {
                while (manifest[weight].Count > 0)
                {
                    var boat = new Boat(limit, manifest[weight].Dequeue());
                    int pairingPassenger = FindPassengerPairing(limit, weight, manifest);
                    if(pairingPassenger != 0)
                    {
                        boat.AddPassenger(pairingPassenger);
                        boats.Add(boat);
                    }
                    else
                    {
                        // Case when there are no available pairing passengers
                        boats.Add(boat);
                    }
                }
            }
            
        }

        public int FindPassengerPairing(int limit, int weight, Dictionary<int, Queue<int>> manifest)
        {
            int pairingWeight = limit - weight;
            for(int i = pairingWeight; i > 0; i--)
            {
                if (manifest.ContainsKey(i))
                {
                    if(manifest[i].Count > 0)
                    {
                        return manifest[i].Dequeue();
                    }
                }
            }

            return 0;
        }

        public void PrintBoats(List<Boat> boats)
        {
            Console.Write($"{boats.Count} boats ");
            foreach(var boat in boats) 
            {
                boat.PrintPassengers();
            }
        }
    }
}
