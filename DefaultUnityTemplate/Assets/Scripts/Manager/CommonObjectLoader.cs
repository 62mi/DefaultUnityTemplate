using UnityEngine;
using System.Collections.Generic;

using UnityEngine;
using System.Collections.Generic;

public class CommonObjectLoader : MonoBehaviour
{
    [SerializeField] private ManagerPrefabList managerList;
    private static bool isLoaded = false;

    void Awake()
    {
        if(isLoaded) return;
        
        foreach (var managerPrefab in managerList.prefabs)
        {
            var manager = Instantiate(managerPrefab);
            DontDestroyOnLoad(manager.gameObject);
            manager.GetComponent<AbstractManager>().Init();
        }
        
        isLoaded = true;
    }
}
