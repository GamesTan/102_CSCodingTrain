namespace GamesTan.Lec03_CmdGame {
    public class PlayerAI : AI {
        public override void Update(float dt) {
            base.Update(dt);
            var rawPos = actor.pos;
            rawPos.y += 1;
            actor.pos = rawPos;
        }
    }

}
