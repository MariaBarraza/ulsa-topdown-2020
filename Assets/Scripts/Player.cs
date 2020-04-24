using System.Collections;
using System.Collections.Generic;
using Platform2DUtils.GameplaySystem;
using UnityEngine;

public class Player : Character2D
{
   // Animator anim;
   // SpriteRenderer sprite;
        
    void Update()
    {
        if(transform.gameObject != null)
            Move();
        if (GameplaySystem.JumpBtn && !jump)
        {
            scale = 90.0f;
            GameplaySystem.JumpTopdown(transform, scale);
            jump = true;
            scale = 75.0f;
            StartCoroutine(JumpTime());
        }

    }

    IEnumerator JumpTime()
    {
        yield return new WaitForSeconds(0.5f);
        transform.localScale = new Vector3(scale, scale, 1.0f);
        jump = false;
    }
    
    public override void Move()
    {
        if (!isNpc)
        {
            GameplaySystem.MovementTopdown(rb2D.transform, moveSpeed);
            moving = GameplaySystem.AxisTopdown != Vector2.zero;

            if (moving)
            {
                //animaciones
                anim.SetFloat("moveX", GameplaySystem.AxisTopdown.x);
                anim.SetFloat("moveY", GameplaySystem.AxisTopdown.y);
                spr.flipX = FlipSprite;
            }

            //animator
            //Sprite renderer
           
            anim.SetBool("moving", moving);

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