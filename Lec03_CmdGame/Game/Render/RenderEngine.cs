using System;

namespace GamesTans.Lec03_CmdGame {
    public class RenderEngine {
        public virtual void Render(RenderInfos info) {
            Console.WriteLine(GetType().Name + " Render ");
        }

    }



}
