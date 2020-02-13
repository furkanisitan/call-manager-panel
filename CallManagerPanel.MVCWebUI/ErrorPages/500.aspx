<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="500.aspx.cs" Inherits="CallManagerPanel.MVCWebUI.ErrorPages._500" %>
<% Response.StatusCode = 500; %>

<!DOCTYPE html>

<html lang="tr" xml:lang="tr" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>HTTP 500 - Internal Server Error</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.1/css/bootstrap.min.css"/>
    <link href="../assets/css/error.css" rel="stylesheet" />

</head>
<body>
    <section class="error-section">
        <p class="error-section-subtitle">Dahili sunucu hatası oluştuğundan erişmeye çalıştığınız sayfa görüntülenemiyor.</p>
        <h1 class="error-title">
            <p>500</p>
            500
        </h1>
        <a href="/" class="btn">Anasayfa</a>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.1/js/bootstrap.min.js"></script>
        <script src="../assets/js/error.js"></script>
    </section>
</body>
</html>
