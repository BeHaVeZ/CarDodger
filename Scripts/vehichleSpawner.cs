using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehichleSpawner : MonoBehaviour
{
    GameObject prefab;
    public float repeatTime = 5f;
    public GameObject[] cars;
    public GameObject[] powerUps;
    float startRandom = 2f, endRandom = 10f;
    int spawnNumber;
    void Start()
    {
        repeatTime = Random.Range(startRandom, endRandom);
    }
    // 3 - 10 * 7 / 3 - 8 * 5 / 2 - 6 * 4 / 1 - 4 * 2
    private void Update()
    {
        if (FindObjectOfType<score>().currentScore > 20) // very easy
        {
            startRandom = 3f;
            endRandom = 10f;
        }
        if (FindObjectOfType<score>().currentScore > 40) // easy
        {
            startRandom = 3f;
            endRandom = 8f;
        }
        if (FindObjectOfType<score>().currentScore > 60) // medium
        {
            startRandom = 2f;
            endRandom = 6f;
        }
        if (FindObjectOfType<score>().currentScore > 100) // hard
        {
            startRandom = 1f;
            endRandom = 4f;
        }
    }
    void FixedUpdate()
    {
        if (FindObjectOfType<carController>().enabled == false)
        {
            enabled = false;
            Invoke("CreatePrefabAfterGameOver", Random.Range(startRandom, endRandom));
        }
        CreatePrefab();
    }
    void CreatePrefab()
    {
        repeatTime -= Time.deltaTime;
        if (repeatTime <= 0)
        {
            spawnNumber = Random.Range(0, 100);
            if(spawnNumber >= 97)
            {
                prefab = powerUps[Random.Range(0,powerUps.Length)];
                Instantiate(prefab,transform.position, Quaternion.identity);
                repeatTime = Random.Range(startRandom, endRandom);
                FindObjectOfType<AudioManager>().Play("Honk" + Random.Range(1, 2));
            }
            if (spawnNumber < 80)
            {
                prefab = cars[Random.Range(0, cars.Length)];
                Instantiate(prefab, transform.position, Quaternion.identity);
                repeatTime = Random.Range(startRandom, endRandom);
            }
        }

    }

    void CreatePrefabAfterGameOver()
    {
        Vector3 newPos = transform.position;
        newPos.x = 9;
        prefab = cars[Random.Range(0, cars.Length)];
        Instantiate(prefab, newPos, Quaternion.identity);
    }
}
