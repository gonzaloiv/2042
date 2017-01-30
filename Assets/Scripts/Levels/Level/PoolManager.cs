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
  private GameObjectPool shotPool;

  #endregion

  public void InitializePools() {
    enemyPools = new List<GameObjectArrayPool>();

    levelEnemies = new GameObject("LevelEnemies").transform;
    levelEnemies.SetParent(transform);

    CreateGameObjectPool("ShotPool", shotPrefab, 30, transform);

    enemyPools.Add(CreateGameObjectPool("MeteorPool", meteorPrefabs, 20, levelEnemies));
    enemyPools.Add(CreateGameObjectPool("UFOPool", ufoPrefabs, 10, levelEnemies));
  }

}
