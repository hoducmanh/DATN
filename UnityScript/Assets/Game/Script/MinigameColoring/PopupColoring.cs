using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupColoring : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button closeButton;
    private void Awake()
    {
        closeButton.onClick.AddListener(OnClickCloseButton);
    }
    private void OnClickCloseButton()
    {
        gameObject.SetActive(false);
    }
}
