using System;
using Unity.VisualScripting;
using UnityEngine;

namespace jjh
{
    public interface IPollutEffect
    {
        void PollutEffect();
    }

    public class AddDPPollutEffect : IPollutEffect
    {
        public void PollutEffect()
        {
            
        }
    }
    public abstract class PollutableBase : MonoBehaviour
    {
        [SerializeField] private bool _bPollute;
        public void SetPollute(bool bPollute) {_bPollute = bPollute;}
        public bool IsPollute() { return _bPollute; }
        public void PollutEffect()
        {
            if (_bPollute == false)
                return;

            if (_bAlreadyEffected)
                return;

            DPmanager.Instance.AddDP(1);
            _bAlreadyEffected = true;
        }

        protected bool _bAlreadyEffected = false;
    }
}