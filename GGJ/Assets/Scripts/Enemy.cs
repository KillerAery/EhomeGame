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
    private float attackForce = 50;
    //辅助
    private Transform target;//玩家位置
    public bool isAngry;
    public AudioSource moveAudio;
    public AudioClip[] Audio;//多个音效
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        moveAudio.clip = Audio[0];
        if (!moveAudio.isPlaying)
        {
            moveAudio.Play();
        }
    }

    void Update()
    {
        moveAudio.clip = Audio[1];
        if (!moveAudio.isPlaying)
        {
            moveAudio.Play();
        }
        Vector3 dr = target.position - transform.position;
        dr = dr.normalized;
        transform.Translate(dr * k * moveSpeed * Time.deltaTime, Space.World);
        //Move();
        //移动时根据朝向flip
        if (Mathf.Abs(dr.x) >= 0.01f)
          transform.localScale = new Vector2(Mathf.Sign(dr.x) * Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (attackForce <= 0) Die();
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().RecivedDamage(2.0f);
            attackForce -= 2.0f;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}