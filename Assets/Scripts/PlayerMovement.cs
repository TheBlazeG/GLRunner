using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    Animator anim;
    [SerializeField] LayerMask floor;
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundDistance;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
    }

    private bool GroundCheck()
    {
        Debug.DrawRay(transform.position, Vector3.down * groundDistance, Color.cyan,1);
        return Physics.Raycast(transform.position, Vector3.down, groundDistance, floor, QueryTriggerInteraction.Ignore);
    }


    public void Jump()
    {
        if (GroundCheck())
        {
            anim.SetBool("Jump", true);
            rb.linearVelocity = Vector3.up*jumpForce;
            
        }
        
    }

    public void ResetJump()
    {
        anim.SetBool("Jump", false);
    }
}
