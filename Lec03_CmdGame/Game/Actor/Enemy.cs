namespace GamesTan.Lec03_CmdGame {
    public class Enemy : Actor {
        public int score = 200;
        public override int Type => (int)EActorType.Enemy;

        protected override void OnDied() {
            GameState.Instance.score += score;
        }
    }


}
