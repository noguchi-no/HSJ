using System.Collections;
using System.Collections.Generic;
using Systems.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using AudioType = Systems.Audio.AudioType;

public class Player_Physics : MonoBehaviour
{

    public string stage;

    public float angle = 0;
    public float power = 0;

    bool isShot = false;
    public static bool end1st = false;
    public static bool end2nd = false;

    bool isEnd = false;

    Vector2 startPos;
    Vector2 endPos;
    Vector2 vec;

    Rigidbody2D rb;
    public PhysicsMaterial2D physicsMaterial2D;
    public PhysicsMaterial2D physicsMaterial2D2;

    public bool isHold = false;
    SystemAudioManager Se;//SEを鳴らすためのスクリプト

    void Start()
    {
        Se = FindObjectOfType<SystemAudioManager>();
        if (Se == null) Debug.LogError("Sesystemが実装されていません");
        end1st = false;
        end2nd = false;
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

                transform.GetChild(0).gameObject.SetActive(false);

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

                switch (Se.type)
                {
                    case SystemAudioManager.SEtype.metal:
                        PlayBoundSe(AudioType.MBound);
                        break;
                    case SystemAudioManager.SEtype.fantasy:
                        PlayBoundSe(AudioType.FBound1);
                        break;
                    case SystemAudioManager.SEtype.wood:
                        PlayBoundSe(AudioType.WBound1);
                        break;
                    case SystemAudioManager.SEtype.cyber:
                        PlayBoundSe(AudioType.SBound1);
                        break;
                    case SystemAudioManager.SEtype.normal:
                        PlayBoundSe(AudioType.Bound);
                        break;
                }
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

                switch(Se.type)
                {
                    case SystemAudioManager.SEtype.metal:
                        PlayBoundSe(AudioType.MBound);
                        break;
                    case SystemAudioManager.SEtype.fantasy:
                        PlayBoundSe(AudioType.FBound2);
                        break;
                    case SystemAudioManager.SEtype.wood:
                        PlayBoundSe(AudioType.WBound2);
                        break;
                    case SystemAudioManager.SEtype.cyber:
                        PlayBoundSe(AudioType.SBound2);
                        break;
                    case SystemAudioManager.SEtype.normal:
                        PlayBoundSe(AudioType.Bound);
                        break;
                }

            }
            else if (!end2nd)
            {   
                end2nd = true;
                Debug.Log("2回目のジャンプ");

                rb.sharedMaterial = physicsMaterial2D2;
                switch (Se.type)
                {
                    case SystemAudioManager.SEtype.metal:
                        PlayBoundSe(AudioType.MBound);
                        break;
                    case SystemAudioManager.SEtype.fantasy:
                        PlayBoundSe(AudioType.FBound2);
                        break;
                    case SystemAudioManager.SEtype.wood:
                        PlayBoundSe(AudioType.WBound3);
                        break;
                    case SystemAudioManager.SEtype.cyber:
                        PlayBoundSe(AudioType.SBound3);
                        break;
                    case SystemAudioManager.SEtype.normal:
                        PlayBoundSe(AudioType.Bound);
                        break;
                }
                StartCoroutine("checkPos");
            }
        }
    }

    private void PlayBoundSe(AudioType type)
    {
        if (Se != null) Se.ShotSe(type);
    }

    IEnumerator checkPos()
    {
        while(true)
        {
            var tempPos = transform.position;
            yield return new WaitForSeconds(1f);
            var dis = Vector3.Distance(transform.position, tempPos);
            Debug.Log(dis);
            if (dis <= 0.1f)
            {
                yield return new WaitForSeconds(1f);
                switch (Se.type)
                {
                    case SystemAudioManager.SEtype.metal:
                        PlayBoundSe(AudioType.MDead);
                        break;
                    case SystemAudioManager.SEtype.fantasy:
                        PlayBoundSe(AudioType.FDead);
                        break;
                    case SystemAudioManager.SEtype.wood:
                        PlayBoundSe(AudioType.WDead);
                        break;
                    case SystemAudioManager.SEtype.cyber:
                        PlayBoundSe(AudioType.SDead);
                        break;
                    case SystemAudioManager.SEtype.normal:
                        PlayBoundSe(AudioType.Dead);
                        break;
                }

                yield return new WaitForSeconds(0.5f);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
