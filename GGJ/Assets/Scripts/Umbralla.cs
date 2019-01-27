using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbralla : MonoBehaviour
{
    private TextManager textManager;
    void Start()
    {
        textManager = GameObject.FindGameObjectWithTag("TextManager").GetComponent<TextManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E) && collision.gameObject.tag == "Player")
        {
            var player = collision.gameObject.GetComponent<Player>();
            player.umbrella = true;
            textManager.ShowText("一把有点历史的伞");
            player.health += 20;
            StartCoroutine(Memory());
            Destroy(gameObject);
        }
    }

    IEnumerator Memory()
    {
        yield return new WaitForSeconds(2f);
        textManager.ShowText("这是。。。。我想起来了");
        yield return new WaitForSeconds(3f);
        textManager.ShowText("那天成绩不理想和父亲吵架");

        yield return new WaitForSeconds(3f);
        textManager.ShowText("我跟父亲说“我不想高考了！”");
        yield return new WaitForSeconds(3f);
        textManager.ShowText("父亲很生气地打了我一巴掌");

        yield return new WaitForSeconds(3f);
        textManager.ShowText("我脸上火辣辣地，不敢相信父亲竟打了我，从家里跑了出去");
        yield return new WaitForSeconds(3f);
        textManager.ShowText("父亲找了我好久，在夜晚时当他找到我时，他只是抱着我沉默了很久");

        yield return new WaitForSeconds(3f);
        textManager.ShowText("最后说了：“我不该打你的，但知难而退可不是真正的男子汉，我们回家吧。”");

        yield return new WaitForSeconds(5f);
        textManager.ShowText("家的回忆在我脑海中一幕幕闪过，我的内心世界突然亮了起来");


        yield return null;
    }
}
