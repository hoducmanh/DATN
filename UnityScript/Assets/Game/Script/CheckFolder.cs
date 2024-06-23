using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckFolder : SingletonDontDestroy<CheckFolder>
{
    public Text textLog;
    // Start is called before the first frame update
    void Start()
    {
        string path = System.IO.Directory.GetCurrentDirectory();
        textLog.text = path;
    }

    
}
