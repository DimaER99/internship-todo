﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="Student.WebFormsTodo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>Список задач</h1>
        <asp:Button ID="buttonAdd" runat="server" CssClass="btn btn-primary mb-2" OnClick="bAddTask_OnClick" Text="Добавить задачу" />
        <div>
            <asp:GridView ID="gvTask" runat="server" AutoGenerateColumns="false"
                AllowPaging="true"
                CssClass="table table-bordered"
                DataKeyNames="Id"
                OnRowDeleting="gvTask_RowDeleting"
                OnRowEditing="gvTask_OnRowEditing"
                OnPageIndexChanging="gvTask_PageIndexChanging">

                <PagerTemplate>
                    <nav aria-label="Page navigation example">
                        <ul class="pagination pagination-sm">
                            <li class="page-item">
                                <asp:LinkButton ID="lnkPrev" runat="server" CommandName="Page" CommandArgument="Prev"
                                    CssClass="page-link">Назад</asp:LinkButton>
                            </li>
                            <asp:PlaceHolder ID="phPages" runat="server"></asp:PlaceHolder>
                            <li class="page-item">
                                <asp:LinkButton ID="lnkNext" runat="server" CommandName="Page" CommandArgument="Next"
                                    CssClass="page-link">Вперед</asp:LinkButton>
                            </li>
                        </ul>
                    </nav>
                </PagerTemplate>

                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" />
                    <asp:BoundField DataField="Title" HeaderText="Заголовок" ReadOnly="true" />
                    <asp:BoundField DataField="Description" HeaderText="Описание" ReadOnly="true" />
                    <asp:ButtonField ButtonType="Button" HeaderText="Действие" CommandName="Edit" Text="Изменить" ControlStyle-CssClass="btn btn-primary" />
                    <asp:ButtonField ButtonType="Button" HeaderText="Действие" CommandName="Delete" Text="Удалить" ControlStyle-CssClass="btn btn-secondary " />
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
                    <asp:LinkButton ID="lbDeleteRow" runat="server" class="btn btn-primary" OnClick="lbDeleteRow_Click">Удалить</asp:LinkButton>
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Отмена</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
