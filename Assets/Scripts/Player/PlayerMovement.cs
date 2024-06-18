using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed = 12;

    private readonly int moveX = Animator.StringToHash("moveX");
    private readonly int moveY = Animator.StringToHash("moveY");
    private readonly int Dead = Animator.StringToHash("Dead");

    private Rigidbody2D rb;
    private Animator animator;

    private float dirX;
    private float dirY;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * speed, dirY * speed);
    }

    public void Move()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        // animator.SetFloat(moveX, dirX);
        // animator.SetFloat(moveY, dirY);
    }
}
