using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.UI.DeveloperTools.Common
{
    public static class FieldCommon
    {
        /// <summary>
        /// 获取当前字段的C#类型
        /// </summary>
        /// <returns></returns>
        public static string GetCShareType(string TypeName)
        {
            string type = string.Empty;
            switch (TypeName.ToUpper())
            {
                case "TEXT":
                case "NTEXT":
                case "VARCHAR":
                case "CHAR":
                case "NVARCHAR":
                case "NCHAR":
                    type = "string";
                    break;
                case "BIT":
                    type = "bool";
                    break;
                case "TINYINT":
                    type = "Byte";
                    break;
                case "SMALLINT":
                    type = "short";
                    break;
                case "INT":
                    type = "int";
                    break;
                case "BIGINT":
                    type = "long";
                    break;
                case "REAL":
                    type = "float";
                    break;
                case "FLOAT":
                    type = "double";
                    break;
                case "MONEY":
                case "DECIMAL":
                case "NUMERIC":
                    type = "decimal";
                    break;
                case "DATETIME":
                case "DATE":
                    type = "DateTime";
                    break;
                case "IMAGE":
                case "BINARY":
                    type = "byte[]";
                    break;
            }
            return type;
        }

        /// <summary>
        /// 字段可为空时需要加?的
        /// </summary>
        /// <returns></returns>
        public static bool IsNullableType(string TypeName)
        {
            return new List<string>()
            {
                "NUMERIC",
                "MONEY",
                "DATETIME",
                "DATE",
                "BIT",
                "TINYNIT",
                "SMALLNIT",
                "BIGINT",
                "REAL",
                "INT",
                "FLOAT",
                "BINARY"
            }.Contains(TypeName.ToUpper());
        }

        ///// <summary>
        ///// 获取是否可以为空字符串
        ///// </summary>
        ///// <returns></returns>
        //private string GetNullableString()
        //{
        //    return !IsNullable ? ",Required," : string.Empty;
        //}

        /// <summary>
        /// 获取字段最大长度
        /// </summary>
        /// <returns></returns>
        public static int GetMaxLength(string TypeName, int MaxLength)
        {
            if (IsString(TypeName))
            {
                switch (TypeName.ToUpper())
                {
                    case "NCHAR":
                    case "NVARCHAR":
                        return MaxLength / 2;
                }
            }
            return MaxLength;
        }

        /// <summary>
        /// 字段是否为需要标识长度
        /// </summary>
        /// <returns></returns>
        public static bool IsString(string TypeName)
        {
            return new List<string>()
                {
                    "NCHAR",
                    "NVARCHAR",
                    "CHAR",
                    "VARCHAR"
                }.Contains(TypeName.ToUpper());
        }
    }
}
