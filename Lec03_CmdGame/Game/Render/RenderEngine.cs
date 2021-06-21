using System;

namespace GamesTan.Lec03_CmdGame {
    public class RenderEngine : IAwake {
        public int RowCount;
        public int ColCount;

        public virtual void SetMapSize(int rowCount, int colCount) {
            this.RowCount = rowCount;
            this.ColCount = colCount;
        }


        public virtual void Awake() {
            Debug.Log($" {GetType().Name} Awake");
        }
        public virtual void Render(RenderInfos info) {
            Debug.Log($" {GetType().Name} Update");
        }
    }



}
