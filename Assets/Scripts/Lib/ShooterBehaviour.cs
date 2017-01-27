using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class ShooterBehaviour : MonoBehaviour {
  
  #region Mono Behaviour

  void OnTriggerEnter2D(Collider2D collider2D) {
    if(collider2D.gameObject.name.Contains("LevelConstraint")) 
      Disable();
  }

  #endregion

  #region Protected Behaviour

  protected void Disable() {
    gameObject.SetActive(false);
  }

  #endregion

}
