using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{

    public GameObject zombie;
    public GameObject maleZombie;
    public float spawnTime;
    public float spawnClock;
    public Vector2 location1;
    public Vector2 location2;
    public Vector2 location3;
    int spawn;
    int points;
    public TextMeshProUGUI killPoints;
    int randonNo = 5;

    // Use this for initialization
    void Start()
    {
        spawnTime = 4f;
        spawnClock = spawnTime;
        spawn = 6;
        points = 0;
         //First Spawn
        Instantiate(zombie);
        zombie.transform.position = location2;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        spawnClock -= 1f * Time.deltaTime;
        if (spawnClock <= 0)
        { 
            /* Selecting & Spawing Zombie Randomly */
            spawn = Random.Range(0, randonNo);
            switch (spawn)
            {
                case 0:
                    Instantiate(zombie);
                    zombie.transform.position = location1;
                    break;
                case 1:
                    Instantiate(zombie);
                    zombie.transform.position = location2;
                    break;
                case 2:
                    Instantiate(zombie);
                    zombie.transform.position = location3;
                    break;
                case 3:
                    Instantiate(maleZombie);
                    zombie.transform.position = location1;
                    break;
                case 4:
                    Instantiate(maleZombie);
                    zombie.transform.position = location2;
                    break;
                case 5:
                    Instantiate(maleZombie);
                    zombie.transform.position = location3;
                    break;
            }
            spawnClock = spawnTime;
        }

    }

    public void IncreaseDeath()
    {
        /* Increasing Player Points */
        points++;
        killPoints.SetText(points.ToString());
       if(points % 5 == 0 && spawnTime > 1f)
       {
            spawnTime -= 0.5f;
       }
       else if(spawnTime<= 1f)
       {
            randonNo = 10;
       }
    }


}
