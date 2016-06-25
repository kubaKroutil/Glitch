using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ProjectileType {bell,cucumber };

public class ObjectPooler : MonoBehaviour {


    public static ObjectPooler instance = null;
    public GameObject bellPrefab;
    public GameObject cucumberPrefab;

    private List<GameObject> bellList = new List<GameObject>();
    private List<GameObject> cucumberList = new List<GameObject>();
    private int initialPoolSize = 5;

    void Awake()
    {
        instance = this;
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateGameObject(bellList, bellPrefab);
            CreateGameObject(cucumberList, cucumberPrefab);
        }
    }

    private GameObject CreateGameObject(List<GameObject> list, GameObject prefab)
    {
        GameObject newObject = Instantiate(prefab);
        newObject.SetActive(false);
        newObject.transform.SetParent(transform);
        list.Add(newObject);
        return newObject;
    }

    public GameObject GetProjectile(ProjectileType type)
    {
        if (type == ProjectileType.bell)
        {
            foreach (GameObject bell in bellList)
            {
                if (!bell.activeInHierarchy)
                {
                    return bell;
                }
            }
            return CreateGameObject(bellList, bellPrefab);
        } else
            foreach (GameObject cucumber in cucumberList)
            {
                if (!cucumber.activeInHierarchy)
                {
                    return cucumber;
                }
            }
        return CreateGameObject(cucumberList, cucumberPrefab);
    }


}
