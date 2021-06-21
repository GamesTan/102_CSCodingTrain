using System;
using System.Collections.Generic;

namespace GamesTans.Lec03_CmdGame {
    public class Time {
        public static int FrameCount;
        public static float deltaTime;
    }
    public class Actor {
        public Vector2 pos;
        public int damage;
        public int health;

        public void Awake() { }
        public void Update() { }
    }
}
