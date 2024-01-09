using JackieSoft;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuizButtonElement : MonoBehaviour, Cell.IView
{
    public Image lockImage;
    public Text levelText;
    public Button button;
    public bool isLock;
    // Start is called before the first frame update
    public void SetLock()
    {
        lockImage.gameObject.SetActive(true);
        levelText.gameObject.SetActive(false);
    }
    public void Unlock()
    {
        lockImage.gameObject.SetActive(false);
        levelText.gameObject.SetActive(true);
    }
}
