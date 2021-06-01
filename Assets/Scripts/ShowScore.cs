using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// 显示分数
/// </summary>
public class ShowScore : MonoBehaviour
{
    public Text nameText;
    public Text scoreList;
    public GameObject totalScore;

    private void Awake()
    {
        totalScore = transform.GetChild(4).gameObject;
    }

    private void Start()
    {
        string textOutPut = "";
        for (int i = 0; i < RecordScore.Instance.Name.Length; i++)
            textOutPut += RecordScore.Instance.Name[i] + "：" + RecordScore.Instance.Score[i] + "\n";
        scoreList.text = textOutPut;
    }

    public void UpdateList()
    {
        string textOutPut = "";
        for (int i = 0; i < RecordScore.Instance.Name.Length; i++)
            textOutPut += RecordScore.Instance.Name[i] + "：" + RecordScore.Instance.Score[i] + "\n";
        scoreList.text = textOutPut;
    }

    public void SetName(string contentName)
    {
        nameText.text = contentName;
    }

    public void ShowTotalScore(int[] score)
    {
        int totalNum = 0;
        for (int i = 0; i < score.Length; i++)
            totalNum += score[i];
        totalScore.SetActive(true);
        totalScore.transform.GetChild(1).GetComponent<Text>().text = totalNum.ToString();
        string name = PlayerPrefs.GetString("name");
        string number = PlayerPrefs.GetString("number");
    }
}