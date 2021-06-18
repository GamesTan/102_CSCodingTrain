using System;

namespace GamesTan.Lec03_CmdGame {
    public class Entity {
        public int damage;
        public int health;
        public string name;

        public float x;
        public float y;


        public void Awake() {
            Console.WriteLine(" " + name + " Awake");
        }
        public virtual void Update() {
            Console.WriteLine(" " + name + " update");
        }
        const int MinAtkDistance = 2;
        protected void Attack(Entity target) {
            if (target == null) return;
            var a = target.x - this.x;
            var b = target.y - this.y;
            var len = Math.Sqrt(a * a + b * b);

            if (len > MinAtkDistance) {
                return;
            }

            var rawHealth = target.health;
            target.health -= damage;
            Console.WriteLine($"{name } atk  {target.name} dmg = {damage}  health: {rawHealth} => {target.health } ");
            if (target.health <= 0) {
                Game.Instance.OnDied(target);
            }
        }
    }
}
