using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.Video;

public class TestVideoPlayer : MonoBehaviour
{
    public new string name; //视频路径
    private VideoPlayer _videoPlayer; //从场景中拖入挂载VideoPlayer组件的RawImage

    private void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        string videoPath = Application.streamingAssetsPath + "/" + name;
        _videoPlayer.url = videoPath;
    }
}