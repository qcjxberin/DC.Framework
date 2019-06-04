## 使用方式
嵌入图片，部署之后访问“/captcha”，可直接加载一张图片

接口:

  1、api/captcha ：返回图片byte[]

  2、api/captcha/verify：校验验证码

## 注意

如果运行在Windows环境，是完成ok的。[System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common)是完美的解决方案。

如果现在你想要部署在Ubuntu或者Docker环境下，你需要安装 对应平台的 `GDI +`相关依赖项。

Ubuntu需要安装的依赖库如下

```
sudo apt install libc6-dev 
sudo apt install libgdiplus
```