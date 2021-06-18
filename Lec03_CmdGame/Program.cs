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
            var lastTime = DateTime.Now;
            while (true) {
                Thread.Sleep(FrameIntervalMs);
                var diff = DateTime.Now - lastTime;
                var deltaTime = (float)diff.TotalSeconds;
                lastTime = DateTime.Now;

                Game.deltaTime = deltaTime;
                game.Update();
                DrawGame(game);
                Game.inputChar = ' ';
            }
            Console.ReadLine();
        }
        static int FrameIntervalMs = 100; // 帧间隔时间 单位毫秒ms

        static int[,] mapData = new int[Game.RowCount, Game.RowCount];

        public struct RenderInfo {
            public int x;
            public int y;
            public char ch;
            public bool isRed;
            public int health;

            public RenderInfo(int health,int x, int y, char ch, bool isRed) {
                this.x = x;
                this.y = y;
                this.ch = ch;
                this.isRed = isRed;
                this.health = health;
            }

            public bool IsEqual(RenderInfo b) {
                return x == b.x && y == b.y && ch == b.ch && isRed == b.isRed && health == b.health;
            }
        }
        static List<RenderInfo> curRenderInfo = new List<RenderInfo>();
        static List<RenderInfo> lastRenderInfo = new List<RenderInfo>();
        static int SpaceFactor = 2;
        private static void DrawGame(Game game) {
            // 繪製地圖
            var allPlayer = game.allPlayers;
            // 清空 屏幕緩存
            for (int i = 0; i < Game.RowCount; i++) {
                for (int j = 0; j < Game.RowCount; j++) {
                    mapData[i, j] = 0;
                }
            }
            curRenderInfo.Clear();
            foreach (var item in allPlayer) {
                var x = (int)item.x + Game.HalfRowCount;
                var y = (int)item.y + Game.HalfRowCount;
                mapData[x, y] = ((int)'P') * (item.isHurted ? -1 : 1);
                curRenderInfo.Add(new RenderInfo(item.health, x, y, 'P', item.isHurted));
            }
            var allEnemies = game.allEnemies;
            foreach (var item in allEnemies) {
                var x = (int)item.x + Game.HalfRowCount;
                var y = (int)item.y + Game.HalfRowCount;
                mapData[x, y] = ((int)'M') * (item.isHurted ? -1 : 1);
                curRenderInfo.Add(new RenderInfo(item.health, x, y, 'M', item.isHurted));
            }
            bool isDirty = false;
            if (lastRenderInfo.Count == curRenderInfo.Count) {
                for (int i = 0; i < lastRenderInfo.Count; i++) {
                    var infoA = lastRenderInfo[i];
                    var infoB = curRenderInfo[i];
                    if (!infoA.IsEqual(infoB)) {
                        isDirty = true;
                        break;
                    }
                }
            } else {
                isDirty = true;
            }
            lastRenderInfo.Clear();
            lastRenderInfo.AddRange(curRenderInfo);
            if (isDirty) {
                Console.Clear();
                for (int row = 0; row < Game.RowCount; row++) {
                    // 绘制 第 i 行
                    char[] chars = new char[Game.RowCount];
                    int lastPrintIdx = -1;
                    for (int col = 0; col < Game.RowCount; col++) {
                        var val = mapData[col, Game.RowCount - row - 1];
                        if (val != 0) {
                            var spaceStr = new string(' ', (col - lastPrintIdx - 1) * SpaceFactor);
                            lastPrintIdx = col;
                            Console.Write(spaceStr);
                            var isRed = val < 0;
                            Console.ForegroundColor = isRed? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write(" " +(char)Math.Abs(val));
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    var otherStr = new string(' ', (Game.RowCount - lastPrintIdx - 1) * SpaceFactor) +"|";
                    Console.Write(otherStr);
                    Console.WriteLine();
                }
                foreach (var item in allPlayer) {
                    Console.WriteLine(item);
                }
                foreach (var item in allEnemies) {
                    Console.WriteLine(item);
                }
                Console.WriteLine("gameStatus: " + game.gameStatus);
                Console.WriteLine(Game.inputChar);
            }
        }
    }
}
