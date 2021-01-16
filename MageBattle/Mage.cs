using System;

namespace MageBattle
{
    public class Mage
    {
        Random Gen = new Random();
        private string name;
        public int hp;
        private int dodge;
        private int damage; //garanteed damage on top of random
        private int focus; //likelyness to hit
        private int defense;
        private string frase;

        private string A = "Teine "; //(coresponding elements; fire, water, earth, shadow, air, light)
        private string B = "Usige ";
        private string C = "Ùir ";
        private string D = "Sgàil ";
        private string E = "Gaoth ";
        private string F = "Leus ";
        
        public Mage(string batteler) // ta resultat in val, asign stats
        { 
            if (batteler== A)
            {
                name = A;
                damage= 5;
                defense=3;
                dodge=10;
                focus= 0;
                frase ="is scurged by blazing flames";

            }
            if (batteler== B)
            {
                name = B;
                damage=1;
                defense=3;
                dodge=10;
                focus=4;
                frase="is drenched by a cruching wave of water";
            }
            if (batteler== C)
            {
                name = C;
                damage=3;
                defense= 5;
                dodge=8;
                focus=2;
                frase= "is hit by rushing boulders";
            }
            if (batteler== D)
            {
                name = D;
                damage=3;
                defense=1;
                dodge=12;
                focus=2;
                frase= "is engulfed in a cloud of shadows";
            }
            if (batteler== E)
            {
                name = E;
                damage=3;
                defense=3;
                dodge=12;
                focus=0;
                frase= "is hurled around by dancing winds";
            }
            if (batteler== F)
            {
               name = F;
                damage=5;
                defense=1;
                dodge=10;
                focus=2;
                frase= "is shreded by sharp rays of light"; 

            }


        }
        

        

    }
    
    
        


    
    
}
