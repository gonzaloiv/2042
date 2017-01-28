using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class Meteor : Enemy {

  #region Fields

  protected Vector3 rotation;

  #endregion

  #region Mono Behaviour

  protected override void Awake() {
    base.Awake();

    rotation = new Vector3(0, 0, Random.Range(0, 2));
  }

  void Update() {
    transform.Rotate(rotation);
  }

  #endregion

}