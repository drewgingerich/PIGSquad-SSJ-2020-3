using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Renderer))]
public class ScaleMatWithTransform : MonoBehaviour
{
	[SerializeField]
	private float xTilesPerUnit = 1;
	[SerializeField]
	private float yTilesPerUnit = 1;

	void Start()
	{
		SetScale();
	}

#if UNITY_EDITOR
	void Update()
	{
		SetScale();
	}
#endif

	public void SetScale()
	{
		var xScale = transform.localScale.x * xTilesPerUnit;
		var yScale = transform.localScale.y * yTilesPerUnit;
		var renderer = GetComponent<Renderer>();
		renderer.material.SetTextureScale("_BaseMap", new Vector2(xScale, yScale));
	}
}