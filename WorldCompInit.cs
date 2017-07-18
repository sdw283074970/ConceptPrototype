using UnityEngine;
using System.Collections;

public class WorldCompInit : MonoBehaviour {

	public GameObject CameraPrefab;
	public GameObject EnvFxPrefab;
	public GameObject WeaponsPrefab;
	public GameObject PlayerPrefab;
	public GameObject CanvasPrefab;

	void Start () {
	
	}
	
	private void FixedUpdate()
	{
		if (Input.GetButton("Jump"))
		{
			Instantiate(EnvFxPrefab, transform.position, transform.rotation);
			Instantiate(PlayerPrefab, transform.position, transform.rotation);
			Instantiate(CameraPrefab, transform.position, transform.rotation);
			Instantiate(WeaponsPrefab, transform.position, transform.rotation);
			Instantiate(CanvasPrefab, transform.position, transform.rotation);
		}
	}
}
