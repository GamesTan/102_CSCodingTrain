using System;
using System.Collections.Generic;

namespace GamesTan.Lec03_CmdGame {
    public class Actor {
        public virtual int Type => 0;
        public Vector2 _pos;
        public Vector2 pos {
            get => _pos;
            set {
                value = world.GetValidPos(value);
                _pos = value;
            }
        }

        public int damage;
        public int health;
        public int initHealth;// 初始血量

        public World world;

        public bool isHurt;

        private List<Component> components = new List<Component>();

        public Action<Actor> OnHurtEvent;

        public Actor FindTarget() {
            return world.FindTarget(pos, Type);
        }
        public void Attack(Actor target) {
            if (target.health <= 0) return;
            target.health -= damage;
            isHurt = true;
            target.OnHurtEvent?.Invoke(this);
            if (target.health <= 0) {
                target.OnDied();
            }
        }
        protected virtual void OnDied() { }


        public void AddComponent(Component comp) {
            components.Add(comp);
            comp.Bind(this);
            comp.Awake();
        }
        public void Awake() {
            initHealth = health;
            Debug.Log($" {GetType().Name} Awake");
        }
        public void Update() {
            Debug.Log($"\t  {GetType().Name} Update");
            foreach (var item in components) {
                item.Update(Time.deltaTime);
            }

        }
        public override string ToString() {
            return $" pos {pos} h:{health} type: {Type} isHurt:{ isHurt}";
        }
    }
}
