using System;

namespace GamesTan.Lec03_CmdGame {
    public class RenderEngine : IAwake {
        public virtual void Awake() {
            Console.WriteLine($" {GetType().Name} Awake");
        }
        public virtual void Render(RenderInfos info) {
            Console.WriteLine($" {GetType().Name} Update");
        }
    }



}
