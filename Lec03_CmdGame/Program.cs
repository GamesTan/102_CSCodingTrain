using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTan.Lec03_CmdGame {
    class Program {
        static void Main(string[] args) {
            var game = new Game();
            game.Awake();

            Driver.FrameIntervalMS = 30; // 100 毫秒更新一次
            Driver.Start(game.OnGetInput, game.OnUpdate);

            Console.ReadLine();
        }
    }
}
