using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform2DUtils.GameplaySystem;

public class Enemy : Enemy2D
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    float actualSpeed;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        CheckDistance();   
        if(GameObject.FindWithTag("Player") != null)
            target = GameObject.FindWithTag("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.KillPlayer();
            Destroy(other.gameObject);
            transform.position = new Vector2(transform.position.x-50.0f,transform.position.y);
            actualSpeed = moveSpeed;
            moveSpeed = 50.0f;
            StartCoroutine(waitEnemy());
        }
    }

    void CheckDistance()
    {
        if(target)
        {    
            if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }
        }
    }

    IEnumerator waitEnemy()
    {
        yield return new WaitForSeconds(500.0f);

        moveSpeed = actualSpeed;
    }
}