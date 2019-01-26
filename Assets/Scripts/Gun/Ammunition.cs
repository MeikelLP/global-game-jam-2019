using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : MonoBehaviour
{

    public int min;
    public int max;
    public int current;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Decrease()
    {
        if (current >= 0)
        {
            current--;    
        }
    }

    public bool isEmpty()
    {
        return current == 0;
    }

    void Reload()
    {
        current = max;
    }
}
