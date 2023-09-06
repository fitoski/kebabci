using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator; // Changed access modifier to private

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Corrected the capitalization and removed unnecessary space
    }

    // Update is called once per frame
    void Update()
    {
        // If the player presses the 'w' key
        if (Input.GetKey("w"))
        {
            // Set the "isWalking" boolean parameter in the animator to true
            animator.SetBool("isWalking", true);
        }
        else
        {
            // If the 'w' key is not being pressed, set the "isWalking" parameter to false
            animator.SetBool("isWalking", false);
        }
    }
}