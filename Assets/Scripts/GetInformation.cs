using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 登录页面，获取用户姓名与学号
/// todo：接入数据库
/// </summary>
public class GetInformation : MonoBehaviour
{
    public InputField studentName;
    public InputField number;

   public void ToMain()
    {
        if (studentName.text == "" && number.text == "")
        {
            Debug.Log("Please input name and number!");
            return;
        }

        PlayerPrefs.SetString("name", studentName.text);
        PlayerPrefs.SetString("number", number.text);
        SceneManager.LoadScene("Main");
        //print(studentName.text + " " + number.text);
    }
}