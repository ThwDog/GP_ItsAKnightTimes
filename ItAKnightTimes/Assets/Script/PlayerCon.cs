
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    float horizontal;
    float vertical;
    public float speed;

    public UiControll uiGame;

    [Header ("Dash System")]
    public float dashSpeed;
    public float dashTime;
    public float staminaMax;
    public float staminaCurrent;
    public float staminaRegen;
    public float staminaCost;
    bool is_dash;

    [Header("HP System")]
    public float hpMax;
    public float hpCost;

    [Header("Bullet System")]
    public float bulletDelay;
    public Vector2 moveDir;
    public Vector2 bullDir;
    public bool canFire;

    
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
        dash();  
    }

    void walk()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        moveDir = new Vector2(horizontal, vertical);

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


        move_player();
    }
    void move_player()
    {
        if(!is_dash)
        {
            RB.velocity = new Vector2(horizontal * speed, vertical * speed);
        }      
    }

    void fire()
    {
        if (Input.GetKey("space") && canFire == true)
        {
            StartCoroutine(shoot_delay());
        }
    }

    IEnumerator shoot_delay()
    {
        Bullet instBullet = Instantiate(bullet, gun.position, gun.rotation);
        instBullet.bullDir = bullDir;
        canFire = false;   
        yield return new WaitForSeconds(bulletDelay);
        canFire = true;
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

    void dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (staminaCurrent > staminaCost)
            {
                StartCoroutine(dash_event(moveDir));
                staminaCurrent -= staminaCost;
            }
        }

        staminaCurrent += Time.deltaTime * staminaRegen;
        staminaCurrent = Mathf.Clamp(staminaCurrent, 0, staminaMax);

        uiGame.staChange("Stamina : " + staminaCurrent.ToString("0"));


    }


    IEnumerator dash_event(Vector2 dashDir)
    {
        is_dash = true;
        float elasTime = 0;

        while(elasTime < dashTime)
        {
            RB.velocity = dashDir * dashSpeed;
            elasTime += Time.deltaTime;
            yield return null;
        }
        is_dash = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Enemy")
        {
            hpMax -= hpCost;
            uiGame.hpChange("HP : " + hpMax.ToString());
            if (hpMax <= 0)
            {
                Debug.Log("DEAD");
                //Destroy(gameObject);
            }

        }
    }
}
