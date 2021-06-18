using System;

namespace GamesTan.Lec03_CmdGame {
    public class Entity {
        public int damage;
        public int health;
        public string name;

        public int initHealth;

        public float x;
        public float y;

        public bool isHurted; // 是否被攻击了
        public float hurtTimer;
        public float hurtDuration = 0.3f; //受伤的持续时间
        public void Awake() {
            initHealth = health;
            Debug.Log(" " + name + " Awake");
        }
        public virtual void Update() {
            Debug.Log(" " + name + " update");
            hurtTimer += Game.deltaTime;
            if (hurtTimer > hurtDuration) {
                isHurted = false;
            }
        }
        const int MinAtkDistance = 2;

        public float cd = 1; // 技能cd
        public float cdTimer;


        protected void Attack(Entity target) {
            cdTimer += Game.deltaTime;
            if (cdTimer < cd) { // cd 不能攻擊
                return;
            }
            cdTimer = 0;

            if (target == null) return;
            var a = target.x - this.x;
            var b = target.y - this.y;
            var len = Math.Sqrt(a * a + b * b);

            if (len > MinAtkDistance) {
                return;
            }
            target.isHurted = true;
            target.hurtTimer = 0;

            var rawHealth = target.health;
            target.health -= damage;
            Debug.Log($"{name } atk  {target.name} dmg = {damage}  health: {rawHealth} => {target.health } ");
            if (target.health <= 0) {
                Game.Instance.OnDied(target);
            }
        }

        public override string ToString() {
            return $"{name} ({x},{y}) health:{health} damage {damage}";
        }
    }
}
