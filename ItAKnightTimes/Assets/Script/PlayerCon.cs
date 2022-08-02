
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    float horizontal;
    float vertical;
    public float speed;
    public Vector2 moveDir;
    public Vector2 bullDir;
    
    
    public Animator anim;
   
    Rigidbody2D RB;

    public Bullet bullet;
    public Transform gun;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        walk();
        fire();
    }

    void walk()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //walk right
        if (Input.GetAxis("Horizontal")  > 0)
        {
            anim.SetBool("Right", true);
            //Debug.Log("r");
            transform.localScale = new Vector3(1,1,1);
        }
        //walk left
        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("Left", true);
            //Debug.Log("l");
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (horizontal == 0)
        {
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
        }

        //walk up
        if (Input.GetAxis("Vertical") > 0)
        {
            //Debug.Log("u");
        }
        //walk down
        if (Input.GetAxis("Vertical") < 0)
        {
            //Debug.Log("d");
        }

        //???????????
        Vector2 pressDir = new Vector2(horizontal, vertical);

        if (pressDir.magnitude > 0)
        {
            bullDir = new Vector2(normalizefloat(horizontal), normalizefloat(vertical));
            
        }


        /*RB.velocity = new Vector2(horizontal * speed, RB.velocity.y);
        RB.velocity = new Vector2(RB.velocity.x, vertical * speed);*/


        RB.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    void fire()
    {
        if (Input.GetKeyDown("space"))
        {
            Bullet instBullet = Instantiate(bullet, gun.position, gun.rotation);
            instBullet.bullDir = bullDir;
        }
    }

    float normalizefloat(float num)
    {
        if (num > 0)
        {
            num = 1;
        }

        if (num < 0)
        {
            num = -1;
        }

        return num;
    }

    void campos()
    {

    }
}
