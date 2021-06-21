using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTan.Lec03_CmdGame {
    public class Debug {
        public static void Log(string msg) {
            //Console.WriteLine(msg);
        }
    }
    class Program {
        static void Main(string[] args) {
            var game = new Game();
            game.Awake();
            for (int i = 0; i < 20; i++) {
                game.Update();
            }
            Console.ReadLine();
        }
    }
}
