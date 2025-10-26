
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    DataTable = $('#departmenttable').DataTable({
        "ajax": { url: '/admin/department/getall' },
        "columns": [
            { data: 'name' },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class = "w-50 btn-group" role="group">
                    <a href="/admin/department/edit?id=${data}" class="btn btn-primary mx-1">Edit</a>
                    <a href="/admin/department/delete?id=${data}" class="btn btn-danger mx-1">Delete</a>

                    </div>`
                },
                "width": "17%"
            }

        ]
    });
}