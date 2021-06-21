using System;
using System.Collections.Generic;

namespace GamesTan.Lec03_CmdGame {
    public interface IAwake {
        void Awake();
    }

    public interface IUpdate {
        void Update();
    }
    public interface ILifeCycle : IAwake, IUpdate {
        void Awake();
        void Update();
    }

    public class World : ILifeCycle {
        public Vector2 xRange;
        public Vector2 yRange;
        RenderEngine renderEngine;
        private List<Actor> allActor = new List<Actor>();
        public void AddActor(Actor actor) {
            allActor.Add(actor);
            actor.Awake();
        }

        public void Awake() {
            Debug.Log($" {GetType().Name} Awake");
            renderEngine = new CmdRenderEngine(); // TODO 看环境 配置 
            renderEngine.Awake();
        }

        public void Update() {
            Debug.Log($" {GetType().Name} Update");
            // 逻辑
            foreach (var item in allActor) {
                item.Update();
            }
            // 渲染
            renderEngine.Render(null);// TODO
        }
    }



}
