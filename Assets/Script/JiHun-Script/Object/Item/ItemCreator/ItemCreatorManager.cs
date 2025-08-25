using System.Collections.Generic;
using UnityEngine;

public class ItemCreatorManager : MonoBehaviour
{
    public static ItemCreatorManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        itemCreators.Add("Stone", new StoneCreator());
        itemCreators.Add("Ballon", new BallonCreator());
    }
    public ItemCreator GetItemCreator(string name)
    {
        return itemCreators.GetValueOrDefault(name);
    }
    private Dictionary<string, ItemCreator> itemCreators = new Dictionary<string, ItemCreator>();
}
