using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
  public GameObject target;
  public GameObject text;
  private NavMeshAgent agent;
  private RestartManager restart;

  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    restart = new RestartManager(target, text);
  }

  // Use this for initialization
  void Update()
  {
    if (restart.IsGameOver() && Input.GetMouseButton(0))
    {
      restart.Restart();
    }
    //目的地となる座標を設定する
    agent.destination = target.transform.position;
  }
  private void OnTriggerEnter(Collider other)
  {
    Debug.Log(other.gameObject.name);
    //接触したオブジェクトがユニティちゃんのとき
    if (other.gameObject.name == target.name)
    {
      restart.PrintGameOver();
    }
  }

}