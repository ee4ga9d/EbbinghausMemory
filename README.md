# EbbinghausMemory
记忆曲线

### 0.介绍：
* 这是一个方便自己使用艾斯浩宾曲线记忆来学习英语的小工具，非常简单的出发点————每天提醒自己该复习哪些内容。个人不习惯使用Excel表格记录。
* 主界面关闭后，会最小化在系统托盘，便于提醒待办事项。
* 只允许运行一个实例。

### 1.算法：
* 添加完学习课程以后，自动生成0天、1天、2天、7天、15天和30天的复习任务。软件启动后，每隔1小时检测是否有未完成的复习并提醒。
* 以复习任务为中心，引入了**教材**、**课程**和**教材类型**概念，并把这些序列为数据库表。
* 增加了课程规划功能。

### 2.代码：
* 采用.NET 4.8 WinForm，引用了EF 6+SQLite+log4net组件。为了使用WIN10系统的提醒功能，引入了UWP组件。
* VS2017开发

![image](https://github.com/user-attachments/assets/60f0bd15-76bb-42ac-859b-89b4ce42b0d6)

