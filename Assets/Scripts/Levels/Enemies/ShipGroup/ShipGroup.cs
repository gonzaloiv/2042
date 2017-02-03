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
    shipGroupBehaviourRoutine = ShipGroupBehaviourRoutine();
    StartCoroutine(shipGroupBehaviourRoutine);
  }

  void OnDisable() {
    StopCoroutine(shipGroupBehaviourRoutine);
  }

  #endregion

  #region Private Behaviour

  private IEnumerator ShipGroupBehaviourRoutine() {
    yield return new WaitForSeconds(.8f);
    while (HasActiveChildren()) {
      foreach (Ship ship in ships)
        if (ship.gameObject.activeInHierarchy)
          ship.ChangeState<MoveShipState>();
      yield return new WaitForSeconds(.2f);
      foreach (Ship ship in ships)
        if (ship.gameObject.activeInHierarchy)
          ship.ChangeState<ShootShipState>();
      yield return new WaitForSeconds(.4f);
      foreach (Ship ship in ships)
        if (ship.gameObject.activeInHierarchy)
          ship.ChangeState<IdleShipState>();
    }
    gameObject.SetActive(false);
  }

  private bool HasActiveChildren() {
    return ships.Where(x => x.gameObject.activeInHierarchy).Count() != 0;
  }

  #endregion

}
