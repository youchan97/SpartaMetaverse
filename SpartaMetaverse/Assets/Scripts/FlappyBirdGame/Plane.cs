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
    [SerializeField] UiManager uiManager;
    public PlayerInput playerInput;

    [SerializeField] float speed;
    [SerializeField] float rotatePower;
    [SerializeField] float jumpPower;
    [SerializeField] float deadCoolDown;

    private bool isDead;
    public bool isGodmode;

    private Vector2 saveVelocity;

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
        if(flappyBirdManager.isStart && flappyBirdManager.isPause == false)
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

    public void PausePlane()
    {
        uiManager.OpenPauseUi(true);
        flappyBirdManager.isPause = true;
        if (rb != null)
        {
            saveVelocity = rb.velocity;
            Destroy(rb);
        }
        
    }

    public void ResumePlane()
    {
        uiManager.OpenPauseUi(false);
        flappyBirdManager.isPause = false;
        rb = this.gameObject.AddComponent<Rigidbody2D>();
        rb.velocity = saveVelocity;
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

    private void OnTriggerExit2D(Collider2D collision)
    {

        if(isDead == false && collision.CompareTag("Obstacle"))
        {
            Debug.Log("Á¡¼ö");
            flappyBirdManager.GetScore();
        }
    }

    #region InputSystem
    private void OnJump()
    {
        if (isDead || flappyBirdManager.isPause)
            return;
        Vector2 velocity = rb.velocity;
        velocity.y += jumpPower;
        rb.velocity = velocity;
    }

    private void OnPause()
    {
        if(flappyBirdManager.isStart)
        {
            if (!flappyBirdManager.isPause)
                PausePlane();
            else
                ResumePlane();
        }
    }
    #endregion

}
