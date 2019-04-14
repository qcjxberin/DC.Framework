using System.Linq;
using Ding.Exceptions;
using Ding.Ui.Attributes;
using Ding.Validations;

namespace Ding.Applications.Dtos {
    /// <summary>
    /// 请求参数
    /// </summary>
    [Model]
    public abstract class RequestBase : IRequest {
        /// <summary>
        /// 验证
        /// </summary>
        public virtual ValidationResultCollection Validate() {
            var result = DataAnnotationValidation.Validate( this );
            if( result.IsValid )
                return ValidationResultCollection.Success;
            throw new Warning( result.First().ErrorMessage );
        }
    }
}
