using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class AlignToTextureBottom : MonoBehaviour
{
	public int pixPerUnit = 200;
	public Texture2D texture;

	private void Awake()
	{
		Align();
	}

#if UNITY_EDITOR
	private void Update()
	{
		Align();
	}
#endif

	private void Align()
	{
		if (texture == null) return;
		var unitHeight = texture.height / pixPerUnit;
		transform.localPosition = Vector3.up * unitHeight * 0.5f;
	}
}
