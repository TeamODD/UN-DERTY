using System;
using UnityEngine;

namespace jjh
{
    public class TeleportPortal : Portal
    {
        [SerializeField] private GameObject _toObject;
        private void Start()
        {
            _pollutableObject = GetComponent<PollutableObject>();
        }
        public override void PortalAct(GameObject callActivator)
        {
            if (_toObject == null)
            {
                Debug.Log("TeleportPortal: ToObject Is None");
                return;
            }

            callActivator.transform.position = _toObject.transform.position;
            if(_pollutableObject.IsPollute())
            {
                // Todo: dp + 1
                Debug.Log("Dp + 1");
            }
        }
        private PollutableObject _pollutableObject = null;
    }
}