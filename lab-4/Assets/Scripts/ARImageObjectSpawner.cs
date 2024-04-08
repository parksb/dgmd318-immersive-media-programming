using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[System.Serializable]
public struct PlaceablePrefabs
{
    public string name;
    public GameObject prefab;
}

public class ARImageObjectSpawner : MonoBehaviour
{
    private ARTrackedImageManager imageManager;
    public PlaceablePrefabs[] prefabs;
    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        imageManager = GetComponent<ARTrackedImageManager>();
        
        foreach (PlaceablePrefabs prefab in prefabs)
        {
            GameObject newPrefab = Instantiate(prefab.prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            newPrefab.SetActive(false);
            spawnedPrefabs.Add(prefab.name, newPrefab);
        }
    }

    private void OnEnable()
    {
        imageManager.trackedImagesChanged += OnImageChanged;
    }
    
    private void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage image in args.added)
        {
            UpdateSpawned(image);
        }

        foreach (ARTrackedImage image in args.updated)
        {
            UpdateSpawned(image);
        }
         
        foreach (ARTrackedImage image in args.removed)
        {
            spawnedPrefabs[image.referenceImage.name].SetActive(false);
        }
    }

    private void UpdateSpawned(ARTrackedImage image)
    {
        string name = image.referenceImage.name;
        GameObject spawned = spawnedPrefabs[name];

        if (image.trackingState == TrackingState.Tracking)
        {
            spawned.transform.position = image.transform.position;
            spawned.transform.rotation = image.transform.rotation;
            spawned.SetActive(true);
        }
        else
        {
            spawned.SetActive(false);
        }
    }
}