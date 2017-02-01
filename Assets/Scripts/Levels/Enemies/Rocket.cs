using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Rocket : ShooterBehaviour {

  #region Fields

  private Vector2 direction;
  private float gravity = Config.GlobalGravity.y;
  private float speed = Config.RocketSpeed;

  #endregion

  #region Mono Behaviour

  void Awake() {
    direction = Random.Range(1, 10) > 5 ? new Vector2(0, 1) : new Vector2(0, -1);
    if(direction.y == 1)
      transform.Rotate(new Vector3(0, 0, 180));
  }

  void OnEnable() {
    transform.position = new Vector2(direction.y * 8 + Random.Range(0, 2), transform.position.y);
  }

  void Update() {
    transform.Translate(new Vector2(0, 1) * speed * Time.timeScale);
    transform.Translate(new Vector2(gravity * direction.y * Time.deltaTime, 0));
  }

  #endregion

}