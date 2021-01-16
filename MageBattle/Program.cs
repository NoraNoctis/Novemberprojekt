using System;

namespace MageBattle
{
    class Program
    {
        static void Main(string[] args)
        {
           bool play = false;
           string A = "Teine"; //(fun note: all names comes from gaelich comes from their respective elements)
           string B = "Usige";//(which are;fire, water, earth, shadow, air, light)
           string C = "Ùir";
           string D = "Sgàil";
           string E = "Gaoth";
           string F = "Leus";
           string[] Roster = { A, B, C, D, E, F };
           string []YesNo ={"Yes","No"};
           string[]Actions = {"Attack", "Guard", "Channel your spell"};
        
         
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
                bool matchActive = true;
                bool p1Alive= true;
                bool p2Alive = true;
                
                Console.WriteLine("Welcome to the Mage Arena");
                Console.WriteLine("Are you alone are with a friend?");
                
                int valSingle = ChoiseMenu("Switch to single player mode?", new string[] {"Yes","No"});

                string single = (YesNo[valSingle]);
                
                if (single=="Yes")
                {
                    singleMode= true;
                }
                
                
                Console.WriteLine("Player1 select your duelist");
                
                int valP1 = ChoiseMenu("Your choises are:", new string[] {A, B, C, D, E, F});

                string p1choise = (Roster[valP1]);// väljer karaktär att spela som från namn i roster, detta avgör sedan stats

                Mage player1 = new Mage("",0,0,0,0,"","");
                 if (p1choise== A)
                {
                    player1 = new Mage(A,5,10,0,3," is scurged by blazing flames","fire");

                }
                if (p1choise== B)
                {
                     player1 = new Mage(B,1,10,4,3," is drenched by a roaring tidal wave","water");
                
                }
                if (p1choise== C)
                {
                    player1 = new Mage(C,3,8,2,5," is hit by rushing boulders","rock");

                }
                if (p1choise== D)
                {
                    player1 = new Mage(D,3,12,2,1," is engulfed in a cloud of shadows","shadow");

                }
                if (p1choise== E)
                {
                    player1 = new Mage(E,3,12,0,3," is hurled around by dancing winds","wind");

                }
                if (p1choise== F)
                {
                    player1 = new Mage(F,5,10,2,1," is shreded by sharp rays of light","light");

                }
                
                int valP2;
                if (singleMode==false)
                {
                    Console.WriteLine("Player2 select your duelist");
                
                    valP2 = ChoiseMenu("Your choises are:", new string[] {A, B, C, D, E, F});


                }
                else
                {
                    valP2 = generator.Next(5);
                }
                string p2choise = (Roster[valP2]);
                Mage player2 =new Mage("",0,0,0,0,"","");
                if (p2choise== A)
            {
                player2 = new Mage(A,5,10,0,3," is scurged by blazing flames","fire");
                

            }
            if (p2choise== B)
            {
                 player2 = new Mage(B,1,10,4,3," is drenched by a roaring tidal wave","water");
                
            }
            if (p2choise== C)
            {
                player2 = new Mage(C,3,8,2,5," is hit by rushing boulders","rock");
               
            }
            if (p2choise== D)
            {
                player2 = new Mage(D,3,12,2,1," is engulfed in a cloud of shadows","shadow");
                
            }
            if (p2choise== E)
            {
                player2 = new Mage(E,3,12,0,3," is hurled around by dancing winds","wind");
                
            }
            if (p2choise== F)
            {
                player2 = new Mage(F,5,10,2,1," is shreded by sharp rays of light","light");
               

            }

                
                Console.WriteLine(p1choise + "VS " + p2choise);
                Console.WriteLine("May the best spellcaster win");
                while (matchActive== true)
                {
                   
                    int actionChoiseP1;
                    actionChoiseP1= ChoiseMenu("It is your turn player 1", new string[] {"Attack", "Guard", "Channel your spell"});

                    string p1Action =(Actions[actionChoiseP1]);
                    if(p1Action=="Attack")
                    {
                        Console.WriteLine(p1choise+" Attacks "+p2choise);
                        player1.Attack(player2);

                    }
                    
                    if(p1Action=="Guard")
                    {
                        
                        player1.Defend();
                        
                    }
                    if(p1Action=="Channel your spell")
                    {
                        player1.Chanell();

                    }
                    if(p1Action=="Attack")
                    {
                        Console.WriteLine(p1choise+" Attacks "+p2choise);
                        player2.Attack(player1);

                    }
                    
                    int actionChoiseP2;
                    if (singleMode==false)
                    {
                       actionChoiseP2= ChoiseMenu("It is your turn player 1", new string[] {"Attack", "Guard", "Channel your spell"}); 
                    }
                    else
                    {
                        actionChoiseP2 = generator.Next(2);
                    }
                    

                    string p2Action =(Actions[actionChoiseP2]);
                    if(p2Action=="Guard")
                    {
                        
                        player2.Defend();
                        
                    }
                    if(p2Action=="Channel your spell")
                    {
                        player2.Chanell();

                    }
                    
                    

                    p1Alive= player1.StatusUpdate();
                    p2Alive= player2.StatusUpdate();
                    if (p1Alive == false&&p2Alive==false)
                    {
                        Console.WriteLine("It is a tie");
                        matchActive= false;
                    }
                    else if(p1Alive == true && p2Alive==false)
                    {
                        Console.WriteLine("Congratulations Player 1 "+p1choise+" is the winner");
                        matchActive = false;
                    }
                    else if(p1Alive == false && p2Alive==true)
                    {
                        Console.WriteLine("Congratulations Player 2 "+p2choise+" is the winner");
                        matchActive = false;
                    }
                    


                }

           }
        
           
        }



        static int ChoiseMenu(string title, string[] options) //

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
