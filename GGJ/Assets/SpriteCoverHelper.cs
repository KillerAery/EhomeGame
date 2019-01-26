using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCoverHelper : MonoBehaviour
{
    private SpriteRenderer render;
    private string layername;
    private int order;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        layername = render.sortingLayerName;
        order = render.sortingOrder;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            render.sortingLayerName = "player";
            render.sortingOrder = 10;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        render.sortingLayerName = layername;
        render.sortingOrder = order;
    }
}
