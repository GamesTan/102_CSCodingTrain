using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTan.Lec03_CmdGame {
    public class Game {
        List<Enemy> allEnemies = new List<Enemy>();
        List<Player> allPlayers = new List<Player>();

        public void Awake() {
            Console.WriteLine("DoAwake()");
            int id = 0;
            allEnemies.Add(CreateEnemy(id++, 200, 20));
            allEnemies.Add(CreateEnemy(id++, 200, 20));
            allEnemies.Add(CreateEnemy(id++, 200, 20));
            allPlayers.Add(CreatePlayer(id++, 700, 30));
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

        public void Update() {
            Console.WriteLine("Update()");
            foreach (var item in allEnemies) {
                item.Update();
            }
            foreach (var item in allPlayers) {
                item.Update();
            }

        }
    }
}
