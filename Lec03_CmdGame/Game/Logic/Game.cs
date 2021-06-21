﻿using System;

namespace GamesTan.Lec03_CmdGame {

    public class Game : ILifeCycle {
        public World world ;
        public EGameState state;
        public void Awake() {
            Debug.Log($" {GetType().Name} Awake");
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

        private void InitActor(Actor actor,int health, int damage) {
            actor.world = world;
            actor.damage = health;
            actor.health = damage;
            actor.pos = world.GetRandomPos();
            //Console.WriteLine(actor.pos);
            actor.AddComponent(new HurtEffect());
            actor.AddComponent(new Skill());
        }
        public void Update() {
            Time.deltaTime = 0.1f;
            Debug.Log($" {GetType().Name} Update  FrameCount {Time.FrameCount}");
            world.Update();
            Time.FrameCount++;
        }

    }

}
