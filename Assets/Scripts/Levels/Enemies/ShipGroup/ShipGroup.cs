using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShipGroup : MonoBehaviour {

  #region Fields

  private Transform target;
  private List<Ship> ships;
  private IEnumerator shipGroupBehaviourRoutine;

  #endregion

  #region Mono Behaviour

  void Awake() {
    ships = GetComponentsInChildren<Ship>().ToList();
  }

  void OnEnable() {
    InitializeChildren();
    shipGroupBehaviourRoutine = ShipGroupBehaviourRoutine();
    StartCoroutine(shipGroupBehaviourRoutine);
  }

  void OnDisable() {
    StopCoroutine(shipGroupBehaviourRoutine);
  }

  #endregion

  #region Private Behaviour

  private void InitializeChildren() {
    for (int i = 0; i < ships.Count; i++) {
      ships[i].transform.position = new Vector2(i * 1.5f - 3, 6);  
      ships[i].gameObject.SetActive(true);
    }
  }

  private IEnumerator ShipGroupBehaviourRoutine() {
    yield return new WaitForSeconds(.8f);
    while (HasActiveChildren()) {
      ships.Where(x => x.gameObject.activeInHierarchy).ToList().ForEach(x => x.ChangeState<MoveShipState>());
      yield return new WaitForSeconds(.2f);
      ships.Where(x => x.gameObject.activeInHierarchy).ToList().ForEach(x => x.ChangeState<ShootShipState>());
      yield return new WaitForSeconds(.4f);
      ships.Where(x => x.gameObject.activeInHierarchy).ToList().ForEach(x => x.ChangeState<IdleShipState>());
    }
    gameObject.SetActive(false);
  }

  private bool HasActiveChildren() {
    return ships.Where(x => x.gameObject.activeInHierarchy).Count() != 0;
  }

  #endregion

}
