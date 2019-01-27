using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wardrobe : MonoBehaviour
{
    //值
    public string password = "0606";
    //辅助
    public GameObject enemy;
    public GameObject player;
    public GameObject inp;
    public InputField inputField;
    private TextManager textManager;
    public bool empty = false;
    public GameObject tip;
    void Start()
    {
        textManager = GameObject.FindGameObjectWithTag("TextManager").GetComponent<TextManager>();
    }

    
    void Update()
    {
       
    }

    public void Open()
    {
        
        Instantiate(enemy, transform.position, Quaternion.identity);
        
        inp.SetActive(true);//"你发现了一个木箱"
        textManager.ShowText("你发现了一个木箱");

        empty = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (empty) return;
        if (collision.collider.tag=="Player")
        {
            tip.SetActive(true);
            if(Input.GetKey(KeyCode.E))
            {
                inp.SetActive(false);
                Open();
                
            }
            tip.SetActive(false);
        }
    }

    public void toOpen()
    {
        //
        if (inputField.text == password)
        {
            
            textManager.ShowText("一条奇怪的围巾");

            StartCoroutine(Memory());
        }
        
        
    }

    IEnumerator Memory()
    {
        yield return new WaitForSeconds(2f);
        textManager.ShowText("这不是我曾经在母亲生日时编织的送给她的生日礼物吗？");
        yield return new WaitForSeconds(3f);
        textManager.ShowText("我当时觉得太丑了，以为母亲会把它随手一丢");

        yield return new WaitForSeconds(3f);
        textManager.ShowText("母亲当时很高兴地收下了，而且竟然如此认真地保留到现在");
        yield return new WaitForSeconds(3f);
        textManager.ShowText("而母亲今晚送我的生日礼物我却因为焦虑烦躁而草草扔在一旁");

        yield return new WaitForSeconds(3f);
        textManager.ShowText("头脑中突然闪过无数母亲照顾生病时我的画面");
        yield return new WaitForSeconds(3f);
        textManager.ShowText("母亲对我一直是如此，我却忽视了");

        yield return new WaitForSeconds(3f);
        textManager.ShowText("家这个词仿佛在心中熟悉了一点");
        yield return new WaitForSeconds(3f);
        textManager.ShowText("心中仿佛变温暖了一些");
        player.SendMessage("Strengthen",25);

        yield return null;
    }
}
