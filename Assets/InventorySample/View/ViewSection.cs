using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ViewSection : MonoBehaviour
{
    [SerializeField] private ViewCell _cellViewPrefab;

    private IReadOnlySection _section;
    private RectTransform _transform;
    private List<ViewCell> _cellViews;
    private InventoryGrid _grid;
    private ItemInfoWindow _infoWindow;

    public string Name => _section.ItemKind.ToString();

    public void Init(IReadOnlySection section, ItemInfoWindow infoWindow)
    {
        if (_cellViewPrefab is null)
            throw new ArgumentNullException(nameof(_cellViewPrefab));

        if (section is null)
            throw new ArgumentNullException(nameof(section));

        if (infoWindow is null)
            throw new ArgumentNullException(nameof(infoWindow));

        _infoWindow = infoWindow;
        _section = section;

        _transform = GetComponent<RectTransform>();

        _cellViews = new List<ViewCell>();
        Hide();
    }

    public void Refresh(IReadOnlySection section)
    {
        _grid = new InventoryGrid(_transform.rect.width, _cellViewPrefab.Scale);

        for (int i = 0; i < section.Cells.Count; i++)
        {
            ViewCell newView = Instantiate(_cellViewPrefab, transform);
            newView.Init(section.Cells[i], _infoWindow);
            newView.Place(_grid.GetNewCellPosition());
            _cellViews.Add(newView);
        }

        _transform.sizeDelta = Vector2.up * _grid.Height;
    }

    public void Clear()
    {
        _grid?.Clear();
        _cellViews.ForEach(x => Destroy(x.gameObject));
        _cellViews.Clear();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

}
