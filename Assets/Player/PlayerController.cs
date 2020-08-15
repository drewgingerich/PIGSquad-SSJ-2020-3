using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
	private PlayerInput input;
	private Vector2 mousePosition = Vector2.zero;
	private bool interact = false;
	private bool turn = false;

	public void OnAim(InputAction.CallbackContext ctx)
	{
		mousePosition = ctx.ReadValue<Vector2>();
	}

	public void OnInteract(InputAction.CallbackContext ctx)
	{
		interact = true;
	}

	public void OnTurn(InputAction.CallbackContext ctx)
	{
		turn = true;
	}
}
