using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(Animator))]

public class Station : MonoBehaviour {

  #region Fields

  private Weapon weapon;
  protected int lives;

  #endregion

  #region Mono Behaviour

  protected virtual void Awake() {
    GetComponent<Enemy>().SetScore((int) EnemyScore.Station);
    weapon = GetComponent<Weapon>();
    weapon.SetShotPool(PoolManager.GetPool<GameObjectPool>("StationShotPool"));
  }

  void OnEnable() {
    lives = Config.InitialRocketGroupLives;
    StartCoroutine(ShootingRoutine());
  }

  void OnDisable() {
    StopAllCoroutines();
  }

  protected virtual void OnCollisionEnter2D(Collision2D collision2D) {
    lives--;
    if (lives == 0)
      gameObject.SetActive(false);
  }

  #endregion

  #region Private behaviour

  private IEnumerator ShootingRoutine() {
    yield return new WaitForSeconds(1);
    while (gameObject.activeInHierarchy) {
      weapon.Shoot();
      yield return new WaitForSeconds(1);
    }
  }

  #endregion

}
