using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public Animation anim;
	IEnumerator Start() {
		anim = GetComponent<Animation>();
		anim.Play(anim.clip.name);
		yield return new WaitForSeconds(anim.clip.length);
	}
}
