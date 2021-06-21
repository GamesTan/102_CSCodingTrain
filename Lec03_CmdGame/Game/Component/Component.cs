using System;

namespace GamesTan.Lec03_CmdGame {
    public class Component {
        public virtual void Awake() {
            Console.WriteLine($" {GetType().Name} Awake");
        }
        public virtual void Update(float dt) {
            Console.WriteLine($"\t\t {GetType().Name} Update");
        }
    }



}
