using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimini : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {

            other.gameObject.transform.localScale = new Vector3(0.1f, 0.1f,1.0f);
            
            Destroy(this.gameObject);
        }  
    }

}
