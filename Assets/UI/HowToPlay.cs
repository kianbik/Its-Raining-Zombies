using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HowToPlay : MonoBehaviour
{

    public Sprite[] gallery;
    public Image displayImage;
    public Button nextImg;
    public Button prevImg;
    public int i = 0; 

    public void BtnNext()
    {
        if (i + 1 < gallery.Length)
        {
            i++;
        }
    }

    public void BtnPrev()
    {
        if (i - 1 >= 0)
        {
            i--;
        }
    }

    void Update()
    {
        displayImage.sprite = gallery[i];
        
    }
}
