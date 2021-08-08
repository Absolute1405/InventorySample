using System;

public class Cell : IReadOnlyCell
{
    public static int MaxCount = 1;
    public Item CellItem { get; private set; }
    private int _count;

    public Cell(Item item, int count)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        if (count <= 0 || count > MaxCount)
            throw new ArgumentOutOfRangeException(nameof(count));

        CellItem = item;
        _count = count;
    }

    public float Weight => CellItem.Weight * Count;

    public int Count
    {
        get => _count;
        set
        {
            if (value < 0 || value > MaxCount)
                throw new ArgumentOutOfRangeException(nameof(Count));

            _count = value;
        }
    }

}
