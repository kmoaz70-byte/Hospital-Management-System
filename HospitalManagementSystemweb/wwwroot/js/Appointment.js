var DataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    DataTable = $('#appo').DataTable({
        "ajax" : { url: '/user/appointment/getall' },
        "columns": [
            { data: 'patient.name', "width": "15%" },
            { data: 'doctor.name', "width": "15%" },
            { data: 'number', "width": "10%" },
            { data: 'status', "width": "10%" },
            { data: 'date', "width": "17%" },
            { data: 'time', "width": "16%" },
            {
                data: 'id',
                "render": function (data)
                {
                    return `<div class = "w-50 btn-group" role="group">
                    <a href="/user/appointment/edit?id=${data}" class="btn btn-primary mx-1">Edit</a>
                    <a href="/user/appointment/delete?id=${data}" class="btn btn-danger mx-1">Delete</a>

                    </div>`
                },
                "width": "17%"
            }
        ]
    });
   
    
 
}


