using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UFOBehaviour : StateMachine {

  #region Mono Behaviour

  void OnEnable() {
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