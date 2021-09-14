using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravitySwitcher : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public float gravityDirection;
    rotating Rotating;
    private float UpsideDown = 180f;
    private float NormalPos = 0;
    private float rotateTik = 180f;
    private float currentAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();  
        gravityDirection  = rigidBody2D.gravityScale;
        Rotating = GetComponent<rotating>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q")){
            ChangeDirection();            
        }
       RotateCheck();
        
    }

    void RotateCheck() {
        if(gravityDirection == -1){
            if( currentAngle < UpsideDown ) {
                currentAngle += rotateTik * Time.deltaTime;
                if(currentAngle > UpsideDown){
                    currentAngle = UpsideDown;                   
                }
                Rotate();
            }
        }
        
        if(gravityDirection == 1){
            if(currentAngle > 0){
                currentAngle -= rotateTik * Time.deltaTime;
            }
            if(currentAngle < 0){
                currentAngle = NormalPos;
                
            }
            Rotate();
        }
    }

    void Rotate(){
        Rotating.SetZ(currentAngle);
                   
    }
    void ChangeDirection(){
            
            rigidBody2D.gravityScale = -rigidBody2D.gravityScale;
            gravityDirection  = rigidBody2D.gravityScale;        
              
    }
}
