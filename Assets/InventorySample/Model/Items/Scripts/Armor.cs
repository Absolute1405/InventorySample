using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Armor", order = 1)]
public class Armor : Item
{
    [SerializeField, Min(0)] private int _defence;
    [SerializeField] private int _resist;
    public override ItemType Kind => ItemType.Armor;
    public int Defence { get => _defence; }
    public int Resist { get => _resist; }
}
