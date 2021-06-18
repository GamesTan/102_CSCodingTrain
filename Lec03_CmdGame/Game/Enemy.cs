using System;

namespace GamesTan.Lec03_CmdGame {
    public class Enemy : Entity {
        float escapeHealthPercent = 0.5f;
        float escapeStopDist = 6;
        float escapeSpeed = 2;
        public override void Update() {
            base.Update();
            var target = Game.Instance.GetPlayer();
            Attack(target);
            if (health < initHealth * escapeHealthPercent ) {
                // 逃跑
                var dx = x - target.x ;
                var dy = y - target.y ;
                var dist = (float)Math.Sqrt((dx * dx + dy * dy));
                if (dist < escapeStopDist) {
                    var normX = dx / dist;
                    var normY = dy / dist;
                    this.x += normX * escapeSpeed* Game.deltaTime;
                    this.y += normY * escapeSpeed* Game.deltaTime;

                    this.x = Math.Min(Game.HalfRowCount, Math.Max(-Game.HalfRowCount, this.x));
                    this.y = Math.Min(Game.HalfRowCount, Math.Max(-Game.HalfRowCount, this.y));

                }
            }
        }
    }
}
