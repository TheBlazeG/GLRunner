using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    Animator anim;
    [SerializeField] LayerMask floor;
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundDistance;
    [SerializeField] private Transform attackCenter;
    [SerializeField] private LayerMask obstacles;

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


    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
        if (GroundCheck() )
        {
            anim.SetBool("Jump", true);
            rb.linearVelocity = Vector3.up*jumpForce;
            
        }
            
        }
        
    }

    public void Attack(InputAction.CallbackContext ctx)
    {

        if (ctx.performed)
        {
        Debug.Log("attackCalled");
        if (Physics.BoxCast(attackCenter.position,new Vector3(.5f,.5f,1f),attackCenter.forward,out RaycastHit hit, Quaternion.Euler(0,0,0),1f,obstacles,QueryTriggerInteraction.Collide) && ctx.performed)
        {
        Debug.Log("BoxcastSucceeded");

            hit.transform.gameObject.GetComponent<BreakableObstacleClass>().TakeDamage(1);
        }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(attackCenter.position,new Vector3(.5f, .5f, .5f) );
    }
    public void ResetJump()
    {
        anim.SetBool("Jump", false);
    }
}
