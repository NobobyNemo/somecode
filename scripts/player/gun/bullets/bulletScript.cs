using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    float hits = 0;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(hits > 1){
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag != "Player"){
            hits++;
        }
    }
}
