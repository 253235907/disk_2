using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour
{
    public int score;                   //分数
    void Start ()
    {
        score = 0;
    }

    public void Record(GameObject disk)
    {	
		int sco = 1;
		Color temp = disk.GetComponent<DiskData>().color;
		if (temp == Color.black) {
			sco = -1;
		}
		else if (temp == Color.blue) {
			sco = 1;
		}
		else if (temp == Color.red) {
			sco = 2;
		}
		else if (temp == Color.yellow) {
			sco = 3;
		}
		score = sco + score;
    }
    //重置分数
    public void Reset()
    {
        score = 0;
    }
}
