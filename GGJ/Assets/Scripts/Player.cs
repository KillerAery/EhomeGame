using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float health = 3;    //生命值
    public float maxhealth = 3; //最大生命值
    private int dr = 1;
    void Start()
    {
        
    }

    
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * x * moveSpeed * Time.deltaTime, Space.World);
        if (Mathf.Abs(x) >= 0.01f)
        {
            dr = (int)Mathf.Sign(x);
            transform.localScale = new Vector2(dr * Mathf.Abs(transform.localScale.x), transform.localScale.y);
            
        }

        float y = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * y * moveSpeed * Time.deltaTime, Space.World);
    }
}
