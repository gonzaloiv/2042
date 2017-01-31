﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedWeapon : Weapon {

  #region Public Behaviour

  // GuidedWeapon shoots in transform.up direction
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
