 using UnityEngine;
 using System.Collections;

public class CameraRotate : MonoBehaviour 
{
 
	public float turnSpeed = 4.0f;

    public Transform player;	 

	public float height = 1f;

	public float distance = 2f;
	 
	private Vector3 offsetX;

	private Vector3 offsetY;

	private Vector3 offsetZ;

	private Vector3 FPSoffset;

	private float coto;

	private float x;

	private float y;

	private Vector3 rotateValue;

	public float up_down;

	private bool FPS;

	public float fYRot;
	 
	void Start () {
	     
		offsetX = new Vector3 (0, height, distance);
	    
		offsetY = new Vector3 (0, 0, 0);

		offsetZ = new Vector3 (0, 2, 0);

		FPSoffset = new Vector3 (0.6f, 2.3f, -1.3f);

	 }
		      
	void Update()
	{
		FPS = GameObject.Find("MonsterHeroBASE").GetComponent<PlayerController>().FPS;

		if (FPS) {

			offsetX = Quaternion.AngleAxis (Input.GetAxis ("Mouse X") * turnSpeed, Vector3.up) * offsetX;

			y = Input.GetAxis("Mouse X");

			x = Input.GetAxis("Mouse Y");

			rotateValue = new Vector3(x, y * -1, 0);

			transform.eulerAngles = transform.eulerAngles - rotateValue;

			//transform.position = player.position;// + offsetX;//+ FPSoffset;

			up_down = Input.GetAxis ("Mouse Y")*0.1f;

			offsetY.y += up_down;

			offsetY.y = Mathf.Clamp (offsetY.y, -1.0f, -1.5f);

			transform.position = player.position + offsetZ;// + offsetY;

			//transform.LookAt (player.position + offsetZ);

		} 
		else {

			offsetX = Quaternion.AngleAxis (Input.GetAxis ("Mouse X") * turnSpeed, Vector3.up) * offsetX;

			up_down = Input.GetAxis ("Mouse Y")*0.1f;

			offsetY.y += up_down;

			offsetY.y = -1.0f;//Mathf.Clamp (offsetY.y, -1.0f, -1.5f);

			transform.position = player.position  + offsetX + offsetY;

			transform.LookAt (player.position + offsetZ);

			//Debug.Log ("Coto = " + offsetY);
		}

		fYRot = Camera.main.transform.eulerAngles.y;
	 }	
}
 
 /*public class CamRotation : MonoBehaviour 
 {
     private float x;
     private float y;
     private Vector3 rotateValue;
 
     void Update()
     {
         y = Input.GetAxis("Mouse X");
         x = Input.GetAxis("Mouse Y");
         Debug.Log(x + ":" + y);
         rotateValue = new Vector3(x, y * -1, 0);
         transform.eulerAngles = transform.eulerAngles - rotateValue;
     }
 }*/