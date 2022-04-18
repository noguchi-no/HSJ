using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class warpGate : MonoBehaviour
{
    [SerializeField]
    private Transform WarpPoint;
    public GameObject iconOverWarpGate;
    public GameObject iconOverTarget;
    Vector3 playerScale;
    public GameObject player;
    public float duration = 0.3f;
    //public float interval;
    Rigidbody2D rb;
    Vector3 playerVelocity;

    public AudioClip enterSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = player.GetComponent<Rigidbody2D>();
        playerScale = player.transform.localScale;
        Debug.Log(playerScale);
        iconOverWarpGate.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, 360.0f), 2.0f)
                                    .SetRelative(true)
                                    .SetLoops(-1);
        iconOverTarget.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, 360.0f), 2.0f)
                                    .SetRelative(true)
                                    .SetLoops(-1); 
    }

    // Update is called once per frame
    void Update()
    {
        if(isWarp)
        {
            playerVelocity = rb.velocity;
            rb.velocity = Vector2.zero;
            //rb.bodyType = RigidbodyType2D.Kinematic;
        }
        
        if(isReStart) 
        {
            rb.velocity = playerVelocity;
            //rb.bodyType = RigidbodyType2D.Dynamic;
        }
        
        
    }
    bool isWarp;
    bool isReStart;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Ball"))
        {
            
            Debug.Log("warp");
            Sequence seq = DOTween.Sequence();
            seq.Append(col.gameObject.transform.DOScale(Vector2.zero, duration))
            .AppendCallback(() =>
            {
                col.gameObject.transform.position = WarpPoint.position;
                audioSource.PlayOneShot(enterSound);
                col.gameObject.transform.DOScale(playerScale, duration);
            });
            //col.gameObject.transform.position = WarpPoint.position;

            /*
            Sequence seq = DOTween.Sequence();
            seq.AppendInterval(interval)
            .AppendCallback(() =>
            {
                
                //Debug.Log(playerVelocity);
                isWarp = true;
                //;
                //Debug.Log(player.GetComponent<Rigidbody2D>().isKinematic);
            })
            .AppendCallback(() =>
            {
                
                //rb.velocity = Vector2.zero;
            })
            
            .Append(col.gameObject.transform.DOScale(Vector2.zero, duration))
            .AppendCallback(() =>
            {
                col.gameObject.transform.position = WarpPoint.position;
                col.gameObject.transform.DOScale(playerScale, duration);
            })
            .AppendCallback(() =>
            {
                isReStart = true;
            });
            //.Append();

            // .OnComplete(() => 
            // {
                

            // });
          */  
            
        }

    }
}
