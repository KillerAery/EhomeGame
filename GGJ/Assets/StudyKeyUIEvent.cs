using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudyKeyUIEvent : MonoBehaviour
{
    private Player player;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.studykey)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
    }
}
