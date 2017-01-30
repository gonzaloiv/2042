using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Pooler {

  #region Fields

  [SerializeField] private GameObject[] meteorPrefabs;
  [SerializeField] private GameObject[] ufoPrefabs;
  [SerializeField] private GameObject shotPrefab;

  public List<GameObjectArrayPool> EnemyPools { get { return enemyPools; } }

  private Transform levelEnemies;
  private List<GameObjectArrayPool> enemyPools;

  #endregion

  #region Public Behaviour

  public void InitializeShotPool() {
    CreateGameObjectPool("ShotPool", shotPrefab, 30, transform);
  }

  public void InitializeEnemyPools() {
    enemyPools = new List<GameObjectArrayPool>();

    levelEnemies = new GameObject("LevelEnemies").transform;
    levelEnemies.SetParent(transform);

    enemyPools.Add(CreateGameObjectPool("MeteorPool", meteorPrefabs, 20, levelEnemies));
    enemyPools.Add(CreateGameObjectPool("UFOPool", ufoPrefabs, 10, levelEnemies));
  }

  #endregion

}
