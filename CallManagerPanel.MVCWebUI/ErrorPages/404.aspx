<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="CallManagerPanel.MVCWebUI.ErrorPages._404" %>

<% Response.StatusCode = 404; %>

<!DOCTYPE html>

<html lang="tr" xml:lang="tr" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>HTTP 404 - NotFound</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.1/css/bootstrap.min.css"/>
    <link href="../assets/css/error.css" rel="stylesheet" />
</head>
<body>
    <section class="error-section">
        <p class="error-section-subtitle">Aradığınız sayfa bulunmamaktadır ya da kaldırılmıştır.</p>
        <h1 class="error-title">
            <p>404</p>
            404
        </h1>
        <a href="/" class="btn">Anasayfa</a>
    </section>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.1/js/bootstrap.min.js"></script>
    <script src="../assets/js/error.js"></script>

</body>
</html>
