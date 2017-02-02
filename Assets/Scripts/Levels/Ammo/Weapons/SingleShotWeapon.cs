using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotWeapon : Weapon {

  #region Public Behaviour

  public override void Shoot() {
    if (shotPool != null) {
      shot = shotPool.PopObject();
      shot.transform.position = transform.position + transform.up;
      shot.transform.rotation = transform.rotation;
      shot.SetActive(true);
      shot.GetComponent<Rigidbody2D>().velocity = shot.transform.up * shotSpeed * (Time.timeScale / 1f);
    }
  }

  #endregion

}
