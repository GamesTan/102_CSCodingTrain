using System;

namespace GamesTan.Lec03_CmdGame {

    public class Game : ILifeCycle {
        public World world;
        public EGameState state;
        public void Awake() {
            Debug.Log($" {GetType().Name} Awake");
            world = new World();
            world.Awake();
            LoadSceneFromConfig();
        }
        private void LoadSceneFromConfig() {
            var allLines = System.IO.File.ReadAllLines("../../config/init.txt");
            var nameSpace = GetType().Namespace;
            foreach (var item in allLines) {
                var strs = item.Split(',');
                int i = 0;
                var fullName = $"{nameSpace}.{strs[i++]}";
                var actor = GetType().Assembly.CreateInstance(fullName) as Actor;
                actor.health = int.Parse(strs[i++]);
                actor.damage = int.Parse(strs[i++]);
                actor.world = world;
                actor.pos = world.GetRandomPos();
                var compStrs = strs[i++].Split('|');
                foreach (var compStr in compStrs) {
                    var compFullName = $"{nameSpace}.{compStr}";
                    var comp = GetType().Assembly.CreateInstance(compFullName) as Component;
                    actor.AddComponent(comp);
                }
                world.AddActor(actor);
            }
        }

        public void Update() {
            if (GameState.Instance.state != EGameState.Playing) return;

            Debug.Log($" {GetType().Name} Update  FrameCount {Time.frameCount}");
            world.Update();
            CheckGameState();
            world.Render();

            Time.frameCount++;
        }
        private void CheckGameState() {

            // 判定胜负条件
            if (world.GetActorCount((int)EActorType.Player) == 0) {
                GameState.Instance.state = EGameState.Loss;
            }
            if (world.GetActorCount((int)EActorType.Enemy) == 0) {
                GameState.Instance.state = EGameState.Win;
            }
        }

        public bool OnUpdate(double timeSinceStart, double deltaTime) {
            Time.deltaTime = (float)deltaTime;
            Update();
            return false;
        }
        public void OnGetInput(char inputCh) {
            switch (inputCh) {
                case 'w': InputManager.inputVec = new Vector2(0, 1); break;
                case 's': InputManager.inputVec = new Vector2(0, -1); break;
                case 'a': InputManager.inputVec = new Vector2(-1, 0); break;
                case 'd': InputManager.inputVec = new Vector2(1, 0); break;
            }
        }
    }

}
