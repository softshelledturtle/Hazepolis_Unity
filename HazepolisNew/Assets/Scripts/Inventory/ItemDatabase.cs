using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance { get; set; }
    public List<Item> Items { get; set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        DontDestroyOnLoad(gameObject);
        BuildDatabase();
    }

    private void BuildDatabase()
    {
        Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/Items").ToString());
        Debug.Log("Database Ready");
    }

    public Item GetItem(string itemSlug)
    {
        foreach(Item item in Items)
        {
            if(item.ObjectSlug == itemSlug)
            {
                Debug.Log("ItemDatabase�w���" + itemSlug);
                return item;
            }
        }
        Debug.LogWarning("�䤣��item");
        return null;
    }
}
