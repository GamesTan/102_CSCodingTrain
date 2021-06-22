namespace GamesTan.Lec03_CmdGame {
    public class GameState {
        // 单例模式  全局唯一的实例 
        public static GameState Instance { get; private set; } = new GameState();
        // 私有构造函数 外面不能创建对象
        private GameState() { }

        public EGameState state;
        public int score;

        public override string ToString() {
            return $"state:{state}  score:{ score}";
        }
    }

}
