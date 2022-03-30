using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlatform : MonoBehaviour
{
    public static bool broken;
    public GameObject effect;
    private void OnCollisionEnter2D(Collision2D other) {
        
        broken = true;
        
        if(other.gameObject.tag == "Player")
        {
            effect.gameObject.transform.parent = null;
            Destroy(this.gameObject);

        }
        
    }

}
