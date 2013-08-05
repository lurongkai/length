#length

##Regards
Merge了一些个人认为优秀的实现，请无视我自己csharp的实现。

* [stfairy](https://github.com/stfairy/length) (Ruby)
* [ChanceDoor](https://github.com/ChanceDoor/length) (Ruby)
* [zn0315](https://github.com/zn0315/length) (Java)
* [mailgyc](https://github.com/mailgyc/length) (Python)
* [zwy1135](https://github.com/zwy1135/length) (Python)

##题目介绍
您要做的是一个长度单位转化和计算工具，能够把不同的长度单位转换为标准长度（米），并且可以在不同单位之间进行加减运算。

## 输入文件
输入文件input.txt的内容可分为两部分：

1. 不同单位和标准长度米的转换规则， 比如

1 mile = 1609.344 meters， 代表1英里等于1609.344米；

2. 转换前或者计算前的单位，比如
1.2 miles													// 一个长度
1.2 miles + 1 fath - 0.2 meters   // 单位可能不同的长度之间的加减运算

## 您要做的

我们期望您编写一个应用程序，可以读取输入文件，了解不同单位与米之间的转换规则后，把以不同单位表示的长度都转换为标准单位米；同时计算不同单位长度的加减表达式，得到以米为单位的结果。

做题要求：

* 请一定Fork本仓库再做题目

* 使用的编程语言不限

* 输出结果为文件"output.txt"，其格式见下面说明

* 源代码和结果文件"output.txt"上传到您的GitHub代码库中

* 结果文件“output.txt”一定要放到代码库的根目录下

## 输出文件格式

该文件的格式共有12行，并严格遵守以下规则：

* 第1行是您在渣打编程马拉松官网上报名时的注册邮箱，比如myName@gmail.com

* 第2行是空行

* 第3行至第12行，每行显示1个计算结果，比如1931.21 m

* 计算结果要求精确到小数点后两位

* 计算结果均以字母m结尾，请注意数字和字母m之间有一个空格。
