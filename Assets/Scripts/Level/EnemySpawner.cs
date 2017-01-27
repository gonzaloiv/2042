using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject[] meteorPrefabs;
  private GameObjectArrayPool meteorPool;

  [SerializeField] private GameObject[] ufoPrefabs;
  private GameObjectArrayPool ufoPool;

  [SerializeField] private GameObject shotPrefab;
  private GameObjectPool shotPool;

  private Transform levelEnemies;


  #endregion

  #region Mono Behaviour

  void Awake() {
    levelEnemies = new GameObject("LevelEnemies").transform;
    levelEnemies.SetParent(transform);
 
    meteorPool = Pooler.CreateGameObjectPool("MeteorPool", meteorPrefabs, 20, levelEnemies);
    ufoPool = Pooler.CreateGameObjectPool("UFOPool", ufoPrefabs, 10, levelEnemies);
  }

  void Start() {
    StartCoroutine(SpawnEnemyWave());
  }

  #endregion

  #region Private Behaviour

  private IEnumerator SpawnEnemyWave() {
    GameObject enemy;
    while (true) {
      for (int i = 0; i < 3; i++) {
        enemy = meteorPool.PopObject();
        enemy.transform.position = new Vector3(Random.Range(-7, 7), 6, 0);
        enemy.SetActive(true);
      }
      for (int i = 0; i < 1; i++) {
        enemy = ufoPool.PopObject();
        enemy.transform.position = new Vector3(Random.Range(-7, 7), 6, 0);
        enemy.SetActive(true);
      }
      yield return new WaitForSeconds(.9f);
    }
  }

  #endregion
}
