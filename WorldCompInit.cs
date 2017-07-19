using UnityEngine;
using System.Collections;

//此脚本挂载在PlayerRespawn上
public class WorldCompInit : MonoBehaviour {

	bool SuccRespa = false;
	public GameObject PlayerPrefab;

	private void Update()
	{
		if (Input.GetButtonDown("Respawn"))
		{
			Instantiate(PlayerPrefab, transform.position, transform.rotation);
			SuccRespa = true;
		}
	}
}
