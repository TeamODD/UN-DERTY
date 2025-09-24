using UnityEngine;

namespace jjh
{
    public class BarrierButton : Button
    {
        [SerializeField] private Barrier _barrier;
        protected override void Start()
        {
            base.Start();
            if(_barrier == null)
                Debug.Log("BarrierButton: Barrier Is None");
        }
        public override void Activate()
        {
            _barrier.SetActive(true);
        }

        public override void Deactivate()
        {
            _barrier.SetActive(false);
        }
    }
}