using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class editorScripts : MonoBehaviour
{
   
}

public class CountSingleMaterialObjects : EditorWindow
{
    [MenuItem("Herramientas/Contar Objetos con Un Solo Material")]
    public static void CountObjectsWithSingleMaterial()
    {
        Renderer[] renderers = GameObject.FindObjectsOfType<Renderer>();
        Dictionary<Material, int> materialCount = new Dictionary<Material, int>();

        int singleMaterialObjects = 0;

        foreach (Renderer rend in renderers)
        {
            Material[] materials = rend.sharedMaterials;
            if (materials.Length == 1 && materials[0] != null)
            {
                singleMaterialObjects++;
                Material mat = materials[0];

                if (materialCount.ContainsKey(mat))
                {
                    materialCount[mat]++;
                }
                else
                {
                    materialCount[mat] = 1;
                }
            }
        }

        Debug.Log($"Total de objetos con un solo material: {singleMaterialObjects}");

        foreach (var pair in materialCount)
        {
            Debug.Log($"Material: {pair.Key.name} - Usado por {pair.Value} objetos");
        }
    }
}