using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiningSpot : NPC
{
    public DropTable DropTable { get; set; }
    public bool pickable;
    public string itemSlug;

    public PickupItem pickupItem;
    private QuestTarget questTarget;

    private void Start(){
        DropTable = new DropTable();
        DropTable.loot = new List<LootDrop>
        {
            new LootDrop(itemSlug, 100),
        };
        questTarget = GetComponent<QuestTarget>();
    }

    public override void Interact()
    {
        base.Interact();
        if (pickable)
        {
            PickedUp();
        }
    }
    public void PickedUp()
    {
            GoOut();
    }
    public void GoOut()
    {
        DropLoot();
        Quest.instance.itemAmount += 1;
        questTarget.QuestComplete();
        Destroy(gameObject);
    }

    void DropLoot()
    {
        Item item = DropTable.GetDrop();
        if (item != null)
        {
            InventoryController.Instance.GiveItem(item);
            //PickupItem instance = Instantiate(pickupItem, transform.position, Quaternion.identity);
            //instance.ItemDrop = item;
        }
    }
}
