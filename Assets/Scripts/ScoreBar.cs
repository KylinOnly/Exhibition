using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 显示需要在当前展品前停留的时间
/// </summary>
public class ScoreBar : MonoBehaviour
{
    private Slider _slider; //滑动条

    private void Start()
    {
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    public IEnumerator LoadTime(double currentProgress, double targetProgress)
    {
        while (true)
        {
            currentProgress += 0.5f;
            double progress = math.remap(0, targetProgress, 0, 100, currentProgress);
            _slider.value = (float) progress / 100;
            if (currentProgress >= targetProgress)
                yield break;
            yield return new WaitForSeconds(0.5f);
        }
    }
}