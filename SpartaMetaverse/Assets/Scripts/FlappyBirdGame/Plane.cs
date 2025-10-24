using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
public class Plane : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] FlappyBirdManager flappyBirdManager;
    public PlayerInput playerInput;

    [SerializeField] float speed;
    [SerializeField] float rotatePower;
    [SerializeField] float jumpPower;
    [SerializeField] float deadCoolDown;

    private bool isDead;
    public bool isGodmode;

    private void Update()
    {
        if(isDead)
        {
            if(deadCoolDown <= 0)
            {
                flappyBirdManager.GameOver();
            }
            else
            {
                deadCoolDown -= Time.deltaTime;
            }
        }
    }


    private void FixedUpdate()
    {
        if(flappyBirdManager.isStart)
        {
            MoveForwardPlane();
            Rotate();
        }
    }
    private void MoveForwardPlane()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = speed;
        rb.velocity = velocity;
    }


    private void Rotate()
    {
        Vector2 velocity = rb.velocity;
        float angle = Mathf.Clamp((velocity.y * rotatePower), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void InitPlane()
    {
        playerInput.enabled = true;
        rb = this.gameObject.AddComponent<Rigidbody2D>();
    }

    public void StopPlane()
    {
        speed = 0;
        playerInput.enabled = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGodmode)
            return;
        if (isDead)
            return;

        animator.SetBool("IsDie", true);
        isDead = true;
        StopPlane();
    }

    #region InputSystem
    private void OnJump()
    {
        if (isDead)
            return;
        Vector2 velocity = rb.velocity;
        velocity.y += jumpPower;
        rb.velocity = velocity;
    }
    #endregion

}
