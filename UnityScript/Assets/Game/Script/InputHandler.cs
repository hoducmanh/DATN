using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour
{
    public bool Active { get => blockersId.Count == 0; }

    private List<string> blockersId = new List<string>();

    public event Action<Collider> OnClick;

    public void BlockInput(string id)
    {
        if (blockersId.Contains(id)) { return; }
        blockersId.Add(id);
    }

    public void UnblockInput(string id)
    {
        Debug.Log("Unblock Input: id=" + id);
        blockersId.Remove(id);
    }

    public void BlockItemInput()
    {
        //ItemManager.BlockItemInPut?.Invoke();
    }

    private void Update()
    {
        if (!Active) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo))
            {
                OnClick?.Invoke(hitInfo.collider);
            }
        }
    }
}
