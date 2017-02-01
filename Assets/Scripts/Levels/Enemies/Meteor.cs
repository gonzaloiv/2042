using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]

public class Meteor : MonoBehaviour {

  #region Fields

  private Vector3 rotation;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rotation = new Vector3(0, 0, Random.Range(0, 2));
    GetComponent<Enemy>().SetScore((int) EnemyScore.Meteor);
  }

  void Update() {
    transform.Rotate(rotation * Time.timeScale);
  }

  #endregion

}