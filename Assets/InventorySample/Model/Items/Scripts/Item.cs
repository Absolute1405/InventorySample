using System;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField, TextArea] private string _description;
    [SerializeField, Min(0)] private float _weight;
    [SerializeField, Min(0)] private int _cost;

    public abstract ItemType Kind { get; }

    public Sprite Icon { get => _icon; }
    public string Description { get => _description; }
    public float Weight { get => _weight; }
    public int Cost { get => _cost; }
}
