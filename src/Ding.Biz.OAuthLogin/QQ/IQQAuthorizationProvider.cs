﻿using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.QQ
{
    /// <summary>
    /// QQ授权提供程序。
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public interface IQQAuthorizationProvider : IAuthorizationUrlProvider<QQAuthorizationRequest>, IAccessTokenProvider, IRefreshTokenProvider, IGetOpenIdProvider, IGetUserInfoProvider<QQAuthorizationUserInfoResult, QQAuthorizationUserRequest>
    {
    }
}
