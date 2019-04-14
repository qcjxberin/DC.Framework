using System.Linq;
using System.Text;
using Ding.Exceptions;

namespace Ding.Validations {
    /// <summary>
    /// 验证失败，抛出异常 - 默认验证处理器
    /// </summary>
    public class ThrowHandler : IValidationHandler{
        /// <summary>
        /// 处理验证错误
        /// </summary>
        /// <param name="results">验证结果集合</param>
        public void Handle( ValidationResultCollection results ) {
            if ( results.IsValid )
                return;
            throw new Warning( results.First().ErrorMessage );
        }
    }

    /// <summary>
    /// 验证失败，抛出异常 - 针对实体验证处理器
    /// </summary>
    public class ModelThrowHandler: IValidationHandler{
        /// <summary>
        /// 处理验证错误
        /// </summary>
        /// <param name="results">验证结果集合</param>
        public void Handle( ValidationResultCollection results ) {
            if ( results.IsValid )
                return;
            var build = new StringBuilder();
            foreach(var item in results)
            {
                build.Append(item.ErrorMessage + ",");
            }
            if(build.Length > 0)
            {
                build = build.Remove(build.Length - 1, 1);
            }
            throw new Warning(build.ToString());
        }
    }
}
