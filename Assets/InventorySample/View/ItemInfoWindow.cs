using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[RequireComponent(typeof(InfoWindowPlacer))]
public class ItemInfoWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private TextMeshProUGUI _descriptionField;
    [SerializeField] private ValueField _costField;
    [SerializeField] private ValueField _weightField;
    [SerializeField] private Image _icon;

    private InfoWindowPlacer _placer;

    public void Init(Camera camera)
    {
        if (_nameField is null)
            throw new ArgumentNullException(nameof(_nameField));
        if (_descriptionField is null)
            throw new ArgumentNullException(nameof(_descriptionField));
        if (_costField is null)
            throw new ArgumentNullException(nameof(_costField));
        if (_weightField is null)
            throw new ArgumentNullException(nameof(_weightField));

        _placer = GetComponent<InfoWindowPlacer>();
        _placer.Init(camera);
    }

    public void ShowInfo(Item item)
    {
        _icon.sprite = item.Icon;
        _nameField.text = item.name;
        _descriptionField.text = item.Description;
        _costField.SetValue(item.Cost);
        _weightField.SetValue(item.Weight);

        _placer.SetPosition();

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
