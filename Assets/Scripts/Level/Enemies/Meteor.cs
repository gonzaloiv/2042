using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Meteor : Enemy {

  #region Fields

  protected Vector3 rotation;

  #endregion

  #region Mono Behaviour

  protected override void Awake() {
    base.Awake();

    rotation = new Vector3(0, 0, Random.Range(0, 2));
    score = (int) EnemyScore.Meteor;
  }

  void Update() {
    transform.Rotate(rotation);
  }

  #endregion

}