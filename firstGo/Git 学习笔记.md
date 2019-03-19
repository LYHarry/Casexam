# 前言
  UtilCore 项目是我接触 GitHub 和 Git 的第一个项目，所以在这里记录下 Git 的基本使用方法。
# 配置 Git
  git config --global user.name "用户名称" <br />
  git config --global user.email "邮箱" <br />
  建议配置 Git 的用户名称和在 Git 上绑定的邮箱。 

| 配置级别 | 作用范围 |
| ------ | ------ |
| --local（默认，高优先级） | 只影响本仓库 |
| --global（中优先级） | 影响当前用户的所有git仓库 |
| --system（低优先级） | 影响全系统的git仓库 |
  ### 修改默认编辑器
       git config --global core.editor 
       参考资料：https://blog.csdn.net/machinecat5888/article/details/73609966
# 生成SSH key
   在 Git Bash 窗口中输入 “ssh-keygen -t rsa -C youremail@example.com” <br />
   参考资料：https://blog.csdn.net/u014103733/article/details/79190004 <br />
   说明：默认生成的key是没有密码的，也可以在设置 passphrase 时设置密钥密码。
# 将代码提交到GitHub
  参考资料：https://blog.csdn.net/Lucky_LXG/article/details/77849212 <br />
  资料中两种方法都需要先在 GitHub 上创建仓库，然后再通过 Git 关联到 GitHub 仓库，所以我建议通过第一种方法即可，这样能避免本地仓库和远程仓库不一致的错误。
# 提交报错
  1. Updates were rejected because the remote contains work that you do not have locally. This is usually caused by another repository pushing to the same ref.  <br />
   解决方法：需要先拉取下远程仓库代码,执行命令 “git pull origin master” 
  2. refusing to merge unrelated histories <br />
     解决方法：git pull origin master –allow-unrelated-histories <br />
     参考资料：https://blog.csdn.net/u012145252/article/details/80628451
# gitignore
  .gitignore 为 git 提交忽略配置文件。
   ### 创建 .gitignore 文件
        1. 在当前项目根路径下执行命令 “touch .gitignore”
        2. 在创建 git 仓库时选择添加 .gitignore 文件。
   ### 全局配置
       全局配置 git 提交忽略文件 <br />
       参考资料：https://blog.csdn.net/singlepepper/article/details/46533539
# 删除远程仓库文件
   rm 命令用于删除远程仓库文件或文件夹。 <br />
   git rm -r -n “需要删除的文件路径”  <br />
   -r 表示删除目录 <br />
   如果只想从版本库中删除,但是本地仍旧保留的话,加上 --cached 参数 <br />
   参考资料：https://www.cnblogs.com/pingjie/p/5046405.html

# 备注
  ### 通过系统自带 cmd 窗口
     1. 生成 SSH key 的 “ssh-keygen” 命令 cmd 窗口不识别，需要用 Git Bash 窗口才行。
     2. git log 命令 cmd 窗口中文打印出来会是乱码(或者被编码后的文字)。
  ### git commit -a 代替 git add 和 git commit
      参考资料：https://www.cnblogs.com/ygjlch/p/6049640.html
  ### 其他
      1. 空文件夹不会提交到GitHub中
# Git 教程资料
    1. 手把手 git 教程系列。https://blog.csdn.net/andylauren/article/details/70162735
    2. https://github.com/Hunter1023/learn_Git/wiki/Git%E7%9A%84%E5%AE%89%E8%A3%85
    3. https://www.liaoxuefeng.com/wiki/0013739516305929606dd18361248578c67b8067c8c017b000

