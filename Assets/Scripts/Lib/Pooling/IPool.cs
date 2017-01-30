using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPool {

  GameObject PopObject(); 
  GameObject PushObject(); 
  void Prepopulate(int objectAmount); 

}
