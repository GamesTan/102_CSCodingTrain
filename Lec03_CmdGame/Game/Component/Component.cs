using System;

namespace GamesTan.Lec03_CmdGame {
    public class Component {
        public virtual void Awake() {
            Debug.Log($" {GetType().Name} Awake");
        }
        public virtual void Update(float dt) {
            Debug.Log($"\t\t {GetType().Name} Update");
        }
    }



}
