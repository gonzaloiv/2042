using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Enemy))]
public class UFO : StateMachine {

  #region Mono Behaviour

  void Awake() {
    GetComponent<Enemy>().Score = (int) EnemyScore.UFO;
  }

  void OnEnable() {
    ChangeState<ShootingState>();
    StartCoroutine(UFOBehaviourRoutine());
  }

  #endregion

  #region Private behaviour

  private IEnumerator UFOBehaviourRoutine() {
    while (gameObject.activeInHierarchy) {
      if (CurrentState is IdleState) {
        ChangeState<ShootingState>();
      } else {
        ChangeState<IdleState>();
      }
      yield return new WaitForSeconds(2);
    }
  }

  #endregion

 
}