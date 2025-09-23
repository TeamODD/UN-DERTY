using UnityEngine;

namespace jjh
{
    public class LiftButton : Button
    {
        [SerializeField] private Lift _lift;
        protected override void Start()
        {
            base.Start();
            if (_lift == null)
                Debug.Log("LiftButton: Lift Is None");
        }
        public override void Activate()
        {
            _lift.MoveTo();
        }

        public override void Deactivate()
        {
            _lift.MoveBack();
        }
    }
}
