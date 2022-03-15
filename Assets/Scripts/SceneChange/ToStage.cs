using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToStage : MonoBehaviour
{
    string stageNum;
    string stageName;

    public void StageChange()
    {
        //stageNum = transform.GetChild(0).gameObject.GetComponent<Text>().ToString();
        GameObject buttonText = transform.GetChild(0).gameObject;

        stageNum = buttonText.GetComponent<Text>().text.ToString();

        Debug.Log(stageNum);

        stageName = "Stage" + stageNum;
    
        FadeManager.Instance.LoadScene(stageName, 0.3f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
