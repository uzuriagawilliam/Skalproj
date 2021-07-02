using System;
using System.Collections;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();//Jag blandar övinig ett och två i ExamineList()
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
           //1. Stcken fungerar enligt FIFO prinsipen det vill säga first in first out.
           //   I heapen står alla object i kön tillgengliga hela tiden
           //2. Valee types är alla den som hör till System.ValueType
           //   Reference Types hör till System.Object.
           //   Reference Types lagras på heapen och lagras både på heapen och stacken
           //3. MyInt x och MyInt y är av typen reference och pekar på en adress. Så när y.MyValue ändrar innehållet på adressen komer x att få den nya innehpllet som finns på  adressen. 
            
            Queue queue = new Queue();//Create an object av klassen Queue (Såg senare att det finns redan en fördefinerad Queue class)

           
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Please type you choose."
                    + "\n'+' Before the name if you want tor add aperson fron the quewe"
                    + "\n'-' if you want tor remove aperson fron the quewe"
                    + "\n'0' to exit");

                string input = " ";
                try
                {
                    input = Console.ReadLine();//               
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                char nav = input[0];
                string value = input.Substring(1);


                switch (nav)
                {
                    case '+':
                        {
                            //theList.Add(value);//En element löggs i kön
                            queue.QueueHandler('+', value);//En element löggs i kön
                            break;
                        }
                    case '-':
                        {
                            //q.TestQueue('-', value, theList);
                            queue.QueueHandler('-', value);//Första element i kön tas bort från kön
                            break;
                        }
                    case '0':
                        {
                            Console.Clear();//Tillbaka till menyn
                            flag = false;
                            break;
                        }

                }

                var capacity = queue.theList.Capacity;
                Console.WriteLine($"Total capacity now {capacity} elements. {queue.theList.Count} Personer i kön: ");
                foreach (string s in queue.theList)
                {
                    Console.WriteLine(s);
                }


                //F 2. Listan ökar efter den fjardet element läggs i listan
                //F 3. Listan ökar med 4 elements till 8 och sedan till 16, 32, 64 ...
                //F 4. Listan ökar inte i samma tack eftersson ökar med 4 elementer åt gången
                //F 5. Listan minskar inte kapacitteten när elementer tas bort 
                //F 6. Man kan använda en array när man vet exct hur många elemeter som behövs
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()//Jag blandar övinig ett och två i ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            
            bool flag = true;
            string userImput;
            string tmpString; 
            int count;
            do
            {
                tmpString = "";
                userImput = "";

                Stack<char> stack = new Stack<char>();
                
                Console.WriteLine("Type in word to get reversed. 0 to exit");                
                userImput = Console.ReadLine();

                if (userImput == "0") flag = false;

                count = userImput.Length;

                for (int y = 0; y < userImput.Length; y++)
                {
                    stack.Push(userImput[y]);
                }
                foreach (var i in stack)
                {
                    tmpString += i ;
                }
                Console.WriteLine(tmpString);
            } while (flag);
            
        }

        static void CheckParanthesis()
        {
            /*
             * Todo: Om man startar sökning med en en close parenthes " ),],}" spricker funktionen
             */
            string userImput= "";
            Console.WriteLine("Type a string to check for parentheses");
            userImput = Console.ReadLine();

            char[] testStr = { };
 

            testStr = userImput.ToCharArray(0, userImput.Length);

            List<char> list = new List<char>();
             string[] tmpString= { };

            for (int i = 0; i < testStr.Length; i++)
			{

                char t = testStr[i];

                if( (t == ')' || t == ']' || t == '}') && (list.Count == 0))
                {
                    Console.WriteLine("Ike välformad sträng");
                    Console.ReadKey();
                    return;
                }
                

                if ((t == '(') || (t == '[') || (t == '{'))
                {
                    //copy t till tmpStr
                    list.Add(testStr[i]);
                }

                if (t == ')')
                {
                    //kolla i vilke pos "(" ligger. Om det ligger sist i tmpString  då tas den bort och programmet forsätter
                    int l = 0;
                    l = list.Count;
                    if (list[l - 1] == '(')
                    {
                        list.Remove('(');
                        continue;
                    }
                    else //
                    {
                        Console.WriteLine("Ike välformad sträng");
                        Console.ReadKey();
                        return;
                    }

                }
                if (t == ']')
                {
                    //kolla i vilke pos "[" ligger. Om det ligger sist i tmpString  då tas den bort och programmet forsätter
                    int l = 0;
                    l = list.Count;
                    if (list[l - 1] == '[')
                    {
                        list.Remove('[');
                        continue;
                    }
                    else 
                    {
                        Console.WriteLine("Ike välformad sträng");
                        Console.ReadKey();
                        return;
                    }

                }
                if (t == '}')
                {
                    //kolla i vilke pos "{" ligger. Om det ligger sist i tmpString då tas den bort och programmet forsätter
                    int l = 0;
                    l=list.Count;
                    if (list[l-1] == '{')
                    {
                        list.Remove('{');
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Ike välformad sträng");
                        Console.ReadKey();
                        return;
                    }


                }
            }

            if (list.Count != 0)
            {
                Console.WriteLine("Ike välformad sträng");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Välformad sträng");
                Console.ReadKey();
            }
        }
   
   
    }
    

}

 


