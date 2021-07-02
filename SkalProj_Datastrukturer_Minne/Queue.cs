using System;
using System.Collections.Generic;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    public class Queue
    {
        public List<string> theList = new List<string>();
        public void QueueHandler(char sig, string name)
        {     
            switch (sig)
            {
                case '+':
                    {
                        theList.Add(name);// En element löggs i kön                        
                        break;
                    }
               case '-':            
                    {
                        int count = theList.Count;
                        if(count == 0)//Om kön är tom hoppar vi ur switchen 
                        {
                            Console.WriteLine("The queue is empty");
                            break;
                        }
                        theList.RemoveAt(0);//Första element tas bort från kön                    
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong input");                        
                        break;
                    }
            }
            /*var capacity = theList.Capacity;
            Console.WriteLine($"Total capacity now {capacity} elements. {theList.Count} Personer i kön: ");
            foreach (string s in theList)
            {
                Console.WriteLine(s);
            }*/

        }
    }
}
