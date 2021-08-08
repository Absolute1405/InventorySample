using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(RectTransform))]
public class ViewInventory : MonoBehaviour
{
    [SerializeField] private ViewSection _sectionPrefab;
    [SerializeField] private ItemInfoWindow _infoWindow;
    [SerializeField] private WeightPanel _weightPanel;
    [SerializeField] private TextMeshProUGUI _sectionNameField;
    [SerializeField] private Camera _camera;
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private RectTransform _viewportWindow;

    private List<ViewSection> _sections;
    private IReadOnlyInventory _inventory;
    private int _currentSectionNumber;

    public void Init(IReadOnlyInventory inventory)
    {
        if (inventory is null)
            throw new ArgumentNullException(nameof(inventory));

        if (_sectionPrefab is null)
            throw new ArgumentNullException(nameof(_sectionPrefab));

        if (_infoWindow is null)
            throw new ArgumentNullException(nameof(_infoWindow));

        if (_camera is null)
            throw new ArgumentNullException(nameof(_camera));

        if (_weightPanel is null)
            throw new ArgumentNullException(nameof(_weightPanel));

        if (_viewportWindow is null)
            throw new ArgumentNullException(nameof(_viewportWindow));

        if (_sectionNameField is null)
            throw new ArgumentNullException(nameof(_sectionNameField));

        if (_scrollRect is null)
            throw new ArgumentNullException(nameof(_scrollRect));


        _inventory = inventory;
        _sections = new List<ViewSection>(inventory.Sections.Count);

        _infoWindow.Init(_camera);
        _infoWindow.Hide();

        for (int i = 0; i < _inventory.Sections.Count; i++)
        {
            ViewSection newSection = Instantiate(_sectionPrefab, _viewportWindow);
            _sections.Add(newSection);
            newSection.Init(_inventory.Sections[i], _infoWindow);
        }
    }

    public void Refresh()
    {
        Clear();

        for (int i = 0; i < _inventory.Sections.Count; i++)
        {
            _sections[i].Refresh(_inventory.Sections[i]);
        }

        _currentSectionNumber = 0;
        _sectionNameField.text = _sections[_currentSectionNumber].Name;
        _scrollRect.content = _sections[_currentSectionNumber].GetComponent<RectTransform>();
        _sections[_currentSectionNumber].Show();
        _weightPanel.Refresh(_inventory.OverallWeight, _inventory.MaxWeight);
    }

    public void Clear()
    {
        _sections.ForEach(x => x.Clear());
    }

    public void ShowNextSection()
    {
        _sections[_currentSectionNumber].Hide();

        if (_currentSectionNumber < _inventory.Sections.Count - 1)
        {
            _currentSectionNumber++;
        }
        else
        {
            _currentSectionNumber = 0;
        }

        _scrollRect.content = _sections[_currentSectionNumber].GetComponent<RectTransform>();
        _sectionNameField.text = _sections[_currentSectionNumber].Name;
        _sections[_currentSectionNumber].Show();
    }

    public void ShowPreviousSection()
    {
        _sections[_currentSectionNumber].Hide();

        if (_currentSectionNumber > 0)
        {
            _currentSectionNumber--;
        }
        else
        {
            _currentSectionNumber = _inventory.Sections.Count - 1;
        }

        _scrollRect.content = _sections[_currentSectionNumber].GetComponent<RectTransform>();
        _sectionNameField.text = _sections[_currentSectionNumber].Name;
        _sections[_currentSectionNumber].Show();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
