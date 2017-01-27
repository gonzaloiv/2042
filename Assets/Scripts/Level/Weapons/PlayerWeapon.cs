using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject shotPrefab;
  private GameObjectPool shotPool;
  private GameObject shot;

  #endregion

  #region Mono Behaviour

  void Awake() {
    shotPool = Pooler.CreateGameObjectPool(shotPrefab, 10, transform.parent);
  }

  #endregion

  #region Event Behaviour

  public void Shoot() {
    shot = shotPool.PopObject();
    shot.transform.position = transform.position + new Vector3(0, transform.localScale.y / 2, 0);
    shot.SetActive(true);
  }

  #endregion

}
