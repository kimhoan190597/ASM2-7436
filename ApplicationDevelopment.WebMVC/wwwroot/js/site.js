let buttonOpenModal = document.getElementById("buttonOpenModal");

const modalSizes = {
    small: "modal-sm",
    medium: "",
    large: "modal-lg",
    extraLarge: "modal-xl",
}

/**
         * Mở Modal hiển thị nội dung.
         */
function openModal(title, body, size = modalSizes.medium) {
    let divModalTitle = document.getElementById("divModalTitle");
    if (divModalTitle) {
        divModalTitle.innerHTML = title;
    }
    let divModalBody = document.getElementById("divModalBody");
    if (divModalBody) {
        divModalBody.innerHTML = body;
    }
    if (size != modalSizes.medium) {
        let divModalDialog = document.getElementById("divModalDialog");
        if (divModalDialog) {
            // console.log("Test Class List: ", divModalDialog.classList);
            // console.log("Test Class Size: ", size);
            if (divModalDialog.classList.contains(modalSizes.small)) {
                divModalDialog.classList.remove(modalSizes.small);
            }
            if (divModalDialog.classList.contains(modalSizes.large)) {
                divModalDialog.classList.remove(modalSizes.large);
            }
            if (divModalDialog.classList.contains(modalSizes.extraLarge)) {
                divModalDialog.classList.remove(modalSizes.extraLarge);
            }
            divModalDialog.classList
                // .remove(modalSizes.small, modalSizes.large, modalSizes.extraLarge)
                .add(size);
        }
    }

    if (buttonOpenModal) {
        buttonOpenModal.click();
    }
}
/**
 * Đóng tắt Modal
 */
function closeModal() {
    let buttonCloseModal = document.getElementById("btnCloseModal");
    if (buttonCloseModal) {
        buttonCloseModal.click();
    }
};