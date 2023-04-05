﻿function GuardarProducto(opcion) {
    console.log("cargado");
    event.preventDefault();
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'guardado',
        showConfirmButton: false,
        timer: 800
    }).then((result) => {
        if (result.dismiss === Swal.DismissReason.timer) {
            const formulario = document.getElementById(opcion);
            formulario.submit();

        }
    });
}

function Registrar(op1, op2, op3, idForm) {
    event.preventDefault();
    const camp1 = document.getElementById(op1).value;
    const camp2 = document.getElementById(op2).value;
    const camp3 = document.getElementById(op3).value;
    if (camp1 == "" || camp2 == "" || camp3 == "") {
        Swal.fire({
            icon: 'Error',
            title: 'Oops...',
            text: 'Algo salió mal!',
            footer: 'Campos requeridos'
        })
    } else {
        Swal.fire({
            title: '¿Quieres guardar los cambios?',
            showDenyButton: true,
            showCancelButton: true,
            confirmButtonText: 'Guardar',
            denyButtonText: `No guardar`,
            allowOutsideClick: false,
            allowEscapeKey: false
        }).then((result) => {
            if (result.isConfirmed) {
                Swal.fire({
                    title: 'Guardado!',
                    text: '',
                    icon: 'Exito',
                    allowOutsideClick: false,
                    allowEscapeKey: false
                }).then((result) => {
                    if (result.isConfirmed) {
                        const formulario = document.getElementById(idForm);
                        formulario.submit();
                    }
                });
            } else if (result.isDenied) {
                Swal.fire('Los cambios no se guardan', '', 'info');
            }
        });
    }
}

function ActualizarAlert(op) {
    event.preventDefault();
    Swal.fire({
        title: '¿Deseas actualizar?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Save',
        denyButtonText: `No guardar`,
        allowOutsideClick: false,
        allwEscapeKey: false
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: 'Guardado!',
                text: '',
                icon: 'exito',
                allowOutsideClick: false,
                allwEscapeKey: false
            }).then((result) => {
                if (result.isConfirmed) {
                    const formulario = document.getElementById(op);
                    formulario.submit();
                }
            })
        } else if (result.isDenied) {
            Swal.fire('Los cambios no se han guardado', '', 'info')
        }
    });
}

function Eliminar(opc) {
    event.preventDefault();
    Swal.fire({
        title: '¿Estas seguro?',
        text: "¡No podrás revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí, quiero eliminarlo',
        allowOutsideClick: false,
        allowEscapeKey: false
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: 'Eliminado!',
                text: 'Su registro fue eliminado',
                icon: 'success',
                allowOutsideClick: false,
                allowEscapeKey: false
            }).then((result) => {
                if (result.isConfirmed) {
                    location.href = opc.href;
                }
            });
        }
    });
}

function Ordenar(opcion) {
    event.preventDefault();
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'ORDENADO',
        showConfirmButton: false,
        timer: 800
    }).then((result) => {
        if (result.dismiss === Swal.DismissReason.timer) {
            location.href = opcion.href;
        }
    });
}

function Buscar(opcion) {
    event.preventDefault();
    let timerInterval;
    Swal.fire({
        title: 'Buscando...', html: '', timer: 600, timerProgressBar: true, didOpen: () => {
            Swal.showLoading();
            const b = Swal.getHtmlContainer().querySelector('b');
            timerInterval = setInterval(() => {
                b.textContent = Swal.getTimerLeft();
            }, 100);
        }, willClose: () => {
            clearInterval(timerInterval);
        }
    }).then((result) => {
        if (result.dismiss === Swal.DismissReason.timer) {
            const formulario = document.getElementById(opcion);
            formulario.submit();
        }
    });
}