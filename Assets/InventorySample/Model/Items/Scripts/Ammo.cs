using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Ammo", order = 2)]
public class Ammo : Item
{
    [SerializeField] private Weapon _relatedWeapon;
    [SerializeField] private int _damage;
    public override ItemType Kind => ItemType.Ammo;

    private void OnValidate()
    {
        if (_relatedWeapon?.IsRanged == false)
        {
            Debug.LogWarning(nameof(_relatedWeapon) + " is not ranged weapon!");
            _relatedWeapon = null;
        }
    }

    public Weapon RelatedWeapon { get => _relatedWeapon; }

    public int Damage { get => _damage; }
}
