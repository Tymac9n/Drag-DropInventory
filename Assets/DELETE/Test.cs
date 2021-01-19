using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Delete delete;

    public void Add3ID()
    {
        delete.AddItem(3);
    }

    public void Debugs()
    {
        Debug.Log("xyi");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
