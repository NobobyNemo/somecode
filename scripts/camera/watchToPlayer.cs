using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watchToPlayer : MonoBehaviour
{
    GameObject Player;    
    Transform PlayerTransform;
    gravitySwitcher gravitySwitcher;
    float y = 5f;
    float z = -10f;
    float currentAngle = 0f;
    float Flipped = 180f;
    float Normal = 0f;
    float RotationTick = 180f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerTransform = Player.GetComponent<Transform>();
        gravitySwitcher = Player.GetComponent<gravitySwitcher>();        
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
        RotateCheck();
    }
    void RotateCheck() {
        if(gravitySwitcher.gravityDirection == 1){
            if(currentAngle > Normal){
                currentAngle -= RotationTick * Time.deltaTime;
            }
            if(currentAngle < Normal){
                currentAngle = Normal;
            }
            Rotate();
        }
        if(gravitySwitcher.gravityDirection == -1){
            if(currentAngle < Flipped){
                currentAngle += RotationTick * Time.deltaTime;
            }
            if(currentAngle > Flipped){
                currentAngle = Flipped;
            }
            Rotate();
        }
    }
    void Rotate() {
        transform.rotation = Quaternion.Euler(0,0,currentAngle);
    }
    void Chase() {
         var pos = new Vector3(0,0,0);

         if(gravitySwitcher.gravityDirection == 1){
            pos = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + y, z);
         }else{
            pos = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y - y, z);
         }
               
        transform.position = pos;
    }
}
