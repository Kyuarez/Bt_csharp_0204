﻿namespace bt_csharp_0217
{
    /* [02.17]
     **********
     * P      *
     *        *
     *        *        
     *   M    *        
     *        *        
     *        *        
     *       G*        
     **********
     */


    internal class Program
    {
        static void Main(string[] args)
        {
            Engine engine = Engine.Instance;
            engine.Load();
            engine.Run();
            //engine.Stop();
        }
    }
}
