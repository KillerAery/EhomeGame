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
    private SpriteRenderer sp;
    //辅助
    private Transform target;//玩家位置
    public bool isAngry;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        sp = GetComponent<SpriteRenderer>();
    }



    void Update()
    {
        Vector3 dr = target.position - transform.position;
        dr = dr.normalized;
        dr.y = 0;
        transform.Translate(dr * k * moveSpeed * Time.deltaTime, Space.World);
        Move();
        //移动时根据朝向flip
        //if (Mathf.Abs(dr.x) >= 0.01f)
        //    transform.localScale = new Vector2(Mathf.Sign(dr.x) * -1.0f, transform.localScale.y);
    }

    private void Move()
    {
        //判断距离
        if (Vector3.Distance(target.position, transform.position) <= attackDistance)
        {
            isAngry = true;
        }
        else if (Vector3.Distance(target.position, transform.position) > attackDistance || transform.position.x > Max || transform.position.x < Min)
        {
            isAngry = false;
        }


        if (!isAngry)
        {
            if (transform.position.x >= Max)
            {
                k = -v;
                sp.flipX = true;
            }
            else if (transform.position.x <= Min)
            {
                k = v;
                sp.flipX = false;
            }

        }
        else
        {
            if (target.position.x > transform.position.x)
            {
                k = 2 * v;
                sp.flipX = false;
            }
            else if (target.position.x < transform.position.x)
            {
                k = -2 * v;
                sp.flipX = true;
            }
            else
            {
                k = 0;
            }

        }
    }
}