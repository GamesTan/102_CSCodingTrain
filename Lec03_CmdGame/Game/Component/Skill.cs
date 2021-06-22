namespace GamesTan.Lec03_CmdGame {
    public class Skill : Component {
        public float cd;
        public float cdTimer;

        public float atkDist = 2;
        public override void Update(float dt) {
            base.Update(dt);
            var target = actor.FindTarget();
            if ((target.pos - actor.pos).magnitude > atkDist) return;
            if (target != null) {
                actor.Attack(target);
            }
        }
    }



}
