using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //值
    public float moveSpeed;
    public float Min;
    public float Max;
    public float attackDistance;
    public float v = 2;
    private float k = 2;
    //辅助
    private Transform target;//玩家位置
    public bool isAngry;
    private new Rigidbody2D rigidbody2D;
    public AudioSource moveAudio;
    public AudioClip[] Audio;

    public GameObject dieParticle;

    public float maxdamage = 50.0f;
    private float damage = 0.0f;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        moveAudio.clip = Audio[0];
        if (!moveAudio.isPlaying)
        {
            moveAudio.Play();
        }
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(Countdown());
    }

    void Update()
    {
        Vector2 dr = target.position - transform.position;
        dr = dr.normalized;
        rigidbody2D.velocity = dr * moveSpeed;
        //Move();
        moveAudio.clip = Audio[1];
        if (!moveAudio.isPlaying)
        {
            moveAudio.Play();
        }
        //移动时根据朝向flip
        if (Mathf.Abs(dr.x) >= 0.01f)
            transform.localScale = new Vector2(-Mathf.Sign(dr.x) * Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float d = 2.0f;
            damage += d;
            collision.gameObject.GetComponent<Player>().RecivedDamage(d);
            if (damage >= maxdamage)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        Instantiate(dieParticle, transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator Countdown()
    {
        for (float timer = 20.0f; timer >= 0; timer -= Time.deltaTime)
            yield return 0;
        Die();
    }
}