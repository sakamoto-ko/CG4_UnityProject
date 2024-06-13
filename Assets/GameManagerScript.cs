using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject backGroundCube;
    public GameObject block;
    public GameObject coin;
    public GameObject goal;
    public GameObject goalParticle;

    public string nextSceneName;

    public TextMeshProUGUI scoreText;
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {

        Screen.SetResolution(1920, 1080, false);

        int[,] map = {

        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,2,0,0,0,0,0,0, 0,2,0,0,0,0,0,0,0,0, 0,0,0,2,2,0,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,1,1,1,1,1,0,0, 0,0,0,0,0,2,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,1,1,1,1,1, 0,0,0,0,0,0,0,0,0,0, 1,1,1,0,0,0,0,0,3,1 },
        {1,0,0,0,0,0,0,2,0,0, 0,1,1,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,1,1,1,1,1,1 },
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,1,1,0,0, 0,0,0,1,1,1,1,0,0,0, 0,0,0,0,0,0,0,0,0,1 },
        {1,0,0,0,0,0,2,0,0,0, 0,0,0,0,0,1,1,1,1,0, 0,0,0,0,0,0,0,1,0,0, 0,0,0,0,0,0,0,0,0,1 },
        {1,0,0,0,0,1,1,1,0,0, 0,0,0,0,1,1,1,1,1,1, 0,0,0,0,0,2,0,0,1,0, 0,0,0,2,0,0,0,0,0,1 },
        {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1 },

        };

        int lenY = map.GetLength(0);
        int lenX = map.GetLength(1);

        Vector3 blockPosition = Vector3.zero;
        Vector3 wallPosition = Vector3.zero;
        Vector3 coinPosition = Vector3.zero;
        Vector3 goalPosition = Vector3.zero;

        for (int y = 0; y < lenY; ++y)
        {
            for (int x = 0; x < lenX; ++x)
            {
                //背景
                wallPosition.x = x;
                wallPosition.y = -y + 5;
                wallPosition.z = 1;
                Instantiate(backGroundCube, wallPosition, Quaternion.identity);

                //ブロック
                blockPosition.x = x;
                blockPosition.y = -y + 5;
                if (map[y, x] == 1)
                {
                    Instantiate(block, blockPosition, Quaternion.identity);
                }

                //コイン
                coinPosition.x = x;
                coinPosition.y = -y + 5;
                if (map[y, x] == 2)
                {
                    Instantiate(coin, coinPosition, Quaternion.identity);
                }

                //ゴール
                goalPosition.x = x;
                goalPosition.y = -y + 5;
                if (map[y, x] == 3)
                {
                    goal.transform.position = goalPosition;
                    goalParticle.transform.position = goalPosition;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //スコア加算
        scoreText.text = "SCORE" + score;

        //ゴールに到達したらクリア
        if(GoalScript.isGameClear == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
