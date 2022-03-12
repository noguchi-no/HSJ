using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondPlayer : MonoBehaviour
{

    public string stage;

    public float angle;
    public float power;

    bool isShot = false;
    bool end1st = false;
    bool end2nd = false;

    bool isEnd = false;

    Vector2 startPos;
    Vector2 endPos;
    Vector2 vec;

    Rigidbody2D rb;
    public PhysicsMaterial2D physicsMaterial2D;
    public PhysicsMaterial2D physicsMaterial2D2;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r")) SceneManager.LoadScene(SceneManager.GetActiveScene().name);

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

                rb.sharedMaterial = physicsMaterial2D2;
            }
        
        //}
    }
}
