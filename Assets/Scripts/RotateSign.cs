using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSign : MonoBehaviour
{
    public static RotateSign instance;
    private Animator animator;
    public bool isActive = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }

        animator = GetComponent<Animator>();
    }

    public void IsActiveFalse()
    {
        isActive = false;
    }
    public void StartAnimation()
    {
        if (!isActive)
        {
            isActive = true;
            animator.SetTrigger("Active");
        }

    }
}
