using System;
using System.Collections.Generic;
using UnityEngine;

public class RandomInventoryTest : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private ViewInventory _inventoryUI;
    [SerializeField, Min(1f)] private int _maxWeight;

    private Inventory _inventory;

    private void Awake()
    {
        if (_items.Count < 1)
            throw new ArgumentNullException(nameof(_items));

        if (_inventoryUI is null)
            throw new ArgumentNullException(nameof(_inventoryUI));


        _inventory = new Inventory(_maxWeight, new ItemType[] { ItemType.Weapon, ItemType.Armor, ItemType.Ammo, ItemType.Book, ItemType.Misc });
        _inventoryUI.Init(_inventory);
    }

    public void AddRandomItem()
    {
        int randItemNum = UnityEngine.Random.Range(0, _items.Count);
        int randItemCount = UnityEngine.Random.Range(1, Cell.MaxCount);

        if (_inventory.TryAddItem(_items[randItemNum], randItemCount) == false)
            Debug.Log("Overweight");
        else
            Debug.Log(_items[randItemNum].name + " " + randItemCount + " added");
    }

    public void RemoveRandomItem()
    {
        int randItemNum = UnityEngine.Random.Range(0, _items.Count);
        int randItemCount = UnityEngine.Random.Range(1, Cell.MaxCount);

        bool success = _inventory.TryRemoveItem(_items[randItemNum], randItemCount, out var cell);
        if (success)
            Debug.Log("Removed " + cell.Count + " " + cell.CellItem.name);
        else
            Debug.Log("Inventory has no " + randItemCount + " " + _items[randItemNum].name);

    }

    public void ReloadUI()
    {
        _inventoryUI.Refresh();
    }
    
}
