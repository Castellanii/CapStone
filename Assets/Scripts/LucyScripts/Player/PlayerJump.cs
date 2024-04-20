using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Rigidbody rb;

    private Animator animator;
    public bool isGrounded { get; private set; }

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }
    public void Jump()
    {
        if (!isGrounded) return;
        Debug.Log("jump");
        animator.SetTrigger("Jump");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);
        if (isGrounded)
        {

            animator.SetBool("IsGrounded", true);
        }
        else
        {
            Debug.Log("false");
            animator.SetBool("IsGrounded", false);
        }
    }

    private void OnDrawGizmos()
    {
        if (isGrounded)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.black;
        }
        
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckDistance);
    }
}
