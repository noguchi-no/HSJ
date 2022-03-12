using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Physics : MonoBehaviour
{
    public float angle = 0;
    public float power = 0;

    bool isShot = false;
    public bool end1st = false;
    public bool end2nd = false;

    bool isEnd = false;

    Vector2 startPos;
    Vector2 endPos;
    Vector2 vec;

    Rigidbody2D rb;
    public PhysicsMaterial2D physicsMaterial2D;
    public PhysicsMaterial2D physicsMaterial2D2;
    public PhysicsMaterial2D physicsMaterial2D3;

    public bool isHold = false;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Shot();

        if (Input.GetKeyDown("r")) SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void Shot()
    {

        if (!isShot)
        {

            if (Input.GetMouseButtonDown(0))
            {
                isHold = false;
                startPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
            else if (Input.GetMouseButton(0))
            {
                isHold = true;
                Vector2 tempVec = new Vector2(startPos.x - Input.mousePosition.x, startPos.y - Input.mousePosition.y);

                power = tempVec.magnitude;

                angle = CalculateAngle(tempVec);

            }
            else if (Input.GetMouseButtonUp(0))
            {
                isHold = false;
                isShot = true;

                endPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                //vec = new Vector2(startPos.x - endPos.x, startPos.y - endPos.y);

                if (power > 400)
                {
                    power = 400;
                }
                else if (power < 10)
                {
                    power = 10;
                }

                Vector2 nextVector = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * power;

                rb.AddForce(nextVector);

            }

        }

    }

    float CalculateAngle(Vector2 _vec)
    {
        _vec = _vec / _vec.magnitude;

        float tempAng = Mathf.Atan2(_vec.y, _vec.x) * Mathf.Rad2Deg;

        return Mathf.Repeat(tempAng, 360);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //下から貫通する床のため。何かしらのギミックと噛み合わない状況が起こったら変えなくはいけない
        //var diff = transform.position.y - coll.gameObject.transform.position.y;
        //if (diff > 0)
        //{
            if (isShot)
            {
                Debug.Log(coll.gameObject);

                if (!end1st)
                {
                    end1st = true;
                    Debug.Log("1回目のジャンプ");

                    rb.sharedMaterial = physicsMaterial2D;

                }
                else if (!end2nd)
                {
                    end2nd = true;
                    Debug.Log("2回目のジャンプ");
                    
                    if(coll.gameObject.tag == "Ice")
                    {
                        Debug.Log("Ice!!!");
                        rb.sharedMaterial = physicsMaterial2D3;
                    }
                    else
                    {
                        rb.sharedMaterial = physicsMaterial2D2;
                    }

                    
                }
            }


        //}
    }
}
