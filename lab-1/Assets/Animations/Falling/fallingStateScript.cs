using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingStateScript : MonoBehaviour
{
    Animator animator;
    
    int isFallingDoneHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();     
        isFallingDoneHash = Animator.StringToHash("isFallingDone");   
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0) {
            transform.Translate(new Vector3(0, -20.0f * Time.deltaTime, 0));
        } else {
            animator.SetBool(isFallingDoneHash, true);
        }
    }
}
