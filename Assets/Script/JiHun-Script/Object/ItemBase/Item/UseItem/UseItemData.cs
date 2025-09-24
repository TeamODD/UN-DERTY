using UnityEngine;

namespace jjh
{
    [CreateAssetMenu(fileName = "UseItemData", menuName = "Scriptable Objects/UseItemData")]
    public class UseItemData : ItemData
    {
        public uint _useCount;
    }
}
