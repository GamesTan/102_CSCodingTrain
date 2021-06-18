using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTan.Lec03_CmdGame {
    public class Game {
        public static Game Instance;
        List<Enemy> allEnemies = new List<Enemy>();
        List<Player> allPlayers = new List<Player>();

        public void Awake() {
            Instance = this;
            Console.WriteLine("DoAwake()");
            int id = 0;
            allEnemies.Add(CreateEnemy(id++, 200, 20));
            allEnemies.Add(CreateEnemy(id++, 200, 20));
            allEnemies.Add(CreateEnemy(id++, 200, 20));
            allPlayers.Add(CreatePlayer(id++, 1000, 40));
        }
        public void OnDied(Entity entity) {
            Console.WriteLine($"{entity.name} died");
            if (entity is Enemy enemy) {
                _OnDied(enemy);
            } else {
                _OnDied((Player)entity);
            }
        }
        private void _OnDied(Enemy entity) {
            allEnemies.Remove(entity);
        }
        private void _OnDied(Player entity) {
            allPlayers.Remove(entity);
        }

        public Enemy GetEnemy() {
            if (allEnemies.Count > 0) return allEnemies[0];
            return null;
        }
        public Player GetPlayer() {
            if (allPlayers.Count > 0) return allPlayers[0];
            return null;
        }


        private static Player CreatePlayer(int id, int health, int damage) {
            var entity = new Player() { name = typeof(Player).Name + id, health = health, damage = damage };
            entity.Awake();
            return entity;
        }

        private static Enemy CreateEnemy(int id, int health, int damage) {
            var entity = new Enemy() { name = typeof(Enemy).Name + id, health = health, damage = damage };
            entity.Awake();
            return entity;
        }

        public bool IsGameOver = false;
        public void Update() {
            if (IsGameOver) return;
            Console.WriteLine("Update()");
            foreach (var item in allEnemies) {
                item.Update();
            }
            foreach (var item in allPlayers) {
                item.Update();
            }

            // 游戏胜利
            if (allEnemies.Count == 0) {
                Console.WriteLine("Game Win ");
                IsGameOver = true;
            }
            // 游戏失败
            if (allPlayers.Count == 0) {
                Console.WriteLine("Game Loss ");
                IsGameOver = true;
            }

        }
    }
}
