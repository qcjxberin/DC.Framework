﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Ding.Offices.Excels.Enums;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Ding.Offices.Npoi.Extensions
{
    /// <summary>
    /// 工作簿<see cref="IWorkbook"/> 扩展
    /// </summary>
    public static class WorkbookExtensions
    {
        /// <summary>
        /// 获取Excel格式类型
        /// </summary>
        /// <param name="workbook">工作簿</param>
        /// <returns></returns>
        public static ExcelFormat GetExcelFormat(this IWorkbook workbook)
        {
            ExcelFormat format = ExcelFormat.None;
            switch (workbook)
            {
                case HSSFWorkbook _:
                    format = ExcelFormat.Xlsx;
                    break;
                case XSSFWorkbook _:
                    format = ExcelFormat.Xls;
                    break;
            }

            return format;
        }

        /// <summary>
        /// 获取工作表集合
        /// </summary>
        /// <param name="workbook">工作簿</param>
        /// <returns></returns>
        public static List<ISheet> GetSheets(this IWorkbook workbook)
        {
            List<ISheet> sheets=new List<ISheet>();
            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                ISheet sheet = workbook.GetSheetAt(i);
                if (sheet != null && !workbook.IsSheetHidden(i))
                {
                    sheets.Add(sheet);
                }
            }
            return sheets;
        }

        /// <summary>
        /// 获取或创建工作表
        /// </summary>
        /// <param name="workbook">工作簿</param>
        /// <param name="name">工作表名</param>
        /// <returns></returns>
        public static ISheet GetOrCreateSheet(this IWorkbook workbook, string name)
        {
            return workbook.GetSheet(name) ?? workbook.CreateSheet(name);
        }

        /// <summary>
        /// 创建工作表并进行操作
        /// </summary>
        /// <param name="workbook">工作簿</param>
        /// <param name="name">工作表名</param>
        /// <param name="action">工作表操作</param>
        /// <returns></returns>
        public static IWorkbook CreateSheet(this IWorkbook workbook, string name, Action<ISheet> action)
        {
            var sheet = workbook.GetOrCreateSheet(name);
            action?.Invoke(sheet);
            return workbook;
        }

        /// <summary>
        /// 获取或创建工作表
        /// </summary>
        /// <param name="workbook">工作簿</param>
        /// <returns></returns>
        public static ISheet GetOrCreateSheet(this IWorkbook workbook)
        {
            ISheet sheet = null;
            if (workbook.NumberOfSheets > 0)
            {
                sheet = workbook.GetSheetAt(0);
            }
            return sheet ?? workbook.CreateSheet();
        }

        /// <summary>
        /// 创建工作表并进行操作
        /// </summary>
        /// <param name="workbook">工作簿</param>
        /// <param name="action">工作表操作</param>
        /// <returns></returns>
        public static IWorkbook CreateSheet(this IWorkbook workbook, Action<ISheet> action)
        {
            var sheet = workbook.GetOrCreateSheet();
            action?.Invoke(sheet);
            return workbook;
        }

        /// <summary>
        /// 将工作簿转换成二进制文件流
        /// </summary>
        /// <param name="workbook">工作簿</param>
        /// <returns></returns>
        public static byte[] SaveToBuffer(this IWorkbook workbook)
        {
            using (var ms=new MemoryStream())
            {
                workbook.Write(ms);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 获取Xls颜色
        /// </summary>
        /// <param name="workbook">工作簿</param>
        /// <param name="color">系统颜色</param>
        /// <returns></returns>
        public static short GetXlsColour(this HSSFWorkbook workbook, Color color)
        {
            short s = 0;
            HSSFPalette palette = workbook.GetCustomPalette(); //调色板实例
            HSSFColor hssfColor = palette.FindColor(color.R, color.G, color.B);
            if (hssfColor == null)
            {
                hssfColor = palette.FindSimilarColor(color.R, color.G, color.B);
                s = hssfColor.Indexed;
            }
            else
            {
                s = hssfColor.Indexed;
            }

            return s;
        }
    }
}
