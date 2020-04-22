using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform2DUtils.GameplaySystem;

public class Character2D : MonoBehaviour
{
    protected SpriteRenderer spr;
    protected Animator anim;
    protected Rigidbody2D rb2D;
    [SerializeField]
    protected float jumpForce = 7f;

    [SerializeField]
    protected float moveSpeed = 2f;

    //Raycast ***********************
    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 5f)]
    float rayDistance = 5f;
    [SerializeField]
    LayerMask groundLayer;
    //********Jump**********

    [SerializeField]
    protected bool jump = false;
    protected bool invencible = false;

    protected float scale;
    //****** Follow
    protected bool moving;

    [SerializeField]
    Player leader;

    [SerializeField]
    float minDistanceFollow;
    
    float dirX;
    float dirY;

    Vector2 npcDirection;

    protected Collider2D collider2D;

    [SerializeField]
    protected bool isLeader;
    [SerializeField]
    protected bool isNpc;
    //********

   
    void Update()
    {
        anim.SetBool("moving", moving);
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    protected bool Grounding
    {
        get => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
    }

    //Drawing raycast
    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }

    public virtual void Move()
    {
        if(transform.gameObject != null)
        moving = Vector2.Distance(leader.transform.position, transform.position) > minDistanceFollow;
        if (moving)
        {
            //esto es para decirle a la animación hacia donde tiene que moverse
            npcDirection = leader.transform.position - transform.position;
            npcDirection.Normalize();
            transform.position = Vector2.MoveTowards(transform.position, leader.transform.position, moveSpeed * Time.deltaTime);
            
            //aqui va el animator
            anim.SetFloat("moveX", npcDirection.x);
            anim.SetFloat("moveY", npcDirection.y);
        }
        
        
    }

    protected bool FlipSprite
    {
        get => GameplaySystem.Axis.x < 0 ? true : GameplaySystem.Axis.x > 0 ? false : spr.flipX;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(other.collider, collider2D);
        }
    }

    public Player Target
    {
        get => leader;
        set => leader = value;
    }
}
