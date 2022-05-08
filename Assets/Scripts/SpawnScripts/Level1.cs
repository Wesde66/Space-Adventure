using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    [SerializeField] GameObject blueEnemy;
    [SerializeField] GameObject blackEnemy;
    [SerializeField] GameObject[] PowerUp;

    [SerializeField] bool BlueEnemyActive = true;
    [SerializeField] bool BlackEnemyActive = true;
    [SerializeField] bool PowerUpActve = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlueEnemy());
        StartCoroutine(BlackEnemy());
        StartCoroutine(PowerUps());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PowerUps()
    {
        while (PowerUpActve)
        {
            int PowerUpRange = Random.Range(0, 3);
            float RandonOnX = Random.Range(-8, 8);
            Vector3 spawnLocation = new Vector3(RandonOnX, 6, 0);
            float RandomSec = Random.Range(8, 20);

            yield return new WaitForSeconds(RandomSec);

            Instantiate(PowerUp[PowerUpRange], spawnLocation, Quaternion.identity);

            yield return new WaitForSeconds (0.5f);
        }

    }


    IEnumerator BlueEnemy()
    {
        while (BlueEnemyActive)
        {
            float randomX = Random.Range(-8, 8);
            Vector3 spawnLocation = new Vector3(randomX, 6, 0);
            float randomSec = Random.Range(0, 5);

            yield return new WaitForSeconds(1);

            Instantiate(blueEnemy, spawnLocation, Quaternion.identity);
            yield return new WaitForSeconds(randomSec);
        }

    }

    IEnumerator BlackEnemy()
    {
        yield return new WaitForSeconds(10);
        
        while (BlackEnemyActive)
        {
            float randomX = Random.Range(-8, 8);
            Vector3 spawnLocation = new Vector3(randomX, 6, 0);
            float randomSec = Random.Range(5, 15);

            yield return new WaitForSeconds(1);

            Instantiate(blackEnemy, spawnLocation, Quaternion.identity);
            yield return new WaitForSeconds(randomSec);
        }

    }
}
