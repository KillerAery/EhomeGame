using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCoverHelper : MonoBehaviour
{
    private Tilemap tilemapRenderer;
    // Start is called before the first frame update
    void Start()
    {
        tilemapRenderer = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var c= tilemapRenderer.color;
            c.a = 0.4f;
            tilemapRenderer.color = c;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var c = tilemapRenderer.color;
        c.a = 1.0f;
        tilemapRenderer.color = c;
    }
}
