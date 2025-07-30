using UnityEngine;

public class BreakableObstacleClass : ObstacleClass
{
    public int health;
    
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            OnDespawn();
        Debug.Log(health);
    }
}
