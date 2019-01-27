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
                    textManager.ShowText("一个护身符。想起来这是奶奶给我高考前买的...balabala");
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
}
