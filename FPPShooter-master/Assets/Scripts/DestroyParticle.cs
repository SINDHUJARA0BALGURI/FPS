using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        


        
        //Debug.Log(timeAlive);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 1f);
    }
}
