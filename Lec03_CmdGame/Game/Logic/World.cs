using System.Collections.Generic;

namespace GamesTan.Lec03_CmdGame {
    public class World : ILifeCycle {
        public Vector2 xRange = new Vector2(-10, 10);
        public Vector2 yRange = new Vector2(-10, 10);
        RenderEngine renderEngine;
        private List<Actor> allActor = new List<Actor>();
        public const int MaxActorTypeCount = 100;
        private int[] actorCount = new int[MaxActorTypeCount];
        private void OnActorCreate(Actor actor) {
            actorCount[actor.Type]++;
        }
        private void OnActorDestroy(Actor actor) {
            actorCount[actor.Type]--;
        }
        public int GetActorCount(int type) {
            return actorCount[type];
        }


        public Vector2 GetRandomPos() {
            var x = RandomUtil.Range(xRange.x, xRange.y);
            var y = RandomUtil.Range(yRange.x, yRange.y);
            return new Vector2(x, y);
        }

        public void AddActor(Actor actor) {
            allActor.Add(actor);
            OnActorCreate(actor);
            actor.Awake();
        }
        public Actor FindTarget(Vector2 pos, int type) {
            float lastDist = float.MaxValue;
            Actor target = null;
            foreach (var item in allActor) {
                if (item.health > 0 && item.Type != type) {
                    var dist = (item.pos - pos).magnitude;
                    if (dist < lastDist) {
                        target = item;
                        lastDist = dist;
                    }
                }
            }
            return target;
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

            for (int i = allActor.Count - 1; i >= 0; --i) {
                if (allActor[i].health < 0) {
                    OnActorDestroy(allActor[i]);
                    allActor.RemoveAt(i);
                }
            }
        }
        public void Render() {
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
            val.AddExtInfo(GameState.Instance);
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
