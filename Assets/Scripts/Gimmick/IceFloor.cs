using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloor : MonoBehaviour
{
    public Rigidbody2D PlayerRB;
    public PhysicsMaterial2D physicsMaterial2D3;
    public PhysicsMaterial2D physicsMaterial2D2;
    //public static bool isIced;

    // Start is called before the first frame update
    void Start()
    {
        //isIced = false;
    }

    void OnCollisionStay2D(Collision2D other) 
    {   
        //isIced = true;
        if (Player_Physics.end1st && other.gameObject.tag == "Player")
        {
            Player_Physics.end2nd = true;
            Debug.Log("2回目のジャンプ");
            PlayerRB.sharedMaterial = physicsMaterial2D3;
        }
        
    }
    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        PlayerRB.sharedMaterial = physicsMaterial2D2;
    }
}
