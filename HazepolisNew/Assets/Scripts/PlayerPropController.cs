using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPropController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedProp { get; set; }

    Item currentlyEquippedItem;
    IProp equippedProp;
    CharacterStat characterStat;

    void Start()
    {
        characterStat = GetComponent<Player>().characterStats;
    }

    public void EquipProp(Item itemToEquip)
    {
        if (EquippedProp != null)
        {
            UnequipProp();
        }

        EquippedProp = (GameObject)Instantiate(Resources.Load<GameObject>("Props/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);
        EquippedProp.transform.SetParent(playerHand.transform);
        equippedProp = EquippedProp.GetComponent<IProp>();
        equippedProp.Stats = itemToEquip.Stats;
        currentlyEquippedItem = itemToEquip;
        characterStat.AddStatBonus(itemToEquip.Stats);
        UIEventHandler.ItemEquipped(itemToEquip);
        UIEventHandler.StatsChanged();
    }

    public void UnequipProp()
    {
        InventoryController.Instance.GiveItem(currentlyEquippedItem.ObjectSlug);
        characterStat.RemoveStatBonus(equippedProp.Stats);
        Destroy(EquippedProp.transform.gameObject);
        UIEventHandler.StatsChanged();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            useKeyProp();
    }

    public void useKeyProp()
    {

    }
}
