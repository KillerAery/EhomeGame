using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarterView : MonoBehaviour
{
    public Transform target;
    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;
    private Vector2 offset;     //相机与人物偏移量
    private Vector2 ve;
    void Start()
    {
        
    }


    void FixedUpdate()
    {

        if (transform.position.x >= xMin && transform.position.x <= xMax && transform.position.y >= yMin && transform.position.y <= yMax)
        {
            Vector3 s = Vector2.SmoothDamp(transform.position, target.position, ref ve, 0.5f);
            s.x = Mathf.Clamp(s.x, xMin, xMax);
            s.y = Mathf.Clamp(s.y, yMin, yMax);
            s.z = transform.position.z;
            transform.position = s;

        }
       
    }
}
