using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//此脚本挂载在CamRig上
namespace Player
{
	public class NewRespawn : MonoBehaviour
	{
		public GameObject PlayerPerfabs;        //设置玩家预制

		void Start()
		{
			if (GameObject.FindGameObjectWithTag("Player") && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAtts>())
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAtts>().PlayerDeadEvent += OnPlayerDead;//订阅死亡事件
			}
		}

		private void OnPlayerDead()
		{
				//等待2秒执行死亡动作
				StartCoroutine(WaitAndExecute(2.0F));
		}

		//延迟执行函数
		IEnumerator WaitAndExecute(float waitTime)
		{
			yield return new WaitForSeconds(waitTime);

			GameObject AIFriend = GameObject.FindWithTag("Robot");		//查找可重生的队友

			if (AIFriend)
			{
				Vector3 AITransformPosition = new Vector3();
				AITransformPosition = AIFriend.transform.position;      //获取AI当前位置
				Quaternion AITransformRotation = new Quaternion();
				AITransformRotation = AIFriend.transform.rotation;      //获取AI当前旋转
																		//预留 传出AI当前状态（武器，弹药，生命，掩护状态）
				Destroy(GameObject.Find("ItemChecker"));        //销毁ItemChecker
				Destroy(GameObject.Find("CoverChecker"));       //销毁CoverChecker
				GameObject.Find("Player Y_Bot").GetComponent<PlayerAtts>().enabled = false;     //关闭PlayerAtt
				GameObject.Find("Player Y_Bot").GetComponent<SetupAndUserInput>().enabled = false;      //关闭玩家输入
				Destroy(AIFriend);      //销毁AI对象

				Instantiate(PlayerPerfabs, AITransformPosition, AITransformRotation);       //原地实例化新玩家
				Destroy(GameObject.Find("Player"));//销毁摄像机以及本脚本
			}
			else
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);		//若没有可重生队友，则重置场景
		}
	}
}
