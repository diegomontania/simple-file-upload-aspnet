using FileUploadInAspUsingjQuery.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUploadInAspUsingjQuery
{
    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //recebe contexto atual
            HttpContext context = HttpContext.Current;

            var upload = new EnviarArquivosServidor();
            upload.ProcessRequest(context);
        }
    }
}