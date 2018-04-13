<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Startseite
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData["Message"] %></h2>
    <table id="list" class="scroll" cellpadding="0" cellspacing="0"></table>
    <div id="pager" class="scroll" style="text-align:center;"></div>
    <script src="../../Scripts/jqgrid/src/grid.subgrid.js" type="text/javascript"></script>

    <table id='PostList'></table><div id='PostList_pager'></div>
    <script type='text/javascript'>
        jQuery(document).ready(function () {
            jQuery('#PostList').jqGrid({

                url: '/Home/PostList/',
                datatype: 'json',
                mtype: 'GET',
                colNames: ['Id', 'Title', 'Text', 'PostedAt', 'BlogId', 'UserId'],
                colModel:
                    [
                        { name: 'Id', index: 'Id', width: 60, align: 'left' },
                        { name: 'Title', index: 'Title', width: 200, align: 'left' },
                        { name: 'Text', index: 'Text', width: 200, align: 'left', sortable: false },
                        { name: 'PostedAt', index: 'PostedAt', width: 75, align: 'left' },
                        { name: 'BlogId', index: 'BlogId', width: 60, align: 'left' },
                        { name: 'UserId', index: 'UserId', width: 75, align: 'left' },
                    ],
                pager: jQuery('#PostList_pager'),
                rowNum: 25,
                rowList: [5, 10, 25, 50],
                height: 'auto',
                width: '950',
                sortname: 'ID',
                sortorder: "ASC",
                viewrecords: true,
                multiselect: false,
                subGrid: true,
                subGridRowExpanded: function(subgrid_id, row_id) {
                            var subgrid_table_id;
                            subgrid_table_id = subgrid_id+"_t";
                            jQuery("#"+subgrid_id).html("<table id='"+subgrid_table_id+"' class='scroll'></table>");
                            jQuery("#"+subgrid_table_id).jqGrid({
                                url: '/Home/BlogList/' + row_id,
                                datatype: 'json',
                                colNames: ['Id', 'Title', 'Subtitle', 'AllowsComments', 'CreatedAt'],
                                colModel:
                                    [
                                        { name: 'Id', index: 'Id', width: 60, align: 'left' },
                                        { name: 'Title', index: 'Title', width: 200, align: 'left' },
                                        { name: 'Subtitle', index: 'Subtitle', width: 200, align: 'left', sortable: false },
                                        { name: 'AllowsComments', index: 'AllowsComments', width: 75, align: 'left' },
                                        { name: 'CreatedAt', index: 'CreatedAt', width: 60, align: 'left' },
                                    ]
                                });
                }                
            })
            jQuery("#PostList").jqGrid('navGrid', '#PostList_pager', { add: false, edit: false, del: false, search: false })
        })
    </script>
</asp:Content>
