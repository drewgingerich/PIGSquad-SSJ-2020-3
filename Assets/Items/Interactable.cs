using UnityEngine;
using UnityEngine.Events;
public class Interactable : MonoBehaviour
{
	public event System.Action<Vector3> OnInteract;

	public void HandleInteract(Vector3 interactionPoint)
	{
		Debug.Log(gameObject.name);
		OnInteract?.Invoke(interactionPoint);
	}
}
