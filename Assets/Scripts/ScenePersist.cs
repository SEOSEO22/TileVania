using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    private void Awake()
    {
        int scenePersistNumber = FindObjectsOfType<GameSession>().Length;

        if (scenePersistNumber > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void destroyPersistObject()
    {
        Destroy(gameObject);
    }
}
