using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    public float xBound, ybound;
    public FallingObject fallingObjPrefab;
    public List<FallingObject> listObj = new List<FallingObject>();
    public Action<string> OnDestroyObject;
    public bool isIngame;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public IEnumerator spawnObjectEasyMode()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(2f, 3f));
        var obj = Instantiate(fallingObjPrefab, new Vector2(UnityEngine.Random.Range(-xBound, xBound), ybound), Quaternion.identity);
        
        listObj.Add(obj);
        StartCoroutine(spawnObjectEasyMode());
    }
    public IEnumerator spawnObjectMediumMode()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1.5f, 2f));
        var obj = Instantiate(fallingObjPrefab, new Vector2(UnityEngine.Random.Range(-xBound, xBound), ybound), Quaternion.identity);

        listObj.Add(obj);
        StartCoroutine(spawnObjectMediumMode());
    }
    public IEnumerator spawnObjectHardMode()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 1.5f));
        var obj = Instantiate(fallingObjPrefab, new Vector2(UnityEngine.Random.Range(-xBound, xBound), ybound), Quaternion.identity);

        listObj.Add(obj);
        StartCoroutine(spawnObjectHardMode());
    }
}
