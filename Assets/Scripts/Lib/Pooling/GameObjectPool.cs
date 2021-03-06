﻿using System;
using UnityEngine;
using System.Collections.Generic;

// Based on TheLiquidFire's: https://theliquidfire.wordpress.com/2015/07/06/object-pooling/
public class GameObjectPool : IPool {

  #region Fields

  private List<GameObject> objects = new List<GameObject>();
  private GameObject prefab;
  GameObject poolGameObject;

  #endregion

  #region Contructors

  public GameObjectPool(string poolName, GameObject prefab, int initialObjectAmount, Transform parent) {
    this.prefab = prefab;
    poolGameObject = new GameObject(poolName);
    poolGameObject.transform.parent = parent;
    Prepopulate(initialObjectAmount);
  }
 
  #endregion

  #region Public Behaviour

  public GameObject PopObject() {
    foreach (GameObject obj in objects) {
      if (!obj.activeInHierarchy)
        return obj;
    }
    return PushObject();
  }

  public GameObject PushObject() {
    GameObject obj = Pooler.CreatePoolGameObject(prefab, poolGameObject.transform);
    obj.SetActive(false);
    objects.Add(obj);

    return obj;
  }
 
  public void Prepopulate(int objectAmount) {
    for(int i = 0; i < objectAmount; i++)
        PushObject(); 
  }

  #endregion

}