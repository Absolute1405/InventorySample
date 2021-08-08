using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class ViewCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI _count;
    [SerializeField] private Image _icon;
    [SerializeField, Min(0.01f)] private float _screenScalePart = 0.1f;

    private RectTransform _transform;
    private ItemInfoWindow _infoWindow;
    private Item _cellItem;
    public float Scale => Screen.width * _screenScalePart;

    public void Init(IReadOnlyCell cell, ItemInfoWindow infoWindow)
    {
        if (_count is null || _icon is null)
            throw new ArgumentNullException();

        if (infoWindow is null)
            throw new ArgumentNullException(nameof(infoWindow));

        _transform = GetComponent<RectTransform>();
        _transform.sizeDelta = new Vector2(Scale, Scale);

        _icon.sprite = cell.CellItem.Icon;
        _count.text = cell.Count.ToString();
        _cellItem = cell.CellItem;
        _infoWindow = infoWindow;
    }

    public void Place(Vector2 position)
    {
        _transform.anchoredPosition = position;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _infoWindow.ShowInfo(_cellItem);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _infoWindow.Hide();
    }
}
