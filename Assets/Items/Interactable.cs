using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InteractEvent : UnityEvent<Vector2> { }

public class Interactable : MonoBehaviour
{
	public InteractEvent OnInteract;

	public void HandleInteract(Vector2 interactionPoint)
	{
		OnInteract.Invoke(interactionPoint);
		Debug.Log(interactionPoint);
	}
}
