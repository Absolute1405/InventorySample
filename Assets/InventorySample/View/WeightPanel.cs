using TMPro;
using UnityEngine;

public class WeightPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textField;

    public void Refresh(float current, float max)
    {
        _textField.text = $"{current} / {max}";
    }
}
