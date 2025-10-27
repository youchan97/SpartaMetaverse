using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] SpriteRenderer characterRenderer;
    [SerializeField] Transform weaponPivot;

    protected Vector2 moveDir = Vector2.zero;
    public Vector2 MoveDir { get { return moveDir; } set { moveDir = value; } }

    protected Vector2 lookDir = Vector2.zero;
    public Vector2 LookDir { get { return lookDir; } set { lookDir = value; } }

    private Camera camera;

    Vector2 knockBack = Vector2.zero;
    float knockBackDuration = 0f;
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move(MoveDir);
        if(knockBackDuration > 0f)
        {
            knockBackDuration -= Time.fixedDeltaTime;
        }
    }

    private void LateUpdate()
    {
        
    }

    void Move(Vector2 dir)
    {
        dir = dir * 5;
        if(knockBackDuration > 0f)
        {
            dir *= 0.2f;
            dir += knockBack;
        }
        rb.velocity = dir;
    }
    
    void OnMove(InputValue inputValue)
    {
        MoveDir = inputValue.Get<Vector2>();
        MoveDir = MoveDir.normalized;
        if (MoveDir.x < 0)
            characterRenderer.flipX = true;
        else if (MoveDir.x > 0)
            characterRenderer.flipX = false;
    }

    void OnLook(InputValue inputValue)
    {
        Vector2 mousePos = inputValue.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePos);
        LookDir = (worldPos - (Vector2)transform.position);
        if (LookDir.magnitude < 0.9f)
            LookDir = Vector2.zero;
        else
            LookDir = LookDir.normalized;
    }
}
