<%@ Page Title="Todo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BUKEP.Student.WebFormsTodo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Список задач</h1>
        <asp:HiddenField runat="server" ID="hfSelectIndex" />
        <asp:Button ID="buttonAdd" runat="server" CssClass="btn btn-primary mb-2" OnClick="bAddTask_OnClick" Text="Добавить задачу" />
        <div>
            <asp:GridView ID="dataView" runat="server" AutoGenerateColumns="false" OnRowDeleting="lbRowDeletingTask" OnRowEditing="dataView_RowEditing" AllowPaging="true" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Заголовок" ReadOnly="true" />
                    <asp:BoundField DataField="Description" HeaderText="Описание" ReadOnly="true" />
                    <asp:ButtonField ButtonType="Button" HeaderText="Действие" CommandName="Edit" Text="Изменить" />
                    <asp:ButtonField ButtonType="Button" HeaderText="Действие" CommandName="Delete" Text="Удалить" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="modal" tabindex="-1" id="modalAddTask">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Добавление задачи</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Закрыть"></button>
                </div>
                <div class="modal-body">
                    <div class="row mb-2">
                        <div class="col-12">
                            <label>Заголовок задачи</label>
                            <asp:TextBox ID="tbAddTitle" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <label>Описание задачи</label>
                            <asp:TextBox ID="tbAddDescription" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" class="btn btn-primary" OnClick="lbSaveAddChanges_OnClick">Сохранить изменения</asp:LinkButton>
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Закрыть</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal" tabindex="-1" id="modalEditTask">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Редактирование задачи</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Закрыть"></button>
                </div>
                <div class="modal-body">
                    <div class="row mb-2">
                        <div class="col-12">
                            <label>Заголовок задачи</label>
                            <asp:TextBox ID="tbEditTitle" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-12">
                            <label>Описание задачи</label>
                            <asp:TextBox ID="tbEditDescription" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" class="btn btn-primary" OnClick="lbSaveEditChanges_OnClick">Сохранить изменения</asp:LinkButton>
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Закрыть</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal" tabindex="-1" id="modalDeleteTask">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Подтверждение удаления задачи</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Закрыть"></button>
                </div>
                <div class="modal-body">
                    <div class="row mb-2">
                        <div class="col-12">
                            <h4>Вы хотите удалить задачу?</h4>
                        </div>
                    </div>
                    <h5>Если вы действительно хотите удалить задачу нажмите "Удалить", иначе "Отмена".</h5>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" class="btn btn-primary" OnClick="lbEditDeleteTask_OnClick">Удалить</asp:LinkButton>
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Отмена</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
