using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Pooler {

  #region Fields

  [SerializeField] private GameObject playerShotPrefab;
  [SerializeField] private GameObject enemyShotPrefab;

  [SerializeField] private GameObject[] meteorPrefabs;
  [SerializeField] private GameObject[] ufoPrefabs;
  [SerializeField] private GameObject[] rocketPrefabs;
  [SerializeField] private GameObject[] shipPrefabs;
  [SerializeField] private GameObject shipGroupPrefab;

  [SerializeField] private GameObject[] powerUpPrefabs;

  public List<IPool> EnemyPools { get { return enemyPools; } }
  private List<IPool> enemyPools;

  public GameObjectArrayPool PowerUpPool { get { return powerUpPool; } }
  private GameObjectArrayPool powerUpPool;

  private Transform levelEnemies;

  #endregion

  #region Public Behaviour
  
  public void InitializePlayerShotPool() {
    CreateGameObjectPool("PlayerShotPool", playerShotPrefab, 30, transform);
  }

  public void InitializeEnemyShotPool() {
    CreateGameObjectPool("EnemyShotPool", enemyShotPrefab, 30, transform);
  }

  public void InitializeEnemyPools() {
    enemyPools = new List<IPool>();

    levelEnemies = new GameObject("EnemyPool").transform;
    levelEnemies.SetParent(transform);

    enemyPools.Add(CreateGameObjectPool("MeteorPool", meteorPrefabs, 16, levelEnemies));
    enemyPools.Add(CreateGameObjectPool("UFOPool", ufoPrefabs, 4, levelEnemies));
    enemyPools.Add(CreateGameObjectPool("RocketPool", rocketPrefabs, 4, levelEnemies));
    enemyPools.Add(CreateGameObjectPool("ShipPool", shipPrefabs, 5, levelEnemies));
    enemyPools.Add(CreateGameObjectPool("ShipGroupPool", shipGroupPrefab, 1, levelEnemies));
  }

  public void InitializePowerUpPool() {
    powerUpPool = CreateGameObjectPool("PowerUpPool", powerUpPrefabs, 3, transform);
  }

  #endregion

}
