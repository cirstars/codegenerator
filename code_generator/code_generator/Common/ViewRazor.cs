using System;
using System.IO;
using RazorEngine.Compilation;
using RazorEngine.Templating;
using Encoding = System.Text.Encoding;

namespace RC.UI.DeveloperTools.Common
{
    public class ViewRazor
    {
        public ViewRazor()
        {
            MasterMapper = "content";
        }
        /// <summary>
        /// 保存路径
        /// </summary>
        public string SaveUrl { get; set; }
        /// <summary>
        /// 母版地址
        /// </summary>
        public string MasterUrl { get; set; }
        /// <summary>
        /// 母版子页标识
        /// </summary>
        public string MasterMapper { get; set; }
        /// <summary>
        /// 模板地址
        /// </summary>
        public string TemplateUrl { get; set; }
        /// <summary>
        /// 输出编码
        /// </summary>
        public Encoding OutputEncoding { get; set; }
        /// <summary>
        /// 母版的 模型
        /// </summary>
        public dynamic BasicModel { get; set; }
        /// <summary>
        /// 生成并保存静态页面（只支持单一模板，不支持多页面嵌套）
        /// </summary>
        /// <param name="templatepath">模板地址</param>
        /// <param name="savepath">保存地址</param>
        /// <param name="encoding">编码格式</param>
        /// <param name="o">数据</param>
        /// <returns></returns>
        public static bool ModelToStaticPage<T>(string templatepath, string savepath, Encoding encoding, T o)
        {
            CompilerServiceBuilder.SetCompilerServiceFactory(new DefaultCompilerServiceFactory());
            using (var service = new TemplateService())
            {
                var index = System.IO.File.ReadAllText(templatepath, encoding);
                string result= service.Parse(index, o);
                using (FileStream stream = new FileStream(savepath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    Byte[] info = encoding.GetBytes(result);
                    stream.Write(info, 0, info.Length);
                    stream.Flush();
                    stream.Close();
                    return true;
                }
            }
        }
        /// <summary>
        /// 生成静态页(带母版)
        /// </summary>
        /// <returns></returns>
        public bool ToPage(dynamic model)
        {
            CompilerServiceBuilder.SetCompilerServiceFactory(new DefaultCompilerServiceFactory());
            using (var service = new TemplateService())
            {
                string master = System.IO.File.ReadAllText(MasterUrl, OutputEncoding);
                string content = System.IO.File.ReadAllText(TemplateUrl, OutputEncoding);
                service.Compile(content,model.GetType(), MasterMapper);
                string result = service.Parse(master, model);
                if (File.Exists(SaveUrl))
                {
                    File.Delete(SaveUrl);
                }

                using (FileStream stream = new FileStream(SaveUrl, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    Byte[] info = OutputEncoding.GetBytes(result);
                    stream.Write(info, 0, info.Length);
                    stream.Flush();
                    stream.Close();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 生成静态页（不带母版）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ToPageNoMaster(dynamic model)
        {
            CompilerServiceBuilder.SetCompilerServiceFactory(new DefaultCompilerServiceFactory());
            using (var service = new TemplateService())
            {
                var index = System.IO.File.ReadAllText(TemplateUrl, OutputEncoding);
                string result = service.Parse(index, model);
                if (File.Exists(SaveUrl))
                {
                    File.Delete(SaveUrl);
                }

                using (FileStream stream = new FileStream(SaveUrl, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    Byte[] info = OutputEncoding.GetBytes(result);
                    stream.Write(info, 0, info.Length);
                    stream.Flush();
                    stream.Close();
                    return true;
                }
            }
            return false;
        }
    }
}