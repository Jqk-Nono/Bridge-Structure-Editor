# Bridge-Structure-Editor
Mainly a dynamic link library to describe the structure of a bridge. 
And an executable file to generate, modify the XML file based on the dynamic link library.
Code in C#, many parameters are the Chinese characters.

使用C# 5.0/6.0编写，很多参数名使用的中文名。

作者是物理系硕士，参与了桥梁维护管理信息系统软件的编写。
肯定有很多不足之处，即便被批评一无是处，我也不会介意，只希望得到宝贵意见。
学凝聚态物理都是一头雾水了，因为懂点数据库，研二被派去写代码了。
一边学C#，学WPF，学数据库，还要学桥梁，真的好累，什么都是半吊子。。。

如果有做桥梁的人进来这里，希望能一起完善BridgeBaseComponentStructures里的类。

在使用Bridge类时的基本思想是，每次检测时的桥梁是一个新的实例。

Bridge类的定义基础,以及为何没有检查记录类。
    /// 基本思想:
    /// 1.每次检查A桥时,把A桥当作与上次检测不一样的桥
    /// 2.每次检测A桥时,都把它当作与之前无关的一座桥
    /// 3.每一次检测,A桥不再是A桥,称它为B桥,而B桥的参数与A一致
    /// 4.A桥与B桥在参数上一致,在标度评分上区分
    /// 5.每一个Bridge的实例,代表一次检测
	
