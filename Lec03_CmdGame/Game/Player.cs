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
            normX = 0;
            normY = 0;
            switch (Game.inputChar) {
                case 'w': normX = 0; normY = 1;break;
                case 's': normX = 0; normY = -1; break;
                case 'a': normX = -1; normY = 0; break;
                case 'd': normX = 1; normY = 0; break;
                default: break;
            }

            this.x += normX * moveSpeed ;
            this.y += normY * moveSpeed ;
            // 限定邊界
            this.x = Math.Min(Game.HalfRowCount, Math.Max(-Game.HalfRowCount, this.x));
            this.y = Math.Min(Game.HalfRowCount, Math.Max(-Game.HalfRowCount, this.y));

            Debug.Log($" ({x},{y})=>({x},{y})   targetPos ({target.x},{target.y})");
            Attack(target);
        }
    }
}
