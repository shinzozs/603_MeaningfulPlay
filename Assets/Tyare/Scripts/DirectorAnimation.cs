using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DirectorAnimation : MonoBehaviour
{
    Vector3 moveDirection;
    private Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (moveDirection == Vector3.zero)
        {
            animator.SetFloat("Speed", 0);
        }
        else
        {
            animator.SetFloat("Speed", 1);
        }
    }
}
