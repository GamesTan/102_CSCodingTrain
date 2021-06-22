using System;

namespace GamesTan.Lec03_CmdGame {
    public class EnemyAI : AI {

        public float escapeInterval = 1;
        public float escapeTimer = 1;

        public float stopDist = 4;
        public float damageHealthPercent = 0.5f;

        public override void Update(float dt) {
            escapeTimer += Time.deltaTime;
            if (escapeTimer < escapeInterval) return;
            if (actor.health > actor.initHealth * damageHealthPercent) return;
            escapeTimer = 0;
            var target = actor.FindTarget();
            if (target == null) return;
            var diff = (actor.pos - target.pos);
            var dist = diff.magnitude;
            if (dist > stopDist) return;

            Vector2 vec = Vector2.zero;
            if (Math.Abs(diff.x) > Math.Abs(diff.y)) {
                if (diff.x > 0) vec = new Vector2(1, 0);
                else vec = new Vector2(-1, 0);
            } else {
                if (diff.y > 0) vec = new Vector2(0, 1);
                else vec = new Vector2(0, -1);
            }
            actor.pos += vec;
        }

    }



}
