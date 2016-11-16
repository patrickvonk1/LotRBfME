using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour {

    [SerializeField]
    private Terrain terrain;

    [SerializeField]
    private Camera camera;
    private GameObject selectedGameObject;

	void Awake () 
    {
	
	}
	
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit))
            {
                if (rayHit.transform.tag == "Unit")
                {
                    selectedGameObject = rayHit.transform.gameObject;
                }
                else
                {
                    selectedGameObject = null;
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (selectedGameObject)
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit rayHit;
                if (Physics.Raycast(ray, out rayHit))
                {
                    if (terrain.SampleHeight(rayHit.point) < 3)
                    {
                        selectedGameObject.GetComponent<NavMeshAgent>().SetDestination(rayHit.point);
                    }
                }
            }
        }
	}
}
