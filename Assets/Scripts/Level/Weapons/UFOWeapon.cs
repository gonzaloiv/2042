using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOWeapon : MonoBehaviour {

  #region Fields

  private GameObjectPool shotPool;
  private GameObject shot;

  #endregion

  #region Mono Behaviour

  void Awake() {
    shotPool = Pooler.GetPoolByName("ShotPool");
  }

  #endregion

  #region Event Behaviour

  public void Shoot() {
    shot = shotPool.PopObject();
    shot.transform.position = transform.position + transform.right;
    shot.transform.rotation = transform.rotation;
    shot.transform.Rotate(0, 0, 90);
    shot.SetActive(true);
  }

  #endregion

}
