using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StationGroup : MonoBehaviour {

  #region Fields

  private Station station;
  private List<UFO> ufos;

  #endregion

  #region Mono Behaviour

  void Awake() {
    station = GetComponentInChildren<Station>();
    ufos = GetComponentsInChildren<UFO>().ToList();
  }

  void OnEnable() {
    SetChildrenActive(true);
    StartCoroutine(MovementRoutine());
  }

  void OnDisable() {
    StopAllCoroutines();
  }

  public IEnumerator MovementRoutine() {
    yield return new WaitForSeconds(1.8f);
    StopFalling();
  }

  public IEnumerator RespawnChildrenRoutine() {
    yield return new WaitForSeconds(8f);
    foreach (UFO ufo in ufos) {
      if (!ufo.gameObject.activeInHierarchy) {
        ufo.gameObject.SetActive(true);
        yield return new WaitForSeconds(.1f);
      }
    }
  }

  #endregion

  #region Public Behaviour

  public void Disable() {
    gameObject.SetActive(false);
    SetChildrenActive(false);
  }

  public bool HasActiveUFOs() {
    return ufos.Where(x => x.gameObject.activeInHierarchy).ToList().Count() > 0;
  }

  #endregion

  #region Private Behaviour

  private void SetChildrenActive(bool active) {
    station.gameObject.SetActive(active);
    ufos.Where(x => !x.gameObject.activeInHierarchy).ToList().ForEach(x => x.gameObject.SetActive(active));
  }

  private void StopFalling() {
    station.GetComponent<Rigidbody2D>().gravityScale = 0;
    station.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    station.GetComponent<Rigidbody2D>().isKinematic = true;
    ufos.ForEach(x => { x.GetComponent<Rigidbody2D>().gravityScale = 0; x.GetComponent<Rigidbody2D>().velocity = Vector2.zero; } );
  }

  #endregion

}
