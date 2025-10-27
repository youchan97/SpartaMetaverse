using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;

    [SerializeField] SpriteRenderer characterRenderer;
    [SerializeField] Transform weaponPivot;

    protected Vector2 moveDir = Vector2.zero;
    public Vector2 MoveDir { get { return moveDir; } set { moveDir = value; } }

    protected Vector2 lookDir = Vector2.zero;
    public Vector2 LookDir { get { return lookDir; } set { lookDir = value; } }

    private Camera camera;

    Vector2 knockBack = Vector2.zero;
    float knockBackDuration = 0f;

    [SerializeField] float jumpPower;
    [SerializeField] LayerMask groundLayer;
    void Start()
    {
        camera = Camera.main;
    }

    private void FixedUpdate()
    {
        Move(MoveDir);
        if(knockBackDuration > 0f)
        {
            knockBackDuration -= Time.fixedDeltaTime;
        }
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
        bool isRun = MoveDir.sqrMagnitude > 0f;
        MoveDir = MoveDir.normalized;
        anim.SetBool("IsRun", isRun);
        if (MoveDir.x < 0)
        {
            characterRenderer.flipX = true;
        }
        else if (MoveDir.x > 0)
        {
            characterRenderer.flipX = false;
        }
        
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

    void OnJump(InputValue inputValue)
    {
        if(IsGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    bool IsGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);
        return (hit.collider != null);
    }
}
