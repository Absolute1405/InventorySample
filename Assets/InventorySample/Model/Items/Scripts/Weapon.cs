using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon", order = 0)]
public class Weapon : Item
{
    [SerializeField, Min(0)] private int _damage;
    [SerializeField] private bool _isRanged;

    public override ItemType Kind => ItemType.Weapon;

    public int Damage { get => _damage; }
    public bool IsRanged { get => _isRanged; }
}