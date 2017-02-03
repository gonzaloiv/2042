﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimator : StateMachine {

  #region Fields

  private IEnumerator shipBehaviourRoutine;

  #endregion

  #region Mono Behaviour

  void OnEnable() {
    shipBehaviourRoutine = ShipBehaviourRoutine();
    StartCoroutine(shipBehaviourRoutine);
    ChangeState<IdleShipState>();
  }

  void OnDisable() {
    StopCoroutine(shipBehaviourRoutine);
  }

  #endregion

  #region Private Behaviour

  private IEnumerator ShipBehaviourRoutine() {
    while (gameObject.activeInHierarchy) {
      ChangeState<IdleShipState>();
      yield return new WaitForSeconds(Random.Range(.6f, .8f));
      ChangeState<ShootShipState>();
      yield return new WaitForSeconds(Random.Range(.6f, .8f));
    }
  }

  #endregion
	
}