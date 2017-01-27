using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOWeapon : MonoBehaviour {

  #region Fields

  private GameObjectPool shotPool;
  private GameObject shot;

  private float shotSpeed = Config.BasicShotSpeed;

  #endregion

  #region Mono Behaviour

  void Awake() {
    shotPool = Pooler.GetPool<GameObjectPool>("ShotPool");
  }

  #endregion

  #region Event Behaviour

  public void Shoot() {
    // Fixes a problem with pool initialization (game launches Shoot before Awake...)
    // TODO: Fix this forcing the order in Game.
    if (shotPool != null) {
      shot = shotPool.PopObject();
      shot.transform.position = transform.position + transform.right;
      shot.transform.rotation = transform.rotation;
      shot.transform.Rotate(0, 0, 90);
      shot.SetActive(true);
      shot.GetComponent<Rigidbody2D>().velocity = -shot.transform.up * shotSpeed;
    }
  }

  #endregion

}


