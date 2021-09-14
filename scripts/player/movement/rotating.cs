using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotating : MonoBehaviour
{
    float y = 0f;
    float z = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    public void SetZ(float angle){
        z = angle;
    }
    
    public void SetY(float angle){
        y = angle;
    }

    void Rotate(){
        transform.rotation = Quaternion.Euler(0, y, z); 
    }
}
