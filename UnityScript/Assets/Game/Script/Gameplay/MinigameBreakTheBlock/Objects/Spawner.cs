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
    [SerializeField] private float minSpawnTime = 1.5f;
    [SerializeField] private float maxSpawnTime = 2f;
    private float xPreValue;
    protected override void Awake()
    {
        base.Awake();
        GameEvent.OnRestartGame += OnRestartGameEvent;
        GameEvent.OnGameLose += StopSpawning;
    }
    private IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnTime, maxSpawnTime));
        var obj = Instantiate(fallingObjPrefab, new Vector2(UnityEngine.Random.Range(-xBound, xBound), ybound), Quaternion.identity);
        
        listObj.Add(obj);
        StartCoroutine(SpawnObject());
    }
    public void GameStart()
    {
        isIngame = true;
        StartCoroutine(SpawnObject());
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
