var dataTable;

$(document).ready(function () {
    cargarDatatable();
});

function cargarDatatable() {
    dataTable = $("#tblProductos").DataTable({
        ajax: {
            url: "/admin/productos/GetAll",
            type: "GET",
            "datatype": "json"
        },
        columns: [
            { data: "id", width: "5%" },
            { data: "nombre", width: "15%" },
            { data: "numeroPlaca", width: "10%" },
            { data: "descripcion", width: "10%" },
            { data: "precio", width: "10%" },       
            { data: "modelo", width: "10%" },       
            { data: "año", width: "10%" },          
            { data: "colorDisponible", width: "10%" }, 
            { data: "categoria.nombre", width: "10%" },
            {
                data: "urlImagen",
                render: function (imagen) {
                    return `<img src="${imagen}" width="120" alt="Imagen del producto"/>`;
                },
                width: "15%"
            },
            { data: "fechaCreacion", width: "15%" },
            {
                data: "id",
                render: function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/Productos/Edit/${data}" class="btn btn-success text-white" style="width:100px;">
                                <i class="far fa-edit"></i> Editar
                            </a>
                            &nbsp;
                            <a onclick="Delete('/Admin/Productos/Delete/${data}')" class="btn btn-danger text-white" style="width:100px;">
                                <i class="far fa-trash-alt"></i> Borrar
                            </a>
                        </div>`;
                },
                width: "30%"
            }
        ],
        language: {
            emptyTable: "No hay registros",
            info: "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            infoEmpty: "Mostrando 0 a 0 de 0 Entradas",
            infoFiltered: "(filtrado de _MAX_ entradas totales)",
            lengthMenu: "Mostrar _MENU_ entradas",
            loadingRecords: "Cargando...",
            processing: "Procesando...",
            search: "Buscar:",
            zeroRecords: "Sin resultados encontrados",
            paginate: {
                first: "Primero",
                last: "Último",
                next: "Siguiente",
                previous: "Anterior"
            }
        },
        width: "100%"
    });
}

function Delete(url) {
    swal({
        title: "¿Está seguro de borrar?",
        text: "¡Este contenido no se puede recuperar!",
        icon: "warning",
        buttons: {
            cancel: "Cancelar",
            confirm: {
                text: "Sí, borrar!",
                closeModal: true
            }
        },
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message || "Ocurrió un error al intentar borrar.");
                    }
                },
                error: function () {
                    toastr.error("Error al conectar con el servidor.");
                }
            });
        }
    });
}
