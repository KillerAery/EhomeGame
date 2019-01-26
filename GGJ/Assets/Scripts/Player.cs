using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float health = 100;    //生命值

    //是否正在握伞
    [HideInInspector]public bool handlingUmbrella = false;

    private int direction = 1;

    void Start()
    {
        
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
        transform.Translate(Vector3.right * x * moveSpeed * Time.deltaTime, Space.World);
        if (Mathf.Abs(x) >= 0.01f)
        {
            direction = (int)Mathf.Sign(x);
            transform.localScale = new Vector2(direction * Mathf.Abs(transform.localScale.x), transform.localScale.y);
            
        }

        float y = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * y * moveSpeed * Time.deltaTime, Space.World);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
