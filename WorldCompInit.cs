using UnityEngine;
using System.Collections;

//此脚本挂载在PlayerRespawn上
public class WorldCompInit : MonoBehaviour {

	public GameObject PlayerPrefab;

	private void Update()
	{
		if (Input.GetButtonDown("Jump"))
		{
			Instantiate(PlayerPrefab, transform.position, transform.rotation);
		}
	}
}
