using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zakaz.Controls
{
    public class VInput : WebControl
    {
        private string nspace = "SostZakaza.Models";
        private string model = "Zakaz";

        public string NameORG
        {
            get { return nspace; }
            set { nspace = value; }
        }
        public string Adres
        {
            get { return model; }
            set { model = value; }
        }

        public string Property { get; set; }

        protected override void RenderContents(HtmlTextWriter output)
        {

            output.AddAttribute(HtmlTextWriterAttribute.Id, Property.ToLower());
            output.AddAttribute(HtmlTextWriterAttribute.Name, Property.ToLower());

            Type modelType = Type.GetType(string.Format("{0}.{1}", NameORG, Adres));
            PropertyInfo propInfo = modelType.GetProperty(Property);
            var attr = propInfo.GetCustomAttribute<RequiredAttribute>(false);
            if (attr != null)
            {
                output.AddAttribute("data-val", "true");
                output.AddAttribute("data-val-required", attr.ErrorMessage);
            }
            output.RenderBeginTag("input");
            output.RenderEndTag();
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
        }
        public override void RenderEndTag(HtmlTextWriter writer)
        {
        }
    }
}
