using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform2DUtils.GameplaySystem;

public class Shadow : Character2D
{
    void Update()
    {
       GameplaySystem.MovementTopdown(rb2D.transform,moveSpeed);
    }

    void FixedUpdate()
    {
        if(GameplaySystem.JumpBtn && !jump)
        {   
            transform.localScale =new Vector3(50.0f,15.47404f,1.0f);
            transform.position = new Vector3(transform.position.x,(transform.position.y-20.0f),transform.position.z);
            jump = true;
            invencible = true;
            StartCoroutine(JumpTime());
        }

        
        IEnumerator JumpTime()
        {
            yield return new WaitForSeconds(0.5f);
            
            transform.position = new Vector3(transform.position.x,(transform.position.y+20.0f),transform.position.z);
            transform.localScale =new Vector3(90.495f,35.47404f,1.0f);
            jump = false;
            invencible = false;
        }
    }
}
