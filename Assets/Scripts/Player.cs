using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform locationLane1;
    public Transform locationLane2;
    public Transform locationLane3;
    public Transform gunpoint;

    Animator anim;

    public GameObject[] Bullet;
    public GameObject currentBullet;

    private int laneSelect;


    // Use this for initialization
    void Start()
    {
        transform.position = new Vector2(locationLane2.position.x, locationLane2.position.y);
        currentBullet = Bullet[0];//MaleBullet
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
             /* Player Movement Using Raycast */ 

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            

            RaycastHit2D rayOut = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (rayOut.collider != null)
            {
                /* Lane Detection */
                if (rayOut.collider.name == "Lane")
                {
                    transform.position = new Vector2(locationLane1.position.x, locationLane1.position.y);
                    laneSelect = 1;
                }
                else if (rayOut.collider.name == "Lane 2")
                {
                    transform.position = new Vector2(locationLane2.position.x, locationLane2.position.y);
                    laneSelect = 2;
                }
                else if (rayOut.collider.name == "Lane 3")
                {
                    transform.position = new Vector2(locationLane3.position.x, locationLane3.position.y);
                    laneSelect = 3;
                }
            }

       

        }

    }

    public void SetBullet(int index)
    {
        /* Select Bullet */
        currentBullet = Bullet[index];
    }

    public void Fire()
    {
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Girl_Fire"))
        {
            return;
        }
        else
        {
            anim.SetTrigger("Fire");
            Instantiate(currentBullet, gunpoint.transform.position, Quaternion.identity);
        }
    }

}
