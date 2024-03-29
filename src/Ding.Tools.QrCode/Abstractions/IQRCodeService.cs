﻿using Ding.QRCode.Core;
using Ding.QRCode.Enums;
using System.IO;

namespace Ding.QRCode.Abstractions
{
    /// <summary>
    /// 二维码服务
    /// </summary>
    public interface IQRCodeService
    {
        /// <summary>
        /// 设置二维码参数
        /// </summary>
        /// <param name="param">二维码参数</param>
        /// <returns></returns>
        IQRCodeService Param(QRCodeParam param);

        /// <summary>
        /// 转换成流
        /// </summary>
        /// <returns></returns>
        Stream ToStream();

        /// <summary>
        /// 转换成字节数组
        /// </summary>
        /// <returns></returns>
        byte[] ToBytes();

        /// <summary>
        /// 转换成Base64字符串
        /// </summary>
        /// <returns></returns>
        string ToBase64String();

        /// <summary>
        /// 转换成Base64字符串，并附带前缀
        /// </summary>
        /// <param name="type">图片类型</param>
        /// <returns></returns>
        string ToBase64String(Base64ImageType type);

        /// <summary>
        /// 写入到文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        string WriteToFile(string path);
    }
}
