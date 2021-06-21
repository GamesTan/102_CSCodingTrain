using System;

namespace GamesTan.Lec03_CmdGame {
    public class RenderEngine : IAwake {
        public virtual void Awake() {
            Debug.Log($" {GetType().Name} Awake");
        }
        public virtual void Render(RenderInfos info) {
            Debug.Log($" {GetType().Name} Update");
        }
    }



}
