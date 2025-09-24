using System;
using UnityEngine;

namespace jjh
{
    public interface ICastable
    {
        void Cast(GameObject casterObject);
    }
    public abstract class SystemCastBase : MonoBehaviour, ICastable
    {
        public Action<SystemCastBase> ActionSuccessCast;
        public abstract void Cast(GameObject casterObject);

    }
}