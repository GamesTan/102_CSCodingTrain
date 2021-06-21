using System;

namespace GamesTan.Lec03_CmdGame {
    public class CmdRenderEngine : RenderEngine {

        // 0 表示没有 >0 正常显示  <0 表示受伤
        int[,] mapData;
        public override void SetMapSize(int rowCount, int colCount) {
            base.SetMapSize(rowCount, colCount);
            mapData = new int[rowCount, colCount];
        }
        public override void Render(RenderInfos info) {
            Console.Clear();
            Debug.Log($" {GetType().Name} Update");
            for (int row = 0; row < RowCount; row++) {
                for (int col = 0; col < ColCount; col++) {
                    mapData[row, col] = 0;
                }
            }
            var infos = info.GetInfos();
            foreach (var item in infos) {
                // ColCount = 21
                // -10    0    10   // 玩家位置x
                //  0     10   20   // 显示列

                // RowCount = 21
                // 玩家 显示行
                //  10   20
                //       
                //  0    10
                //       
                // -10   0
                var halfColCount = (ColCount - 1) / 2;
                var col = item.pos.x + halfColCount;
                var haflRowCount = (RowCount - 1) / 2;
                var row = item.pos.y + haflRowCount;
                mapData[row, col] = item.color * item.type;
            }
            const int CharSpaceCount = 2;
            for (int row = 0; row < RowCount; row++) {
                int lastIdx = -1;
                for (int col = 0; col < ColCount; col++) {
                    var val = mapData[RowCount- row -1, col];
                    if (val == 0) continue;
                    var spaceCount = col - lastIdx - 1;
                    lastIdx = col;
                    var spaceStr = new string(' ', spaceCount *CharSpaceCount);
                    Console.Write(spaceStr);
                    var color = val < 0 ? ConsoleColor.Red : ConsoleColor.White;
                    Console.ForegroundColor = color;
                    var ch = (Math.Abs(val) == 1 ? "M" : "P") + new string(' ',CharSpaceCount-1);
                    Console.Write(ch);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                var endSpaceStr = new string(' ', (ColCount - lastIdx - 1) * CharSpaceCount);
                Console.Write(endSpaceStr);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('|');
                Console.WriteLine();
            }
            var endLineStr = new string('-', ColCount * CharSpaceCount);
            Console.WriteLine(endLineStr);
            var extraInfos = info.GetExtInfos();
            foreach (var item in extraInfos) {
                Console.WriteLine(item);
            }
        }

    }



}
