using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamesTan.Lec03_CmdGame {
    class Program {
        static void Main(string[] args) {

            var game = new Game();
            game.Awake();
            var thread = new Thread(() => {
                while (true) {
                    var info = Console.ReadKey();
                    var ch = info.KeyChar;
                    Game.inputChar = ch;
                }
            });
            thread.Start();
            
            while (true) {
                Thread.Sleep(100);
                Game.deltaTime = 0.1f;
                game.Update();
                DrawGame(game);
                Console.WriteLine(Game.inputChar);
                Game.inputChar = ' ';
            }
            Console.ReadLine();
        }

        static char[,] mapData = new char[Game.RowCount, Game.RowCount];
        private static void DrawGame(Game game) {
            // 繪製地圖
            var allPlayer = game.allPlayers;
            Console.Clear();
            // 清空 屏幕緩存
            for (int i = 0; i < Game.RowCount; i++) {
                for (int j = 0; j < Game.RowCount; j++) {
                    mapData[i, j] = ' ';
                }

            }
            foreach (var item in allPlayer) {
                var x = (int)item.x + Game.HalfRowCount;
                var y = (int)item.y + Game.HalfRowCount;
                mapData[x, y] = 'P';
            }
            var allEnemies = game.allEnemies;
            foreach (var item in allEnemies) {
                var x = (int)item.x + Game.HalfRowCount;
                var y = (int)item.y + Game.HalfRowCount;
                mapData[x, y] = 'M';
            }
            for (int row = 0; row < Game.RowCount; row++) {
                // 绘制 第 i 行
                char[] chars = new char[Game.RowCount];
                for (int col = 0; col < Game.RowCount; col++) {
                    chars[col] = mapData[col, Game.RowCount - row -1];
                }
                var str = new string(chars);
                Console.WriteLine(str);
            }
            foreach (var item in allPlayer) {
                Console.WriteLine(item);
            }
            foreach (var item in allEnemies) {
                Console.WriteLine(item);
            }
            Console.WriteLine("gameStatus: " + game.gameStatus);
        }
    }
}
