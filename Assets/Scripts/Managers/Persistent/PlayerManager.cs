using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    private bool _onFloor;
    public bool OnFloor
    {
        get => _onFloor;
        set
        {
            if (value == true)
            {
                animator.SetBool("Jump", false);
                animator.SetBool("Fall", false);
            }
            else if (rb.velocity.y > 0)
            {
                animator.SetBool("Jump", true);
                animator.SetBool("Fall", false);
            }
            else
            {
                animator.SetBool("Jump", false);
                animator.SetBool("Fall", true);
            }
            _onFloor = value;
        }
    }

    public bool isOn = false;

    private Vector3 startPosition;

    private Rigidbody2D rb;
    private Animator animator;

    private float horizontal = 0;
    private float vertical = 0;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this);
            Instance = this;
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }
    }

    private void Start() => startPosition = transform.position;


    private void Update()
    {
        if (!isOn)
            return;
        horizontal = Input.GetAxis("Horizontal") * 10;
        if (Input.GetButtonDown("Fire1") && OnFloor)
            vertical = 300;
    }

    public void FixedUpdate()
    {
        if (!isOn)
            return;
        if (!OnFloor && rb.velocity.y < 0)
            animator.SetBool("Fall", true);
        rb.AddForce(new Vector2(horizontal, vertical));
        Walk(!Mathf.Approximately(0, rb.velocity.x));
        horizontal = 0;
        vertical = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
            GameManager.Instance.End();
    }

    public void Reset()
    {
        transform.position = startPosition;
        rb.velocity = Vector2.zero;
        Walk(false);
    }

    public void Walk(bool walk) => animator.SetBool("Walk", walk);
}