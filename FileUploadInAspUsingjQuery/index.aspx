<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FileUploadInAspUsingjQuery.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Upload Demo</title>
    <style>
        #progressbar
        {
            background-color: black;
            background-repeat: repeat-x;
            border-radius: 13px; /* (height of inner div) / 2 + padding */
            padding: 3px;
        }
        
        #progressbar > div
        {
            background-color: orange;
            width: 0%; /* Adjust with JavaScript */
            height: 20px;
            border-radius: 10px;
            color: white;
        }
    </style>
    <script src="Scripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="Scripts/jquery.iframe-transport.js" type="text/javascript"></script>
    <script src="Scripts/jquery.fileupload.js" type="text/javascript"></script>
    <script src="Scripts/upload.js" type="text/javascript"></script>
</head>
    <body>

        <!--utilizando asp forms e c#-->
        <br/>
        <form id="form1" runat="server">
            <asp:FileUpload accept=".csv" ID="FileUpload1" runat="server" multiple="multiple"/>
            <asp:Button ID="btnUpload" runat="server" Text="Enviar Arquivos web forms" onclick="btnUpload_Click" /> 
        </form><br/><br/>

        <!--utilizando Jquery e GenericHandler-->
        <div id="divJquery"> 
            <input id="fileUploadField" type="file" accept=".csv" name="file[]" multiple="multiple"/>
            <button id="btnUploadJquery" type="button">Enviar Arquivos Jquery</button>
            <br /><br />

            <div id="progressbar" style="width:100px;display:none;">
                <div>
                    Looading :D
                </div>
            </div>
        </div>

    </body>
</html>
