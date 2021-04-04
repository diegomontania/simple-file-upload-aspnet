using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileUploadInAspUsingjQuery.Classes
{
    public class EnviarArquivosServidor : IHttpHandler
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