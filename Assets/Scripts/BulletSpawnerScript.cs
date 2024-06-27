using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    
    [SerializeField]
    private float minSpawnTime;
    
    [SerializeField]
    private float maxSpawnTime;

    private float timetillSpawn;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timetillSpawn -= Time.deltaTime;

        if(timetillSpawn <= 0) {

            Instantiate(bullet, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        timetillSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
