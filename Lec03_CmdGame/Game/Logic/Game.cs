using System;

namespace GamesTan.Lec03_CmdGame {
    public class GameState {
        // 单例模式  全局唯一的实例 
        public static GameState Instance { get; private set; } = new GameState();
        // 私有构造函数 外面不能创建对象
        private GameState() { }

        public EGameState state;
        public int score;

        public override string ToString() {
            return $"state:{state}  score:{ score}";
        }
    }


    public class Game : ILifeCycle {
        public World world ;
        public EGameState state;
        public void Awake() {
            Debug.Log($" {GetType().Name} Awake");
            world = new World();
            world.Awake();
            // TODO Create Actors 
            world.AddActor(CreatePlayer(1000, 40));
            world.AddActor(CreateEmemy(100, 10));
            world.AddActor(CreateEmemy(100, 10));
            world.AddActor(CreateEmemy(100, 10));
        }

        Actor CreatePlayer(int health,int damage) {
            var player = new Player();
            InitActor(player, health, damage);
            player.AddComponent(new PlayerAI());
            return player;
        }
        Actor CreateEmemy(int health, int damage) {
            var enemy = new Enemy();
            InitActor(enemy,health, damage);
            enemy.AddComponent(new EnemyAI());
            return enemy;
        }

        private void InitActor(Actor actor,int health, int damage) {
            actor.world = world;
            actor.damage = damage;
            actor.health = health;
            actor.pos = world.GetRandomPos();
            //Console.WriteLine(actor.pos);
            actor.AddComponent(new HurtEffect());
            actor.AddComponent(new Skill());
        }
        public void Update() {
            if (GameState.Instance.state != EGameState.Playing) return;

            Debug.Log($" {GetType().Name} Update  FrameCount {Time.FrameCount}");
            world.Update();
            CheckGameState();
            world.Render();

            Time.FrameCount++;
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
