using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    public int chairNumber;
    public Color color;
    public int sortingOrder;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        transform.localScale = transform.parent.localScale * .8f;
        transform.localPosition = new Vector2(chairNumber - Random.Range(0, 16), 0);
        StartCoroutine(CoroutineSit());
        spriteRenderer.color = color;
    }

    private IEnumerator CoroutineSit()
    {
        spriteRenderer.sortingOrder = sortingOrder - 2;
        while (transform.localPosition.x < chairNumber + .5f)
        {
            transform.localPosition += new Vector3(.1f, 0, 0);
            yield return new WaitForFixedUpdate();
        }
        spriteRenderer.sortingOrder = sortingOrder - 1;
        animator.SetTrigger("sit");
    }

    public void InitValues(int chairNumber, Color color, int sortingOrder)
    {
        this.chairNumber = chairNumber;
        this.color = color;
        this.sortingOrder = sortingOrder;
    }

    public void Up()
    {
        if (transform.localPosition.x >= chairNumber + .5f)
        {
            animator.SetTrigger("up");
            transform.localPosition += new Vector3(Random.Range(-45, -40), -transform.localPosition.y, 0);
            StartCoroutine(CoroutineSit());
        }
        else
            transform.localPosition += new Vector3(-40, 0, 0);
    }
}