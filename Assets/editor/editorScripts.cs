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

public class EnableContributeGI
{
    [MenuItem("Tools/Enable Contribute GI")]
    public static void EnableContributeGlobalIllumination()
    {
        int count = 0;

        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj.GetComponent<MeshRenderer>() != null)
            {
                StaticEditorFlags flags = GameObjectUtility.GetStaticEditorFlags(obj);

                // Añade la bandera ContributeGI
                flags |= StaticEditorFlags.ContributeGI;

                GameObjectUtility.SetStaticEditorFlags(obj, flags);
                count++;
            }
        }

        Debug.Log($"Se ha activado 'Contribute GI' en {count} GameObjects con MeshRenderer.");
    }
}

public class SetLightsToBaked
{
    [MenuItem("Tools/Set All Lights To Baked")]
    public static void SetAllLightsToBaked()
    {
        Light[] allLights = GameObject.FindObjectsOfType<Light>();
        int count = 0;

        foreach (Light light in allLights)
        {
            if (light.lightmapBakeType != LightmapBakeType.Baked)
            {
                Undo.RecordObject(light, "Set Light to Baked"); // Para permitir deshacer
                light.lightmapBakeType = LightmapBakeType.Baked;
                EditorUtility.SetDirty(light); // Marca como modificado
                count++;
            }
        }

        Debug.Log($"Se han establecido {count} luces como Baked.");
    }
}