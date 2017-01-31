using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Weapon : MonoBehaviour {

  #region Fields

  protected GameObjectPool shotPool;
  protected GameObject shot;

  protected float shotSpeed = Config.BasicShotSpeed;

  #endregion

  #region Mono Behaviour

  void Awake() {
    shotPool = PoolManager.GetPool<GameObjectPool>("ShotPool");
  }

  #endregion
 
  #region Public Behaviour

  public virtual void Shoot() {}

  #endregion

}
