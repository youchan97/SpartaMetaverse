using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static ConstInfo;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] PopupManager popupManager;

    [SerializeField] SpriteRenderer characterRenderer;

    private Vector2 moveDir = Vector2.zero;
    public Vector2 MoveDir { get { return moveDir; } set { moveDir = value; } }

    /*private Vector2 lookDir = Vector2.zero;
    public Vector2 LookDir { get { return lookDir; } set { lookDir = value; } }*/


    [SerializeField] float jumpPower;
    [SerializeField] LayerMask groundLayer;

    private bool isMove = true;
    public bool IsMove { get { return isMove; } set { isMove = value; } }
    private void FixedUpdate()
    {
        if (isMove)
            Move(MoveDir);
    }

    void Move(Vector2 dir)
    {
        dir = dir * 5;
        rb.velocity = dir;
    }

    public void StopPlayer()
    {
        IsMove = false;
        anim.SetBool("IsRun", false);
        rb.velocity = Vector2.zero;
        MoveDir = Vector2.zero;
    }

    public void MovePlayer()
    {
        IsMove = true;
    }

    void OnMove(InputValue inputValue)
    {
        if (isMove)
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
    }

    /*void OnLook(InputValue inputValue)
    {
        Vector2 mousePos = inputValue.Get<Vector2>();
        Camera camera = Camera.main;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePos);
        LookDir = (worldPos - (Vector2)transform.position);
        if (LookDir.magnitude < 0.9f)
            LookDir = Vector2.zero;
        else
            LookDir = LookDir.normalized;
    }*/

    /*void OnJump(InputValue inputValue)
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
    }*/
}
