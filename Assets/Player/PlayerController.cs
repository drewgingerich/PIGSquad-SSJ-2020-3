using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
	public PlayableDirector fadeToRoom;
	public PlayableDirector fadeToMirror;

	PlayerInput input;
	Vector2 mousePosition = Vector2.zero;
	bool interact = false;
	bool facingRoom = true;
	bool turning = false;

	public void OnAim(InputAction.CallbackContext ctx)
	{
		mousePosition = ctx.ReadValue<Vector2>();
	}

	public void OnInteract(InputAction.CallbackContext ctx)
	{
		if (ctx.phase != InputActionPhase.Performed) return;

		var ray = Camera.main.ScreenPointToRay(mousePosition);
		var hit = Physics2D.GetRayIntersection(ray);
		Debug.Log(hit);
		if (hit.collider == null) return;

		var interactable = hit.collider.gameObject.GetComponent<Interactable>();
		if (interactable == null) return;

		interactable.HandleInteract(hit.point);
	}

	public void OnTurn(InputAction.CallbackContext ctx)
	{
		if (turning) return;
		StartCoroutine(TurnRoutine());
	}

	IEnumerator TurnRoutine()
	{
		turning = true;
		if (facingRoom)
		{
			fadeToMirror.Play();
		}
		else
		{
			fadeToRoom.Play();
		}
		facingRoom = !facingRoom;
		yield return new WaitForSeconds(0.2f);
		turning = false;
	}
}
