using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAchievement : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    private void OnEnable()
    {
        closeButton.onClick.AddListener(OnClickCloseButton);
    }
    private void OnClickCloseButton()
    {
        gameObject.SetActive(false);
    }
}
