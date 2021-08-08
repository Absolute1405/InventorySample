using System;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class InfoWindowPlacer : MonoBehaviour
{
    private Camera _camera;
    private RectTransform _transform;
    private RectTransform _itemWindow;
    private float _height;
    private float _width;

    public void Init(Camera camera)
    {
        if (camera is null)
            throw new ArgumentNullException();

        _camera = camera;

        _transform = GetComponent<RectTransform>();
        _itemWindow = _transform.parent.GetComponent<RectTransform>();

        _height = _transform.rect.height;
        _width = _transform.rect.width;
    }

    public void SetPosition()
    {
        Vector3 cursorPos = Input.mousePosition;
        Vector3 offset = new Vector3(_width / 2f, -_height / 2f);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_itemWindow, cursorPos + offset, _camera, out Vector2 pos);
        _transform.anchoredPosition = pos;
    }
}
