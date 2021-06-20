using System;
using System.Collections.Generic;

namespace GamesTans.Lec03_CmdGame {
    public class World {
        public Vector2 xRange;
        public Vector2 yRange;

        public RenderEngine renderer;
        public List<Actor> actors = new List<Actor>();

        public void Awake() {
            renderer = new CmdRenderEngine();
            // TODO 临时代码 配置初始化 所有的角色
            int i = 0;
            actors.Add(CreateActor<Player, PlayerAI>(new Vector2(3, 5), 300, 20));
            actors.Add(CreateActor<Enemy, EnemyAI>(new Vector2(2, 5), 100, 10));
            actors.Add(CreateActor<Enemy, EnemyAI>(new Vector2(3, 3), 100, 10));
            actors.Add(CreateActor<Enemy, EnemyAI>(new Vector2(1, 5), 100, 10));

            foreach (var item in actors) {
                item.Awake();
            }
        }

        public T CreateActor<T, T2>(Vector2 pos, int health, int damage)
            where T : Actor, new()
            where T2 : Component, new() {
            var actor = new T();
            actor.pos = new Vector2(3, 5); actor.health = 300; actor.damage = 20;
            actor.AddComponent(new Skill());
            actor.AddComponent(new HurtEffect());
            actor.AddComponent(new T2());
            return actor;
        }

        public void Update() {
            Time.FrameCount++;
            Console.WriteLine($"-----------------  Frame {Time.FrameCount} ----------------");
            Time.deltaTime = 0.1f;// TODO 获取真正的 距离上一帧的 时间差 
            // 更新逻辑 
            foreach (var item in actors) {
                item.Update();
            }
            // 渲染
            Render();
        }

        public void Render() {
            var info = GetRenderInfos();
            renderer.Render(info);
        }

        private RenderInfos GetRenderInfos() {
            return new RenderInfos(); // TODO 获取真正的渲染
        }

    }



}
