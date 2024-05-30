using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + Vector3.up * offset.y +
            Vector3.ProjectOnPlane(target.right, Vector3.up).normalized * offset.x +
            Vector3.ProjectOnPlane(target.forward, Vector3.up).normalized * offset.z;
    }
}
