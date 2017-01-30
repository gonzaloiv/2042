using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
