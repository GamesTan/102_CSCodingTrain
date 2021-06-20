namespace GamesTans.Lec03_CmdGame {

    public class Game {
        public World world;
        public EGameState state;
        public void Awake() {
            world = new World();
            world.Awake();
        }
        public void Update() {
            world.Update();
        }
        
    }

}
