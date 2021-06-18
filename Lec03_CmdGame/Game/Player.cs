using System;

namespace GamesTan.Lec03_CmdGame {
    public class Player : Entity {

        public float moveSpeed = 1; // 移动速度
        public override void Update() {

            // 靠近敌人
            var target = Game.Instance.GetEnemy();
            if (target == null) return;
            var xDiff = target.x - this.x;
            var yDiff = target.y - this.y;
            float len = (float)Math.Sqrt(xDiff *xDiff+ yDiff * yDiff);
            var normX = xDiff / len;
            var normY = yDiff / len;

            this.x += normX * moveSpeed;
            this.y += normY * moveSpeed;

            Console.WriteLine($" ({x},{y})=>({x},{y})   targetPos ({target.x},{target.y})");
            Attack(target);
        }
    }
}
