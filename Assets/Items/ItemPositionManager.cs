using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPositionManager : MonoBehaviour
{
	ItemPosition selectedPosition;

	void Start()
	{
		var positions = transform.GetComponentsInChildren(typeof(ItemPosition));
		foreach (ItemPosition p in positions)
		{
			p.OnSelect += HandleSelectItemPosition;
		}
	}

	void HandleSelectItemPosition(ItemPosition position)
	{
		if (selectedPosition == null)
		{
			selectedPosition = position;
			return;
		}
		var selectedItem = selectedPosition.item;
		selectedPosition.SetItem(position.item);
		position.SetItem(selectedItem);
	}
}
