using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTans.Lec03_CmdGame {
    class Program {
        static void Main(string[] args) {

            var game = new Game();
            game.Awake();
            for (int i = 0; i < 3; i++) {
                game.Update();
            }
            Console.ReadLine();
        }
    }
}
