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
        if (Input.GetKeyUp("space"))
        {
            Fire();
        }
    }

    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            #region raycast movement 

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(worldPoint);

            RaycastHit2D rayOut = Physics2D.Raycast(worldPoint, Vector2.zero);

            //Debug.DrawRay(worldPoint, new Vector3(worldPoint.x, worldPoint.y,50), Color.white,3f);
            /* if (!rayOut)
                 Debug.Log("null collider");*/

            if (rayOut.collider != null)
            {
                //Debug.Log("ray collided");
                if (rayOut.collider.name == "Lane")
                {
                    //Debug.Log("ray collided lane 1");
                    //transform.position = new Vector2(-7.5f, 3.3f);
                    transform.position = new Vector2(locationLane1.position.x, locationLane1.position.y);
                    laneSelect = 1;
                }
                else if (rayOut.collider.name == "Lane 2")
                {
                    // Debug.Log("ray collided lane 2");
                    //transform.position = new Vector2(-7.5f, 0.95f);
                    transform.position = new Vector2(locationLane2.position.x, locationLane2.position.y);
                    laneSelect = 2;
                }
                else if (rayOut.collider.name == "Lane 3")
                {
                    //Debug.Log("ray collided lane 3");
                    //transform.position = new Vector2(-7.5f, -1.40f);
                    transform.position = new Vector2(locationLane3.position.x, locationLane3.position.y);
                    laneSelect = 3;
                }
            }

            #endregion

        }

    }

    public void SetBullet(int index)
    {
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
