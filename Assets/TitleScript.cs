using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public string nextSceneName;
    public GameObject hitKey;

    private int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //timerの増減で文字を点滅させる処理
        timer++;
        if (timer % 100 > 50)
        {
            hitKey.SetActive(false);
        }
        else
        {
            hitKey.SetActive(true);
        }

        //スペースキーを押したらゲームシーンへ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
