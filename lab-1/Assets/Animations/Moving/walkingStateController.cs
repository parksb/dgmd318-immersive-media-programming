using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingStateController : MonoBehaviour
{
    Animator animator;
 
    int isWalkingHash;
    int isWalkingBackHash;
    int isRunningHash;
    int isJumpingHash;
  
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isWalkingBackHash = Animator.StringToHash("isWalkingBack");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        float velo = 1.5f;
       
        if (!isWalking && forwardPressed) {
            animator.SetBool(isWalkingHash, true);
        }
        
        if (isWalking && !forwardPressed) {
            animator.SetBool(isWalkingHash, false);
        }
        
        bool isWalkingBack = animator.GetBool(isWalkingBackHash);
        bool backwardPressed = Input.GetKey("s");

        if (!isWalkingBack && backwardPressed) {
            animator.SetBool(isWalkingBackHash, true);
        }
        
        if (isWalkingBack) {
            velo = -1.2f;
            if (!backwardPressed) {
                animator.SetBool(isWalkingBackHash, false);
            }
        }
          
        bool isRunning = animator.GetBool(isRunningHash);
        bool runPressed = Input.GetKey("left shift");
        
        if (!isRunning && (forwardPressed && runPressed)) {
            animator.SetBool(isRunningHash, true);
        }
        
        if (isRunning) {
            velo = 3.1f;
            if (!forwardPressed || !runPressed) {
                animator.SetBool(isRunningHash, false);
            }
        }
        
        bool isJumping = animator.GetBool(isJumpingHash);
        bool jumpPressed = Input.GetKey("space");
        
        if (!isJumping && jumpPressed) {
            animator.SetBool(isJumpingHash, true);
        }
        
        if (isJumping && !jumpPressed) {
            animator.SetBool(isJumpingHash, false);
        }
        
        if (isWalking || isRunning || isWalkingBack) {
            transform.Translate(new Vector3(0, 0, velo * Time.deltaTime));
        }
    }
}
