using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlace : MonoBehaviour
{
    public List<GameObject> prefabs;
    public AudioSource sound;

    public TMP_Text objectAliveText;

    private ARRaycastManager raycastManager;
    private List<GameObject> spawnedObjects = new List<GameObject>();

    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            create(Input.mousePosition);
            sound.Play();
            objectAliveText.text = "Objects alive: " + spawnedObjects.Count;
        }
    }

    void create(Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (raycastManager.Raycast(ray, hitResults, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hitResults[0].pose;
            int count = Random.Range(1, 4);
            for (int i = 0; i < count; i++)
            {
                GameObject prefab = prefabs[Random.Range(0, prefabs.Count)];
                Vector3 direction = new Vector3(Random.Range(-0.2f, 0.2f), 0.1f, Random.Range(-0.2f, 0.2f));
                GameObject obj = Instantiate(prefab, hitPose.position + direction, hitPose.rotation);
                spawnedObjects.Add(obj);
            }
        }
    }
}
