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

        public static void AddChild(Control parent, Control child)
        {
            parent.Controls.Add(child);
        }
        public static void AddChild(HtmlGenericControl parent, Control child)
        {
            parent.Controls.Add(child);
        }
        public static void AddChild(Control parent, HtmlGenericControl child)
        {
            parent.Controls.Add(child);
        }
        public static void AddChild(HtmlGenericControl parent, HtmlGenericControl child)
        {
            parent.Controls.Add(child);
        }
        public static ImageButton CreateNewImage(string cssClass, string id, string src, string alt, string[] attrs, string[] values)
        {
            var newImage = new ImageButton { CssClass = cssClass, ID = id, AlternateText = alt, ImageUrl = src};
            var c = 0;
            foreach (var attr in attrs)
            {
                newImage.Attributes.Add(attr,values[c++]);
            }
            return newImage;
        }
        public static ImageButton CreateNewImage(string cssClass, string id, string src, string[] attrs, string[] values)
        {
            var newImage = new ImageButton { CssClass = cssClass, ID = id, ImageUrl = src };
            var c = 0;
            foreach (var attr in attrs)
            {
                newImage.Attributes.Add(attr, values[c++]);
            }
            return newImage;
        }

        public static ImageButton CreateNewImage(string cssClass, string id, string src, string alt)
        {
            var newImage = new ImageButton { CssClass = cssClass, ID = id, AlternateText = alt, ImageUrl = src };
            return newImage;
        }
        public static ImageButton CreateNewImage(string cssClass, string id, string src)
        {
            var newImage = new ImageButton { CssClass = cssClass, ID = id, ImageUrl = src };
            return newImage;
        }
        public static LinkButton CreateNewLButton(string cssClass, string id, string text, string[] attrs, string[] values)
        {
            var newButton = new LinkButton { CssClass = cssClass, ID = id, Text = text};
            var c = 0;
            foreach (var attr in attrs)
            {
                newButton.Attributes.Add(attr, values[c++]);
            }
            return newButton;
        }

        public static LinkButton CreateNewLButton(string cssClass, string id, string text)
        {
            var newButton = new LinkButton { CssClass = cssClass, ID = id, Text = text};
            return newButton;
        }
        public static TextBox CreateNewTextBox(string cssClass, string id, string text)
        {
            var newTextBox = new TextBox() { CssClass = cssClass, ID = id, Text = text };
            return newTextBox;
        }
        public static TextBox CreateNewTextBox(string cssClass, string id, string text, string[] attrs, string[] values)
        {
            var newTextBox = new TextBox() { CssClass = cssClass, ID = id, Text = text };
            var c = 0;
            foreach (var attr in attrs)
            {
                newTextBox.Attributes.Add(attr, values[c++]);
            }
            return newTextBox;
        }
    }
}