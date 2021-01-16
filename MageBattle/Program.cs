using System;

namespace MageBattle
{
    class Program
    {
        static void Main(string[] args)
        {
           bool play = false;
           string A = "Teine "; //(fun note: all names comes from gaelich comes from their respective elements)
           string B = "Usige ";
           string C = "Ùir ";
           string D = "Sgàil ";
           string E = "Gaoth ";
           string F = "Leus ";
           string[] Roster = { A, B, C, D, E, F };
           string []YesNo ={"Yes","No"}
        
         
           Console.WriteLine("To play press: p");
            ConsoleKeyInfo confirm = Console.ReadKey();

            if ((confirm.KeyChar == 'p') || (confirm.KeyChar == 'P'))
            {
                play = true;

            }
           while (play== true)
           {
               Random generator = new Random(); // används senare till att styra p2 
                
                bool singleMode = false;

                Console.WriteLine("Welcome to the Mage Arena");
                Console.WriteLine("Are you alone are with a friend?");
                
                int valSingle = ChoiseMenu("Switch to single player mode?", new string[] {  });

                string single = (Roster[valSingle]);
                
                if (single=="Yes")
                {
                    singleMode= true;
                }
                
                
                Console.WriteLine("Player1 select your duelist");
                
                int valP1 = ChoiseMenu("Your choises are:", new string[] {  });

                string p1choise = (Roster[valP1]);
                Mage player1 = new Mage(p1choise);
                
                
                int valP2;
                if (singleMode==false)
                {
                    Console.WriteLine("Player2 select your duelist");
                
                    valP2 = ChoiseMenu("Your choises are:", new string[] {  });


                }
                else
                {
                    valP2 = generator.Next(6);
                }
                string p2choise = (Roster[valP2]);
                Mage player2 = new Mage(p2choise);

                
                Console.WriteLine(p1choise + "VS " + p2choise);
                Console.WriteLine("May the best spellcaster win");

           }
        
           
        }



        static int ChoiseMenu(string title, string[] options)
        {
            bool selectedValue = false;
            int currentIndex = 0;

            while (selectedValue== false)
            {
                Console.Clear();

                Console.WriteLine(title);
                for (int i = 0; i < options.Length; i++)
                {
                    if (currentIndex == i)
                    {
                        Console.WriteLine(options[i] + "<-");
                    }
                    else
                    {
                        Console.WriteLine(options[i]);
                    }

                    
                }


                ConsoleKey key = Console.ReadKey(true).Key;

                if(key== ConsoleKey.UpArrow)
                {
                    currentIndex--;

                    if(currentIndex < 0)
                    {
                        currentIndex = 0;
                    }

                }
                else if ( key== ConsoleKey.DownArrow)
                {
                    currentIndex++;

                    if(currentIndex >= options.Length)
                    {
                        currentIndex = -1;
                    }

                }

                if(key == ConsoleKey.Enter)
                {

                    selectedValue = true;
                }
                  

            }

            return currentIndex;
        }
        

    }
}
