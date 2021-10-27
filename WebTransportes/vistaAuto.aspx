<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vistaAuto.aspx.cs" Inherits="WebTransportes.vistaAuto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMarca" runat="server" Text="Marca: "></asp:Label>
            <asp:DropDownList ID="ddlMarca" runat="server">
            </asp:DropDownList>
            <br />
            Modelo: <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
            <br />
            Matricula: <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
            <br />
            Precio: <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <br />
            Id: <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblBuscarPorMarca" runat="server" Text="Buscar autos por marca: "></asp:Label>
            <asp:DropDownList ID="ddlBuscarAutosPorMarca" runat="server" OnSelectedIndexChanged="ddlBuscarAutosPorMarca_SelectedIndexChanged" AutoPostBack="True"> </asp:DropDownList>
            <br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        </div>

        <asp:GridView ID="gridAuto" runat="server"></asp:GridView>
        
    </form>
</body>
</html>
