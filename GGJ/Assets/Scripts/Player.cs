using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float health = 100.0f;    //生命值

    //是否正在握伞
    [HideInInspector]public bool handlingUmbrella = false;
    //是否持有伞
    [HideInInspector] public bool umbrella = false;
    //是否持有书房钥匙
    [HideInInspector]public bool studykey = false;
    //是否持有大门钥匙
    [HideInInspector] public bool gatekey = false;

    public Light pointLight;

    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private float init_intensity;
    private int direction = 1;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        init_intensity = pointLight.intensity;
    }
    
    void Update()
    {
        pointLight.intensity = init_intensity * (health / 100.0f);
        Move();
        UmbrallaControll();
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
        var v = new Vector2(x, y);
        v = moveSpeed * v.normalized;
        rigidbody2D.velocity = v;
        if (Mathf.Abs(x) >= 0.01f)
        {
            direction = -(int)Mathf.Sign(x);
            transform.localScale = new Vector3(direction * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void UmbrallaControll()
    {
        if (umbrella&&Input.GetKey(KeyCode.J))
        {
            handlingUmbrella = true;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
