using System;
using System.Collections.Generic;

namespace UltraNuke.CommonMormon.DDD
{
    public abstract class TreeAggregateRoot<T> : AggregateRoot where T : TreeAggregateRoot<T>
    {
        #region Public Properties
        /// <summary>
        /// 序号
        /// </summary>
        public virtual int No { get; protected set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; protected set; }
        /// <summary>
        /// 全名
        /// </summary>
        public virtual string FullName
        {
            get
            {
                return getFullName(this);
            }
            protected set { }
        }
        /// <summary>
        /// 全路径
        /// </summary>
        public virtual string FullPath
        {
            get
            {
                return getFullPath(this);
            }
            protected set { }
        }
        /// <summary>
        /// 说明
        /// </summary>
        public virtual string Description { get; protected set; }
        /// <summary>
        /// 父节点
        /// </summary>
        public virtual T ParentNode { get; protected set; }
        public virtual Guid? ParentNodeId { get; protected set; }
        /// <summary>
        /// 子节点集合
        /// </summary>
        public virtual IList<T> ChildNodes { get; protected set; }
        /// <summary>
        /// 是否根节点
        /// </summary>
        public virtual bool IsRootNode
        {
            get
            {
                if (this.ParentNodeId == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            protected set { }
        }
        /// <summary>
        /// 是否页节点
        /// </summary>
        public virtual bool IsLeafNode
        {
            get
            {
                if (this.ChildNodes == null || this.ChildNodes.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            protected set { }
        }
        /// <summary>
        /// 树层数
        /// </summary>
        public virtual int Level
        {
            get
            {
                return getLevel(this);
            }
            protected set { }
        }

        /// <summary>
        /// 全树排序号
        /// </summary>
        public virtual double FullSortNo
        {
            get
            {
                return getFullSortNo(this);
            }
            protected set { }
        }

        /// <summary>
        /// 全树排序号
        /// </summary>
        public void SetChildNodes(IList<T> childNodes)
        {
            this.ChildNodes = childNodes;
        }
        #endregion

        #region Private Methods
        private int getLevel(TreeAggregateRoot<T> node)
        {
            int level = 0;
            if (node.ParentNode == null)
                return 0;
            else
            {
                level = getLevel(node.ParentNode);
                return level + 1;
            }
        }

        private double getFullSortNo(TreeAggregateRoot<T> node)
        {
            double finalSortNo = node.No;
            if (node.ParentNode == null)
                return finalSortNo;
            else
            {
                finalSortNo = getFullSortNo(node.ParentNode);
                return finalSortNo + Math.Pow(0.01, node.Level) * node.No;
            }
        }

        private string getFullName(TreeAggregateRoot<T> node)
        {
            string fullName = node.Name;
            if (node.ParentNode == null)
                return fullName;
            else
            {
                fullName = getFullName(node.ParentNode);
                return fullName + "." + node.Name;
            }
        }

        private string getFullPath(TreeAggregateRoot<T> node)
        {
            string fullPath = node.Id.ToString();
            if (node.ParentNode == null)
                return fullPath;
            else
            {
                fullPath = getFullPath(node.ParentNode);
                return fullPath + "." + node.Id.ToString();
            }
        }
        #endregion
    }
}
