using UnityEngine;
using System.Collections;

//此脚本挂载在PlayerPerfab上
namespace Player
{
	public class OnRespawn : MonoBehaviour {
		void Start()
		{
			if (GameObject.Find("CameraInit"))
			{
				Destroy(GameObject.Find("CameraInit"));
			}

			GameObject.Find("ItemChecker").GetComponent<ItemsAround>().enabled = true;
			GameObject.Find("CoverChecker").GetComponent<CoverTargetLogic>().enabled = true;
			GameObject.Find("Player Y_Bot").GetComponent<PlayerAtts>().enabled = true;
			GameObject.Find("Player Y_Bot").GetComponent<SetupAndUserInput>().enabled = true;
			GameObject.Find("Player Y_Bot").GetComponent<Animator>().enabled = true;
			GameObject.Find("CamRig").GetComponent<NewRespawn>().enabled = true;
		}

		// Update is called once per frame
		void Update() {

		}
	}
}
