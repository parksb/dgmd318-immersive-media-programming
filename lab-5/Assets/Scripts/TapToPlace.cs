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
    public Material waterMaterial;
    public Material defaultMaterial;

    public AudioSource addSound;
    public AudioSource rangedAttackSound;
    public AudioSource massAttackSound;
    public AudioSource destroyedSound;

    private UpdateLabels labelController;
    private ARRaycastManager raycastManager;
    private ARPlaneManager arPlaneManager;
    private List<GameObject> spawnedObjects = new List<GameObject>();

    private string mode = "Add";
    private int objectsDestroyed = 0;

    // Start is called before the first frame update
    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        labelController = GetComponent<UpdateLabels>();
        arPlaneManager = GetComponent<ARPlaneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 mousePosition = Input.mousePosition;
            if (!IsOverUI(mousePosition))
            {
                List<ARRaycastHit> hitResults = new List<ARRaycastHit>();
                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                if (raycastManager.Raycast(ray, hitResults, TrackableType.PlaneWithinPolygon))
                {
                    ARRaycastHit hit = hitResults[0];
                    if (mode == "Add")
                    {
                        Add(mousePosition, hit.pose);
                        addSound.Play();
                        labelController.UpdateObjectsAliveLabel(spawnedObjects.Count);
                    }
                    else if (mode == "Ranged attack")
                    {
                        RangedAttack(mousePosition, hit.pose);
                        rangedAttackSound.Play();
                    }
                    else
                    {
                        MassAttack(mousePosition, hit);
                        massAttackSound.Play();
                    }
                }
            }
        }
    }

    void Add(Vector3 mousePosition, Pose hitPose)
    {
        int count = Random.Range(1, 4);
        for (int i = 0; i < count; i++)
        {
            GameObject prefab = prefabs[Random.Range(0, prefabs.Count)];
            Vector3 direction = new Vector3(Random.Range(-0.2f, 0.2f), 0.5f, Random.Range(-0.2f, 0.2f));
            GameObject obj = Instantiate(prefab, hitPose.position + direction, hitPose.rotation);
            spawnedObjects.Add(obj);
        }
    }

    void RangedAttack(Vector3 mousePosition, Pose hitPose)
    {
        Vector3 hitPosition = hitPose.position;
        Collider[] colliders = Physics.OverlapSphere(hitPosition, 0.3f);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(80.0f, hitPosition, 0.3f, 50);
            }
        }
    }

    void MassAttack(Vector3 mousePosition, ARRaycastHit hit)
    {
       StartCoroutine(ChangePlaneMaterial(hit));
    }

    bool IsOverUI(Vector3 position)
    {
        PointerEventData eventPosition = new PointerEventData(EventSystem.current);
        eventPosition.position = new Vector2(position.x, position.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventPosition, results);

        return results.Count > 0;
    }

    IEnumerator ChangePlaneMaterial(ARRaycastHit hit) {
        ARPlane plane = arPlaneManager.GetPlane(hit.trackableId);
        Renderer renderer = plane.GetComponent<Renderer>();

        renderer.material = waterMaterial;
        plane.GetComponent<PlaneController>().Toggle();
        yield return new WaitForSeconds(1);
        plane.GetComponent<PlaneController>().Toggle();
        renderer.material = defaultMaterial;
    }

    public void ChangeMode(string value)
    {
        mode = value;
        labelController.UpdateModeLabel(value);
    }

    public void DestoryObject(GameObject obj)
    {
        int lived = spawnedObjects.Count;

        Destroy(obj);
        destroyedSound.Play();
        spawnedObjects.RemoveAll(x => obj.GetInstanceID() == x.GetInstanceID());
        labelController.UpdateObjectsAliveLabel(spawnedObjects.Count);

        objectsDestroyed += lived - spawnedObjects.Count;
        labelController.UpdateObjectsDestroyedLabel(objectsDestroyed);
    }
}