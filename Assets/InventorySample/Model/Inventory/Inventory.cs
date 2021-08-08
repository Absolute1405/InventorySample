using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory : IReadOnlyInventory
{
    private Dictionary<ItemType, InventorySection> _sections;
    public float MaxWeight { get; private set; }

    public Inventory(float maxWeight, ItemType[] itemTypes)
    {
        if (maxWeight < 1f)
            throw new ArgumentOutOfRangeException(nameof(maxWeight));

        if (itemTypes is null)
            throw new ArgumentNullException(nameof(itemTypes));

        MaxWeight = maxWeight;
        _sections = new Dictionary<ItemType, InventorySection>();

        for (int i = 0; i < itemTypes.Length; i++)
        {
            _sections.Add(itemTypes[i], new InventorySection(itemTypes[i]));
        }
    }

    public IReadOnlyList<IReadOnlySection> Sections => new List<IReadOnlySection>(_sections.Values);
    public float OverallWeight => _sections.Values.Sum(x => x.Weight);

    public bool TryAddItem(Item item, int count)
    {
        if (OverallWeight + item.Weight * count > MaxWeight)
            return false;

        if (_sections.ContainsKey(item.Kind))
        {
            _sections[item.Kind].AddItem(item, count);
            return true;
        }

        throw new InvalidOperationException("Inventory has no section " + item.Kind.ToString());
    }

    public bool TryRemoveItem(Item item, int count, out Cell cell)
    {
        cell = null;

        if (_sections.ContainsKey(item.Kind))
        {
            bool result = _sections[item.Kind].TryRemoveItem(item, count, out Cell removedCell);
            cell = removedCell;
            return result;
        }

        return false;
    }

}
