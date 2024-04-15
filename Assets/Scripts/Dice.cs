using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private List<SO_DiceSide> all_dice_sides;
    public SO_DiceSide currentSO;

    [SerializeField] private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2D;

    [SerializeField] private float jump_force = 1000f;

    [SerializeField] private SpriteRenderer Freeze_Effect;

    private bool isFrozen = false;

    public bool canRoll = false;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        all_dice_sides = DiceSideHolder.instance.current_dice_sides;
        Freeze_Effect.enabled = isFrozen;
    }

    public void ResetDice()
    {
        if (isFrozen)
        {
            FreezeDice();
        }
    }

    public void FreezeDice()
    {
        isFrozen = !isFrozen;
        Freeze_Effect.enabled = isFrozen;
    }
    public bool GetIsFrozen()
    {
        return isFrozen;
    }

    public void ActivateDice()
    {
        if (!isFrozen)
        {
            canRoll = false;
            rb2D.velocity = Vector3.up * jump_force;
            StartCoroutine(Rotate(.3f));
        }
    }

    private void RandomDice()
    {
        int randomNum = Random.Range(0, all_dice_sides.Count);
        spriteRenderer.sprite = all_dice_sides[randomNum].side_image;
        currentSO = all_dice_sides[randomNum];
    }

    private IEnumerator Rotate(float duration)
    {
        float rotationAmount = 180.0f;
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
        RandomDice();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!canRoll) canRoll = true;
    }
    public void ActivateSO()
    {
        if (currentSO.gameObjectForEffect.TryGetComponent<EffectSO>(out EffectSO effectSO) )
        {
            rb2D.velocity = Vector3.up * jump_force/3;
            effectSO.ActivateDice();
        }

    }
    public void EndTurnEffectSO()
    {
        if (currentSO.gameObjectForEffect.TryGetComponent<EffectSO>(out EffectSO effectSO))
        {
            effectSO.EndTurnEffect();
        }
    }
}
