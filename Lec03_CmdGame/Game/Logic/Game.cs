using System;

namespace GamesTan.Lec03_CmdGame {

    public class Time {
        public static float deltaTime;
        public static int FrameCount = 0;
    }

    public class Game : ILifeCycle {
        public World world ;
        public EGameState state;
        public void Awake() {
            Console.WriteLine($" {GetType().Name} Awake");
            world = new World();
            world.Awake();
            // TODO Create Actors 
            world.AddActor(CreatePlayer(1000, 40));
            world.AddActor(CreateEmemy(300, 10));
            world.AddActor(CreateEmemy(300, 10));
            world.AddActor(CreateEmemy(300, 10));
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

        private static void InitActor(Actor actor,int health, int damage) {
            actor.damage = health;
            actor.health = damage;
            actor.AddComponent(new HurtEffect());
            actor.AddComponent(new Skill());
        }
        public void Update() {
            Time.deltaTime = 0.1f;
            Console.WriteLine($" {GetType().Name} Update  FrameCount {Time.FrameCount}");
            world.Update();
            Time.FrameCount++;
        }

    }

}
