using UnityEngine;

public class BossScript : MonoBehaviour
{
    public ObstacleSpawner obstacleSpawner;
    public PlayerUI playerUI;
    public GameObject bossGO, bossHeartPrefab;
    public Transform obstacleSpawn;
    public float bossSpawnTime, heartSpawnTime;
    public int maxBossHealth;
    private int currentBossHealth;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossGO.SetActive(false);
        playerUI.ChangeBossText("");
        InvokeRepeating("SpawnBoss", bossSpawnTime, bossSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnHearts()
    {
        GameObject newObstacle = Instantiate(bossHeartPrefab, obstacleSpawn.position, obstacleSpawn.rotation);
        newObstacle.GetComponent<BossLifeObstacle>().boss = this;
    }

    private void SpawnBoss()
    {
        if (bossGO.activeSelf) return;
        currentBossHealth = maxBossHealth;
        bossGO.SetActive(true);
        playerUI.ChangeBossText("Jefe: -Anti Spiral- <" + currentBossHealth + ">");
        InvokeRepeating("SpawnHearts", heartSpawnTime, heartSpawnTime);
    }

    public void TakeDamage()
    {
        currentBossHealth--;
        playerUI.ChangeBossText("Jefe: -Anti Spiral- <" + currentBossHealth + ">");
        if (currentBossHealth <= 0)
            OnDeath();
    }

    private void OnDeath()
    {
        playerUI.ChangeBossText("");
        CancelInvoke("SpawnHearts");
        bossGO.SetActive(false);
    }
}
