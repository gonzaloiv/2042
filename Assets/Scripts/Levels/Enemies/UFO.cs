using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(IdleUFOState))]
[RequireComponent(typeof(ShootUFOState))]

public class UFO : StateMachine {

  #region Mono Behaviour

  void Awake() {
    GetComponent<Enemy>().SetScore((int) EnemyScore.UFO);
    GetComponent<Weapon>().SetShotPool(PoolManager.GetPool<GameObjectPool>("EnemyShotPool"));
  }

  void OnEnable() {
    ChangeState<IdleUFOState>();
    StartCoroutine(UFOBehaviourRoutine());
  }

  #endregion

  #region Private Behaviour

  private IEnumerator UFOBehaviourRoutine() {
    while (gameObject.activeInHierarchy) {
      ChangeState<IdleUFOState>();
      yield return new WaitForSeconds(Random.Range(.7f, 1.6f));
      ChangeState<ShootUFOState>();
      yield return new WaitForSeconds(Random.Range(.3f, .4f));
    }
  }

  #endregion
 
}