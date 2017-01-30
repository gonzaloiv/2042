using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomUpWeapon : Weapon {

  #region Public Behaviour

  public override void Shoot() {
    shot = shotPool.PopObject();
    shot.transform.position = transform.position + transform.up;
    shot.transform.rotation = Quaternion.identity;
    shot.SetActive(true);
    shot.GetComponent<Rigidbody2D>().velocity = Vector2.up * shotSpeed * (Time.timeScale / 1f);
  }

  #endregion

}