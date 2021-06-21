namespace GamesTan.Lec03_CmdGame {
    public class CmdRenderEngine : RenderEngine {

        // 0 表示没有 >0 正常显示  <0 表示受伤
        int[,] mapData;
        public override void SetMapSize(int rowCount, int colCount) {
            base.SetMapSize(rowCount, colCount);
            mapData = new int[rowCount, colCount];
        }
        public override void Render(RenderInfos info) {
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
                var HalfColCount = (ColCount - 1) / 2;
                var col = item.pos.x + HalfColCount;
                // RowCount = 21
                // 玩家 显示行
                //  10   0
                //       
                //  0    10
                //       
                // -10   20
                var haflRowCount = (RowCount - 1) / 2;
                var row = RowCount-(item.pos.y + haflRowCount);
                mapData[row, col] = item.color * item.type;
            }

        }

    }



}
