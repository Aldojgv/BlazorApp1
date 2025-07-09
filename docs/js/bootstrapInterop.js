window.bootstrapInterop = {
    mostrarModal: function (id) {
        const modalElement = document.getElementById(id);
        if (modalElement) {
            let modal = bootstrap.Modal.getInstance(modalElement);
            if (!modal) {
                modal = new bootstrap.Modal(modalElement);
            }
            modal.show();
        } else {
            console.warn(`No se encontró ningún modal con id='${id}'`);
        }
    },
    cerrarModal: function (id) {
        const modalElement = document.getElementById(id);
        const modal = bootstrap.Modal.getInstance(modalElement);
        if (modal) {
            modal.hide();
        } else {
            console.warn(`El modal con id='${id}' no está inicializado o no existe.`);
        }
    }
};
