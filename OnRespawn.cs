using UnityEngine;
using System.Collections;

//此脚本挂载在CamRig上
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
			GameObject.FindWithTag("Player").GetComponent<PlayerAtts>().enabled = true;
			GameObject.FindWithTag("Player").GetComponent<SetupAndUserInput>().enabled = true;
			GameObject.FindWithTag("Player").GetComponent<Animator>().enabled = true;
		}

		// Update is called once per frame
		void Update() {

		}
	}
}
