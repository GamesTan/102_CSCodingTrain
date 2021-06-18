using System;

namespace GamesTan.Lec03_CmdGame {
    public class Player : Entity {
        public override void Update() {
            Attack(Game.Instance.GetEnemy());
        }
    }
}
