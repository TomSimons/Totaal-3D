using Netherlands3D.Core;
using Netherlands3D.T3D.Uitbouw;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using T3D.LoadData;
using UnityEngine;

public class CityJsonBagBoundingBoxVisualizer : MonoBehaviour
{
    void OnEnable()
    {
        ServiceLocator.GetService<MetadataLoader>().CityJsonBagBoundingBoxReceived += OnCityJsonBagBoundingBoxReceived;
    }

    void OnDisable()
    {
        ServiceLocator.GetService<MetadataLoader>().CityJsonBagBoundingBoxReceived -= OnCityJsonBagBoundingBoxReceived;
    }

    private void OnCityJsonBagBoundingBoxReceived(string cityJson, string excludeBagId)
    {
        StartCoroutine(ParseCityJson(cityJson, excludeBagId, false));
    }

    private IEnumerator ParseCityJson(string cityjson, string excludeBagId, bool checkDistanceFromCenter)
    {
        yield return new WaitUntil(() => RestrictionChecker.ActivePerceel.IsLoaded); //needed because perceelRadius is needed
        var buildingMeshes = CityJsonVisualiser.ParseCityJson(cityjson, transform.localToWorldMatrix, true, false);

        foreach (var pair in buildingMeshes.ToList()) //go to list to avoid Collection was modiefied errors
        {
            //if (pair.Key.Key.Contains(excludeBagId) || pair.Key.Key == "NL.IMBAG.Pand.-0")
            if (!pair.Key.Key.Contains(excludeBagId))
            {
                //buildingMeshes.Remove(pair.Key);
                AddMesh(pair.Key.Key, pair.Value);
                yield return null;
            }
        }

        //var combinedMesh = CityJsonVisualiser.CombineMeshes(buildingMeshes.Values.ToList(), transform.localToWorldMatrix);
        //GetComponent<MeshFilter>().sharedMesh = combinedMesh;
        //GetComponent<MeshCollider>().sharedMesh = combinedMesh;
    }

    /// <summary>
    /// Visualize each mesh
    /// </summary>    
    void AddMesh(string id, Mesh mesh)
    {
        var gam = new GameObject();
        gam.name = id;
        var filter = gam.AddComponent<MeshFilter>();
        var ren = gam.AddComponent<MeshRenderer>();
        ren.material = GetComponent<MeshRenderer>().material;
        filter.sharedMesh = mesh;
        gam.transform.parent = transform;
    }
}
