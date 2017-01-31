using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotWeapon : Weapon {

  #region Public Behaviour

  // GuidedWeapon shoots in transform.up direction
  public override void Shoot() {
    if (shotPool != null) {
      for (float i = 0; i < .5f; i = i + .4f) {
        shot = shotPool.PopObject();
        shot.transform.position = transform.position + new Vector3(-.2f + i, 0, 0) + transform.up;
        shot.transform.rotation = transform.rotation;
        shot.SetActive(true);
        shot.GetComponent<Rigidbody2D>().velocity = shot.transform.up * shotSpeed * (Time.timeScale / 1f);
      }
    }
  }

  #endregion

}
