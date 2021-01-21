using System;

namespace MageBattle
{
    public class Mage
    {
        static Random Gen = new Random();
        private string name;
        private Stat<int> hp= new Stat<int>();
        private Stat<int> m_dodge =new Stat<int> ();
        private Stat<int> m_damage = new Stat<int>(); //garanteed damage on top of random
        private Stat<int> m_focus= new Stat<int>(); //likelyness to hit
        private Stat<int> m_defense= new Stat<int>();
        private string m_frase;
        private string elementType;

        
        public Mage(string batteler, int damage, int dodge, int focus, int defense, string frase,string element)
        { //tar in val av karaktär med stats, vilka tillhör den instansen. 
          //om har tid gör om karaktärer till 6 separata subklasser av Mage användning av arv
           name = batteler;
           m_damage.value = damage;
           m_defense.value = defense;
           m_dodge.value = dodge;
           m_focus.value = focus;
           m_frase= frase;
           elementType = element;
           hp.value= 50;

        }
         public void Attack(Mage target) // to hit d20 + attacker focus vs oponent dodge, Mage target är andra spelaren 
         {
           int attack = Gen.Next(20) + m_focus.value + m_focus.modifier;
           if(attack >= target.m_dodge.value+target.m_dodge.modifier)//on hit: d5+ d5+ damage vs oponent defense
           {
               int damageAmount = Gen.Next(5) + Gen.Next(5) + m_damage.value+m_damage.modifier-(target.m_defense.value+target.m_defense.modifier);
              target.hp.modifier-=damageAmount;
              Console.WriteLine(target.name + m_frase + " and takes " + damageAmount + " amount of damage");
              
           }
           else
           {
               Console.WriteLine(target.name+" evades the attack");
           }
           

           m_defense.modifier = 0;
           m_dodge.modifier =0;
           m_focus.modifier = 0;
           m_damage.modifier = 0;



         }
         public void Defend() // defens +10
         {
             m_defense.modifier = 10;
             Console.WriteLine(name+" Surounds themself in a protective sheald made out "+ elementType);

         }
         public void Chanell() // focus +3 & damage +5 (stacks on repeat) dodge -2
         {
             m_dodge.modifier = -2;
             m_focus.modifier+=3;
             m_damage.modifier+=5;
             Console.WriteLine(name+" Channels their magic for a powerfull attack");

         }
        
         
         public bool StatusUpdate()
         {
             bool isAlive = true;
             if(hp.value - hp.modifier <= 0) // value grund hp
             {
                 int lifeLeft= hp.value - hp.modifier;

                 isAlive=false;
                 Console.WriteLine(name+" has"+ lifeLeft+" hp left");

             }
             return isAlive;


         }



        

    }
    
    
        


    
    
}
