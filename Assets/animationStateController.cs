using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator; // Changed access modifier to private
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private Transform cameraFollowPoint;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Corrected the capitalization and removed unnecessary space
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(x, 0, z).normalized;

        if (movement.magnitude > 0)
        {
            transform.position += movement * 5f * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(movement);
        }

        // If the player presses the 'w' key
        if (movement.magnitude > 0)
        {
            // Set the "isWalking" boolean parameter in the animator to true
            animator.SetBool("isWalking", true);
        }
        else
        {
            // If the 'w' key is not being pressed, set the "isWalking" parameter to false
            animator.SetBool("isWalking", false);
        }

        cameraPivot.transform.position = cameraFollowPoint.transform.position;
    }
}