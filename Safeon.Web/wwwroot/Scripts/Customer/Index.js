$(document).ready(function () {
    $('#table-customer').DataTable({
        scrollX: '100%',
        scrollY: '100%',
        scrollXInner: '100%',
        displayLength: 25,
        scrollCollapse: true,
        paging: true,
        sort: true,
        searching: true,
        destroy: true,
        serverSide: true,
        ajax: {
            url: '/Customer/Search',
            type: 'POST',
            dataType: 'json'
        },
        columns: [
            { data: 'name' },
            { data: 'document' },
            { data: 'persontype' },
            { data: 'registerDateTime' },
            { data: 'phoneNumber' },
            { data: 'id', render: function (value) { return GetButtons(value); } }
        ],
        order: [[0, 'asc']]
    });

    function GetButtons(id) {
        var buttonEdit = `<a class="btn btn-white btn-info btn-xs" title="Editar" data-rel="tooltip" data-placement="bottom" href="/Customer/Edit/${id}">
                            <i class="ace-icon fa fa-edit"></i>
                        </a>&nbsp;`;

        return `<div class="action-buttons align-center">
                    ${buttonEdit}
                </div>`;
    }
});
