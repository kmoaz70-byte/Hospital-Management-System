
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    DataTable = $('#patienttable').DataTable({
        "ajax": { url: '/admin/patient/getall' },
        "columns": [
            { data: 'name',"width" : "20%" },
            { data: 'age', "width": "10%" },
            { data: 'bloodGroup', "width": "10%" },
            { data: 'gender', "width": "10%" },
            { data: 'phone', "width": "15%" },
            { data: 'emergencyContact', "width": "15%" },
            { data: 'address', "width": "20%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class = "w-50 btn-group" role="group">
                    <a href="/admin/patient/edit?id=${data}" class="btn btn-primary mx-1">Edit</a>
                    <a href="/admin/patient/delete?id=${data}" class="btn btn-danger mx-1">Delete</a>

                    </div>`
                },
                "width": "17%"
            }

        ]
    });
}
