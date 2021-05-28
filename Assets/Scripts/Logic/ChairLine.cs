using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairLine : MonoBehaviour
{
    public enum EChairLineMovement
    {
        stopped,
        linear,
        sinusoidal
    }
    private const int LINE = 8;

    public EChairLineMovement chairLineMovement = EChairLineMovement.stopped;

    public People[] peoples;

    private float angle;
    private Vector3 lastLocalPosition;
    private SpriteRenderer spriteRenderer;
    private readonly List<People> peopleCreated = new List<People>();

    private void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

    private void Start()
    {
        Color colorLine = RandomFromColor(spriteRenderer.color);

        int chairNumber = -LINE;
        while (chairNumber < LINE - 1)
        {
            chairNumber = Random.Range(chairNumber + 1, chairNumber + LINE);
            if (chairNumber < LINE)
            {
                People tmp = Instantiate<People>(peoples[Random.Range(0, peoples.Length - 1)], transform.position, transform.rotation, transform);
                tmp.InitValues(chairNumber, colorLine, spriteRenderer.sortingOrder);
                peopleCreated.Add(tmp);
            }
        }
        angle = (transform.localScale.x - 1) * 5;
        lastLocalPosition = transform.localPosition;
    }

    private void FixedUpdate()
    {        
        switch (chairLineMovement)
        {
            case EChairLineMovement.stopped: return;
            case EChairLineMovement.linear:
                transform.localPosition -= new Vector3(.05f * transform.localScale.x, 0, 0);
                if (transform.localPosition.x <= -20 * transform.localScale.x)
                {
                    transform.localPosition += new Vector3(40 * transform.localScale.x, 0, 0);
                    foreach (People people in peopleCreated)
                        people.Up();
                }
                lastLocalPosition = transform.localPosition;
                break;
            case EChairLineMovement.sinusoidal:
                transform.localPosition = lastLocalPosition + Mathf.Sin(angle) * Vector3.right * transform.localScale.x;
                if (transform.localPosition.x <= -20 * transform.localScale.x)
                {
                    transform.localPosition += new Vector3(40 * transform.localScale.x, 0, 0);
                    foreach (People people in peopleCreated)
                        people.Up();
                }
                angle += .1f;
                break;
        }
    }

    private Color RandomFromColor(Color color) => new Color(RandomComponent(color.r), RandomComponent(color.g), RandomComponent(color.b));

    private float RandomComponent(float component) => Random.Range(component / 4, component / 2);

}