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

        public readonly static Vector2 zero = new Vector2(0, 0);

        public float magnitude => (float)System.Math.Sqrt(x * x + y * y);

        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.x * b.x, a.y * b.y);
        public static Vector2 operator /(Vector2 a, Vector2 b) => new Vector2(a.x / b.x, a.y / b.y);

        public static Vector2 operator -(Vector2 a) => new Vector2(-a.x, -a.y);

        public static Vector2 operator *(Vector2 a, int d) => new Vector2(a.x * d, a.y * d);

        public static Vector2 operator *(int d, Vector2 a) => new Vector2(a.x * d, a.y * d);

        public static Vector2 operator /(Vector2 a, int d) => new Vector2(a.x / d, a.y / d);

        public static bool operator ==(Vector2 lhs, Vector2 rhs) {
            int num1 = lhs.x - rhs.x;
            int num2 = lhs.y - rhs.y;
            return (double)num1 * (double)num1 + (double)num2 * (double)num2 < 9.99999943962493E-11;
        }

        public static bool operator !=(Vector2 lhs, Vector2 rhs) => !(lhs == rhs);

        public override bool Equals(object other) => other is Vector2 other1 && Equals(other1);

        public bool Equals(Vector2 other) => x == other.x && y == other.y;

        public override int GetHashCode() => this.x.GetHashCode() ^ this.y.GetHashCode() << 2;

    }



}
