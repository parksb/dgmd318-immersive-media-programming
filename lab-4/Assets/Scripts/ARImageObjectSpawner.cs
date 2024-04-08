using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARImageObjectSpawner : MonoBehaviour
{
    private ARTrackedImageManager imageManager;

    [SerializeField]
    private GameObject prefab;

    private GameObject spawned;

    // Start is called before the first frame update
    void Start()
    {
        imageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        imageManager.trackedImagesChanged += OnImagesChanged;
    }
    
    private void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnImagesChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage image in args.added)
        {
            if (image.referenceImage.name == "earth" && spawned == null)
            {
                spawned = Instantiate(prefab, image.transform.position, image.transform.rotation);
            }
        }
        
         foreach (ARTrackedImage image in args.updated)
         {
             UpdateSpawned(image);
         }
         
          foreach (ARTrackedImage image in args.removed)
          {
              spawned.setActive(false);
          }
    }

    private void UpdateSpawned(ARTrackedImage image)
    {
        if (spawned == null)
        {
            return;
        }
        
        if (image.trackingState == TrackingState.Tracking && image.referenceImage.name == "earth")
        {
            spawned.setActive(true);
            spawned.transform.position = image.transform.position;
            spawned.transform.rotation = image.transform.rotation;
        }
        else if (image.trackingState == TrackingState.Limited || image.trackingState == TrackingState.None)
        {
            spawned.setActive(false);
        }
    }
}