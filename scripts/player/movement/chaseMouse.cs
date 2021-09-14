using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseMouse : MonoBehaviour
{
    public GameObject head;
    public GameObject hand;
    public bool flip = false;
    rotating Rotating;
    float offset = 180f;
    gravitySwitcher gravitySwitcher;

    // Start is called before the first frame update
    void Start()
    {
        Rotating = GetComponent<rotating>();
        gravitySwitcher = GetComponent<gravitySwitcher>();
    }

    // Update is called once per frame
    void Update()
    {        
        Rotate();
    }

    Vector3 playerPosition()
    {
        return transform.position;
    }

    Vector3 mousePosition(){
        float camDis = Camera.main.transform.position.y - playerPosition().y;
        return Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, camDis));  
    }

    float Angle(){        
        var mouse = mousePosition();   
        return Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg;       
    }

    void Rotate(){    
        Flipping();    
        PartsRotate(); 
    }

    void PartsRotate() {   
       if(gravitySwitcher.gravityDirection == 1){ 
            if(flip){
                head.transform.localRotation = Quaternion.Euler(0,0, -Angle() - offset);
                hand.transform.localRotation = Quaternion.Euler(0,0, -Angle() - offset);
            }else{
                head.transform.localRotation = Quaternion.Euler(0,0, Angle());
                hand.transform.localRotation = Quaternion.Euler(0,0, Angle());
            }     
        }
        if(gravitySwitcher.gravityDirection == -1){
            if(flip){
                head.transform.localRotation = Quaternion.Euler(0,0, -Angle());
                hand.transform.localRotation = Quaternion.Euler(0,0, -Angle());
            }else{
                head.transform.localRotation = Quaternion.Euler(0,0, Angle() + offset);
                hand.transform.localRotation = Quaternion.Euler(0,0, Angle() + offset);
            }   
        }
    }

   
    
    void Flipping() {
        var playerPos = playerPosition();
        var mousePos = mousePosition();
        var dir = gravitySwitcher.gravityDirection;
        if(dir == 1){
            if(mousePos.x < playerPos.x ){
                flip = true;
            }
            if(mousePos.x > playerPos.x){
                flip = false;
            }           
        }
        if(dir == -1){
            if(mousePos.x > playerPos.x ){
                flip = true;
            }
            if(mousePos.x < playerPos.x){
                flip = false;
            }
        }
         if(flip){
                Rotating.SetY(180f);
            }else{
                Rotating.SetY(0f);
            }
    }
}
