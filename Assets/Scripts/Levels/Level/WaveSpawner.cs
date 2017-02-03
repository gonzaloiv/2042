using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolManager))]

public class WaveSpawner : MonoBehaviour {

  #region Fields

  private static PoolManager poolManager;
  private static List<GameObject> waveObjects;

  #endregion

  #region Mono Behaviour

  void Awake() {
    poolManager = GetComponent<PoolManager>();
  }

  #endregion

  #region Public Behaviour

  public static List<GameObject> SpawnWave(LevelData.Wave wave) {
    waveObjects = new List<GameObject>();
    if (wave.enemies != null)
      SpawnWaveGameObjects<LevelData.Enemy>(wave.enemies);
    if (wave.powerUps != null)
      SpawnWaveGameObjects<LevelData.PowerUp>(wave.powerUps);   

    return waveObjects;
  }

  #endregion

  #region Private Behaviour

  private static void SpawnWaveGameObjects<T>(T[] gameObjects) where T : LevelData.ISpawnable {
    for (int i = 0; i < gameObjects.Length; i++)
      if (gameObjects[i].GetAmount() != 0)
        SpawnGameObject(gameObjects[i]);
  }

  private static void  SpawnGameObject<T>(T objectData) where T : LevelData.ISpawnable {
    for (int i = 0; i < objectData.GetAmount(); i++) {
      GameObject obj = typeof(T) == typeof(LevelData.Enemy) ? poolManager.EnemyPools[objectData.GetType()].PopObject() : poolManager.PowerUpPool.PopObject(objectData.GetType());
      obj.transform.position = objectData.GetPositions().Length != 0 ? new Vector3(objectData.GetPositions()[i], 6, 0) : new Vector3(Random.Range(-7, 7), 6, 0);
      obj.SetActive(true);
 
      waveObjects.Add(obj);
    }
  }

  #endregion

}
