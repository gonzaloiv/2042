using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Enemy))]
public class UFO : StateMachine {

  #region Mono Behaviour

  void Awake() {
    GetComponent<Enemy>().SetScore((int) EnemyScore.UFO);
  }

  void OnEnable() {
    ChangeState<IdleState>();
    StartCoroutine(UFOBehaviourRoutine());
  }

  #endregion

  #region Private Behaviour

  private IEnumerator UFOBehaviourRoutine() {
    while (gameObject.activeInHierarchy) {
      ChangeState<IdleState>();
      yield return new WaitForSeconds(Random.Range(.7f, 1.6f));
      ChangeState<ShootState>();
      yield return new WaitForSeconds(Random.Range(.3f, .4f));
    }
  }

  #endregion

 
}