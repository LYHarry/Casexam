using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Rpc.Infrastructures.Extensions
{
    /// <summary>
    /// AutoMapper 扩展帮助类
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        /// 类型映射
        /// </summary>
        /// <typeparam name="TDestination">映射后的对象</typeparam>
        /// <param name="source">要映射的对象</param>
        /// <returns></returns>
        public static TDestination MapTo<TDestination>(this object source) where TDestination : class
        {
            if (source == null)
                return default(TDestination);
            var config = new MapperConfiguration(cfg => cfg.CreateMap(source.GetType(), typeof(TDestination)));
            var mapper = config.CreateMapper();
            return mapper.Map<TDestination>(source);
        }
    }
}
