using System;
using System.Collections.Generic;

namespace GamesTans.Lec03_CmdGame {
    public class Time {
        public static int FrameCount;
        public static float deltaTime;
    }
    public class Actor {
        public string name;
        public Vector2 pos;
        public int damage;
        public int health;

        static int globalActorId = 0;

        public List<Component> components = new List<Component>();


        public void AddComponent(Component comp) {
            components.Add(comp);
        }

        public Actor() {
            this.name = GetType().Name + (globalActorId++);
        }

        public void Awake() {
            Console.WriteLine($" {name} awake");
        }
        public void Update() {
            Console.WriteLine($" {name} Update");
            foreach (var item in components) {
                item.Update(Time.deltaTime);
            }
        }
    }
}
