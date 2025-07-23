using Unity.VisualScripting;
using UnityEngine;

public class ObstacleClass : MonoBehaviour
{
    public int damage, myObstacleIndex;
    public float speed;
    protected Rigidbody rb;


    protected virtual void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        MoveLeft();
    }

    public virtual void OnSpawn(int obstacleIndex)
    {
        myObstacleIndex = obstacleIndex;
    }

    public virtual void OnDespawn()
    {
        gameObject.SetActive(false);
    }

    protected virtual void MoveLeft()
    {
        rb.AddForce(Vector3.left * speed * Time.fixedDeltaTime, ForceMode.Force);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            OnDespawn();
        }
        else if (other.gameObject.name == "EndWall")
        {
            OnDespawn();
        }
    }
}
