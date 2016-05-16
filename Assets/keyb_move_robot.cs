using UnityEngine;
using System.Collections;

public class keyb_move_robot : MonoBehaviour {

	const float MOVE_FACTOR = 0.05f;
	float move_speed = 0.5f;

	float posx;
	float posz;
	float posy;


	int change_x;
	int change_z;

	float new_rot;


	// Use this for initialization
	void Start () {
		posx = gameObject.transform.position.x;
		posz = gameObject.transform.position.z;
		posy = gameObject.transform.position.y;

	}

	// Update is called once per frame
	void Update () {
		posx = gameObject.transform.position.x;
		posz = gameObject.transform.position.z;

		change_x = 0;
		change_z = 0;

		new_rot = 0;

		if (Input.GetKey ("d")) {
			posx = posx + (MOVE_FACTOR * move_speed);
			change_x += 1;

		}

		if (Input.GetKey ("a")) {
			posx = posx - (MOVE_FACTOR * move_speed);
			change_x += -1;
		}

		if (Input.GetKey ("w")) {
			posz = posz + (MOVE_FACTOR * move_speed);
			change_z += 1;
		}

		if (Input.GetKey ("s")) {
			posz = posz - (MOVE_FACTOR * move_speed);
			change_z += -1;
		}

		if (change_x != 0 || change_z != 0) {


			new_rot = ((change_z - 1)*(90)) * Mathf.Abs(change_z);

			//(change_x * 90)
			//(Mathf.Abs(change_z) + Mathf.Abs(change_x)

			if (change_x != 0) {
				new_rot = Mathf.Abs(new_rot) * change_x; 
			}

			new_rot = (new_rot + (change_x * 90f)) / (Mathf.Abs(change_z) + Mathf.Abs(change_x));

			gameObject.transform.rotation = Quaternion.Euler((new Vector3 (gameObject.transform.rotation.eulerAngles.x, new_rot, gameObject.transform.rotation.eulerAngles.z)));
		}

		//gameObject.transform.rotation = Quaternion.Euler((new Vector3 (gameObject.transform.rotation.eulerAngles.x, 90.0f, gameObject.transform.rotation.eulerAngles.z)));


		gameObject.transform.position = new Vector3 (posx, posy, posz);
	}
}
