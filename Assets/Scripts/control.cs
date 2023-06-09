using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public int currPos;
    public int speed;
    
    public float jump_speed;
    private Vector3 tragetCoords = new Vector3(-4.5f, 0, 0);
    private bool isChanged = true;
    private bool isGrounded = true;
    public Rigidbody rb;
    private bool flag = true;


    void Update()
    {
       
            if (Input.GetKey("a"))
            {
                if (currPos > -1 & isChanged)
                {
                    currPos -= 1;
                    tragetCoords += new Vector3(-3, 0, 0);
                    isChanged = false;
                }
            }

            else if (Input.GetKey("d"))
            {
                if (currPos < 1 & isChanged)
                {
                    currPos += 1;
                    tragetCoords += new Vector3(3, 0, 0);
                    isChanged = false;
                    
                }

            }
            else
            {   
                isChanged = true;
            }

            if (Input.GetKey("w") & isGrounded)
            {
                rb.AddForce(new Vector3(0, jump_speed, 0));
                isGrounded = false;
            }

            Debug.Log(isGrounded);
            
            

            float time = Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, tragetCoords, time * 5);
            transform.Translate(Vector3.forward * time * speed);
            tragetCoords = new Vector3(tragetCoords.x, 0, 0) + new Vector3(0, transform.position.y, transform.position.z);



    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag("Rump"))
        {
            transform.rotation = new Quaternion(-16, 0, 0, 90);
            if (flag)
            {
                transform.position += new Vector3(0, 1, 0);
                flag = false;
            }
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            flag = true;
        }
        
    }
    
}
