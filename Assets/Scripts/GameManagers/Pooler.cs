using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Based on TheLiquidFire's: https://theliquidfire.wordpress.com/2015/07/06/object-pooling/
public class Pooler : Singleton<Pooler> {

  #region Fields

  private Dictionary<string, GameObjectPool> pools = new Dictionary<string, GameObjectPool>();
  private Dictionary<string, GameObjectArrayPool> arrayPools = new Dictionary<string, GameObjectArrayPool>();

  #endregion

  #region Game Object Pool Behaviour

  public static GameObjectPool CreateGameObjectPool(GameObject prefab, int initialObjectAmount, Transform parent) {
    return CreateGameObjectPool(prefab.name + "Pool", prefab, initialObjectAmount, parent);
  }

  public static GameObjectPool CreateGameObjectPool(string poolName, GameObject prefab, int initialObjectAmount, Transform parent) {
    GameObjectPool gameObjectPool = GetPoolByName(poolName);
    if(gameObjectPool != null)
      return gameObjectPool;

    gameObjectPool = new GameObjectPool(poolName, prefab, initialObjectAmount, parent);
    Instance.pools.Add(poolName, gameObjectPool);
   
    return gameObjectPool;
  }

  public static GameObjectPool GetPoolByName(string poolName) {
    if (!Instance.pools.ContainsKey(poolName))
      return null;
    return Instance.pools[poolName];
  }

  #endregion

  #region Game Object Array Pool Behaviour

  public static GameObjectArrayPool CreateGameObjectArrayPool(GameObject[] prefabs, int initialObjectAmount, Transform parent) {
    return CreateGameObjectArrayPool(prefabs[0].name + "Pool", prefabs, initialObjectAmount, parent);
  }

  public static GameObjectArrayPool CreateGameObjectArrayPool(string poolName, GameObject[] prefabs, int initialObjectAmount, Transform parent) {
    GameObjectArrayPool gameObjectArrayPool = GetArrayPoolByName(poolName);
    if(gameObjectArrayPool != null)
      return gameObjectArrayPool;

    gameObjectArrayPool = new GameObjectArrayPool(poolName, prefabs, initialObjectAmount, parent);
    Instance.arrayPools.Add(poolName, gameObjectArrayPool);

    return gameObjectArrayPool;
  }

  public static GameObjectArrayPool GetArrayPoolByName(string arrayPoolName) {
    if (!Instance.arrayPools.ContainsKey(arrayPoolName))
      return null;
    return Instance.arrayPools[arrayPoolName];
  }

  #endregion

  #region Public Object Behaviour

  public static GameObject CreatePoolGameObject(GameObject prefab, Transform parent) {
    GameObject obj = Instantiate(prefab, parent) as GameObject;
    return obj;
  }

  #endregion

}
