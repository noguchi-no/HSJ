using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpGate : MonoBehaviour
{
    [SerializeField]
    private Transform WarpPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("warp");
            col.gameObject.transform.position = WarpPoint.position;
            
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("warp");
            col.gameObject.transform.position = WarpPoint.position;
            
        }
    }
}
