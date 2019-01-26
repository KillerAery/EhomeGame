using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float Max;
    public float Min;
    private Vector2 offset;     //相机与人物偏移量
    private Vector2 ve;
    void Start()
    {
        
    }


    void FixedUpdate()
    {
        if (transform.position.x >= Min && transform.position.x <= Max)
        {
            Vector3 s = Vector2.SmoothDamp(transform.position, target.position, ref ve, 0.5f);
            s.z = transform.position.z;
            transform.position = s;
        }
    }
}
