using System;
using System.Collections.Generic;
using System.Linq;

public class InventorySection : IReadOnlySection
{
    private List<Cell> _cells;
    public ItemType ItemKind { get; private set; }

    public InventorySection(ItemType itemKind)
    {
        if (itemKind == ItemType.None)
            throw new ArgumentNullException(nameof(ItemKind));

        ItemKind = itemKind;
        _cells = new List<Cell>();
    }

    public IReadOnlyList<IReadOnlyCell> Cells => _cells;
    public float Weight => _cells.Sum(x => x.Weight);

    public void AddItem(Item item, int count)
    {
        List<Cell> matched = _cells.FindAll(x => x.CellItem == item);
        int freeSlots = 0;

        if (matched.Count == 0)
        {
            _cells.Add(new Cell(item, count));
            return;
        }

        for (int i = 0; i < matched.Count; i++)
        {
            freeSlots = Cell.MaxCount - matched[i].Count;

            if (freeSlots == 0)
                continue;

            if (freeSlots >= count)
            {
                matched[i].Count += count;
                return;
            }
            else
            {
                matched[i].Count = Cell.MaxCount;
                count -= freeSlots;
            }
        }

        if (count > 0)
            _cells.Add(new Cell(item, count));
    }

    public bool TryRemoveItem(Item item, int count, out Cell cell)
    {
        cell = null;
        List<Cell> matched = _cells.FindAll(x => x.CellItem == item);

        if (matched.Sum(x => x.Count) < count)
            return false;

        int tmp = count;

        for (int i = matched.Count - 1; i >= 0; i--)
        {
            if (matched[i].Count <= tmp)
            {
                tmp -= matched[i].Count;
                _cells.Remove(matched[i]);
            }
            else
            {
                matched[i].Count -= tmp;
                break;
            }
        }

        cell = new Cell(item, count);
        return true;
    }
}
