using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}

public partial class ResourceManager
{
    
}
