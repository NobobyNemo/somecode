using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumping : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private float jumpStrength = 10f;
    private gravitySwitcher gravitySwitcher;
    private bool grounded = false;
    private bool additionalJump = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>(); 
        gravitySwitcher = GetComponent<gravitySwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){
           if(grounded || additionalJump) Jump();
        }
    }

    void Jump() 
    {
        if(!grounded && additionalJump){
            additionalJump = false;
        }
        rigidBody2D.AddForce(new Vector2(rigidBody2D.velocity.x, jumpStrength * gravitySwitcher.gravityDirection), ForceMode2D.Impulse);
    }

    void GroundedStateChange(bool state){
        if(state){
            grounded = state;
            additionalJump = state;
        }
        if(!state){
            grounded = state;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {        
        if(other.gameObject.tag == "plateDown" && gravitySwitcher.gravityDirection > 0){
            GroundedStateChange(true);
        }
        if(other.gameObject.tag == "plateUp" && gravitySwitcher.gravityDirection < 0){
            GroundedStateChange(true);
        }
    }
    
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "plateDown" && gravitySwitcher.gravityDirection > 0){
            GroundedStateChange(false);
        }
        if(other.gameObject.tag == "plateUp" && gravitySwitcher.gravityDirection < 0){
            GroundedStateChange(false);
        }
    }
}
