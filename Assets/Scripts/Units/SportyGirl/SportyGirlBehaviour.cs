using UnityEngine;
using System.Collections;

public class SportyGirlBehaviour : MonoBehaviour, Unit {

    private UnitStats unityStats;
    private GameObject gameObjectToInteractWith;

	void Awake () 
    {
        UnitStats = GetComponent<UnitStats>();
	}
	
	void Update () 
    {
	    
	}

    public UnitStats UnitStats
    {
        get
        {
            return unityStats;
        }
        set
        {
            unityStats = value;
        }
    }
    public GameObject GameObjectToInteractWith
    {
        get
        {
            return gameObjectToInteractWith;
        }
        set
        {
            gameObjectToInteractWith = value;
        }
    }
}
