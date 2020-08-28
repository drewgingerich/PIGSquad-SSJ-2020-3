﻿// https://forum.unity.com/threads/transparency-sort-mode-and-lightweight-render-pipeline.651700/

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.Rendering;

#if UNITY_EDITOR
[InitializeOnLoad]
#endif
class TransparencySortGraphicsHelper
{
	static TransparencySortGraphicsHelper()
	{
		OnLoad();
	}

	[RuntimeInitializeOnLoadMethod]
	static void OnLoad()
	{
		GraphicsSettings.transparencySortMode = TransparencySortMode.CustomAxis;
		GraphicsSettings.transparencySortAxis = new Vector3(0, 0, 1f);
		// GraphicsSettings.transparencySortMode = TransparencySortMode.Orthographic;
		// Debug.Log(GraphicsSettings.transparencySortMode);
		// Debug.Log(GraphicsSettings.transparencySortAxis);
	}
}
