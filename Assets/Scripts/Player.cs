using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform2DUtils.GameplaySystem;


public class Player : Character2D
{
    void Update()
    {
       Move();
       if(GameplaySystem.JumpBtn && !jump)
        {   
            scale = 90.0f;
            GameplaySystem.JumpTopdown(transform,scale);
            jump = true;
            scale=75.0f;
            StartCoroutine(JumpTime());
        }
        
    }

    
        IEnumerator JumpTime()
        {
            yield return new WaitForSeconds(0.5f);
            transform.localScale = new Vector3(scale,scale,1.0f);
            jump = false;
        }

    public override void Move()
    {
        if(!isNpc)
        {
            GameplaySystem.MovementTopdown(rb2D.transform,moveSpeed);
            moving = GameplaySystem.AxisTopdown != Vector2.zero;

            if(!moving)
            {
                //animaciones
            }

            //animator
            //Sprite renderer

        }
        else
        {
            base.Move();
        }
    }

    public bool IsLeader
    {
        get => isLeader;
        set => isLeader = value;
    }

    public bool IsNpc
    {
        get => isNpc;
        set => isNpc = value;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            CollectableObject collectable = other.GetComponent<CollectableObject>();
            GameManager.instance.AddPoints(collectable.Points);
            Destroy(other.gameObject);
        }
    }

}
