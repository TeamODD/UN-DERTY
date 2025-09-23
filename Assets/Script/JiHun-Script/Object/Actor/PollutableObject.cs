using UnityEngine;

namespace jjh
{
    public class PollutableObject : MonoBehaviour
    {
        [SerializeField] private bool _bPollute;
        public bool IsPollute() { return _bPollute; }
        public void SetPollute(bool bPollute) {  _bPollute = bPollute; }
    }
}