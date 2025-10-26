
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    DataTable = $('#doctortable').DataTable({
        "ajax" : { url: '/admin/doctors/getall' },
        "columns": [
            { data: 'name', "width": "20%" },
            { data: 'specialization', "width": "25%" },
            { data: 'department.name', "width": "25%" },
            { data: 'yearsofExperience', "width": "10%" },
            { data: 'appointmentFee', "width": "10%" },
            { data: 'phone', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class = "w-50 btn-group" role="group">
                    <a href="/admin/doctors/edit?id=${data}" class="btn btn-primary mx-1">Edit</a>
                    <a href="/admin/doctors/delete?id=${data}" class="btn btn-danger mx-1">Delete</a>

                    </div>`
                },
                "width": "17%"
            }
          
        ]
    });

}

     





