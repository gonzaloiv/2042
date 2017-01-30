using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : State {

  #region Mono Behaviour

  private Transform target;
  private Weapon weapon;

  #endregion

  #region Mono Behaviour

  void Awake() {
    weapon = GetComponent<Weapon>();
  }

  void Update() {
    FocusOnPlayer();
  }

  #endregion

  #region State Behaviour

  public override void Enter() {
    base.Enter();

    // TODO: corregir dependencia entre los enemigos y el jugador
    if(!target)
      target = transform.root.GetComponentInChildren<Player>().transform;
    
    StartCoroutine(ShootingCoroutine());
  }

  public override void Exit() {
    base.Exit();

    StopCoroutine(ShootingCoroutine());
  }

  #endregion

  #region Private Behaviour

  private IEnumerator ShootingCoroutine() {
    while (true) {
      weapon.Shoot();
      yield return new WaitForSeconds(.5f);
    }
  }

  private void FocusOnPlayer() {
    Vector3 dir = target.position - transform.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    // The angle focus transform.up on the direction of the target
    Quaternion q = Quaternion.AngleAxis(angle + -90, Vector3.forward);
    transform.rotation = Quaternion.Slerp(transform.rotation, q, 100);
  }
 
  #endregion


}
