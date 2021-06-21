using System.Collections.Generic;

namespace GamesTan.Lec03_CmdGame {

    public class World : ILifeCycle {
        public Vector2 xRange = new Vector2(-10, 10);
        public Vector2 yRange = new Vector2(-10, 10);
        RenderEngine renderEngine;
        private List<Actor> allActor = new List<Actor>();

        public Vector2 GetRandomPos() {
            var x = RandomUtil.Range(xRange.x, xRange.y);
            var y = RandomUtil.Range(yRange.x, yRange.y);
            return new Vector2(x, y);
        }

        public void AddActor(Actor actor) {
            allActor.Add(actor);
            actor.Awake();
        }

        public void Awake() {
            Debug.Log($" {GetType().Name} Awake");
            renderEngine = new CmdRenderEngine(); // TODO 看环境 配置 
            renderEngine.SetMapSize(
                yRange.y - yRange.x + 1,
                xRange.y - xRange.x + 1);
            renderEngine.Awake();
        }

        public void Update() {
            Debug.Log($" {GetType().Name} Update");
            // 逻辑
            foreach (var item in allActor) {
                item.Update();
            }
            // 渲染
            renderEngine.Render(GetRenderInfo());
        }

        RenderInfos GetRenderInfo() {
            var val = new RenderInfos();
            foreach (var item in allActor) {
                var info = new RenderInfo();
                info.pos = item.pos;
                info.color = item.isHurt ? -1 : 1;
                info.type = item.Type;
                val.AddInfo(info);
            }
            val.AddExtInfos(allActor);
            return val;
        }

        public Vector2 GetValidPos(Vector2 pos) {
            if (pos.x < xRange.x) pos.x = xRange.x;
            if (pos.x > xRange.y) pos.x = xRange.y;
            if (pos.y < yRange.x) pos.y = yRange.x;
            if (pos.y > yRange.y) pos.y = yRange.y;
            return pos;
        }
    }



}
