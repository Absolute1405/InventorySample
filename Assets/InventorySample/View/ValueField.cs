using UnityEngine;
using TMPro;
using System;

public class ValueField : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textField;

    private void Awake()
    {
        if (_textField is null)
            throw new ArgumentNullException(nameof(_textField));
    }

    public void SetValue(float value)
    {
        _textField.text = value.ToString("0.00");
    }

    public void SetValue(int value)
    {
        _textField.text = value.ToString();
    }
}
