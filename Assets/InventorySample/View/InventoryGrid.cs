using System;
using UnityEngine;

public class InventoryGrid 
{
    public int CellsInRow { get; private set; }
    public float Offset { get; private set; }
    public int BusyCellsCount { get; private set; }
    private int _busyRows;
    public float Height => (_busyRows + 1) * _cellScale + _cellScale * 0.5f;

    private float _cellScale;

    public InventoryGrid(float width, float cellScale)
    {
        if (width < 1f)
            throw new ArgumentOutOfRangeException(nameof(width));

        if (cellScale < 1f)
            throw new ArgumentOutOfRangeException(nameof(cellScale));

        _cellScale = cellScale;
        Offset = (width % cellScale) / 2f;
        CellsInRow = (int)(width / cellScale);
        BusyCellsCount = 0;
    }

    public Vector2 GetNewCellPosition()
    {
        _busyRows = BusyCellsCount / CellsInRow;
        int col = BusyCellsCount % CellsInRow;

        float y = -_busyRows * _cellScale - _cellScale;
        float x = Offset / 2f + col * _cellScale + _cellScale / 2f;

        BusyCellsCount++;
        return new Vector2(x, y);
    }

    public void Clear() => BusyCellsCount = 0;
}
