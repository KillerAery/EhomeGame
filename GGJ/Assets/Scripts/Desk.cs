using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    public GameObject tip;
    private TextManager textManager;
    void Start()
    {
        textManager = GameObject.FindGameObjectWithTag("TextManager").GetComponent<TextManager>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="Player")
        {
            tip.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                Open();
                tip.SetActive(false);
            }
        }
    }

    public void Open()
    {
        textManager.ShowText("抽屉里有本日记，上面写着：6月6日生日，而明天便是高考，哪有心思过什么生日");
    }
}
