using System;

namespace GamesTan.Lec03_CmdGame {
    public class Entity {
        public int damage;
        public int health;
        public string name;
        public void Awake() {
            Console.WriteLine(" " + name + " Awake");
        }
        public virtual void Update() {
            Console.WriteLine(" " + name + " update");
        }
        protected void Attack(Entity target) {
            if (target == null) return;
            var rawHealth = target.health;
            target.health -= damage;
            Console.WriteLine($"{name } atk  {target.name} dmg = {damage}  health: {rawHealth} => {target.health } ");
            if (target.health <= 0) {
                Game.Instance.OnDied(target);
            }
        }
    }
}
