using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootShipState : State {

  #region Mono Behaviour

  private Weapon weapon;

  private IEnumerator shootingCoroutine;

  #endregion

  #region Mono Behaviour

  void Awake() {
    weapon = GetComponent<Weapon>();
    weapon.SetShotSpeed(Config.BasicShotSpeed * 1.4f);
  }

  #endregion

  #region State Behaviour

  public override void Enter() {
    base.Enter();

    shootingCoroutine = ShootingCoroutine();
    StartCoroutine(shootingCoroutine);
  }

  public override void Exit() {
    base.Exit();

    StopCoroutine(shootingCoroutine);
  }

  #endregion

  #region Private Behaviour

  private IEnumerator ShootingCoroutine() {
    while (gameObject.activeInHierarchy) {
      weapon.Shoot();
      yield return new WaitForSeconds(.4f);
    }
  }

  #endregion

}
