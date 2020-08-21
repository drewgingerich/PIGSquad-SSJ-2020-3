using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SizeToTexture : MonoBehaviour
{
	public int pixPerUnit = 200;
	public Texture2D texture;

	void OnEnable()
	{
		SetSize();
	}

	private void SetSize()
	{
		if (texture == null) return;
		transform.localScale = new Vector3(texture.width / pixPerUnit, texture.height / pixPerUnit, 1);
	}
}
