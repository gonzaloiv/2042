using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

// Based on TheLiquidFire's: https://theliquidfire.wordpress.com/2015/07/06/object-pooling/
public class GameObjectArrayPool {

  #region Fields

  private List<KeyValuePair<string, GameObject>> objects = new List<KeyValuePair<string, GameObject>>();
  private GameObject[] prefabs;
  GameObject pool;

  #endregion

  #region Contructors

  public GameObjectArrayPool(string poolName, GameObject[] prefabs, int initialObjectAmount, Transform parent) {
    this.prefabs = prefabs;
    pool = new GameObject(poolName);
    pool.transform.parent = parent;
    for (int i = 0; i < initialObjectAmount; i++)
      PushObject(); 
  }
 
  #endregion

  #region Public Behaviour

  public GameObject PopObject() {
    foreach (KeyValuePair<string, GameObject> pair in objects) {
      if (!pair.Value.activeInHierarchy)
        return pair.Value;
    }
    return PushObject();
  }

  public GameObject PopObject(string prefabName) {
    List<GameObject> prefabObjects = objects.Where(x => x.Key == prefabName).Select(x => x.Value).ToList();
    foreach (GameObject obj in prefabObjects) {
      if (!obj.activeInHierarchy)
        return obj;
    }
    return PushObject();
  }

  public GameObject PushObject() {
    int index = UnityEngine.Random.Range(0, prefabs.Length);
    return PushObject(prefabs[index]);
  }

  public GameObject PushObject(GameObject prefab) {
    GameObject obj = Pooler.CreatePoolGameObject(prefab, pool.transform);
    obj.SetActive(false);
    objects.Add(new KeyValuePair<string, GameObject>(prefab.name, obj));

    return obj;
  }

  #endregion

}