using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentvalidationDemoConsoles
{
    public static class ValidationCommon
    {
        /// <summary>
        /// 处理校验结果
        /// </summary>
        /// <param name="results"></param>
        public static void Check(this ValidationResult results)
        {
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("属性： " + failure.PropertyName + " 校验失败，错误信息：" + failure.ErrorMessage);
                }
            }
        }
    }
}
