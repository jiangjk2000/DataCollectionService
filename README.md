# Data Collection Service
C# TCP服务 Cowboy 开源 WebSocket 网络库

## 所需第三方类库
1. NuGets
	- Nlog
	- ZedGraph
	- Costura.Fody
2. 类库
	- Cowboy.Sockets https://github.com/gaochundong/Cowboy
	- CSkin http://www.cskin.net/

## 参考文档
- C# 高性能 TCP 服务的多种实现方式Cowboy.Sockets
https://www.cnblogs.com/lvdongjie/p/6963799.html

- Cowboy 开源 WebSocket 网络库
https://www.cnblogs.com/gaochundong/p/cowboy_websockets.html

## 实现目标
1. 设置界面 
	- 服务器IP、端口号
	- 接收数据存储路径、文件名格式

2. 状态栏
	- 显示统计数据：接收,发送数据的量与速度,连接数
	- 显示服务器状态

3. 查看当前接入的客户端
	- IP地址、端口号

4. 关于对话框
	- 软件信息
	- 版权信息

5. 界面设计
	- 图标
	- 配色
	- 布局

6. 查看接收数据
	- 实时数据
	- 历史数据

7. 接收数据的描述、分析、提取、绘图

8. 数据存储格式的用户自定义

9. 网络数据自动应答

10. 可能的数据格式：
	- 二进制、文本
	- 行
	- 单变量、数组、矩阵	
	- 帧
	- 其他
11. 其他
	- 参数方式：预想各种场景，设定相关参数
	- 插件方式：通过插件方式，处理、存储数据,每种数据格式定义一个插件,自定义的由用户实现
	- 脚本方式：由用户编写脚本处理、存储数据,脚本：LUA、Python
