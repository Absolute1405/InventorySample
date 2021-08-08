using UnityEngine;

[CreateAssetMenu(menuName = "Items/Books", order = 3)]
public class Book : Item
{
    [SerializeField] private TextAsset _textSource;
    public override ItemType Kind => ItemType.Book;


}
