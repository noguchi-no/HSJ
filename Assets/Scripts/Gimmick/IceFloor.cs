using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloor : MonoBehaviour
{
    public Rigidbody2D rb;
    //public PhysicsMaterial2D physicsMaterial2D3;
    public Player Player;
    public static bool isIced;
    
    // Start is called before the first frame update
    void Start()
    {
        isIced = false;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {   
        isIced = true;
        // if (!Player.end2nd && Player.end1st)
        // {
        //     Player.end2nd = true;
        //     Debug.Log("2回目のジャンプ");

        //     rb.sharedMaterial = physicsMaterial2D3;
        // }'Player.end2nd' is inaccessible due to its protection level
        
    }
}
