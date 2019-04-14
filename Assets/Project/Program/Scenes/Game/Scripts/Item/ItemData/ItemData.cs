using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData/CreateItem")]
public class ItemData : ScriptableObject
{
	public enum ItemType
	{
		Weapon,
		Consumable
	}

	//　アイテムの種類
	[SerializeField]
	ItemType _itemType;

	//　アイテムのアイコン
	[SerializeField]
	 Sprite _icon;
	
	//　アイテムの名前
	[SerializeField]
	 string _itemName;
	
	//　アイテムの情報
	[SerializeField]
	 string _information;

	public ItemType GetItemType()
	{
		return _itemType;
	}

	public Sprite GetIcon()
	{
		return _icon;
	}
	
	public string GetItemName()
	{
		return _itemName;
	}
	
	public string GetInformation()
	{
		return _information;
	}
}
