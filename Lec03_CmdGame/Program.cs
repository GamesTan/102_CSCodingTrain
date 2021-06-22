using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamesTan.Lec03_CmdGame {
    public class Driver {
        public static int FrameIntervalMS = 30; // 
        private static bool isNeedStop;

        public static void Start(Action<char> onGetInput, Func<double, double, bool> onUpdate) {
            var thread = new Thread(() => {
                while (true) {
                    var info = Console.ReadKey();
                    var inputCh = info.KeyChar;
                    onGetInput(inputCh);
                }
            });
            thread.Start();
            RepeatInvoke((timeSinceStart, dt) => {
                isNeedStop = onUpdate(timeSinceStart, dt);
            }, FrameIntervalMS);
        }

        static void RepeatInvoke(Action<double, double> func, int callIntervalMs) {
            var initTime = DateTime.Now;
            var lastTimestamp = DateTime.Now;
            while (true) {
                try {
                    Thread.Sleep(Math.Max(1, callIntervalMs));
                    var totalElipse = DateTime.Now - initTime;
                    var totalSec = totalElipse.TotalSeconds;
                    var elipse = DateTime.Now - lastTimestamp;
                    var dtSec = elipse.TotalSeconds;
                    lastTimestamp = DateTime.Now;
                    func(totalSec, dtSec);
                    if (isNeedStop) return;
                } catch (ThreadAbortException e) {
                    return;
                } catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }


    class Program {
        static void Main(string[] args) {
            var game = new Game();
            game.Awake();

            Driver.FrameIntervalMS = 300; // 100 毫秒更新一次
            Driver.Start(game.OnGetInput, game.OnUpdate);

            Console.ReadLine();
        }
    }
}
