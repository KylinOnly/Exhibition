using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Video;

public class RecordScore : MonoBehaviour
{
    public static RecordScore Instance;
    [Header("图片单值分数")] public int imageScore = 20; //图片单值分数
    [Header("视频单值分数")] public int videoScore = 10; //视频单值分数
    [Header("图片前必须停留的时间")] public int stayImageTime = 8; //图片前停留的时间

    private int[] _score;
    private string[] _name;
    private IEnumerator _recordVideoScore;
    private IEnumerator _recordImageScore;
    private IEnumerator _loadTime;
    private ShowScore _showScore;
    private ScoreBar _scoreBar;

    public string[] Name => _name;
    public int[] Score => _score;

    private void Awake()
    {
        Instance = this;
        //获取其他脚本
        _showScore = GameObject.Find("Canvas").GetComponent<ShowScore>();
        _scoreBar = _showScore.transform.GetChild(3).gameObject.GetComponent<ScoreBar>();
        //初始化分数列表
        GameObject parent = GameObject.Find("Content");
        var childCount = parent.transform.childCount;
        _score = new int[childCount];
        _name = new string[childCount];
        for (int i = 0; i < childCount; i++)
            _name[i] = parent.transform.GetChild(i).GetChild(1).name;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Video":
                //播放视频
                VideoPlayer videoPlayer = other.transform.parent.GetChild(1).GetComponent<VideoPlayer>();//播放
                videoPlayer.Play();
                //获得视频长度与名字，在ui上显示
                _recordVideoScore = RecordVideoScore(videoPlayer.clip.length, int.Parse(other.transform.parent.name));
                _showScore.SetName(other.transform.parent.GetChild(1).name);
                _loadTime = _scoreBar.LoadTime(videoPlayer.time, videoPlayer.clip.length);
                StartCoroutine(_loadTime);
                StartCoroutine(_recordVideoScore);
                break;
            case "Image":
                _recordImageScore = RecordImageScore(stayImageTime, int.Parse(other.transform.parent.name));
                _showScore.SetName(other.transform.parent.GetChild(1).name);
                _loadTime = _scoreBar.LoadTime(0, stayImageTime);
                StartCoroutine(_loadTime);
                StartCoroutine(_recordImageScore);
                break;
            case "Exit":
                _showScore.ShowTotalScore(_score);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Video":
                VideoPlayer videoPlayer = other.transform.parent.GetChild(1).GetComponent<VideoPlayer>();
                videoPlayer.Pause();
                _showScore.SetName(" ");
                _showScore.UpdateList();
                StopCoroutine(_loadTime);
                StopCoroutine(_recordVideoScore);
                break;
            case "Image":
                _showScore.SetName(" ");
                _showScore.UpdateList();
                StopCoroutine(_loadTime);
                StopCoroutine(_recordImageScore);
                break;
        }
    }

    IEnumerator RecordVideoScore(double length, int index)
    {
        float t = 0;
        while (true)
        {
            t += 0.5f;

            if (t < length / 2 && t >= length / 4) //1/4~2/4
                _score[index] = 5;
            else if (t < length / 4 * 3 && t >= length / 2) //2/4~3/4
                _score[index] = 10;
            else if (t < length && t >= length / 4 * 3) //3/4~4/4
                _score[index] = 15;
            else if (t >= length) //4/4
            {
                _score[index] = 20;
                print("已完成");
                yield break;
            }
            else
                _score[index] = 0;

            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator RecordImageScore(int stayTime, int index)
    {
        float t = 0;
        while (true)
        {
            if (t < stayTime / 2 && t >= stayTime / 4) //1/4~2/4
                _score[index] = 5;
            else if (t < stayTime / 4 * 3 && t >= stayTime / 2) //2/4~3/4
                _score[index] = 10;
            else if (t < stayTime && t >= stayTime / 4 * 3) //3/4~4/4
                _score[index] = 15;
            else if (t >= stayTime) //4/4
            {
                _score[index] = 20;
                print("已完成");
                yield break;
            }
            else
                _score[index] = 0;

            t++;
            yield return new WaitForSeconds(1f);
        }
    }
}