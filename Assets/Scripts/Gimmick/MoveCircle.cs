using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCircle : MonoBehaviour
{
    Vector2 senterPos;
    Vector2 rotationPos;
    float startTime;

    public float moveSpeed = 1.0f;
    public float radian = 1.0f;
    public float initPosition = 0f;//初期位置をどれだけ回転させた状態にするか

    void Start()
    {
        senterPos = transform.position; //円移動する中心の位置
    }

    void Update()
    {
        startTime = Time.time + initPosition;
        float T = moveSpeed;
        float f = 1.0f / T;
        rotationPos = senterPos;
        rotationPos.x += radian * (Mathf.Sin(2 * Mathf.PI * f * startTime));
        rotationPos.y += radian * (Mathf.Cos(2 * Mathf.PI * f * startTime));
        transform.position = rotationPos;
    }
}
