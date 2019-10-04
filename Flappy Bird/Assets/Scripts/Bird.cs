using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public float upForce = 200f;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0)) //Left mouse button
            {
                rb2d.velocity = Vector2.zero; //Reset the velocity to zero everytime the player jumps
                rb2d.AddForce(new Vector2(0, upForce));
                animator.SetTrigger("Flap");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        animator.SetTrigger("Die");
        GameControl.instance.BirdDied();
        rb2d.velocity = new Vector2(0, 0);
    }
}
