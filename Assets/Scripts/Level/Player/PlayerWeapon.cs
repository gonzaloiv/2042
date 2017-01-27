using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject shotPrefab;
  private GameObjectPool shotPool;
  private GameObject shot;

  private float shotSpeed = Config.BasicShotSpeed;

  #endregion

  #region Mono Behaviour

  void Awake() {
    shotPool = shotPool = Pooler.GetPool<GameObjectPool>("ShotPool");
  }

  #endregion

  #region Event Behaviour

  public void Shoot() {
    if (shotPool != null) {
      shot = shotPool.PopObject();
      shot.transform.position = transform.position + transform.up;
      shot.SetActive(true);
      shot.GetComponent<Rigidbody2D>().velocity = transform.transform.up * shotSpeed;
    }
  }

  #endregion

}
