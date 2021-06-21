namespace GamesTan.Lec03_CmdGame {
    public struct Vector2 {
        public int x;
        public int y;

        public Vector2(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public override string ToString() {
            return $"({x},{y})";
        }
    }



}
