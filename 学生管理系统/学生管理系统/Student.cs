using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 学生管理系统
{
    /// <summary>
    /// 学生类
    /// </summary>
    class Student
    {
        public string id = ""; //学号
        public string name = ""; //姓名
        public string sex = ""; //性别
        public int age = 0;//年龄
        public string grade = "";//班级
        public int score = 0; //成绩

        /// <summary>
        /// 学生信息
        /// </summary>
        /// <param name="id">学号</param>
        /// <param name="name">姓名</param>
        /// <param name="sex">性别</param>
        /// <param name="age">年龄</param>
        /// <param name="grade">班级</param>
        /// <param name="score">成绩</param>
        public Student(string id, string name, string sex, int age, string grade, int score)
        {
            this.id = id;
            this.name = name;
            this.sex = sex;
            this.age = age;
            this.grade = grade;
            this.score = score;
        }

    }
}
