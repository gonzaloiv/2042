using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BaseEnemy : MonoBehaviour {
  
  #region Mono Behaviour

  void OnTriggerEnter2D(Collider2D collider2D) {
    if(collider2D.gameObject.name == "LevelYConstraint") 
      Disable();
  }

  #endregion

  #region Private Behaviour

  private void Disable() {
    gameObject.SetActive(false);
  }

  #endregion

}
