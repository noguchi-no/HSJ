using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public Player player;
    public Player_Physics player_Physics;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float power = player_Physics.shotPower / 100.0f;
        /*
        if (player_Physics.power > 500)
        {
            power = 5;
        }
        */
        transform.localScale = new Vector3(power, 1.0f, 1.0f);
        transform.rotation = Quaternion.AngleAxis(player_Physics.angle, new Vector3(0, 0, 1));
        //transform.localScale = new Vector3(player.power/100.0f, 1.0f, 1.0f);
        //transform.rotation = Quaternion.AngleAxis(player.angle, new Vector3(0, 0, 1));
    }
}
