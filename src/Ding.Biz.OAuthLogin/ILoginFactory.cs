using System.Threading.Tasks;

namespace Ding.Biz.OAuthLogin
{
    /// <summary>
    /// 登录工厂
    /// </summary>
    public interface ILoginFactory
    {
        /// <summary>
        /// Step1：获取Authorization Code
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<string> AuthorizationHref(QQ_Authorization_RequestEntity entity);

        /// <summary>
        /// Step2：通过Authorization Code获取Access Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<QQ_AccessToken_ResultEntity> AccessToken(QQ_AccessToken_RequestEntity entity);

        /// <summary>
        /// Step3：获取用户OpenId
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<QQ_OpenId_ResultEntity> OpenId(QQ_OpenId_RequestEntity entity);

        /// <summary>
        /// Step4：获取用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<QQ_OpenId_get_user_info_ResultEntity> OpenId_Get_User_Info(QQ_OpenAPI_RequestEntity entity);
    }
}
