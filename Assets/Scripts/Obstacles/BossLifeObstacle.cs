using Unity.VisualScripting;
using UnityEngine;

public class BossLifeObstacle : BreakableObstacleClass
{
    public BossScript boss;

    public override void TakeDamage(int damage)
    {
        if (boss != null)
            boss.TakeDamage();
        health -= damage;
        if (health <= 0)
            OnDespawn();
        Debug.Log(health);
    }
}
