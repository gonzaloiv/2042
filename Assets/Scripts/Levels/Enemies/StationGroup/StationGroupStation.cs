using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class StationGroupStation : Station {

  #region Fields

  private StationGroup stationGroup;
  private Animator anim;
  private ParticleSystem particles;

  #endregion

  #region Mono Behaviour

  override protected void Awake() {
    base.Awake();
    stationGroup = GetComponentInParent<StationGroup>();
    anim = GetComponent<Animator>();
    particles = GetComponentInChildren<ParticleSystem>();
  }
  
  void Update() {
    if (!stationGroup.HasActiveUFOs())
      particles.Play();
    else
      particles.Stop();
  }

  override protected void OnCollisionEnter2D(Collision2D collision2D) {
    base.OnCollisionEnter2D(collision2D);
    if (!stationGroup.HasActiveUFOs()) {
      anim.Play("LoseLife");
      if (lives == 0)
        stationGroup.Disable();
    }
  }

  #endregion

}
