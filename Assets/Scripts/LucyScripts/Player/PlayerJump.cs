using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    private Rigidbody rb;

    private ShapeShiftInteractor shapeShiftInteractor;

    [SerializeField] private Animator[] animators;
    private int animatorIndex;

    private bool animated;

    public bool isGrounded { get; private set; }


    private void OnEnable()
    {
        shapeShiftInteractor.ShapeChanged += changeAnimator;
    }

    public void changeAnimator(string character)
    {
        Debug.Log(character);
        if (character == "Sponge")
        {
            animatorIndex = 0;
            animated = true;
        }
        else if (character == "Patrick")
        {
            animatorIndex = 1;
            animated = true;
        }
        else//Gary
        {
            animated = false;
        }

    }
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        shapeShiftInteractor = this.GetComponent<ShapeShiftInteractor>();   
        animatorIndex = 0;
        animated = true;
    }

    public void Jump()
    {
        if (!isGrounded) return;
        Debug.Log("jump");

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        if (!animated) return;
        Debug.Log(animatorIndex);
        animators[animatorIndex].SetTrigger("Jump");
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);

        if (!animated) return;

        if (isGrounded)
        {

            animators[animatorIndex].SetBool("IsGrounded", true);
        }
        else
        {
            
            animators[animatorIndex].SetBool("IsGrounded", false);
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
