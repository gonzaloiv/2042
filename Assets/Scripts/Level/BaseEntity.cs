using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BaseEntity : MonoBehaviour {
  
  #region Mono Behaviour

  void OnTriggerEnter2D(Collider2D collider2D) {
    string collider2DName = collider2D.gameObject.name;
    if(collider2DName == "LevelYMinConstraint" || collider2DName == "LevelYMaxConstraint") 
      Disable();
  }

  #endregion

  #region Public Behaviour

  public void Disable() {
    gameObject.SetActive(false);
  }

  #endregion

}
