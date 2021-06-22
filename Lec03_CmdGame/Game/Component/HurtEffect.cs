namespace GamesTan.Lec03_CmdGame {
    public class HurtEffect : Component {
        public float timer;
        public float duration = 0.3f;
        public override void Awake() {
            base.Awake();
            actor.OnHurtEvent += OnHurt;
        }
        void OnHurt(Actor actor) {
            timer = 0;
        }
        public override void Update(float dt) {
            base.Update(dt);
            timer += Time.deltaTime;
            if (timer > duration) {
                actor.isHurt = false;
            }
        }
    }



}
