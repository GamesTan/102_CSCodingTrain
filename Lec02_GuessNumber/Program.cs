using System;

namespace Lec02_GuessNumber {
    class Program {
        static Random random = new Random();
        static int GenRandomInt() {
            var number = random.Next(0, 100);
            return number;
        }
        static int totalCount = 0;
        static int systemNumber = 0;
        static void Main(string[] args) {
            int ss = 0;
            systemNumber = GenRandomInt();
            Console.WriteLine(systemNumber);
            while (true) {
                totalCount++;
                Console.WriteLine("请输入一个0~99的数字，按回车键结束：");
                var inputStr = Console.ReadLine();
                int inputNumber = int.Parse(inputStr);
                if (inputNumber == systemNumber) {
                    Console.WriteLine($"太厉害了，你只猜了{totalCount}次，就答对了！");
                    // 重置游戏
                    ResetStatus();
                } else {
                    if (inputNumber > systemNumber) {
                        Console.WriteLine("太大了");
                    } else {
                        Console.WriteLine("太小了");
                    }
                }
            }
            Console.ReadLine();
        }

        private static void ResetStatus() {
            systemNumber = GenRandomInt();
            Console.WriteLine(systemNumber);
            totalCount = 0;
        }
    }
}
