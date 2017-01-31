using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]

public class Opening : MonoBehaviour {

  #region Mono Behaviour

  void Update() {
    if (Input.GetKey(KeyCode.Space))
      GetComponent<Animator>().Play("FadeOut");
  }

  #endregion

  #region Mono Behaviour

  private void LoadGameScene() {
    SceneManager.LoadScene("Game");
  }

  #endregion

}
