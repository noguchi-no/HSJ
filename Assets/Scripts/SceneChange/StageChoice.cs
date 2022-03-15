using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageChoice : MonoBehaviour
{
    /*クリアしたらそのステージ番号をSetIntする
    PlayerPrefs.SetInt("stageNum", stageNum);
    //PlayerPrefsをセーブする         
    PlayerPrefs.Save();
    */
    private int stageNum;
    public Button[] stageButtons;
    //public int stageMaxNum = 50;
    void Start()
    {
        CantTapButton();

        stageNum = PlayerPrefs.GetInt("stageNum", 1);

        for (int i = 0; i < stageNum; i++)
        {
            //半透明にしておいたボタンのアルファを最大まであげる
            //ボタンを押せるようにする
            stageButtons[i].interactable = true;
        }
    }
    private void CantTapButton()
    {
        //全てのボタンは最初は押せないようにする。
        for (int i = 0; i <= stageButtons.Length - 1; i++)
        {
            stageButtons[i].interactable = false;
        }
    }

}
