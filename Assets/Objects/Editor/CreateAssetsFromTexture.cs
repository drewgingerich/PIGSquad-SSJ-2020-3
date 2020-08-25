using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class CreateAssetsFromTexture
{
	private const string objectDir = "Assets/Objects/";
	private const string objectArtDir = objectDir + "Art";
	private const string objectPrefabDir = objectDir + "Prefabs";
	private const string templatePrefabPath = objectDir + "Sprite-3DLit.prefab";

	[MenuItem("Assets/Create/Recreate Object Prefabs", false, 0)]
	public static void Test()
	{
		var guids = AssetDatabase.FindAssets("t:Sprite", new string[] { objectArtDir });
		var spritePaths = guids
			.Select(g => AssetDatabase.GUIDToAssetPath(g))
			.Cast<string>()
			.ToArray();

		try
		{
			AssetDatabase.StartAssetEditing();
			foreach (var spritePath in spritePaths)
			{
				var sprite = (Sprite)AssetDatabase.LoadAssetAtPath(spritePath, typeof(Sprite));

				var prefabName = Path.GetFileNameWithoutExtension(spritePath) + ".prefab";
				var prefabPath = Path.Combine(objectPrefabDir, prefabName);
				GameObject prefab = null;

				if (File.Exists(prefabPath))
				{
					AssetDatabase.DeleteAsset(prefabPath);
				}

				var templatePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(templatePrefabPath, typeof(GameObject));
				prefab = (GameObject)PrefabUtility.InstantiatePrefab(templatePrefab);

				prefab.GetComponent<SpriteRenderer>().sprite = sprite;

				PrefabUtility.SaveAsPrefabAsset(prefab, prefabPath);
				GameObject.DestroyImmediate(prefab);
			}
		}
		finally
		{
			AssetDatabase.StopAssetEditing();
		}
	}
}
