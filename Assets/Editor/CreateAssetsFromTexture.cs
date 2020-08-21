using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class CreateAssetsFromTexture
{
	private const string shaderName = "Universal Render Pipeline/Simple Lit";
	private const string referenceMatPath = "Assets/General/Reference Material.mat";

	[MenuItem("Assets/Create/Assets From Texture", false, 0)]
	public static void Test()
	{
		var textures = Selection.GetFiltered(typeof(Texture2D), SelectionMode.Assets)
			.Cast<Texture2D>()
			.ToArray();
		if (textures.Length == 0)
		{
			Debug.LogWarning("No textures selected");
			return;
		};

		var shader = Shader.Find(shaderName);

		try
		{
			AssetDatabase.StartAssetEditing();
			foreach (var tex in textures)
			{
				var texPath = AssetDatabase.GetAssetPath(tex);

				var matPath = Path.ChangeExtension(texPath, "mat");
				Material mat = null;
				if (File.Exists(matPath))
				{
					mat = (Material)AssetDatabase.LoadAssetAtPath(matPath, typeof(Material));
				}
				else
				{
					var referenceMat = (Material)AssetDatabase.LoadAssetAtPath(referenceMatPath, typeof(Material));
					mat = new Material(referenceMat);
					AssetDatabase.CreateAsset(mat, matPath);
				}
				mat.SetTexture("_BaseMap", tex);


				var prefabPath = Path.ChangeExtension(texPath, "prefab");
				GameObject prefab = null;
				if (File.Exists(prefabPath))
				{
					prefab = (GameObject)AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject));
				}
				else
				{
					prefab = GameObject.CreatePrimitive(PrimitiveType.Quad);
				}

				prefab.GetComponent<MeshRenderer>().material = mat;
				var sizer = prefab.GetComponent<SizeToTexture>();
				if (sizer == null) sizer = prefab.AddComponent<SizeToTexture>();
				sizer.texture = tex;

				if (File.Exists(prefabPath))
				{
					PrefabUtility.SavePrefabAsset(prefab);
				}
				else
				{
					PrefabUtility.SaveAsPrefabAsset(prefab, prefabPath);
					GameObject.DestroyImmediate(prefab);
				}

			}
		}
		finally
		{
			AssetDatabase.StopAssetEditing();
		}
	}
}
