using UnityEngine;
using System.Collections;

public interface Unit {

    UnitStats UnitStats { get; set; }

    GameObject GameObjectToInteractWith { get; set; }
}
