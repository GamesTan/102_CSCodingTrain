using System;

namespace GamesTan.Lec03_CmdGame {
    public class Enemy : Entity {
        public override void Update() {
            Attack(Game.Instance.GetPlayer());
        }
    }
}
