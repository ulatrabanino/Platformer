using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterMoves : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    public float runForce = 10f;
    public float maxRunSpeed = 6f;
    public float jumpForce = 10f;
    public bool feetInContactWithGround;
    private Collider c;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private float ogrun;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        c = GetComponent<Collider>();
        animator = GetComponent<Animator>();
        ogrun = runForce;
    }

    // Update is called once per frame
    void Update()
    {
        float castDistance = c.bounds.extents.y + 0.1f;
        feetInContactWithGround = Physics.Raycast(transform.position, Vector3.down, castDistance);

        float horizontal = Input.GetAxis("Horizontal");
        rb.AddForce(Vector3.right * horizontal * runForce, ForceMode.Force);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            runForce = ogrun * 5f;
            rb.AddForce(Vector3.right * horizontal * runForce, ForceMode.Force);
            Debug.Log(rb.velocity.magnitude);
        }
        else
        {
            runForce = ogrun;
        }

        if (feetInContactWithGround && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            animator.SetBool("Jump", true);
            Debug.Log(isJumping);
            jumpTimeCounter = jumpTime;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        //hold space to jump higher
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                float temp = 0.3f;
                rb.AddForce(Vector3.up * temp, ForceMode.Impulse);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
                animator.SetBool("Jump", false);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            animator.SetBool("Jump", false);
        }

        if(Mathf.Abs(rb.velocity.x) > maxRunSpeed)
        {
            float newX = maxRunSpeed * Mathf.Sign(rb.velocity.x);
            rb.velocity = new Vector3(newX, rb.velocity.y, rb.velocity.z);
        }

        if(horizontal < 0.1f)
        {
            float newX = rb.velocity.x * (1f - Time.deltaTime * 5f);
            rb.velocity = new Vector3(newX, rb.velocity.y, rb.velocity.z);
        }

        animator.SetFloat("Speed", rb.velocity.magnitude);
    }

}
