# DataCollectionService
Csharp TCP服务-Cowboy 开源 WebSocket 网络库

参考文档
C# 高性能 TCP 服务的多种实现方式Cowboy.Sockets
https://www.cnblogs.com/lvdongjie/p/6963799.html

Cowboy 开源 WebSocket 网络库
https://www.cnblogs.com/gaochundong/p/cowboy_websockets.html

设置界面 
    服务器IP、端口号
    接收数据存储路径、文件名格式

状态栏
    显示统计数据：接收、发送数据的量与速度
                  连接数
	显示服务器状态

查看当前接入的客户端
    IP地址、端口号

关于对话框
软件信息
版权信息

界面设计
图标
配色
布局

查看接收数据
    实时数据
    历史数据

接收数据的描述、分析、提取、绘图
	
数据存储格式的用户自定义

网络数据自动应答

可能的数据格式：
	二进制、文本
	行
	单变量、数组、矩阵	
	帧
	其他

0.参数方式：预想各种场景，设定相关参数
1.插件方式：通过插件方式，处理、存储数据,每种数据格式定义一个插件,自定义的由用户实现
2.脚本方式：由用户编写脚本处理、存储数据,脚本：LUA、Python
