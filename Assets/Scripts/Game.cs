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
  [SerializeField] private Texture2D cursorSprite;

  #endregion

  #region Mono Behaviour

  void Awake() {
    Physics2D.gravity = Config.GlobalGravity;
    Application.targetFrameRate = 60;
    Cursor.SetCursor(cursorSprite, Vector2.zero, CursorMode.ForceSoftware);

    Instantiate(backgroundPrefab, transform);
    Instantiate(levelPrefab, transform);
  }

  #endregion

}
