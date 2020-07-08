using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    public GameObject player;
    public GameObject text;
    private bool isGoal = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGoal && Input.GetMouseButton(0))
        {
            Restart();
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        //当たってきたオブジェクトの名前がユニティちゃんの名前と同じとき
        if(other.name == player.name)
        {
            //テキストの内容を変更する
            text.GetComponent<Text>().text = "Goal!!!\n画面クリックで再スタート";
            //テキストをオンにして非表示→表示にする
            text.SetActive(true);

            //Goal判定をTrueにする
            isGoal = true;
        }
    }

    private void Restart()
    {
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);
    }
}
