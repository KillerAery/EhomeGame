using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    public bool isOpened=false;
    public GameObject enemy;
    public GameObject woodBox;

    void Start()
    {
        
    }

    
    void Update()
    {
       
    }

    public void Open()
    {
        //Instantiate(enemy, transform.position, Quaternion.identity);
        woodBox.SendMessage("toOpen");
        isOpened = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isOpened&&collision.collider.tag=="Player")
        {
            Open();
        }
    }

    public void toOpen(string str)
    {

        tex.SetActive(true);
        ima.SetActive(true);
        inp.SetActive(true);
        text.text = "你发现了一个木箱";
        if (str == password)
        {
            Debug.Log("right");

        }

    }
}
