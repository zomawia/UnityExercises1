using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharger : _BaseAIController
{
    public float viewRadius = 15.0f;
    public float movespeed = 7.0f;
    public float attackDmg = 20.0f;
    float minRadius = .5f;
    float timer;
    float attackDelay = 2.0f;

    void doAttack()
    {
        timer += Time.deltaTime;
        if (timer > attackDelay)
        {
            //attack            
            IDamage otherPlayer = player.gameObject.GetComponent<IDamage>();
            otherPlayer.TakeDamage(attackDmg);            
            timer = 0.0f;            
        }

    }

    void OnCollisionEnter(Collision other)
    {
        float force = 50f;
        if (other.gameObject.tag == "Player")
        {
            doAttack();
            Vector3 dir = other.contacts[0].point - transform.position;
            dir = -dir.normalized;

            gameObject.GetComponent<Rigidbody>().AddForce(dir * force, ForceMode.Impulse);
        }
    }

    public override void Start()
    {
        base.Start();        
    }

    // Update is called once per frame
    public override void Update()
    {
        transform.LookAt(player.transform);

        //if (Vector3.Distance(transform.position, player.transform.position)>= viewRadius)
        //{
        //    transform.position += transform.forward * movespeed * Time.deltaTime;
        //}
        if (Vector3.Distance(transform.position, player.transform.position) < viewRadius &&
            Vector3.Distance(transform.position, player.transform.position) >= minRadius)
        {
            transform.position += transform.forward * movespeed * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, player.transform.position) < minRadius)
        {
            // do attack

        }

    }
}
