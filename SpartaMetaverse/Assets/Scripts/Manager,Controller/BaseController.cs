using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] SpriteRenderer characterRenderer;
    [SerializeField] Transform weaponPivot;

    protected Vector2 moveDir = Vector2.zero;
    public Vector2 MoveDir { get { return moveDir; } set { moveDir = value; } }

    protected Vector2 lookDir = Vector2.zero;
    public Vector2 LookDir { get { return lookDir; } set { lookDir = value; } }

    Vector2 knockBack = Vector2.zero;
    float knockBackDuration = 0f;

    protected virtual void Awake()
    {

    }


    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {
        Movment(MoveDir);
    }

    private void Movment(Vector2 direction)
    { 
        direction = direction * 5;
        if (knockBackDuration > 0.0f)
        { 
            direction *= 0.2f;
            direction += knockBack;
        } 
        rb.velocity = direction;
    }
}
