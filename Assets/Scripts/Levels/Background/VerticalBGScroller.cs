using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Based on valryons's Gist: https://gist.github.com/valryon/7547513
public class VerticalBGScroller : MonoBehaviour {

  #region Mono Behaviour

  private Vector2 scrollingVelocity = Vector2.down * Config.BackgroundScrollingSpeed;
  private List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>(); // Works with n sprites of the same size
  private float spritesYSize;

  #endregion

  #region Mono Behaviour

  void Awake() {
    spriteRenderers = GetComponentsInChildren<SpriteRenderer>().ToList();
    spriteRenderers = spriteRenderers.OrderBy(sr => sr.transform.position.y).ToList();
    spritesYSize = spriteRenderers[1].transform.position.y - spriteRenderers[0].transform.position.y;
  }

  void OnEnable() {
    StartCoroutine(ScrollingRoutine());
  }

  void OnDisable() {
    StopCoroutine(ScrollingRoutine());
  }

  #endregion

  private IEnumerator ScrollingRoutine() {
    while (gameObject.activeInHierarchy) {
      transform.Translate(scrollingVelocity * Time.deltaTime);
      SpriteRenderer firstChild = spriteRenderers[0];
      if (firstChild.transform.position.y < -spritesYSize) {
        firstChild.transform.position = (Vector2) spriteRenderers.Last().transform.position + new Vector2(0, spritesYSize);
        spriteRenderers.Remove(firstChild); 
        spriteRenderers.Add(firstChild); // Reloads last element
      }
      yield return null;
    }
  }

}
