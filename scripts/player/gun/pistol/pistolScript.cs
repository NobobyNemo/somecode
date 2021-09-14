using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistolScript : MonoBehaviour
{
    public GameObject bullet;
    float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Fire();
        }
    }
    void GiveImpulse(GameObject someBullet){
        Rigidbody2D rb = someBullet.GetComponent<Rigidbody2D>();
      
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }
    void Fire(){
      GameObject instanceOfBullet =  Instantiate(bullet, transform.position, Quaternion.identity);
      GiveImpulse(instanceOfBullet);
      
    }
}
