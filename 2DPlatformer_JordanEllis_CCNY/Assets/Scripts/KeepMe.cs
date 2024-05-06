using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public static GameObject instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            //Debug.Log("Audio Manager not destroyed");
            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            //Debug.Log("Extra Destroyed");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
