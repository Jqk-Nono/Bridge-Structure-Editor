using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace BridgeBaseComponents
{

    /// <summary>
    /// <!--Bridge类的定义基础，以及为何没有检查记录类
    /// 基本思想：
    /// 1.每次检查A桥时，把A桥当作与上次检测不一样的桥；
    /// 2.每次检测A桥时，都把它当作与之前无关的一座桥；
    /// 3.每一次检测，A桥不再是A桥，称它为B桥，B桥的参数与A一致；
    /// 4.A桥与B桥在参数上一致，在评分上区分；
    /// 5.每一个Bridge的实例，代表一次检测；-->
    /// </summary>
    //[Serializable]
    public class Bridge
    {
        public string 桥梁类型名称 { get; set; }

        public 基本信息数据 基本信息数据 { get; set; }

        public 养护管理数据 养护管理数据 { get; set; }

        public double 评分 { get; set; }

        public double 固定评分
        {
            get
            {
                double _评分 = 0;
                foreach (桥梁组成结构 s in 养护管理数据.桥梁组成结构集合)
                {
                    _评分 += s.评分 * s.权重;
                }
                return _评分;
            }
        }

        public string 桥梁技术状况等级
        {
            get
            {
                return GetEvaluationScale(固定评分);
            }
        }

        public double 检测费用 { get; set; }

        public string 检测备注 { get; set; }

        public double 总维修费用 { get; set; }

        public string 维修备注 { get; set; }

        public Bridge()
        {
            基本信息数据 = new 基本信息数据();
            养护管理数据 = new 养护管理数据();
        }

        public static string GetEvaluationScale(double 评分)
        {
            if (评分 <= 100 && 评分 >= 95)
            {
                return "1类";
            }
            else if (评分 < 95 && 评分 >= 80)
            {
                return "2类";
            }
            else if (评分 < 80 && 评分 >= 60)
            {
                return "3类";
            }
            else if (评分 < 60 && 评分 >= 40)
            {
                return "4类";
            }
            else if (评分 < 40 && 评分 >= 0)
            {
                return "5类";
            }
            else return "1类";
        }
    }

    //[Serializable]
    public class 基本信息数据
    {
        ////[XmlIgnore]
        public 基本信息数据组成结构 基本信息记录项目结构 { get; set; }
        //[XmlIgnore]
        public 基本信息数据组成结构 基本参数记录项目结构 { get; set; }
        //[XmlIgnore]
        public 基本信息数据组成结构 结构简图记录项目结构 { get; set; }
        public List<基本信息数据组成结构> 基本信息数据组成结构集合
        {
            get { return new List<基本信息数据组成结构>() { 基本信息记录项目结构, 基本参数记录项目结构, 结构简图记录项目结构 }; }
        }
        public 基本信息数据()
        {
            this.基本信息记录项目结构 = new 基本信息数据组成结构();
            this.基本参数记录项目结构 = new 基本信息数据组成结构();
            this.结构简图记录项目结构 = new 基本信息数据组成结构();
        }
    }

    //[Serializable]
    public class 基本信息数据组成结构
    {
        public string 结构名称 { get; set; }
        public List<基础记录项目> 基础记录项目集合 { get; set; }
        public 基本信息数据组成结构()
        {
            this.基础记录项目集合 = new List<基础记录项目>();
        }
        public 基本信息数据组成结构(string 结构名称)
        {
            this.结构名称 = 结构名称;
            this.基础记录项目集合 = new List<基础记录项目>();
        }
        public 基本信息数据组成结构(string 名称, List<基础记录项目> 基础记录项目集合)
        {
            this.基础记录项目集合 = new List<基础记录项目>();

            this.结构名称 = 名称;
            this.基础记录项目集合 = 基础记录项目集合;
        }
    }

    //[Serializable]
    public class 基础记录项目
    {
        public string 描述名称 { get; set; }
        public object 描述内容 { get; set; }

        private System.Data.SqlDbType _存储数据类型 = System.Data.SqlDbType.NText;
        public System.Data.SqlDbType 存储数据类型
        {
            get { return _存储数据类型; }
            set { _存储数据类型 = value; }
        }

        public int 最大长度 { get; set; }

        public 基础记录项目()
        {
            this.描述内容 = new object();
        }

        public 基础记录项目(string 描述名称)
        {
            this.描述内容 = new object();

            this.描述名称 = 描述名称;
        }

        public 基础记录项目(string 描述名称, System.Data.SqlDbType 存储数据类型)
        {
            this.描述内容 = new object();

            this.描述名称 = 描述名称;
            this.存储数据类型 = 存储数据类型;
        }

        public 基础记录项目(string 描述名称, System.Data.SqlDbType 存储数据类型, int 存储数据大小)
        {
            this.描述内容 = new object();

            this.描述名称 = 描述名称;
            this.存储数据类型 = 存储数据类型;
            this.最大长度 = 存储数据大小;
        }
    }

    //[Serializable]
    public class 养护管理数据
    {
        //[XmlIgnore]
        public 桥梁组成结构 桥面系 { get; set; }

        //[XmlIgnore]
        public 桥梁组成结构 上部结构 { get; set; }

        //[XmlIgnore]
        public 桥梁组成结构 下部结构 { get; set; }

        public List<桥梁组成结构> 桥梁组成结构集合
        {
            get { return new List<桥梁组成结构>() { 桥面系, 上部结构, 下部结构 }; }
        }

        ////[XmlIgnore]
        public Dictionary<string, 桥梁组成一级部件> Available桥梁组成一级部件字典
        {
            get
            {
                Dictionary<string, 桥梁组成一级部件> _桥梁组成一级部件字典 = new Dictionary<string, 桥梁组成一级部件>();
                foreach (桥梁组成结构 s in 桥梁组成结构集合)
                {
                    foreach (桥梁组成一级部件 ss in s.桥梁组成一级部件集合)
                    {
                        if (ss.IsExist)
                        {
                            _桥梁组成一级部件字典.Add(ss.部件名称, ss);
                        }
                    }
                }
                return _桥梁组成一级部件字典;
            }
        }

        ////[XmlIgnore]
        public Dictionary<string, 桥梁组成二级部件> Available桥梁组成二级部件字典
        {
            get
            {
                Dictionary<string, 桥梁组成二级部件> _桥梁组成二级部件字典 = new Dictionary<string, 桥梁组成二级部件>();
                foreach (桥梁组成结构 s in 桥梁组成结构集合)
                {
                    foreach (桥梁组成一级部件 ss in s.桥梁组成一级部件集合)
                    {
                        if (ss.IsExist)
                        {
                            foreach (桥梁组成二级部件 sss in ss.桥梁组成二级部件集合)
                            {
                                if (sss.IsExist)
                                {
                                    _桥梁组成二级部件字典.Add(sss.部件名称, sss);
                                }
                            }
                        }
                    }
                }
                return _桥梁组成二级部件字典;
            }
        }

        public 养护管理数据()
        {
            this.桥面系 = new 桥梁组成结构();
            this.上部结构 = new 桥梁组成结构();
            this.下部结构 = new 桥梁组成结构();
        }
    }

    //[Serializable]
    public class 桥梁组成结构
    {
        public string 名称 { get; set; }

        private double _权重 = 0;
        public double 权重
        {
            get
            {
                while (_权重 > 1)
                {
                    _权重 -= 1;
                }
                return _权重;
            }
            set { _权重 = value; }
        }

        public double 评分 { get; set; }

        public string 评定等级
        {
            get
            {
                return Bridge.GetEvaluationScale(评分);
            }
        }

        public string 评价建议 { get; set; }

        public List<桥梁组成一级部件> 桥梁组成一级部件集合 { get; set; }

        ////[XmlIgnore]
        public List<桥梁组成一级部件> Available桥梁组成一级部件集合
        {
            get
            {
                List<桥梁组成一级部件> _tempList = new List<桥梁组成一级部件>();
                foreach (桥梁组成一级部件 s in 桥梁组成一级部件集合)
                {
                    if (s.IsExist)
                    {
                        _tempList.Add(s);
                    }
                }
                return _tempList;
            }
        }

        ////[XmlIgnore]
        public Dictionary<string, 桥梁组成一级部件> Available桥梁组成一级部件字典
        {
            get
            {
                Dictionary<string, 桥梁组成一级部件> _桥梁组成一级部件字典 = new Dictionary<string, 桥梁组成一级部件>();
                foreach (桥梁组成一级部件 s in 桥梁组成一级部件集合)
                {
                    if (s.IsExist)
                    {
                        _桥梁组成一级部件字典.Add(s.部件名称, s);
                    }
                }
                return _桥梁组成一级部件字典;
            }
        }

        ////[XmlIgnore]
        public List<桥梁组成二级部件> Available桥梁组成二级部件集合
        {
            get
            {
                List<桥梁组成二级部件> _tempList = new List<桥梁组成二级部件>();
                foreach (桥梁组成一级部件 ss in 桥梁组成一级部件集合)
                {
                    if (ss.IsExist)
                    {
                        foreach (桥梁组成二级部件 sss in ss.桥梁组成二级部件集合)
                        {
                            if (sss.IsExist)
                            {
                                _tempList.Add(sss);
                            }
                        }
                    }
                }
                return _tempList;
            }
        }

        ////[XmlIgnore]
        public Dictionary<string, 桥梁组成二级部件> Available桥梁组成二级部件字典
        {
            get
            {
                Dictionary<string, 桥梁组成二级部件> _桥梁组成二级部件字典 = new Dictionary<string, 桥梁组成二级部件>();
                foreach (桥梁组成一级部件 ss in 桥梁组成一级部件集合)
                {
                    if (ss.IsExist)
                    {
                        foreach (桥梁组成二级部件 sss in ss.桥梁组成二级部件集合)
                        {
                            if (sss.IsExist)
                            {
                                _桥梁组成二级部件字典.Add(sss.部件名称, sss);
                            }
                        }
                    }
                }
                return _桥梁组成二级部件字典;
            }
        }

        public 桥梁组成结构()
        {
            this.桥梁组成一级部件集合 = new List<桥梁组成一级部件>();
        }

        public 桥梁组成结构(string 名称)
        {
            this.桥梁组成一级部件集合 = new List<桥梁组成一级部件>();

            this.名称 = 名称;
        }

        public 桥梁组成结构(string 名称, double 权重)
        {
            this.桥梁组成一级部件集合 = new List<桥梁组成一级部件>();

            this.名称 = 名称;
            this.权重 = 权重;
        }

        public 桥梁组成结构(string 名称, double 权重, List<桥梁组成一级部件> 桥梁组成一级部件集合)
        {
            this.桥梁组成一级部件集合 = new List<桥梁组成一级部件>();

            this.名称 = 名称;
            this.权重 = 权重;
            this.桥梁组成一级部件集合 = 桥梁组成一级部件集合;
        }
    }


    //[Serializable]
    public class 养护管理记录总表项目
    {
        public bool IsChecked { get; set; }

        public int 记录编号 { get; set; }

        public string 检查开始日期 { get; set; }

        public string 检查结束日期 { get; set; }

        public string 备注 { get; set; }

        public string 记录人 { get; set; }

        public string 负责人 { get; set; }

        public 养护管理记录总表项目()
        {

        }
    }

    //[Serializable]
    public class 桥梁组成一级部件
    {
        public string 部件名称 { get; set; }

        private double _部件权重 = 0;
        public double 部件权重
        {
            get
            {
                while (_部件权重 > 1)
                {
                    _部件权重 -= 1;
                }
                return _部件权重;
            }
            set { _部件权重 = value; }
        }

        public bool 是否主要部件 { get; set; }

        public bool IsExist { get; set; }

        public double 评分 { get; set; }  //取二级部件最低分

        public string 评定等级
        {
            get
            {
                return Bridge.GetEvaluationScale(评分);
            }
        }

        public List<桥梁组成二级部件> 桥梁组成二级部件集合 { get; set; }

        public List<桥梁组成二级部件> Available桥梁组成二级部件集合
        {
            get
            {
                List<桥梁组成二级部件> _tempList = new List<桥梁组成二级部件>();
                foreach (桥梁组成二级部件 s in 桥梁组成二级部件集合)
                {
                    if (s.IsExist)
                    {
                        _tempList.Add(s);
                    }
                }
                return _tempList;
            }
        }

        ////[XmlIgnore]
        public Dictionary<string, 桥梁组成二级部件> Available桥梁组成二级部件字典
        {
            get
            {
                Dictionary<string, 桥梁组成二级部件> _桥梁组成二级部件字典 = new Dictionary<string, 桥梁组成二级部件>();
                foreach (桥梁组成二级部件 s in 桥梁组成二级部件集合)
                {
                    if (s.IsExist)
                    {
                        _桥梁组成二级部件字典.Add(s.部件名称, s);
                    }
                }
                return _桥梁组成二级部件字典;
            }
        }

        public 桥梁组成一级部件()
        {
            this.桥梁组成二级部件集合 = new List<桥梁组成二级部件>();
        }

        public 桥梁组成一级部件(string 部件名称, double 部件权重, bool 是否主要部件)
        {
            this.桥梁组成二级部件集合 = new List<桥梁组成二级部件>();

            this.部件名称 = 部件名称;
            this.部件权重 = 部件权重;
            this.是否主要部件 = 是否主要部件;
        }

        public 桥梁组成一级部件(string 部件名称, double 部件权重, bool 是否主要部件, List<桥梁组成二级部件> 桥梁组成二级部件集合)
        {
            this.桥梁组成二级部件集合 = new List<桥梁组成二级部件>();

            this.部件名称 = 部件名称;
            this.部件权重 = 部件权重;
            this.是否主要部件 = 是否主要部件;
            this.桥梁组成二级部件集合 = 桥梁组成二级部件集合;
        }
    }

    //[Serializable]
    public class 桥梁组成二级部件
    {
        public string 部件名称 { get; set; }

        public int 构件数 { get; set; }

        private double _部件权重 = 0;
        public double 部件权重
        {
            get
            {
                while (_部件权重 > 1)
                {
                    _部件权重 -= 1;
                }
                return _部件权重;
            }
            set { _部件权重 = value; }
        }

        public bool IsExist { get; set; }

        public double 评分 { get; set; }

        public string 评定等级
        {
            get
            {
                return Bridge.GetEvaluationScale(评分);
            }
        }

        public bool 是否主要部件 { get; set; }

        public List<检查指标> 检查指标集合 { get; set; }

        ////[XmlIgnore]
        public Dictionary<string, 检查指标> 检查指标字典
        {
            get
            {
                Dictionary<string, 检查指标> _检查指标字典 = new Dictionary<string, 检查指标>();
                foreach (检查指标 s in 检查指标集合)
                {
                    _检查指标字典.Add(s.指标名称, s);
                }
                return _检查指标字典;
            }
        }


        #region ---维修记录---
        public 维修记录 维修记录 { get; set; }

        public bool 是否维修
        {
            get
            {
                bool b;
                if (bool.TryParse(维修记录.是否维修.记录内容.ToString(), out b))
                {
                    return b;
                }
                else return false;
            }
            set
            {
                维修记录.是否维修.记录内容 = value;
            }
        }

        public double 维修费用
        {
            get
            {
                double dbl = 0;
                if (double.TryParse(维修记录.维修费用.记录内容.ToString(), out dbl))
                {
                    return dbl;
                }
                else return 0;
            }
            set
            {
                double dbl = 0;
                if (double.TryParse(value.ToString(), out dbl))
                {
                    维修记录.维修费用.记录内容 = value;
                }
                else 维修记录.维修费用.记录内容 = 0;
            }
        }

        public string 维修范围
        {
            get
            {
                return 维修记录.维修范围.记录内容.ToString();
            }
            set
            {
                维修记录.维修范围.记录内容 = value;
            }
        }

        public string 维修方式
        {
            get { return 维修记录.维修方式.记录内容.ToString(); }
            set { 维修记录.维修方式.记录内容 = value; }
        }

        public DateTime 维修时间
        {
            get
            {
                DateTime dt = new DateTime();
                if (DateTime.TryParse(维修记录.维修时间.记录内容.ToString(), out dt))
                {
                    return dt;
                }
                else return DateTime.Now;
            }
            set
            {
                DateTime dt = new DateTime();
                if (DateTime.TryParse(value.ToShortDateString(), out dt))
                {
                    维修记录.维修时间.记录内容 = dt;
                }
                else 维修记录.维修时间.记录内容 = DateTime.Now;
            }
        }

        public bool 是否需要进行特殊检查
        {
            get
            {
                bool b;
                if (bool.TryParse(维修记录.是否需要进行特殊检查.记录内容.ToString(), out b))
                {
                    return b;
                }
                else return false;
            }
            set
            {
                维修记录.是否需要进行特殊检查.记录内容 = value;
            }
        }

        ////[XmlIgnore]
        public Dictionary<int, 维修记录> 维修记录字典 { get; set; }   //记录编号，维修记录 
        #endregion

        public string 二级部件养护建议 { get; set; }

        public 桥梁组成二级部件()
        {
            this.检查指标集合 = new List<检查指标>();
            维修记录 = new BridgeBaseComponents.维修记录();
            维修记录字典 = new Dictionary<int, 维修记录>();
        }
    }

    //[Serializable]
    public class 检查指标
    {
        public string 指标名称 { get; set; }

        public double 扣分 { get; set; }

        public int 标度
        {
            get
            {
                int result = 1;
                if (int.TryParse(检查项目内容.标度.记录内容.ToString(), out result))
                {
                    return result;
                }
                else return 1;
            }
        }

        public List<标度及其说明> 标度及其说明集合 { get; set; }

        public List<标度及其说明> Available标度及其说明集合
        {
            get
            {
                List<标度及其说明> _tmpList = new List<标度及其说明>();
                foreach (标度及其说明 s in 标度及其说明集合)
                {
                    if (s.IsExist)
                    {
                        _tmpList.Add(s);
                    }
                }
                return _tmpList;
            }
        }
       
        //[XmlIgnore]
        public Dictionary<int, 标度及其说明> 标度及其说明字典
        {
            get
            {
                Dictionary<int, 标度及其说明> _temp = new Dictionary<int, 标度及其说明>();
                foreach (标度及其说明 s in 标度及其说明集合)
                {
                    _temp.Add(s.标度, s);
                }
                return _temp;
            }
        }

        public 检查项目内容 检查项目内容 { get; set; }

        public 检查指标()
        {
            this.标度及其说明集合 = new List<标度及其说明>();
            this.检查项目内容 = new 检查项目内容();
        }

        public 检查指标(string 指标名称)
        {
            this.标度及其说明集合 = new List<标度及其说明>();
            this.检查项目内容 = new 检查项目内容();

            this.指标名称 = 指标名称;
        }

        public 检查指标(string 指标名称, List<标度及其说明> 标度及其说明集合)
        {
            this.标度及其说明集合 = new List<标度及其说明>();
            this.检查项目内容 = new 检查项目内容();

            this.指标名称 = 指标名称;
            this.标度及其说明集合 = 标度及其说明集合;
        }

        public 检查指标(string 指标名称, List<标度及其说明> 标度及其说明集合, 检查项目内容 检查项目内容)
        {
            this.标度及其说明集合 = new List<标度及其说明>();
            this.检查项目内容 = new 检查项目内容();

            this.指标名称 = 指标名称;
            this.标度及其说明集合 = 标度及其说明集合;
            this.检查项目内容 = 检查项目内容;
        }
    }

    //[Serializable]
    public class 标度及其说明
    {
        public int 标度 { get; set; }

        public string 定性说明 { get; set; }

        public string 定量说明 { get; set; }

        public bool IsExist { get; set; }

        public 标度及其说明()
        {

        }
        public 标度及其说明(int 标度)
        {
            this.标度 = 标度;
        }
        public 标度及其说明(int 标度, string 定性说明, string 定量说明)
        {
            this.标度 = 标度;
            this.定性说明 = 定性说明;
            this.定量说明 = 定量说明;
        }
    }

    //[Serializable]
    public class 检查项目内容
    {
        public 存储数据结构 是否检查 { get; set; }

        public 存储数据结构 范围及程度 { get; set; }

        public 存储数据结构 具体位置描述 { get; set; }

        public 存储数据结构 标度 { get; set; }

        public 存储数据结构 照片 { get; set; }

        public List<存储数据结构> 检查指标存储数据结构集合
        {
            get
            {
                List<存储数据结构> _tempList = new List<存储数据结构>();
                _tempList.Add(是否检查);
                _tempList.Add(范围及程度);
                _tempList.Add(具体位置描述);
                _tempList.Add(标度);
                _tempList.Add(照片);
                return _tempList;
            }
        }

        public 检查项目内容()
        {
            是否检查 = new 存储数据结构("是否检查", System.Data.SqlDbType.NText, 5);
            范围及程度 = new 存储数据结构("范围及程度", System.Data.SqlDbType.NText);
            具体位置描述 = new 存储数据结构("具体位置描述", System.Data.SqlDbType.NText);
            标度 = new 存储数据结构("标度", System.Data.SqlDbType.NChar, 2);
            照片 = new 存储数据结构("照片", System.Data.SqlDbType.Image);
        }
    }

    //[Serializable]
    public class 存储数据结构
    {
        public string 描述名称 { get; set; }

        public object 记录内容 { get; set; }

        public System.Data.SqlDbType 存储数据类型 { get; set; }

        public int 存储数据大小 { get; set; }

        public 存储数据结构()
        {
            记录内容 = new object();
        }

        public 存储数据结构(string 描述名称, System.Data.SqlDbType 存储数据类型)
        {
            记录内容 = new object();

            this.描述名称 = 描述名称;
            this.存储数据类型 = 存储数据类型;
        }

        public 存储数据结构(string 描述名称, System.Data.SqlDbType 存储数据类型, int 存储数据大小)
        {
            记录内容 = new object();

            this.描述名称 = 描述名称;
            this.存储数据类型 = 存储数据类型;
            this.存储数据大小 = 存储数据大小;
        }
    }

    //[Serializable]
    public class 维修记录
    {
        public 存储数据结构 是否维修 { get; set; }
        public 存储数据结构 维修费用 { get; set; }
        public 存储数据结构 维修范围 { get; set; }
        public 存储数据结构 维修方式 { get; set; }
        public 存储数据结构 维修时间 { get; set; }    //开始日期
        public 存储数据结构 是否需要进行特殊检查 { get; set; }

        public List<存储数据结构> 维修记录存储数据结构集合
        {
            get
            {
                List<存储数据结构> _tempList = new List<存储数据结构>();
                _tempList.Add(是否维修);
                _tempList.Add(维修费用);
                _tempList.Add(维修范围);
                _tempList.Add(维修方式);
                _tempList.Add(维修时间);
                _tempList.Add(是否需要进行特殊检查);
                return _tempList;
            }
        }

        public 维修记录()
        {
            是否维修 = new 存储数据结构("是否维修", System.Data.SqlDbType.NText);
            维修费用 = new 存储数据结构("维修费用", System.Data.SqlDbType.Money);
            维修范围 = new 存储数据结构("维修范围", System.Data.SqlDbType.NText);
            维修方式 = new 存储数据结构("维修方式", System.Data.SqlDbType.NText);
            维修时间 = new 存储数据结构("维修时间", System.Data.SqlDbType.Date);
            是否需要进行特殊检查 = new 存储数据结构("是否需要进行特殊检查", System.Data.SqlDbType.NText);
        }
    }

}
