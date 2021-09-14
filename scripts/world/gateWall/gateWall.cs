using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateWall : MonoBehaviour
{

    public bool opened = false;
    public float Y;
    [Range(10,100)]
    public float speed;
    Rigidbody2D rigidBody2D;
    private bool upped = false;
    // Start is called before the first frame update

    void Start()
    {
        Y = transform.position.y;
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        if(opened){
            GateMove();
        }        
    }

    public void GateOpen(){
        opened = true;
    }

    public void GateStop(){
        opened = false;
    }
    
    void GateMove(){
       if(!upped) rigidBody2D.AddForce(new Vector2(0, speed), ForceMode2D.Force);
       if(upped)  rigidBody2D.AddForce(new Vector2(0, -speed), ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "plateUp"){
            GateStop();
            upped = true;
        }else
        if(other.gameObject.tag == "plateDown"){
            GateStop();
            upped = false;
        }else
        if(other.gameObject.tag != "Player") GateOpen();        
    }

}
