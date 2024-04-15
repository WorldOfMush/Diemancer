using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private float speed = .2f;
    [SerializeField] private Vector3 direction;
    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 1.5f;
            direction = direction * -1;
        }

        transform.position += direction * speed * Time.deltaTime;
    }
}
