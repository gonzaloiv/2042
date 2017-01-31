using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

  #region Fields

  [SerializeField] private Text livesLabel;
  [SerializeField] private Text scoreLabel;

  private string initialLivesLabelText = "LIVES ";
  private string initialScoreLabelText = "SCORE ";

  #endregion

  #region Mono Behaviour

  void Awake() {
    livesLabel.text = initialLivesLabelText + Config.InitialLivesAmount;
    scoreLabel.text = initialScoreLabelText + Config.InitialScore;
  }

  void OnEnable() {
    EventManager.StartListening<LivesUIEvent>(OnLivesUIEvent);
    EventManager.StartListening<ScoreUIEvent>(OnScoreUIEvent);
  }

  void OnDisable() {
    EventManager.StopListening<LivesUIEvent>(OnLivesUIEvent);
    EventManager.StopListening<ScoreUIEvent>(OnScoreUIEvent);
  }

  #endregion

  #region Event Behaviour

  void OnLivesUIEvent(LivesUIEvent livesUIEvent) {
    livesLabel.text = initialLivesLabelText + livesUIEvent.lives;
  }

  void OnScoreUIEvent(ScoreUIEvent scoreUIEvent) {
    scoreLabel.text = initialScoreLabelText + scoreUIEvent.score;
  }

  #endregion

}
