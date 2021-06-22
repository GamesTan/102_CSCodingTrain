namespace GamesTan.Lec03_CmdGame {
    public class Skill : Component {
        public float cd = 1;
        public float cdTimer;

        public float atkDist = 2;
        public override void Update(float dt) {
            base.Update(dt);
            cdTimer += Time.deltaTime;
            if (cdTimer < cd) return;
            cdTimer = 0;
            var target = actor.FindTarget();
            if ((target.pos - actor.pos).magnitude > atkDist) return;
            if (target != null) {
                actor.Attack(target);
            }
        }
    }



}
