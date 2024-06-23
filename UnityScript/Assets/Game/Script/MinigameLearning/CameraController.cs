using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private int currentCamIndex = 0;
    private WebCamTexture tex;
    [SerializeField] private RawImage display;
    private void Start()
    {
        StartCoroutine(DelayProcess());
        
    }
    private void SwapCam()
    {
        if (WebCamTexture.devices.Length > 0)
        {
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;
        }
    }
    private void OnDestroy()
    {
        if(tex != null)
        {
            display.texture = null;
            tex.Stop();
            tex = null;
        }
    }
    IEnumerator DelayProcess()
    {
        yield return new WaitForSeconds(15f);
        if (tex != null)
        {
            display.texture = null;
            tex.Stop();
            tex = null;
        }
        else
        {
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;
            tex.Play();
        }
    }
}
