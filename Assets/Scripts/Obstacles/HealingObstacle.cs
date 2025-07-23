using UnityEngine;

public class HealingObstacle : ObstacleClass
{
    public int healing;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeHealing(healing);
            OnDespawn();
        }
        else if (other.gameObject.name == "EndWall")
        {
            OnDespawn();
        }
    }
}
