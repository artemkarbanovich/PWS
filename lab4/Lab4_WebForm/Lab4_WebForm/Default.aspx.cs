using Lab4_WebForm.Server;
using System;
using System.Web.UI;

namespace Lab4_WebForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            button.Click += (_, ea) =>
            {
                output.Text = string.Empty;

                if (int.TryParse(x.Text, out var xProp) && int.TryParse(y.Text, out var yProp))
                    output.Text = new SimplexImplementation().Add(xProp, yProp).ToString();
                else
                    output.Text = "Invalid parameters";
            };
        }
    }
}
