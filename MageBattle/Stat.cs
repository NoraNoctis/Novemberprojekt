using System;


namespace MageBattle
{
    public class Stat<T>//generisk klass
    {
        //låter mig separera bas stat och modifier i instansera av klassen
        //<T> insert variabel type
        public T value;
        public T modifier;
    }
}
