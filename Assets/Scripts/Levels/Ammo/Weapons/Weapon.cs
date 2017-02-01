using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Weapon : MonoBehaviour {

  #region Fields

  protected IPool shotPool;
  protected float shotSpeed = Config.BasicShotSpeed;

  #endregion

  #region Public Behaviour

  public virtual void SetShotPool(IPool shotPool) {
    this.shotPool = shotPool;
  }

  public virtual void SetShotSpeed(float shotSpeed) {
    this.shotSpeed = shotSpeed;
  }

  public virtual void Shoot() {}

  #endregion

}
