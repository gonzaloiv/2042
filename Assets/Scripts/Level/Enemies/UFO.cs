using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(CircleCollider2D))]
public class UFO : Enemy {

  #region Mono Behaviour

  private Transform target;
  private Weapon weapon;

  #endregion

  #region Mono Behaviour

  protected override void Awake() {
    base.Awake();

    weapon = GetComponent<Weapon>();
    target = GameObject.FindGameObjectWithTag("Player").transform;

    score = (int) EnemyScore.UFO;
  }

  void OnEnable() {
    StartCoroutine(ShootingCoroutine());
  }

  void Update() {
    FocusOnPlayer();
  }

  #endregion

  #region Private Behaviour

  private void FocusOnPlayer() {
    Vector3 dir = target.position - transform.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    // The angle focus transform.up on the direction of the target
    Quaternion q = Quaternion.AngleAxis(angle + -90, Vector3.forward);
    transform.rotation = Quaternion.Slerp(transform.rotation, q, 100);
  }

  private IEnumerator ShootingCoroutine() {
    while (true) {
      weapon.Shoot();
      yield return new WaitForSeconds(.6f);
    }
  }
 
  #endregion

}