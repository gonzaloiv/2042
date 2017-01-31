using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EventManager))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(TimeManager))]

public class Game : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject backgroundPrefab;
  [SerializeField] private GameObject levelPrefab;

  #endregion

  #region Mono Behaviour

  void Awake() {
    Physics2D.gravity = Config.GlobalGravity;
    Application.targetFrameRate = 60;

    Instantiate(backgroundPrefab, transform);
    Instantiate(levelPrefab, transform);
  }

  #endregion

}
