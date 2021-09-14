using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class running : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    gravitySwitcher gravitySwitcher;
    [Range(10,100)]
    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();       
        gravitySwitcher = GetComponent<gravitySwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        Run(x, y);
    }

    void Run(float x, float y){        
        if(x != 0){
            if(gravitySwitcher.gravityDirection == 1){
                rigidBody2D.velocity = new Vector2(x * speed, rigidBody2D.velocity.y);
            }else{
                rigidBody2D.velocity = new Vector2(-x * speed, rigidBody2D.velocity.y);
            }
            
        }
        
    }
}
