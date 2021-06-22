namespace GamesTan.Lec03_CmdGame {
    public class Buff : Component {
        public float cd = 1f;
        public float cdTimer;
        public override void Update(float dt) {
            base.Update(dt);
            cdTimer += Time.deltaTime;
            if (cdTimer < cd) return;
            cdTimer = 0;
            actor.health += 15;
        }
    }



}
