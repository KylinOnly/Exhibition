using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using OfficeOpenXml;

public class ShowScore : MonoBehaviour
{
    public Text nameText;
    public Text scoreList;
    public GameObject TotalScore;

    private void Awake()
    {
        TotalScore = transform.GetChild(4).gameObject;
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
        TotalScore.SetActive(true);
        TotalScore.transform.GetChild(1).GetComponent<Text>().text = totalNum.ToString();
        string name = PlayerPrefs.GetString("name");
        string number = PlayerPrefs.GetString("number");
    }
}