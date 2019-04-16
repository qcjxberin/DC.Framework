using System.Reflection;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Ding.Helpers;
using Ding.Ui.Angular.Enums;
using Ding.Ui.Angular.Internal;
using Ding.Ui.Configs;
using Ding.Ui.Extensions;

namespace Ding.Ui.Angular.Resolvers {
    /// <summary>
    /// 标签表达式解析器
    /// </summary>
    public class LabelExpressionResolver {
        /// <summary>
        /// 初始化标签表达式解析器
        /// </summary>
        /// <param name="expression">属性表达式</param>
        /// <param name="config">配置</param>
        private LabelExpressionResolver( ModelExpression expression, IConfig config ) {
            if( expression == null || config == null )
                return;
            _expression = expression;
            _config = config;
            _memberInfo = expression.GetMemberInfo();
        }

        /// <summary>
        /// 属性表达式
        /// </summary>
        private readonly ModelExpression _expression;

        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 成员
        /// </summary>
        private readonly MemberInfo _memberInfo;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="expression">属性表达式</param>
        /// <param name="config">配置</param>
        public static void Init( ModelExpression expression, IConfig config ) {
            new LabelExpressionResolver( expression, config ).Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init() {
            _config.SetAttribute( AngularConst.BindText,Helper.GetModel( _expression,_memberInfo ) );
            InitType();
        }

        /// <summary>
        /// 根据类型初始化
        /// </summary>
        private void InitType() {
            if( Reflection.IsBool( _memberInfo ) )
                _config.SetAttribute( UiConst.Type, LabelType.Bool );
            else if( Reflection.IsDate( _memberInfo ) )
                _config.SetAttribute( UiConst.Type, LabelType.Date );
        }
    }
}
