using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPosition : MonoBehaviour
{
	public event System.Action<ItemPosition> OnSelect;

	public Transform item;

	void Start()
	{
		if (item == null) return;
		var interactable = item.GetComponent<Interactable>();
		interactable.OnInteract += HandleInteract;
	}

	public void SetItem(Transform item)
	{
		if (this.item != null)
		{
			this.item.GetComponent<Interactable>().OnInteract -= HandleInteract;
		}
		this.item = item;
		item.position = transform.position;
		item.GetComponent<Interactable>().OnInteract += HandleInteract;
	}

	void HandleInteract(Vector3 _)
	{
		Debug.Log("Here");
		OnSelect?.Invoke(this);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(transform.position, 0.2f);
	}
}
