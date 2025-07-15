
var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#myNewTable').DataTable({
        "ajax": { url: '/admin/flat/getall' },
        "columns": [
            { data: 'flatId', "width": "10%" },
            { data: 'floor.floorName', "width": "15%" },
            { data: 'flatName', "width": "20%" },
            { data: 'flatSize', "width": "15%" }, 
            { data: 'flatRent', "width": "15%" },
            
            {
                data: 'flatId',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                           <a href="/admin/flat/Upsert/${data}"" class='btn btn-primary mx-2'><i class="bi bi-pencil-square"></i>Edit</a>
                           <a onClick= Delete('/admin/flat/Delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i>Delete</a>  
                    </div>`
                },
                "width": "25%"
            }
           
        ]
    });
}
function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    dataTable.ajax.reload();
                        toastr.success(data.message);


                }

            })
        }
    })
}

//function loadDataTable() {
//    dataTable = $('#myNewTable').DataTable({
//        "ajax": {
//            url: '/admin/flat/getall',
//            dataSrc: "" // assuming the response is an array of objects
//        },
//        "columns": [
//            { data: 'flatId', "width": "15%" },
//            {
//                data: 'floor',
//                "width": "15%",
//                render: function (data, type, row) {
//                    // Safely access nested field, return a default value if undefined
//                    return data && data.floorName ? data.floorName : 'N/A';
//                }
//            },
//            { data: 'flatName',  "width": "15%" },
//            { data: 'flatSize', "width": "15%" },
//            { data: 'flatRent', "width": "15%" }
//        ]
//    });
//}