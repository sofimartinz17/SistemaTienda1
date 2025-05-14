var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#tblPagos").DataTable({
        "ajax": {
            "url": "/admin/pagos/GetAll",  // Cambia la URL para que apunte a los pagos
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "ventaId", "width": "20%" },
            { "data": "fechaPago", "width": "25%" },
            { "data": "montoPagado", "width": "20%" },
            { "data": "metodoPago", "width": "15%" },
            {
                "data": "estado",
                "width": "10%",
                "render": function (data) {
                    return data ? "Activo" : "Inactivo";
                }
            },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="d-flex justify-content-center gap-2">
                                <a href="/Admin/Pagos/Edit/${data}" class="btn btn-success text-white" style="width:100px;">
                                    <i class="far fa-edit"></i> Editar
                                </a>
                                &nbsp;
                                <a onclick="Delete('/Admin/Pagos/Delete/${data}')" class="btn btn-danger text-white" style="width:100px;">
                                    <i class="far fa-trash-alt"></i> Borrar
                                </a>
                            </div>`;
                },
                "width": "25%"
            }
        ],
        "language": {
            "emptyTable": "No hay registros",
            "info": "Mostrando START a END de TOTAL Entradas",
            "infoEmpty": "Mostrando 0 a 0 de 0 Entradas",
            "infoFiltered": "(filtrado de MAX entradas totales)",
            "lengthMenu": "Mostrar MENU entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "¿Está seguro de borrar?",
        text: "¡Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Sí, borrar!",
        closeOnConfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                } else {
                    toastr.error(data.message);
                }
            }
        });
    });
}
