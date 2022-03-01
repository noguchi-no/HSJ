using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCalculator : MonoBehaviour
{

    public Player_Physics player_Physics;
    public static bool isShot = false;

    GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

        float power = player_Physics.power;
        float angle = player_Physics.angle;

        if (power > 400)
        {
            power = 400;
        }
        else if (power < 10)
        {
            power = 10;
        }

        Vector2 nextVector = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * power;


        if (transform.childCount == 1 && player_Physics.isHold && power > 100) {

            ball = Instantiate(transform.GetChild(0).gameObject, Vector3.zero, Quaternion.identity);

            ball.transform.SetParent(this.transform);
            ball.transform.localPosition = Vector3.zero;
            ball.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            ball.SetActive(true);

            ball.GetComponent<Rigidbody2D>().AddForce(nextVector);
            isShot = true;
        }
    }
}
