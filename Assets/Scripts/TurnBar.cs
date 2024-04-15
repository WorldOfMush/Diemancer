using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBar : MonoBehaviour
{
    [SerializeField] private float velocity = 5;
    [SerializeField] private float gravityScale = 1;
    private Rigidbody2D rb2D;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void ActivateTurnBar()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("OverLayer");
        foreach (SpriteRenderer obj in gameObject.GetComponentsInChildren<SpriteRenderer>()){
            obj.sortingLayerID = SortingLayer.NameToID("OverLayer");
        }
        float randomX = Random.Range(-.25f, .25f);
        rb2D.gravityScale = gravityScale;
        rb2D.velocity = new Vector3(randomX, 1, 0) * velocity;

        StartCoroutine(Rotate(3f));
    }

    private IEnumerator Rotate(float duration)
    {
        float rotationAmount = 360f;
        float startRotation = transform.eulerAngles.z;
        float endRotation = startRotation + rotationAmount;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float zRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % rotationAmount;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);
            yield return null;
        }
    }
}
