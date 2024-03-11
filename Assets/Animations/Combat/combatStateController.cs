using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatStateController : MonoBehaviour
{
    Animator animator;
    int isPunchingHash;
    int isKickingHash;
  
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isPunchingHash = Animator.StringToHash("isPunching");
        isKickingHash = Animator.StringToHash("isKicking");
    }

    // Update is called once per frame
    void Update()
    {
        bool isPunching = animator.GetBool(isPunchingHash);
        bool punchPressed = Input.GetKey("z");
        
        if (!isPunching && punchPressed) {
            animator.SetBool(isPunchingHash, true);
        }
        
        if (isPunching && !punchPressed) {
            animator.SetBool(isPunchingHash, false);
        }
        
        bool isKicking = animator.GetBool(isKickingHash);
        bool kickPressed = Input.GetKey("x");
        
        if (!isKicking && kickPressed) {
            animator.SetBool(isKickingHash, true);
        }
        
        if (isKicking && !kickPressed) {
            animator.SetBool(isKickingHash, false);
        }
    }
}
