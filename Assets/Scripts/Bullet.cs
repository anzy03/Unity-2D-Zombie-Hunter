using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float thrust = 5f;
    private float bulletTime;
    public string BulletName;


    // Use this for initialization
    void Start()
    {
        if (BulletName == null || BulletName.Length == 0)
        {
            Debug.LogError("Empty BulletName" + gameObject.name);
        }
        bulletTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * thrust * Time.deltaTime);
        bulletTime++;

        if (bulletTime >= 200)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == BulletName)
        {
            col.gameObject.GetComponent<Zombie>().death = true;
            Debug.Log(col.gameObject.name);
            FindObjectOfType<ZombieSpawner>().IncreaseDeath();
        }

        Destroy(gameObject);

    }
}
