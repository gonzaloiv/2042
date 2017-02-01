using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour{

  #region Fields
  
  private static PoolManager poolManager;

  #endregion

  #region Mono Behaviour

  void Awake() {
    poolManager = GetComponent<PoolManager>();
  }

  #endregion

  #region Public Behaviour

  public static void SpawnWave(GameData.Wave wave) {
    SpawnEnemies(wave);
    SpawnPowerUps(wave);
  }

  #endregion

  #region Private Behaviour

  private static void SpawnEnemies(GameData.Wave wave) {
    for (int i = 0; i < wave.enemies.Length; i++)
      if(wave.enemies[i].amount != 0)
        SpawnEnemy(wave.enemies[i]);
  }

  private static void  SpawnEnemy(GameData.Enemy enemyData) {
    for (int i = 0; i < enemyData.amount; i++) {
      GameObject enemy = poolManager.EnemyPools[(int) enemyData.type].PopObject();
      enemy.transform.position = new Vector3(Random.Range(-7, 7), 6, 0);
      enemy.SetActive(true);
    }
  }

  private static void SpawnPowerUps(GameData.Wave wave) {
      for (int i = 0; i < wave.powerUps.Length; i++)
        if(wave.powerUps[i].amount != 0)
          SpawnPowerUp(wave.powerUps[i]);
  }

  private static void SpawnPowerUp(GameData.PowerUp powerUpData) {
    GameObject powerUp = poolManager.PowerUpPool.PopObject((int) powerUpData.type);
    powerUp.transform.position = new Vector3(Random.Range(-7, 7), 6, 0);
    powerUp.SetActive(true);
  }

  #endregion

}
