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
    public float rotation;
}

public struct SpawnedPrefab
{
    public GameObject gameObject;

    public float rotation;
}

public class ARImageObjectSpawner : MonoBehaviour
{
    private ARTrackedImageManager imageManager;
    public PlaceablePrefabs[] prefabs;
    private Dictionary<string, SpawnedPrefab> spawnedPrefabs = new Dictionary<string, SpawnedPrefab>();

    // Start is called before the first frame update
    void Awake()
    {
        imageManager = GetComponent<ARTrackedImageManager>();
        
        foreach (PlaceablePrefabs prefab in prefabs)
        {
            GameObject newPrefab = Instantiate(prefab.prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            newPrefab.SetActive(false);

            SpawnedPrefab spawnedPrefab;
            spawnedPrefab.gameObject = newPrefab;
            spawnedPrefab.rotation = prefab.rotation;
            spawnedPrefabs.Add(newPrefab.name, spawnedPrefab);
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
            spawnedPrefabs[image.referenceImage.name].gameObject.SetActive(false);
        }
    }

    private void UpdateSpawned(ARTrackedImage image)
    {
        string name = image.referenceImage.name;
        SpawnedPrefab spawned = spawnedPrefabs[name];

        if (image.trackingState == TrackingState.Tracking)
        {
            spawned.gameObject.transform.position = image.transform.position;
            spawned.gameObject.transform.Rotate(Vector3.up, spawned.rotation);
            spawned.gameObject.SetActive(true);
        }
        else
        {
            spawned.gameObject.SetActive(false);
        }
    }
}