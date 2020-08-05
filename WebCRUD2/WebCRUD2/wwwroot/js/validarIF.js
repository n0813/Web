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