# SampleProjects


# PokerGame
15个任意物品（可以是火柴牙签poker）
以下按牙签为例
 
将15根牙签
分成三行
每行自上而下（其实方向不限）分别是3、5、7根

 **（扩展为可默认，也可自定义行数和每行牙签数）**
 

安排两个玩家，每人可以在一轮内，在任意行拿任意根牙签，但不能跨行

 **（扩展为接受多个玩家参与）**
 
拿最后一根牙签的人即为输家

################################################################
程序是控制台项目，使用vs2017，.net framwork 4.6.1
根据需求抽象出如下对象：
Game：一个完整轮次的游戏，关联玩家列表和当前玩家。
IGame：抽象出的Game接口，一个扩展点，用以适配其他同类游戏。
User：玩家，拥有姓名，可以玩游戏。
GameCenter：游戏中心，用以管控玩家和游戏，具有初始化游戏，继续游戏等操作，后面可以扩展记录和查询游戏过程和结果的功能。
Tools：封装的工具类。


