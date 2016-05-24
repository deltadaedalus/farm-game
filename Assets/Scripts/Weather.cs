using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour
{
    public Light sun;
    public float dayLength = 120;

    float worldTime;

	// Use this for initialization
	void Start () {
        worldTime = 0;
        sun.type = LightType.Directional;
        sun.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;

        worldTime += dt / dayLength;
        sun.transform.rotation = Quaternion.AngleAxis(worldTime * 360f + 180f, Vector3.left);
	}
}
