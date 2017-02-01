using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Pooler {

  #region Fields

  [SerializeField] private GameObject shotPrefab;
  [SerializeField] private GameObject[] meteorPrefabs;
  [SerializeField] private GameObject[] ufoPrefabs;
  [SerializeField] private GameObject[] rocketPrefabs;
  [SerializeField] private GameObject[] powerUpPrefabs;

  public List<GameObjectArrayPool> EnemyPools { get { return enemyPools; } }
  public GameObjectArrayPool PowerUpPool { get { return powerUpPool; } }

  private Transform levelEnemies;
  private List<GameObjectArrayPool> enemyPools;
  private GameObjectArrayPool powerUpPool;

  #endregion

  #region Public Behaviour

  public void InitializeShotPool() {
    CreateGameObjectPool("ShotPool", shotPrefab, 30, transform);
  }

  public void InitializeEnemyPools() {
    enemyPools = new List<GameObjectArrayPool>();

    levelEnemies = new GameObject("EnemyPool").transform;
    levelEnemies.SetParent(transform);

    enemyPools.Add(CreateGameObjectPool("MeteorPool", meteorPrefabs, 15, levelEnemies));
    enemyPools.Add(CreateGameObjectPool("UFOPool", ufoPrefabs, 6, levelEnemies));
    enemyPools.Add(CreateGameObjectPool("RocketPool", rocketPrefabs, 6, levelEnemies));
  }
  
  public void InitializePowerUpPool() {
    powerUpPool = CreateGameObjectPool("PowerUpPool", powerUpPrefabs, 1, transform);
  }

  #endregion

}
