namespace GamesTan.Lec03_CmdGame {
    public class PlayerAI : AI {
        public override void Update(float dt) {
            base.Update(dt);
            var dir = InputManager.inputVec;
            actor.pos += dir;
            InputManager.inputVec = Vector2.zero;
        }
    }

}
