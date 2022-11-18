using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;

    public TMP_Text Wintext;
    public Vector3 startPosition;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player velocity is: "+ body.velocity);
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        
        if(Input.GetKey(KeyCode.Space))
        {
            if(body.gravityScale == 1)
            {
                 body.velocity = new Vector2(body.velocity.x, speed);
                 //Debug.Log("Gravity scale positive");
            }
            else if (body.gravityScale == -1)
            {
                
                body.velocity = new Vector2(body.velocity.x, speed)*-1;
                //Debug.Log("Gravity scale negative");
            }

           
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Gate")
        {
            Wintext.gameObject.SetActive(true);
            body.gameObject.SetActive(false);
        }


        if(collider.tag == "Invert")
        {
            if(body.gravityScale == 1)
            {
                body.gravityScale = -1;
                body.AddForce(new Vector2(0,-3), ForceMode2D.Impulse);
                Vector3 rotate = new Vector3(0, 0, 180);
                body.transform.eulerAngles = rotate;
                //Physics2D.gravity = new Vector2(9.8f,0);
            

            }
            else if (body.gravityScale == -1)
            {
                body.gravityScale = 1;
                body.AddForce(new Vector2(0,3), ForceMode2D.Impulse);
                Vector3 rotate2 = new Vector3(0, 0, 1);
                body.transform.eulerAngles = rotate2;
                
                
            }   

        }


        if(collider.tag == "Bounds")
        {
            if(body.gravityScale == 1)
            {
                
                body.transform.position = new Vector3(-1.701f, -0.744f, 0f);
            }
            else if(body.gravityScale == -1)
            {
                body.gravityScale = 1;
                body.AddForce(new Vector2(0,-6), ForceMode2D.Impulse);
                body.transform.position = new Vector3(-1.701f, -0.744f, 0f);
                Vector3 rotate3 = new Vector3(0, 0, 1);
                body.transform.eulerAngles = rotate3;
            }
           
        }
       

           
        
    }
}
