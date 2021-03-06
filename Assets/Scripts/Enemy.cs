﻿using System.Collections;
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
        GameplaySystem.CheckDistance(transform, target, chaseRadius, moveSpeed);   
        if(GameObject.FindWithTag("Player") != null)
            target = GameObject.FindWithTag("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.KillPlayer();
            Destroy(other.gameObject);
            transform.position = new Vector2(transform.position.x,transform.position.y-150.0f);
            actualSpeed = moveSpeed;
            moveSpeed = 50.0f;
            StartCoroutine(waitEnemy());
        }
    }

    IEnumerator waitEnemy()
    {
        yield return new WaitForSeconds(0.5f);

        moveSpeed = actualSpeed;
    }
}