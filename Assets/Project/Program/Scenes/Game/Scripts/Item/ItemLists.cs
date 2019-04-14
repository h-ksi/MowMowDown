using UnityEngine;
using UniRx;

[CreateAssetMenu(fileName = "PlayersItem", menuName = "CreatePlayersItem")]
public class ItemLists : ScriptableObject
{
    public static ReactiveCollection<ItemData> _itemLists = new ReactiveCollection<ItemData>();

    //アイテムリストを返す
    public ReactiveCollection<ItemData> GetItemLists()
    {
        return _itemLists;
    }
}
