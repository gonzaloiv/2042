using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationGroupUFO : StateMachine {

  #region Fields

  private StationGroup stationGroup;

  #endregion

  #region Mono Behaviour

  void Awake() {
    stationGroup = GetComponentInParent<StationGroup>();
  }

  void OnEnable() {
    StartCoroutine(UFOBehaviourRoutine());
  }

  #endregion

  #region Mono Behaviour 

  void OnCollisionEnter2D(Collision2D collision2D) {
    stationGroup.StartCoroutine(stationGroup.RespawnChildrenRoutine());
  }

  #endregion

  #region Private Behaviour

  private IEnumerator UFOBehaviourRoutine() {
    while (gameObject.activeInHierarchy) {
      ChangeState<IdleUFOState>();
      yield return new WaitForSeconds(Random.Range(1f, 2f));
      ChangeState<ShootUFOState>();
      yield return new WaitForSeconds(Random.Range(.2f, .3f));
    }
  }

  #endregion
 
	
}
