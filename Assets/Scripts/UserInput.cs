using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour {

    [SerializeField]
    private Terrain terrain;

    [SerializeField]
    private Camera camera;
    private GameObject selectedGameObject;

    //The speed the camera moves across the y axis
    public float cameraYPosSpeed = 4;

    //The max position the cameraGameobject can have across the y axis
    private float cameraMaxY = 100;

    //The min position the cameraGameobject can have across the y axis
    private float cameraMinY = 3;

    //The size of the rects for moving the camera with your mouse
    public float boundrySize = 10;
    //The speed of the camera when move from left to right and up to down
    public float cameraMoveSpeed = 4;
    private Rect topBorder;
    private Rect bottomBorder;
    private Rect leftBorder;
    private Rect rightBorder;

	void Awake () 
    {
        topBorder = new Rect(0, Screen.height - boundrySize, Screen.width, boundrySize);
        bottomBorder = new Rect(0, 0, Screen.width, boundrySize);
        leftBorder = new Rect(0, 0, 0 + boundrySize, Screen.height);
        rightBorder = new Rect(Screen.width - boundrySize, 0, 0 + boundrySize, Screen.height);

        if (transform.position.y < 3)
        {
            transform.position = new Vector3(transform.position.x, 3, transform.position.z);
        }
        else if (transform.position.y > 100)
        {
            transform.position = new Vector3(transform.position.x, 100, transform.position.z);
        }

	}
	
	void Update ()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)// scroll Up
        {
            if (transform.position.y >= 3 + cameraYPosSpeed)
            {
                transform.Translate(new Vector3(0, 0, cameraYPosSpeed));
            }
            else
            {
                transform.position = new Vector3(transform.position.x, 3, transform.position.z);
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)// scroll Down
        {
            if (transform.position.y <= 100 - cameraYPosSpeed)
            {
                transform.Translate(new Vector3(0, 0, -cameraYPosSpeed));
            }
            else
            {
                transform.position = new Vector3(transform.position.x, 100, transform.position.z);
            }
        }

        Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
        if (screenRect.Contains(Input.mousePosition))
        {
            if (topBorder.Contains(Input.mousePosition))
            {
                gameObject.transform.Translate(new Vector3(0, cameraMoveSpeed * Time.deltaTime, 0));
            }
            if (bottomBorder.Contains(Input.mousePosition))
            {
                gameObject.transform.Translate(new Vector3(0, -cameraMoveSpeed * Time.deltaTime, 0));
            }
            if (leftBorder.Contains(Input.mousePosition))
            {
                gameObject.transform.Translate(new Vector3(-cameraMoveSpeed * Time.deltaTime, 0, 0));
            }
            if (rightBorder.Contains(Input.mousePosition))
            {
                gameObject.transform.Translate(new Vector3(cameraMoveSpeed * Time.deltaTime, 0, 0));
            }

            //markd is just for testing you can remove the markd variable in the FpsCounter Class
            FpsCounter.markd = "Inside Screen";
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, LayerMask.NameToLayer("Unit")))
            {
                    selectedGameObject = rayHit.transform.gameObject;
            }
            else
            {
                selectedGameObject = null;
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
                        selectedGameObject.GetComponent<Actions>().Walk();
                        var lookPos = rayHit.point - selectedGameObject.transform.position;
                        lookPos.y = 0;
                        var rotation = Quaternion.LookRotation(lookPos);
                        selectedGameObject.transform.rotation = Quaternion.RotateTowards(selectedGameObject.transform.rotation, rotation, 360);
                    }
                }
            }
        }
	}
}
