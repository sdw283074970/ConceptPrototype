using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//此脚本挂载在EnvFx上
namespace Player
{
	public class NewRespawn : MonoBehaviour
	{

		public delegate void PlayerRespawnEventHandler();		//初始初生委托
		public event PlayerRespawnEventHandler PlayerRespawnEvent;

		public GameObject PlayerPrefabs;        //设置玩家预制
		private bool isOnePlayer = false;		//确保场景中有且只有唯一的玩家

		private void Start()
		{
			PlayerRespawnEvent += OnPlayerRespawn;		//订阅初生事件
		}

		void Update()		//当有playeratt检测出为真，启用重生事件
		{
			if (GameObject.FindGameObjectWithTag("Player") && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAtts>()&&isOnePlayer.Equals(false))
			{
				if (PlayerRespawnEvent != null)
				{
					PlayerRespawnEvent();
				}
				isOnePlayer = true;
			}
		}

		private void OnPlayerRespawn()		//重生事件
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

			GameObject AIFriend = GameObject.FindWithTag("Robot");      //查找可重生的队友
			GameObject DeadPlayer = GameObject.FindWithTag("Player");

			if (AIFriend)
			{
				Vector3 AITransformPosition = new Vector3();
				AITransformPosition = AIFriend.transform.position;      //获取AI当前位置
				Quaternion AITransformRotation = new Quaternion();
				AITransformRotation = AIFriend.transform.rotation;      //获取AI当前旋转

				//预留 传出AI当前状态（武器，弹药，生命，掩护状态）
				Destroy(GameObject.Find("Weapons"));       //销毁武器
				DeadPlayer.GetComponent<SetupAndUserInput>().enabled = false;      //关闭玩家输入
				DeadPlayer.GetComponent<PlayerAtts>().enabled = false;     //关闭PlayerAtt
				Destroy(GameObject.Find("CoverChecker"));       //销毁CoverChecker
				Destroy(GameObject.Find("ItemChecker"));        //销毁ItemChecker
				Destroy(AIFriend);      //销毁AI对象
				Destroy(GameObject.FindWithTag("CamRig").GetComponentInChildren<AudioListener>());//销毁音频接收器
				GameObject.FindWithTag("CamRig").GetComponentInChildren<Camera>().enabled = false;      //禁用死亡玩家摄像机
				DeadPlayer.tag = "DeadPlayer";
				isOnePlayer = false;
				Instantiate(PlayerPrefabs, AITransformPosition, AITransformRotation);
			}
			else
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);     //若没有可重生队友，则重置场景
		}
	}
}
