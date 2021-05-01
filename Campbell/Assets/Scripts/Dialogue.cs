using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    public GameObject box;
    public AudioSource voice;
    public string dialogue;
    public Text text;
    public Image Image;
    public Sprite sprite;
    public GameObject talk;
    public bool cantalk = true;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cantalk && collision.gameObject.tag=="Player")
        {
            talk.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)

    {
        if (cantalk)
        {
            if (Input.GetKeyDown("z"))
            {
                ShowBox();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        HideBox();
        talk.SetActive(false);
    }
    void ShowBox()
    {
        talk.SetActive(false);
        box.SetActive(true);
        text.text = dialogue;
        Image.sprite = sprite;
        voice.Play();
       
    }

    void HideBox()
    {
        box.SetActive(false);

    }

}
