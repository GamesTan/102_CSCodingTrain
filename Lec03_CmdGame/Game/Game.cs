using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTan.Lec03_CmdGame {

    public enum EGameStatus {
        Playing,
        Win,
        Loss
    }

    public class Game {
        public static char inputChar; 
        public static float deltaTime; // 距離上一幀的時間

        public static Game Instance;
        public List<Enemy> allEnemies = new List<Enemy>();
        public List<Player> allPlayers = new List<Player>();

        static Random rand = new Random();
        public EGameStatus gameStatus = EGameStatus.Playing;

        public static float RangePos(float minVal, float maxVal) {
            var num01 = (float)(rand.Next(0, 10000000) * 0.0000001);
            return num01 * (maxVal - minVal) + minVal;
        }

        public void Awake() {
            Instance = this;
            Debug.Log("DoAwake()");
            int id = 0;
            allEnemies.Add(CreateEntity<Enemy>(id++, 200, 20));
            allEnemies.Add(CreateEntity<Enemy>(id++, 200, 20));
            allEnemies.Add(CreateEntity<Enemy>(id++, 200, 20));
            allPlayers.Add(CreateEntity<Player>(id++, 1000, 40));
        }
        public void OnDied(Entity entity) {
            Debug.Log($"{entity.name} died");
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

        public const int RowCount = 21;
        public const int HalfRowCount = RowCount / 2;

        public static T CreateEntity<T>(int id, int health, int damage) where T : Entity, new() {
            float x = RangePos(-HalfRowCount, HalfRowCount);
            float y = RangePos(-HalfRowCount, HalfRowCount);
            var entity = new T() { name = typeof(T).Name + id, health = health, damage = damage };
            entity.x = x;
            entity.y = y;
            entity.Awake();
            Debug.Log($"({ x},{y})");
            return entity;
        }

        public bool IsGameOver => gameStatus != EGameStatus.Playing;
        public void Update() {
            if (IsGameOver) return;
            Debug.Log("Update()");
            foreach (var item in allEnemies) {
                item.Update();
            }
            foreach (var item in allPlayers) {
                item.Update();
            }

            // 游戏胜利
            if (allEnemies.Count == 0) {
                Debug.Log("Game Win ");
                gameStatus = EGameStatus.Win;
            }
            // 游戏失败
            if (allPlayers.Count == 0) {
                Debug.Log("Game Loss ");
                gameStatus = EGameStatus.Loss;
            }

        }
    }
}
