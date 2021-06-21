using System;
using System.Collections.Generic;

namespace GamesTan.Lec03_CmdGame {
    public class Actor {
        public virtual int Type => 0;
        public Vector2 pos;
        public int damage;
        public int health;

        public bool isHurt;

        private List<Component> components = new List<Component>();

        public void AddComponent(Component comp) {
            components.Add(comp);
            comp.Awake();
        }
        public void Awake() {
            Debug.Log($" {GetType().Name} Awake");
        }
        public void Update() {
            Debug.Log($"\t  {GetType().Name} Update");
            foreach (var item in components) {
                item.Update(Time.deltaTime);
            }

        }
    }
}
