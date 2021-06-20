using System;

namespace GamesTans.Lec03_CmdGame {
    public class Component {
        public virtual void Update(float dt) {
            Console.WriteLine("\t" + GetType().Name + " Update ");
        }
    }



}
