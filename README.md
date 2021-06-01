# Exhibition

## 概述

实现一个虚拟的展览房间
根据用户在图片或视频前停留的时间进行计分
现可通过“Build and run”在 web 进行播放
待建立服务器与数据库传递用户分数等信息

## 主要 Assets 清单

- LogIn.unity：登录场景
  - GetInformation.cs：获取用户的姓名和学号，并记录
- Main.unity：主要展览场景
  - RecordScore.cs：挂载在玩家身上，用来触发视频和图片的观看情况，及计分条件
  - ScoreBar.cs：用来显示用户还需要停留多久
  - ShowScore.cs：用来显示需要观看的展品列表，并显示分数
  - TestVideoPlayer.cs：控制需要播放的视频
- Video.prefab：视频展览组预设体
  - Trigger：用户触发计分的位置（需要在里面停留）
  - Name：图片或视频承载体
  - Light：提供合适的光照
- Image.prefab：图片展览组预设体

## 使用说明

- **添加展览品**
  - 找到 Main 场景中的 Content 物体，按照需要的数量，添加 Video 或 Image 预设体到其物体下
  - 调整各物体的位置与方向
  - 按照次序更改预设体的名字，_请注意从 0 开始_
  - 更改 Image，找到 Image 预设体下的第二个物体
    - 直接将图片拖给它
    - 可以更改此物体的名字，运行后在 UI 上会显示更改的名字
  - 更改 Video，找到 Video 预设体下的第二个物体
    - 找到此物体的 VideoPlayer 组件，确保其 Source 为 URL，且 URL 框无文字
    - 将需要添加的视频放在 StreamingAssets 文件夹
    - 找到此物体的 TestVideoPlayer 脚本组件
    - 将需要添加的视频的名字填到框里，譬如视频文件命名为"test"，视频格式为.mp4，则需要在框中填入"test.mp4"
- **更改停留时间及单项分数**
  - 找到 Main 场景中的 Player 物体
  - 找到 RecordScore 脚本组件，更改数值即可

## 注意事项

此项目中的脚本大多用到 Find 或者 GetChild 来获取变量
除非在了解脚本构成的情况下
请不要轻易改动场景中物体的名字或其在父物体下的顺序
