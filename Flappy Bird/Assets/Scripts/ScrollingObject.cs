using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{

    // This rigidbody is created in the Ground GameObject to be able to add the scrolling script. 
    //However, it is set to Kinematic so that it is not affected by any physical components except what is given in the script.
    private Rigidbody2D rb2d; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameControl.instance.gameOver == true)
        {
            rb2d.velocity = new Vector2(0, 0);
        }
    }
}
