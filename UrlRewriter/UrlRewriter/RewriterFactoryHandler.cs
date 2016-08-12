using System;
using System.IO;
using System.Web.UI;
using System.Web;
using URLRewriter.Config;
using System.Text.RegularExpressions;

namespace URLRewriter
{
	/// <summary>
	/// Provides an HttpHandler that performs redirection.
	/// </summary>
	/// <remarks>The RewriterFactoryHandler checks the rewriting rules, rewrites the path if needed, and then
	/// delegates the responsibility of processing the ASP.NET page to the <b>PageParser</b> class (the same one
	/// used by the <b>PageHandlerFactory</b> class).</remarks>
	public class RewriterFactoryHandler : IHttpHandlerFactory
	{
		/// <summary>
		/// GetHandler is executed by the ASP.NET pipeline after the associated HttpModules have run.  The job of
		/// GetHandler is to return an instance of an HttpHandler that can process the page.
		/// </summary>
		/// <param name="context">The HttpContext for this request.请求的上下文</param>
		/// <param name="requestType">The HTTP data transfer method 请求的方法(<b>GET</b> or <b>POST</b>)</param>
		/// <param name="url">The RawUrl of the requested resource.请求文件的虚拟路径以’/‘开头的</param>
		/// <param name="pathTranslated">The physical path to the requested resource.请求文件的物理完整路径</param>
		/// <returns>An instance that implements IHttpHandler; specifically, an HttpHandler instance returned
		/// by the <b>PageParser</b> class, which is the same class that the default ASP.NET PageHandlerFactory delegates
		/// to.</returns>
		public virtual IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
		{
			// log info to the Trace object...
			context.Trace.Write("RewriterFactoryHandler", "Entering RewriterFactoryHandler");

			string sendToUrl = url;//保存请求URL的虚拟路径
			string filePath = pathTranslated;//保存请求文件的物理路径

			// get the configuration rules
			RewriterRuleCollection rules = RewriterConfiguration.GetConfig().Rules;

			// iterate through the rules
			for(int i = 0; i < rules.Count; i++)
			{
				// Get the pattern to look for (and resolve its URL)
				string lookFor = "^" + RewriterUtils.ResolveUrl(context.Request.ApplicationPath, rules[i].LookFor) + "$"; 

				// Create a regular expression object that ignores case...
				Regex re = new Regex(lookFor, RegexOptions.IgnoreCase);

				// Check to see if we've found a match
				if (re.IsMatch(url))
				{
                    //用正则把请求的虚拟路径的地址替换实际的虚拟路径地址
					// do any replacement needed
					sendToUrl = RewriterUtils.ResolveUrl(context.Request.ApplicationPath, re.Replace(url, rules[i].SendTo));
					
					// log info to the Trace object...
					context.Trace.Write("RewriterFactoryHandler", "Found match, rewriting to " + sendToUrl);

					// Rewrite the path, getting the querystring-less url and the physical file path
					string sendToUrlLessQString;
                    //重写请求的路径
					RewriterUtils.RewriteUrl(context, sendToUrl, out sendToUrlLessQString, out filePath);
                    //第一个参数是文件虚拟路径，第二个参数文件物理路径
					// return a compiled version of the page
					context.Trace.Write("RewriterFactoryHandler", "Exiting RewriterFactoryHandler");	// log info to the Trace object...
					//转到实际的页面
                    return PageParser.GetCompiledPageInstance(sendToUrlLessQString, filePath, context);
				    
                }
			}


			// if we reached this point, we didn't find a rewrite match
			context.Trace.Write("RewriterFactoryHandler", "Exiting RewriterFactoryHandler");	// log info to the Trace object...
			return PageParser.GetCompiledPageInstance(url, filePath, context);
		}

		public virtual void ReleaseHandler(IHttpHandler handler)
		{
		}
	}
}
