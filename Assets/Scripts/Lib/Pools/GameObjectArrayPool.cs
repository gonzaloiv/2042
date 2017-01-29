using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

// Based on TheLiquidFire's: https://theliquidfire.wordpress.com/2015/07/06/object-pooling/
public class GameObjectArrayPool : IPool {

  #region Fields

  private List<KeyValuePair<int, GameObject>> objects = new List<KeyValuePair<int, GameObject>>();
  private GameObject[] prefabs;
  GameObject pool;
  int currentPrefabIndex = 0;

  #endregion

  #region Contructors

  public GameObjectArrayPool(string poolName, GameObject[] prefabs, int initialObjectAmount, Transform parent) {
    this.prefabs = prefabs;
    pool = new GameObject(poolName);
    pool.transform.parent = parent;
    Prepopulate(initialObjectAmount);
  }

  #endregion

  #region Public Behaviour

  public GameObject PopObject() {
    foreach (KeyValuePair<int, GameObject> pair in objects) {
      if (!pair.Value.activeInHierarchy)
        return pair.Value;
    }
    return PushObject();
  }

  public GameObject PopObject(int prefabIndex) {
    List<GameObject> prefabObjects = objects.Where(x => x.Key == prefabIndex).Select(x => x.Value).ToList();
    foreach (GameObject obj in prefabObjects) {
      if (!obj.activeInHierarchy)
        return obj;
    }
    return PushObject();
  }

  public GameObject PushObject() {
    currentPrefabIndex++;
    return PushObject(currentPrefabIndex, prefabs[currentPrefabIndex]);
  }

  public GameObject PushObject(int index, GameObject prefab) {
    GameObject obj = PoolManager.CreatePoolGameObject(prefab, pool.transform);
    obj.SetActive(false);
    objects.Add(new KeyValuePair<int, GameObject>(index, obj));

    return obj;
  }

  public void Prepopulate(int objectAmount) {
    int x = 0, y = 0;
    while (x < objectAmount) {
      for (y = currentPrefabIndex; y < prefabs.Length; y++) {
        PushObject(currentPrefabIndex, prefabs[y]); 
        x++;
      }
    }
    currentPrefabIndex = y;
  }

  #endregion

}