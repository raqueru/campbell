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
 
    private void OnTriggerStay2D(Collider2D collision)

    {
        if (Input.GetKeyDown("z"))
        {
            ShowBox();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        HideBox();
    }
    void ShowBox()
    {
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
