using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	static Animator anim;

	//Rigidbody m_Character;

	public float speed = 0;

	public float slow_speed = 20.0f;

	public float fast_speed = 20.0f;

	public float rotationSpeed = 75.0f;

	public bool FPS = false;

	float fYRot;

	private bool is_button = false;

	public float face_vector ;

	void Start(){
	
		anim = GetComponent<Animator> ();

		//m_Character = GetComponent<Rigidbody> ();
	
	}

	void LateUpdate () {

		float translation = 0; //= Input.GetAxis ("Vertical") * speed;

		float rotation = Input.GetAxis ("Mouse X") * rotationSpeed;

		//fYRot = GameObject.Find("Camera").GetComponent<CameraRotate>().fYRot;

		//Debug.Log ("Coto = " + fYRot);

		if (Input.GetKey ("w") || Input.GetKey ("s") || Input.GetKey ("a") || Input.GetKey ("d") ) {

			translation = Time.deltaTime* speed;

			//transform.Translate(Vector3.forward*speed*Time.deltaTime);

			//transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;

			//face_vector = Camera.main.transform.forward;//new Vector3 (0, 0, 0);

			//transform.forward = Camera.main.transform.forward;//face_vector;

			//Camera.main.transform.forward.y
		}

		if (Input.GetKey ("left shift") && !is_button) {

			anim.SetFloat ("SpeedRun", 1.2f);

			speed = fast_speed;

		} else {

			anim.SetFloat ("SpeedRun", 1.0f);

			speed = slow_speed;

		}

		if (Input.GetKey ("w") && !is_button )  {

			//transform.Translate (0, 0, translation);

			if (Input.GetKey ("w") && Input.GetKey ("s")) {

				translation = 0;

			} else {

				transform.Translate (Vector3.forward * speed * Time.deltaTime);

				transform.forward = Camera.main.transform.forward;

				is_button = true;

			}

		}

		if (Input.GetKey ("s")  && !is_button ) {


			if (Input.GetKey ("w") && Input.GetKey ("s")) {

				translation = 0;

			} else {

				//translation *= 0.3f;

				//transform.Translate (0, 0, -translation);

				transform.Translate (Vector3.forward * speed * Time.deltaTime);

				transform.forward = -Camera.main.transform.forward;

				is_button = true;

			}



			//m_Character.velocity = -transform.forward * speed;

		}

		if (Input.GetKey ("d")  && !is_button ) {

			if (Input.GetKey ("a") && Input.GetKey ("d")) {

				translation = 0;

			} else {

				//transform.Translate (translation, 0, 0);

				transform.Translate (Vector3.forward * speed * Time.deltaTime);

				transform.forward = Camera.main.transform.right;

				is_button = true;

			}

		}

		if (Input.GetKey ("a")  && !is_button ) {

			if (Input.GetKey ("a") && Input.GetKey ("d")) {

				translation = 0;

			} else {

				//transform.Translate (-translation, 0, 0);

				transform.Translate (Vector3.forward * speed * Time.deltaTime);

				transform.forward = -Camera.main.transform.right;//face_vector;

				is_button = true;

			}

		}

		is_button = false;

		rotation *= Time.deltaTime;

		if (translation != 0) {
		
			anim.SetBool ("IsRunning", true);
		
		} else {
		
			anim.SetBool ("IsRunning", false);
		
		}

		if (Input.GetKeyDown ("space")) {

			//transform.Translate (Vector3.up * 200 * speed * Time.deltaTime);

			if (anim.GetBool ("DrawWeapon")) {
				
				anim.SetBool ("DrawWeapon", false);
			
			} else {

				anim.SetBool ("DrawWeapon", true);

				anim.SetBool ("IsRunning", false);

				translation = 0;

			}

		}
			
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("DRAW_WEAPON") || anim.GetCurrentAnimatorStateInfo (0).IsName ("HIDE_WEAPON")) {

			translation = 0;

		} 

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("FPS_IDLE")) {

			FPS = true;

		} else {

			FPS = false;

			//transform.forward = Camera.main.transform.forward;

		}

		if (FPS) {

			transform.forward = Camera.main.transform.forward;

		}




		//transform.Rotate (0, rotation, 0);




			
		/*Vector3 pos = transform.position;

		if (FPS) {
			this.GetComponent<Animator>().Play("FPS_IDLE");
		} 
		else {
			this.GetComponent<Animator>().Play("DRAW_WEAPON");
		}




		if (Input.GetKey ("w")) {
			pos.z += speed * Time.deltaTime;
			if (!FPS) {
				this.GetComponent<Animator> ().Play ("RUN");
			}
		}
		if (Input.GetKey ("s")) {
			pos.z -= speed * Time.deltaTime;
			if (!FPS) {
				this.GetComponent<Animator> ().Play ("RUN");
			}
		}
		if (Input.GetKey ("d")) {
			pos.x += speed * Time.deltaTime;
			if (!FPS) {
				this.GetComponent<Animator> ().Play ("RUN");
			}
		}
		if (Input.GetKey ("a")) {
			pos.x -= speed * Time.deltaTime;
			if (!FPS) {
				this.GetComponent<Animator> ().Play ("RUN");
			}
		}





		if (Input.GetKeyDown ("space")) {
			this.GetComponent<Animator>().Play("DRAW_WEAPON");
		
			if (FPS) {
				FPS = false;
			} else {
				FPS = true;
			}
		}


		transform.position = pos;*/
	}
}