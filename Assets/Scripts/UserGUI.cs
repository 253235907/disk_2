using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    private IUserAction action;
    public int life = 5;                   //血量
    //每个GUI的style
    GUIStyle bold_style = new GUIStyle();
	GUIStyle round_style = new GUIStyle();
    GUIStyle score_style = new GUIStyle();
    GUIStyle text_style = new GUIStyle();
    GUIStyle over_style = new GUIStyle();
    private int high_score = 0;            //最高分
    private bool game_start = false;       //游戏开始

    void Start ()
    {
        action = SSDirector.GetInstance().CurrentScenceController as IUserAction;
    }
	
	void OnGUI ()
    {
		bold_style.normal.textColor = Color.red;
        bold_style.fontSize = 20;
		round_style.normal.textColor = Color.red;
		round_style.fontSize = 20;
		text_style.normal.textColor = Color.red;
        text_style.fontSize = 20;
		score_style.normal.textColor = Color.red;
        score_style.fontSize = 20;
        over_style.normal.textColor = new Color(1, 1, 1);
        over_style.fontSize = 50;

        if (game_start)
        {
            //用户射击
            if (Input.GetButtonDown("Fire1"))
            {
                Vector3 pos = Input.mousePosition;
                action.Hit(pos);
            }

            GUI.Label(new Rect(10, 5, 200, 50), "Scores:", text_style);
            GUI.Label(new Rect(85, 5, 200, 50), action.GetScore().ToString(), score_style);

			GUI.Label(new Rect(350, 5, 200, 50), "round:  ", text_style);
			GUI.Label(new Rect(440, 5, 200, 50), action.GetRound().ToString(), round_style);

            GUI.Label(new Rect(Screen.width - 150, 5, 50, 50), "Health:", text_style);
            //显示当前血量
            for (int i = 0; i < life; i++)
            {
                GUI.Label(new Rect(Screen.width - 75 + 10 * i, 5, 50, 50), "♥", bold_style);
            }
            //游戏结束
            if (life == 0)
            {
                high_score = high_score > action.GetScore() ? high_score : action.GetScore();
                GUI.Label(new Rect(Screen.width / 2 - 120, Screen.width / 2 - 350, 100, 100), "GAME OVER", over_style);
                GUI.Label(new Rect(Screen.width / 2 - 110, Screen.width / 2 - 300, 50, 50), "Final Scores:", text_style);
                GUI.Label(new Rect(Screen.width / 2 + 50, Screen.width / 2 - 300, 50, 50), high_score.ToString(), text_style);
                if (GUI.Button(new Rect(Screen.width / 2 - 20, Screen.width / 2 - 150, 100, 50), "Restart"))
                {
                    life = 5;
                    action.ReStart();
                    return;
                }
                action.GameOver();
            }
        }
        else
        {

            GUI.Label(new Rect(Screen.width / 2  - 230, Screen.width / 2  -200, 400, 100), "Click disks to shoot them down. You have only 5 lifes.", text_style);
            if (GUI.Button(new Rect(Screen.width / 2 - 80, Screen.width / 2-300, 100, 50), "START"))
            {
                game_start = true;
                action.BeginGame();
            }
        }
    }
    public void ReduceBlood()
    {
        if(life > 0)
            life--;
    }
}
