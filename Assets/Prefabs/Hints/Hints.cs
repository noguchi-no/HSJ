using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    float currentTime;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float speedAccount = speed * Time.deltaTime;
        currentTime += speedAccount;

        GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, Mathf.Abs(Mathf.Sin(currentTime)));
    }
}
