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

        /// <summary>
        /// Step1：获取Authorization Code
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<string> AuthorizationHref(WeChat_Authorization_RequestEntity entity);

        /// <summary>
        /// Step2：通过Authorization Code获取Access Token、openid
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<WeChat_AccessToken_ResultEntity> AccessToken(WeChat_AccessToken_RequestEntity entity);

        /// <summary>
        /// Step3：获取用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<WeChat_OpenId_get_user_info_ResultEntity> Get_User_Info(WeChat_OpenAPI_RequestEntity entity);

        /// <summary>
        /// 请求授权地址
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<string> AuthorizeHref(GitHub_Authorize_RequestEntity entity);

        /// <summary>
        /// 获取 access token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<GitHub_AccessToken_ResultEntity> AccessToken(GitHub_AccessToken_RequestEntity entity);

        /// <summary>
        /// 获取 用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<GitHub_User_ResultEntity> User(GitHub_User_RequestEntity entity);

        /// <summary>
        /// 请求授权地址
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<string> AuthorizeHref(MicroSoft_Authorize_RequestEntity entity);

        /// <summary>
        /// 获取 access token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<MicroSoft_AccessToken_ResultEntity> AccessToken(MicroSoft_AccessToken_RequestEntity entity);

        /// <summary>
        /// 获取 用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<MicroSoft_User_ResultEntity> User(MicroSoft_User_RequestEntity entity);

        /// <summary>
        /// Step1：请求用户授权Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<string> AuthorizeHref(Taobao_Authorize_RequestEntity entity);

        /// <summary>
        /// Step2：获取授权过的Access Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Taobao_AccessToken_ResultEntity> AccessToken(Taobao_AccessToken_RequestEntity entity);

        /// <summary>
        /// Step1：请求用户授权Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<string> AuthorizeHref(Weibo_Authorize_RequestEntity entity);

        /// <summary>
        /// Step2：获取授权过的Access Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Weibo_AccessToken_ResultEntity> AccessToken(Weibo_AccessToken_RequestEntity entity);

        /// <summary>
        /// Step3：查询用户access_token的授权相关信息，包括授权时间，过期时间和scope权限。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Weibo_GetTokenInfo_ResultEntity> GetTokenInfo(Weibo_GetTokenInfo_RequestEntity entity);

        /// <summary>
        /// Step4：根据用户ID获取用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Weibo_UserShow_ResultEntity> UserShow(Weibo_UserShow_RequestEntity entity);
    }
}
