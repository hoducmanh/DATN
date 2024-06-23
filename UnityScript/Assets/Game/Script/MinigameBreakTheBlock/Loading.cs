using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    
    private void OnEnable()
    {
        
        StartCoroutine(delayTime());
    }
    IEnumerator delayTime()
    {
        yield return new WaitForSeconds(10f);
        
    }
}
