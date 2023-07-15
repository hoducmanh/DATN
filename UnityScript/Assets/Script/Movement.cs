using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float xBound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxis("Vertical");
        Vector2 pos = transform.position;
        pos.x += h * speed * Time.deltaTime;
        //pos.y += v * Time.deltaTime;
        transform.position = new Vector2(Mathf.Clamp(pos.x, -xBound, xBound), pos.y);
    }
}
