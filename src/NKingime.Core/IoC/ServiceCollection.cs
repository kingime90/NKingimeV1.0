using System;
using System.Collections;
using System.Collections.Generic;

namespace NKingime.Core.IoC
{
    /// <summary>
    /// 依赖注入映射描述信息集合。
    /// </summary>
    public class ServiceCollection : IServiceCollection
    {
        /// <summary>
        /// 初始化一个<see cref="ServiceCollection"/>新实例。
        /// </summary>
        public ServiceCollection()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IList<ServiceDescriptor> _descriptors = new List<ServiceDescriptor>();

        /// <summary>
        /// 获取或设置指定索引处的元素。
        /// </summary>
        /// <param name="index">要获得或设置的元素从零开始的索引。</param>
        /// <returns></returns>
        public ServiceDescriptor this[int index]
        {
            get
            {
                return _descriptors[index];
            }
            set
            {
                _descriptors[index] = value;
            }
        }

        /// <summary>
        /// 获取集合中包含的元素数。
        /// </summary>
        public int Count
        {
            get
            {
                return _descriptors.Count;
            }
        }

        /// <summary>
        /// 获取一个值，该值指示集合是否为只读。
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 将某项添加到集合中。
        /// </summary>
        /// <param name="item"></param>
        public void Add(ServiceDescriptor item)
        {
            _descriptors.Add(item);
        }

        /// <summary>
        /// 从集合中移除所有项。
        /// </summary>
        public void Clear()
        {
            _descriptors.Clear();
        }

        /// <summary>
        /// 确定集合是否包含特定值。
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(ServiceDescriptor item)
        {
            return _descriptors.Contains(item);
        }

        /// <summary>
        /// 从特定的 System.Array 索引处开始，将集合的元素复制到一个 System.Array中。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
        {
            _descriptors.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// 返回一个循环访问集合的枚举器。
        /// </summary>
        /// <returns></returns>
        public IEnumerator<ServiceDescriptor> GetEnumerator()
        {
            return _descriptors.GetEnumerator();
        }

        /// <summary>
        /// 确定集合中特定项的索引。
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(ServiceDescriptor item)
        {
            return _descriptors.IndexOf(item);
        }

        /// <summary>
        /// 将一个项插入指定索引处的集合中。
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, ServiceDescriptor item)
        {
            _descriptors.Insert(index, item);
        }

        /// <summary>
        /// 从集合中移除特定对象的第一个匹配项。
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(ServiceDescriptor item)
        {
            return _descriptors.Remove(item);
        }

        /// <summary>
        /// 移除指定索引处的集合项。
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            _descriptors.RemoveAt(index);
        }

        /// <summary>
        /// 返回一个循环访问集合的枚举器。
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// 克隆创建当前集合的副本。
        /// </summary>
        /// <returns></returns>
        public IServiceCollection Clone()
        {
            IServiceCollection descriptors = new ServiceCollection();
            foreach (ServiceDescriptor item in this)
            {
                descriptors.Add(item);
            }
            return descriptors;
        }
    }
}
