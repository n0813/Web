function Validar() {
    return Swal.fire({
        title: "Desea eliminar el registro?",
        text: "Desea eliminar la informacion en la base de datos",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si!'
    })
}



function Alerta() {
    return Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'Cambios guardados exitosamente!',
        showConfirmButton: false,
        timer: 1500
    })
}