﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject[] lgMeteorPrefabs;
  [SerializeField] private GameObject[] mdMeteorPrefabs;
  [SerializeField] private GameObject[] smMeteorPrefabs;
  private GameObjectArrayPool lgMeteorPool;
  private GameObjectArrayPool mdMeteorPool;
  private GameObjectArrayPool smMeteorPool;
  private Transform levelEnemies;

  #endregion

  #region Mono Behaviour

  void Awake() {
    levelEnemies = new GameObject("LevelEnemies").transform;
    levelEnemies.SetParent(transform);
    lgMeteorPool = Pooler.CreateGameObjectArrayPool("LgMeteorPool", lgMeteorPrefabs, 0, levelEnemies);
    mdMeteorPool = Pooler.CreateGameObjectArrayPool("MdMeteorPool", mdMeteorPrefabs, 0, levelEnemies);
    smMeteorPool = Pooler.CreateGameObjectArrayPool("SmMeteorPool", smMeteorPrefabs, 0, levelEnemies);
  }

  void Start() {
    StartCoroutine(SpawnMeteorWave());
  }

  #endregion

  #region Private Behaviour

  private IEnumerator SpawnMeteorWave() {
    while (true) {
      for (int i = 0; i < 1; i++) {
        GameObject meteor = lgMeteorPool.PopObject();
        meteor.transform.position = new Vector3(Random.Range(-9, 9), 6, 0);
        meteor.SetActive(true);
      }
      yield return new WaitForSeconds(1);
    }
  }

  #endregion
}
