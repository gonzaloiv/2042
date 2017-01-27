using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UFOWeapon))]
[RequireComponent(typeof(Animator))]
public class UFO : ShooterBehaviour {

  #region Mono Behaviour

  [SerializeField] private Transform player;
  private UFOWeapon weapon;
  private Animator anim;

  #endregion

  #region Mono Behaviour

  void Awake() {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    weapon = GetComponent<UFOWeapon>();
    anim = GetComponent<Animator>();
  }

  void OnEnable() {
    StartCoroutine(ShootingCoroutine());
  }

  void Update() {
    FocusOnPlayer();
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.name.Contains("Player"))
       Disable();
  }

  #endregion

  #region Private Behaviour

  private void FocusOnPlayer() {
    Vector3 dir = player.position - transform.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
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