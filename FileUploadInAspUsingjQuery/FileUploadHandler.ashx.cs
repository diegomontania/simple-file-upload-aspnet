using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Web.Script.Serialization;
namespace FileUploadInAspUsingjQuery
{
    //https://www.codehandbook.org/jquery-file-upload-asp-net-csharp/
    //https://stackoverflow.com/questions/42965632/how-to-create-jquery-fileupload-with-asp-net-c-sharp-included-crud-not-mvc
    //https://forums.asp.net/t/2150514.aspx?Jquery+File+Upload
    /// <summary>
    /// Summary description for FileUploadHandler
    /// </summary>
    public class FileUploadHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var arquivosEnviados = context.Request.Files;
            var caminhoFinal = HttpContext.Current.Server.MapPath("Upload");

            try
            {
                //se o diretorio não existir, crie
                if (!Directory.Exists(caminhoFinal))
                    Directory.CreateDirectory(caminhoFinal);

                //para cada arquivo enviado, faça o upload
                foreach (string arquivo in arquivosEnviados)
                {
                    //recebe o arquivo enviado
                    var arquivoAtual = context.Request.Files[arquivo];

                    //caminho onde será armazenado o arquivo e salvando
                    arquivoAtual.SaveAs(caminhoFinal + "\\" + arquivoAtual.FileName);

                    //escreve no html
                    context.Response.Write("<b>File: </b>" + arquivoAtual.FileName + " <b>Size:</b> " + arquivoAtual.ContentLength + " <b>Type:</b> " + arquivoAtual.ContentType + " Uploaded Successfully <br/>");
                    #region
                    //context.Response.AddHeader("Vary", "Accept");
                    //try
                    //{
                    //    if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
                    //        context.Response.ContentType = "application/json";
                    //    else
                    //        context.Response.ContentType = "text/plain";
                    //}
                    //catch
                    //{
                    //    context.Response.ContentType = "text/plain";
                    //}

                    //context.Response.Write("successo ao fazer upload do arquivo");
                    #endregion
                }
            }
            catch (Exception exp)
            {
                context.Response.Write(exp.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}