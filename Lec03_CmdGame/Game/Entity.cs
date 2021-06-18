using System;

namespace GamesTan.Lec03_CmdGame {
    public class Entity {
        public int damage;
        public int health;
        public string name;
        public void Awake() {
            Console.WriteLine(" " + name + " Awake");
        }
        public void Update() {
            Console.WriteLine(" " + name + " update");
        }

    }
}
