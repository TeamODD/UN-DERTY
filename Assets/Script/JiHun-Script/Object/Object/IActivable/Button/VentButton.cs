using UnityEngine;

namespace jjh
{
    public class VentButton : Button
    {
        [SerializeField] private Vent _vent;

        public override void Activate()
        {
            _vent.Activate(true);
        }

        public override void Deactivate()
        {
            _vent.Activate(false);
        }
    }
}