using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform2DUtils.GameplaySystem;


public class Player : Character2D
{

    
    void Update()
    {
        
       /* Vector2 AxisTopdown = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        transform.Translate(AxisTopdown * moveSpeed * Time.deltaTime);*/

       GameplaySystem.Movement(rb2D.transform,moveSpeed);

    }

    void FixedUpdate()
    {
        if(Grounding)
        {
            
        }
    }
}
