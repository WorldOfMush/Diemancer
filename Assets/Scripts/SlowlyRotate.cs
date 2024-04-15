using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyRotate : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
            transform.Rotate(new Vector3(0,0,1) * speed * Time.deltaTime);
    }
}
