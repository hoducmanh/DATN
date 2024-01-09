using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpawnObject : MonoBehaviour
{
    public static SpawnObject Instance;
    public float xBound, ybound;
    public FallingObject fallingObjPrefab;
    public List<FallingObject> listObj = new List<FallingObject>();
    public Action<string> OnDestroyObject;
    public bool isIngame = false;
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        GameStart();
    }
    private IEnumerator spawnObjectEasyMode()
    {
        yield return new WaitForSeconds(10f);
        yield return new WaitForSeconds(UnityEngine.Random.Range(1.5f, 2f));
        var obj = Instantiate(fallingObjPrefab, new Vector2(UnityEngine.Random.Range(-xBound, xBound), ybound), Quaternion.identity);
        
        listObj.Add(obj);
        StartCoroutine(spawnObjectEasyMode());
    }
    public void GameStart()
    {
        isIngame = true;
        StartCoroutine(spawnObjectEasyMode());
    }
    public void StopSpawning()
    {
        StopAllCoroutines();
    }
}
