using System;

namespace MageBattle
{
    public class Mage
    {
        static Random Gen = new Random();
        private string name;
        public Stat<int> hp;
        private Stat<int> m_dodge;
        private Stat<int> m_damage; //garanteed damage on top of random
        private Stat<int> m_focus; //likelyness to hit
        private Stat<int> m_defense;
        private string m_frase;
        private string elementType;

        private string A = "Teine "; //(coresponding elements; fire, water, earth, shadow, air, light)
        private string B = "Usige ";
        private string C = "Ùir ";
        private string D = "Sgàil ";
        private string E = "Gaoth ";
        private string F = "Leus ";
        
        public Mage(string batteler, int damage, int dodge, int focus, int defense, string frase,string element ) // ta resultat in val, asign stats
        { 
           name = batteler;
           m_damage.value = damage;
           m_defense.value = defense;
           m_dodge.value = dodge;
           m_focus.value = focus;
           m_frase= frase;
           elementType = element;

        }
         public void Attack(Mage target) // random 20 + focus vs dodge,  on hit: random 5 + random 5 + damage vs defense
         {
           int attack = Gen.Next(20) + m_focus.value + m_focus.modifier;
           if(attack >= target.m_dodge.value+target.m_dodge.modifier)
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
             if(hp.value<=hp.modifier)
             {
                 isAlive=false;

             }
             return isAlive;


         }



        

    }
    
    
        


    
    
}
