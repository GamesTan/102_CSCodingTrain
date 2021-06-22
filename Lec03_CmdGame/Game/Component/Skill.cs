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
            if (target == null) return;
            if ((target.pos - actor.pos).magnitude > atkDist) return;
            if (target != null) {
                actor.Attack(target);
            }
        }
    }



}
