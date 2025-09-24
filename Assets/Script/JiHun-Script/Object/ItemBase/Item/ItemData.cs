using UnityEngine;

namespace jjh
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
    public class ItemData : ScriptableObject
    {
        public string itemName;
        public string description;
        public uint maxHasCount;
    }
}