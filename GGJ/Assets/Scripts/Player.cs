using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float health = 100;    //生命值

    //是否正在握伞
    [HideInInspector]public bool handlingUmbrella = false;
    //是否持有书房钥匙
    [HideInInspector]public bool studykey = false;
    //是否持有大门钥匙
    [HideInInspector] public bool gatekey = false;

    private new Rigidbody2D rigidbody2D;
    private Animator animator;

    private int direction = 1;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        Move();
    }

    public void RecivedDamage(float damage)
    {
        health -= damage;
        if(health <= 0.0f)
        {
            health = 0.0f;
            Die();
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //animator.SetFloat("Walk", Mathf.Abs(x) + Mathf.Abs(y));
        rigidbody2D.velocity = Vector3.up * y * moveSpeed + Vector3.right * x * moveSpeed;
        if (Mathf.Abs(x) >= 0.01f)
        {
            direction = -(int)Mathf.Sign(x);
            transform.localScale = new Vector2(direction * Mathf.Abs(transform.localScale.x), transform.localScale.y);
            
        }


    }

    void Die()
    {
        Destroy(gameObject);
    }
}
