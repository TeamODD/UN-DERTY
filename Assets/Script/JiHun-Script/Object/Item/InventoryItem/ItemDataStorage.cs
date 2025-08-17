using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public Data(int itemMaxCount, int itemUseCount)
    {
        this.itemMaxCount = itemMaxCount;
        this.itemUseCount = itemUseCount;
    }
    public readonly int itemMaxCount;
    public readonly int itemUseCount;
}
[System.Serializable]
public class EditorInput
{
    public string itemName;
    public int itemMaxCount;
    public int itemUseCount;
}
public class ItemDataStorage : MonoBehaviour
{
    [SerializeField] private List<EditorInput> editorInputDatas;
    private void Awake()
    {
        foreach (EditorInput editorInput in editorInputDatas)
        {
            datas.Add(editorInput.itemName, new Data(editorInput.itemMaxCount, editorInput.itemUseCount));
        }
    }
    public bool FindData(string itemName, out Data data)
    {
        return datas.TryGetValue(itemName, out data);
    }
    private Dictionary<string, Data> datas = new Dictionary<string, Data>();
}