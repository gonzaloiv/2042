using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
      SpawnEnemies(wave);
    if (wave.powerUps != null)
      SpawnPowerUps(wave);

    return waveObjects;
  }

  #endregion

  #region Private Behaviour

  private static void SpawnEnemies(LevelData.Wave wave) {
    for (int i = 0; i < wave.enemies.Length; i++)
      if (wave.enemies[i].amount != 0)
        SpawnEnemy(wave.enemies[i]);
  }

  private static void  SpawnEnemy(LevelData.Enemy enemyData) {
    for (int i = 0; i < enemyData.amount; i++) {
      GameObject enemy = poolManager.EnemyPools[(int) enemyData.type].PopObject();
      enemy.transform.position = enemyData.positions.Length != 0 ? new Vector3(enemyData.positions[i], 6, 0) : new Vector3(Random.Range(-7, 7), 6, 0);
      enemy.SetActive(true);
 
      waveObjects.Add(enemy);
    }
  }

  private static void SpawnPowerUps(LevelData.Wave wave) {
    for (int i = 0; i < wave.powerUps.Length; i++)
      if (wave.powerUps[i].amount != 0)
        SpawnPowerUp(wave.powerUps[i]);
  }

  private static void SpawnPowerUp(LevelData.PowerUp powerUpData) {
    for (int i = 0; i < powerUpData.amount; i++) {
      GameObject powerUp = poolManager.PowerUpPool.PopObject((int) powerUpData.type);
      powerUp.transform.position = powerUpData.positions.Length != 0 ? new Vector3(powerUpData.positions[i], 6, 0) : new Vector3(Random.Range(-7, 7), 6, 0);
      powerUp.SetActive(true);

      waveObjects.Add(powerUp);
    }
  }

  #endregion

}
