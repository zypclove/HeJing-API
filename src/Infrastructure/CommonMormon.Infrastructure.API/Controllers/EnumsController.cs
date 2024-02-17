using CommonMormon.Infrastructure.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CommonMormon.Infrastructure.API.Controllers;

/// <summary>
/// 审计日志
/// </summary>
[Area("common")]
public class EnumsController : AppControllerBase
{

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="service"></param>
    public EnumsController(IServiceProvider serviceProvider) :
        base(serviceProvider)
    {
    }

    /// <summary>
    /// 获取枚举集合
    /// </summary>
    /// <param name="enumName"></param>
    /// <returns></returns>
    [HttpGet]
    public ApiResult<List<KeyValuePair<int, string>>> GetEnums(string enumName)
    {
        var assemblyStrings = Configuration.GetSection("EnumAssemblyStrings").Get<string[]>();
        foreach(var assemblyString in assemblyStrings)
        {
            //加载枚举所在命名空间程序集
            var assembly = Assembly.Load(assemblyString);

            //判断该字符串是否为枚举名称
            var enumType = assembly.GetTypes().First(t => t.Name.Equals(enumName, StringComparison.OrdinalIgnoreCase) && t.IsEnum);

            if (enumType == null)
                return Failure<List<KeyValuePair<int, string>>>("不是有效枚举类");

            //获取枚举内容
            var result = EnumHelper.GetEnums(enumType);
            return Success(result);
        }
        return Failure<List<KeyValuePair<int, string>>>("没有找到枚举类");
    }
}