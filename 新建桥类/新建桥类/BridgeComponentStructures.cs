using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace 新建桥类
{
    public class Bridge
    {
        public string 桥梁类型名称 { get; set; }
        public 基本信息数据 基本信息数据 { get; set; }
        public 养护管理数据 养护管理数据 { get; set; }
        public Bridge()
        {
            基本信息数据 = new 基本信息数据();
            养护管理数据 = new 养护管理数据();
        }
    }

    public class 基本信息数据
    {
        public 基本信息数据组成结构 基本信息记录项目结构 { get; set; }
        public 基本信息数据组成结构 基本参数记录项目结构 { get; set; }
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
            this.结构名称 = 名称;
            this.基础记录项目集合 = new List<基础记录项目>();
            this.基础记录项目集合 = 基础记录项目集合;
        }
    }

    public class 基础记录项目
    {
        
        public string 描述名称 { get; set; }
        private System.Data.SqlDbType _存储数据类型 = System.Data.SqlDbType.NText;
        public System.Data.SqlDbType 存储数据类型
        {
            get { return _存储数据类型; }
            set { _存储数据类型 = value; }
        }
        public int 最大长度 { get; set; }
        public 基础记录项目()
        {

        }
        public 基础记录项目(string 描述名称)
        {
            this.描述名称 = 描述名称;
        }
        public 基础记录项目(string 描述名称, System.Data.SqlDbType 存储数据类型)
        {
            this.描述名称 = 描述名称;
            this.存储数据类型 = 存储数据类型;
        }
        public 基础记录项目(string 描述名称, System.Data.SqlDbType 存储数据类型, int 存储数据大小)
        {
            this.描述名称 = 描述名称;
            this.存储数据类型 = 存储数据类型;
            this.最大长度 = 存储数据大小;
        }
    }

    public class 养护管理数据
    {
        public 桥梁组成结构 桥面系 { get; set; }
        public 桥梁组成结构 上部结构 { get; set; }
        public 桥梁组成结构 下部结构 { get; set; }
        public List<桥梁组成结构> 桥梁组成结构集合
        {
            get { return new List<桥梁组成结构>() { 桥面系, 上部结构, 下部结构 }; }
        }
        
        public 养护管理数据()
        {
            this.桥面系 = new 桥梁组成结构();
            this.上部结构 = new 桥梁组成结构();
            this.下部结构 = new 桥梁组成结构();
        }
    }

    public class 桥梁组成结构
    {
        public string 名称 { get; set; }
        public double 权重 { get; set; }
        public List<桥梁组成一级部件> 桥梁组成一级部件集合 { get; set; }
        public 桥梁组成结构()
        {
            this.桥梁组成一级部件集合 = new List<桥梁组成一级部件>();
        }
        public 桥梁组成结构(string 名称)
        {
            this.名称 = 名称;
            this.桥梁组成一级部件集合 = new List<桥梁组成一级部件>();
        }
        public 桥梁组成结构(string 名称, double 权重)
        {
            this.名称 = 名称;
            this.权重 = 权重;
            this.桥梁组成一级部件集合 = new List<桥梁组成一级部件>();
        }
        public 桥梁组成结构(string 名称, double 权重, List<桥梁组成一级部件> 桥梁组成一级部件集合)
        {
            this.名称 = 名称;
            this.权重 = 权重;
            this.桥梁组成一级部件集合 = new List<桥梁组成一级部件>();
            this.桥梁组成一级部件集合 = 桥梁组成一级部件集合;
        }
    }

    //public class 桥梁部件
    //{
    //    //待替换, to replace with 桥梁组成部件
    //    public string 部件名称 { get; set; }
    //    public int 构件数 { get; set; }
    //    public double 权重 { get; set; }
    //    public bool 是否主要部件 { get; set; }
    //    public string 记录项目指标名称集合 { get; set; }
    //    public int 检查项目指标标度序列集合 { get; set; }
    //    public 标度及其说明 检查项目指标标度及说明 { get; set; }
    //}

    public class 桥梁组成一级部件
    {
        public string 部件名称 { get; set; }
        public double 部件权重 { get; set; }
        public bool 是否主要部件 { get; set; }
        public bool IsExist { get; set; }
        public List<桥梁组成二级部件> 桥梁组成二级部件集合 { get; set; }
        public 桥梁组成一级部件()
        {
            this.桥梁组成二级部件集合 = new List<桥梁组成二级部件>();
        }
        public 桥梁组成一级部件(string 部件名称, double 部件权重, bool 是否主要部件)
        {
            this.部件名称 = 部件名称;
            this.部件权重 = 部件权重;
            this.是否主要部件 = 是否主要部件;
            this.桥梁组成二级部件集合 = new List<桥梁组成二级部件>();
        }
        public 桥梁组成一级部件(string 部件名称, double 部件权重, bool 是否主要部件, List<桥梁组成二级部件> 桥梁组成二级部件集合)
        {
            this.部件名称 = 部件名称;
            this.部件权重 = 部件权重;
            this.是否主要部件 = 是否主要部件;
            this.桥梁组成二级部件集合 = new List<桥梁组成二级部件>();
            this.桥梁组成二级部件集合 = 桥梁组成二级部件集合;
        }
    }

    public class 桥梁组成二级部件
    {
        public string 部件名称 { get; set; }
        public int 构件数 { get; set; }
        public double 部件权重 { get; set; }
        public bool IsExist { get; set; }
        public bool 是否主要部件 { get; set; }
        public List<检查指标> 检查指标集合 { get; set; }
        public 桥梁组成二级部件()
        {
            this.检查指标集合 = new List<检查指标>();
        }
    }

    public class 检查指标
    {
        public string 指标名称 { get; set; }
        public List<标度及其说明> 标度及其说明集合 { get; set; }
        public 检查项目内容 检查项目内容 { get; set; }
        public 检查指标()
        {
            this.标度及其说明集合 = new List<标度及其说明>();
        }
        public 检查指标(string 指标名称)
        {
            this.指标名称 = 指标名称;
            this.标度及其说明集合 = new List<标度及其说明>();
        }
        public 检查指标(string 指标名称, List<标度及其说明> 标度及其说明集合)
        {
            this.指标名称 = 指标名称;
            this.标度及其说明集合 = new List<标度及其说明>();
            this.标度及其说明集合 = 标度及其说明集合;
        }
        public 检查指标(string 指标名称, List<标度及其说明> 标度及其说明集合, 检查项目内容 检查项目内容)
        {
            this.指标名称 = 指标名称;
            this.标度及其说明集合 = new List<标度及其说明>();
            this.标度及其说明集合 = 标度及其说明集合;
            this.检查项目内容 = 检查项目内容;
        }
    }

    public class 标度及其说明
    {
        public int 标度 { get; set; }
        public string 定性说明 { get; set; }
        public string 定量说明 { get; set; }
        public bool 是否存在 { get; set; }
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

    public class 检查项目内容
    {
        private 检查指标存储数据结构 _是否检查 = new 检查指标存储数据结构("是否检查", System.Data.SqlDbType.NText, 5);
        public 检查指标存储数据结构 是否检查
        {
            get { return _是否检查; }
            set { _是否检查 = value; }
        }
        private 检查指标存储数据结构 _范围及程度 = new 检查指标存储数据结构("范围及程度", System.Data.SqlDbType.NText, 300);
        public 检查指标存储数据结构 范围及程度
        {
            get { return _范围及程度; }
            set { _范围及程度 = value; }
        }
        private 检查指标存储数据结构 _具体位置描述 = new 检查指标存储数据结构("具体位置描述", System.Data.SqlDbType.NText, 300);
        public 检查指标存储数据结构 具体位置描述
        {
            get { return _具体位置描述; }
            set { _具体位置描述 = value; }
        }
        private 检查指标存储数据结构 _标度 = new 检查指标存储数据结构("标度", System.Data.SqlDbType.NChar, 2);
        public 检查指标存储数据结构 标度
        {
            get { return _标度; }
            set { _标度 = value; }
        }
        private 检查指标存储数据结构 _照片 = new 检查指标存储数据结构("照片", System.Data.SqlDbType.Image);
        public 检查指标存储数据结构 照片
        {
            get { return _照片; }
            set { _照片 = value; }
        }
    }

    public class 检查指标存储数据结构
    {
        public string 描述名称 { get; set; }
        public System.Data.SqlDbType 存储数据类型 { get; set; }
        public int 存储数据大小 { get; set; }
        public 检查指标存储数据结构(string 描述名称, System.Data.SqlDbType 存储数据类型)
        {
            this.描述名称 = 描述名称;
            this.存储数据类型 = 存储数据类型;
        }
        public 检查指标存储数据结构(string 描述名称, System.Data.SqlDbType 存储数据类型, int 存储数据大小)
        {
            this.描述名称 = 描述名称;
            this.存储数据类型 = 存储数据类型;
            this.存储数据大小 = 存储数据大小;
        }
    }
}
