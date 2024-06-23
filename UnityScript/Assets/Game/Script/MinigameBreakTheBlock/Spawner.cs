using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Spawner : SingletonMonoBehavior<Spawner>
{
    [SerializeField] private float xBound, ybound;
    [SerializeField] private FallingObject fallingObjPrefab;
    public static List<FallingObject> listObj = new();
    public static Action<string> OnDestroyObject;
    public bool isIngame = false;
    protected override void Awake()
    {
        base.Awake();
        GameEvent.OnRestartGame += OnRestartGameEvent;
        GameEvent.OnGameLose += StopSpawning;
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
    private void OnRestartGameEvent()
    {
        if (listObj.Count != 0)
            listObj.Clear();
        GameStart();
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameEvent.OnRestartGame -= OnRestartGameEvent;
        GameEvent.OnGameLose -= StopSpawning;
    }
}
