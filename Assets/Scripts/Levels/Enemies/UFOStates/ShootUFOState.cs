using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class ShootUFOState : State {

  #region Mono Behaviour

  private Transform target;
  private Weapon weapon;

  private IEnumerator shootingCoroutine;

  #endregion

  #region Mono Behaviour

  void Awake() {
    weapon = GetComponent<Weapon>();
    shootingCoroutine = ShootingCoroutine();
  }

  void Update() {
    FocusOnTarget();
  }

  #endregion

  #region State Behaviour

  public override void Enter() {
    base.Enter();

    // TODO: corregir dependencia entre los enemigos y el jugador
    if(!target)
      target = transform.root.GetComponentInChildren<Player>().transform;

    StartCoroutine(shootingCoroutine);
  }

  public override void Exit() {
    base.Exit();

    StopCoroutine(shootingCoroutine);
  }

  #endregion

  #region Private Behaviour

  private IEnumerator ShootingCoroutine() {
    while (true) {
      weapon.Shoot();
      yield return new WaitForSeconds(.15f);
    }
  }

  private void FocusOnTarget() {
    Vector3 dir = target.position - transform.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    // The angle focus transform.up on the direction of the target
    Quaternion q = Quaternion.AngleAxis(angle + -90, Vector3.forward);
    transform.rotation = Quaternion.Slerp(transform.rotation, q, 100);
  }
 
  #endregion


}
