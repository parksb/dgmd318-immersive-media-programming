using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlace : MonoBehaviour
{
    public List<GameObject> prefabs;
    public AudioSource sound;

    private UpdateLabels labelController;
    private ARRaycastManager raycastManager;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    private string mode = "Add";

    // Start is called before the first frame update
    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        labelController = GetComponent<UpdateLabels>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 mousePosition = Input.mousePosition;
            if (!IsOverUI(mousePosition) && mode == "Add")
            {
                create(mousePosition);
                sound.Play();
                labelController.UpdateObjectAliveLabel(spawnedObjects.Count);
            }
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

    bool IsOverUI(Vector3 position)
    {
        PointerEventData eventPosition = new PointerEventData(EventSystem.current);
        eventPosition.position = new Vector2(position.x, position.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventPosition, results);

        return results.Count > 0;
    }

    public void ChangeMode(string value)
    {
        mode = value;
        labelController.UpdateModeLabel(value);
    }
}