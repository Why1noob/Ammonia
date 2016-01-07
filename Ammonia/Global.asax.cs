using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ammonia
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-1.4.2.min.js",
                DebugPath = "~/Scripts/jquery-1.4.2.js",
                CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js",
                CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js"
            };
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public static Panel CreateNewPanel(string cssClass, string id, string innerText, string styleProperty, string styleValue)
        {
            var newPanel = new Panel {CssClass = cssClass, ID = id};
            newPanel.Controls.Add(new LiteralControl(innerText));
            if(!string.IsNullOrEmpty(styleProperty))
            newPanel.Style.Add(styleProperty,styleValue);
            return newPanel;
        }

        public static Panel CreateNewPanel(string cssClass, string id, string innerText)
        {
            var newPanel = new Panel { CssClass = cssClass, ID = id };
            newPanel.Controls.Add(new LiteralControl(innerText));
            return newPanel;
        }

        public static HtmlGenericControl CreateNewHtmlControl(string tag, string cssClass, string id, string innerText,
            string attrProperty, string attrValue)
        {
            var newHtmlControl = new HtmlGenericControl(tag) {InnerHtml = innerText, ID = id};
            newHtmlControl.Attributes["class"] = cssClass;
            if(!string.IsNullOrEmpty(attrProperty))
                newHtmlControl.Attributes.Add(attrProperty,attrValue);
            return newHtmlControl;
        }

        public static void AddChild(Panel parent, Panel child)
        {
            parent.Controls.Add(child);
        }
        public static void AddChild(HtmlGenericControl parent, Panel child)
        {
            parent.Controls.Add(child);
        }
        public static void AddChild(Panel parent, HtmlGenericControl child)
        {
            parent.Controls.Add(child);
        }
        public static void AddChild(HtmlGenericControl parent, HtmlGenericControl child)
        {
            parent.Controls.Add(child);
        }
    }
}