using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerGrandParent : MonoBehaviour
{
    //是否护身符
    public bool amulet = false;
    //是否书房的钥匙
    public bool key = false;
    //是否被搜刮过
    public bool empty = false;

    public GameObject barrier;

    public GameObject tip;
    private TextManager textManager;

    //Start is called before the first frame update
    void Start()
    {
        textManager = GameObject.FindGameObjectWithTag("TextManager").GetComponent<TextManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        //搜刮过则没必要再显示
        if (empty) return;

        if (collision.gameObject.tag == "Player")
        {
            tip.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                var player = collision.gameObject.GetComponent<Player>();
                if (key)
                {
                    player.studykey = true;
                    textManager.ShowText("这是书房的钥匙..");
                }
                else if (amulet) {
                    textManager.ShowText("一个护身符.");
                    player.ambut = true;
                    player.health += 20;
                    StartCoroutine(Memory());
                    Destroy(barrier);
                }
                else
                {
                    textManager.ShowText("这什么都没有。");
                }
                empty = true;
                tip.SetActive(false);
            }
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        tip.SetActive(false);
    }

    IEnumerator Memory()
    {
        yield return new WaitForSeconds(2f);
        textManager.ShowText("这是。。。。奶奶高考前费了很大劲为我求来的保佑符");
        yield return new WaitForSeconds(3f);
        textManager.ShowText("我当时刚考砸了一模，幸苦地刷题却等来了退步");

        yield return new WaitForSeconds(3f);
        textManager.ShowText("一气之下我说了“老一辈人就是封建迷信”");
        yield return new WaitForSeconds(3f);
        textManager.ShowText("然后把它扔在了垃圾桶里");

        yield return new WaitForSeconds(3f);
        textManager.ShowText("那时的我是失去理智了吗。。。奶奶那么幸苦求来的");
        yield return new WaitForSeconds(3f);
        textManager.ShowText("奶奶对不起，我一定伤了您的心了吧。"); 
        
        yield return null;
    }
}
