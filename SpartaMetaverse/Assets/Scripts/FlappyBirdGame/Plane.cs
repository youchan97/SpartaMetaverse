using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Plane : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;

    [SerializeField] float speed;
    [SerializeField] float rotatePower;
    [SerializeField] float jumpPower;

    private bool isRotate;
    private bool isDead;
    public bool isGodmode;

    private void FixedUpdate()
    {
        MoveForwardPlane();
        Rotate();
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




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGodmode)
            return;
        if (isDead)
            return;

        animator.SetBool("IsDie", true);
        isDead = true;
    }

    #region InputSystem
    private void OnJump()
    {
        Vector2 velocity = rb.velocity;
        velocity.y += jumpPower;
        rb.velocity = velocity;
    }
    #endregion

}
